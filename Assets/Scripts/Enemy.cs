using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
public class Enemy : MonoBehaviour
{
    [HideInInspector] public Animator anim;
    public bool Idle;
    public bool Walk;
    public bool Attack;
    public List<Transform> walkPoints;
    [HideInInspector] public float idleWaitTime;
    [HideInInspector] public NavMeshAgent navMesh;
    [HideInInspector] public int currentWalkPoint;
    [HideInInspector] public float idleWaitTimer;
    public Transform target;
  
    [SerializeField]
    LayerMask layerMask;
    public bool canAttack;
    public float range;
    public GameObject rangeObject;
    public GameObject closestTarget;
    public bool throwHero;
    public bool isEnemyInRange;
    public bool gettingDamage;
    public float gettingDamageTimer;
    public GameObject fieldOfViewObject;
    public float fieldOfViewRange;
    public GameManager gm;
    public float health, maxHealth;
    public Image healthBar;
    public TextMeshProUGUI healthText;
    public Transform walkTransforms;
    public float mageAreaDamageTimer;
    public GameObject canvas;
    public bool dead;
    public Transform coins;
    public int dropCoinCount;
    private void Start()
    {
        anim = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
        gm = FindObjectOfType<GameManager>();
        for (int i = 0; i < walkTransforms.childCount; i++)
        {
            walkPoints.Add(walkTransforms.GetChild(i));
        }
        walkTransforms.parent = GameObject.FindGameObjectWithTag("WalkTransforms").transform;
        WalkDecision();
        rangeObject.transform.localScale = new Vector3(range * 2, 0.01f, range * 2);
        fieldOfViewObject.transform.localScale = new Vector3(fieldOfViewRange * 2, 0.01f, fieldOfViewRange * 2);
        health = maxHealth;
        healthBar.fillAmount = health / maxHealth;
        healthText.text = health.ToString();

        dropCoinCount = Random.Range(2, 10);
        for (int i = 0; i < coins.childCount; i++)
        {
            coins.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void Update()
    {

        if (Idle)
        {
            IdleState();
        }
        if (Walk)
        {
            WalkState();
        }
        if (Attack)
        {
            AttackState();
        }
        FindClosestEnemy();
        if (dead)
        {
            dead = false;
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", false);
            anim.SetBool("Attack", false);
            anim.SetBool("Die", true);
            Destroy(navMesh);
            Destroy(GetComponent<Enemy>());
        }


        if (gettingDamage)
        {
            gettingDamageTimer += Time.deltaTime;
            if (gettingDamageTimer > 5)
            {
                navMesh.SetDestination(walkPoints[currentWalkPoint].position);
                gettingDamage = false;
                gettingDamageTimer = 0;
                WalkDecision();
                Attack = false;

            }
        }
       

    }

    public void AttackState()
    {
        if (closestTarget != null)
        {
            if (Vector3.Distance(transform.position, closestTarget.transform.position) < range)
            {
                var lookPos = closestTarget.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 50);
                anim.SetBool("Walk", false);
                anim.SetBool("Idle", false);
                anim.SetBool("Attack", true);
            }
            else
            {
                navMesh.SetDestination(closestTarget.transform.position);
                anim.SetBool("Walk", true);
                anim.SetBool("Idle", false);
                anim.SetBool("Attack", false);
            }
        }
      
    }
   
    void FindClosestEnemy()
    {
        float distanceClosestEnemy = Mathf.Infinity;
        PlayerAttack closestEnemy = null;
        List<PlayerAttack> allEnemies = new List<PlayerAttack>();
        foreach (PlayerAttack enemy in FindObjectsOfType<PlayerAttack>())
        {
            if (!enemy.GetComponent<PlayerType>().Invisibilty)
            {
                allEnemies.Add(enemy);
            }
          
        }

        if (allEnemies.Count != 0)
        {
            foreach (PlayerAttack currentEnemy in allEnemies)
            {
                float distanceToEnemy = (currentEnemy.transform.position - transform.position).sqrMagnitude;
                if (distanceToEnemy < distanceClosestEnemy)
                {
                    distanceClosestEnemy = distanceToEnemy;
                    closestEnemy = currentEnemy;
                    closestTarget = closestEnemy.gameObject;
                    if (!throwHero)
                    {
                        if (Vector3.Distance(transform.position, closestTarget.transform.position) < fieldOfViewRange && canAttack)
                        {
                            Attack = true;
                        }
                        else
                        {
                            if (Attack && !gettingDamage)
                            {
                                Attack = false;
                                WalkDecision();
                            }
                        }
                      
                    }
                    else
                    {
                        if (Vector3.Distance(transform.position, closestTarget.transform.position) < fieldOfViewRange)
                        {
                            Attack = true;
                        }
                        else
                        {
                            if (Attack && !gettingDamage)
                            {
                                Attack = false;
                                WalkDecision();
                            }
                        }
                    }

                }
            }
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.position + closestEnemy.transform.position, out hit, 100, layerMask))
            {
                if (hit.transform.gameObject.layer == 6)
                {

                    canAttack = false;
                }
                else
                {

                    canAttack = true;
                }
            }
        }
        else
        {
            if (closestTarget != null)
            {
                closestTarget = null;
                Attack = false;
                WalkDecision();
            }
        }

     

    }
    public void IdleState()
    {
        idleWaitTimer += Time.deltaTime;
        if (idleWaitTimer > idleWaitTime)
        {
            idleWaitTimer = 0;
            WalkDecision();
            Idle = false;
        }
    }
    public void WalkState()
    {
        if (Vector3.Distance(transform.position, target.position) < 2) // Go Idle
        {
            Walk = false;
            Idle = true;
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", true);
            anim.SetBool("Attack", false);
            idleWaitTime = Random.Range(2f, 5f);
        }
    }
    public void WalkDecision()
    {
        Walk = true;
        currentWalkPoint = Random.Range(0, walkPoints.Count);
        navMesh.SetDestination(walkPoints[currentWalkPoint].transform.position);
        target = walkPoints[currentWalkPoint];
        anim.SetBool("Walk", true);
        anim.SetBool("Idle", false);
        anim.SetBool("Attack", false);
    }

    public void GetDamage(float damage)
    {
        gettingDamage = true;
        gettingDamageTimer = 0;
        Walk = false;
        Idle = false;
        Attack = true;
        if (closestTarget != null)
        {
            navMesh.SetDestination(closestTarget.transform.position);
        }
       

        health -= damage;
        healthBar.fillAmount = health / maxHealth;
        healthText.text = health.ToString();

        if (health <= 0 && !dead)
        {
            DOVirtual.DelayedCall(2, () => canvas.SetActive(false), false);
            healthText.text = "0";
            dead = true;
            rangeObject.SetActive(false);
            for (int i = 0; i < dropCoinCount; i++)
            {
                var myCoin = coins.GetChild(i);
                myCoin.gameObject.SetActive(true);
                myCoin.DOJump(new Vector3(transform.position.x + Random.Range(-3f, 3f), transform.position.y, transform.position.z + Random.Range(-3f, 3f)), 2, 1, 1.5f).SetEase(Ease.OutBounce);
                DOVirtual.DelayedCall(2, () => { myCoin.GetComponent<Coin>().enabled = true; });
              
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Flame>())
        {
                GetDamage(gm.hammerFlameDamage);
                GetComponent<DamageNumbersPro.Demo.DNP_Example>().SpawnPopup(gm.hammerFlameDamage, "yellow");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<MageAreaDamage>())
        {
            mageAreaDamageTimer += Time.deltaTime;
            if (mageAreaDamageTimer > 1)
            {
                mageAreaDamageTimer = 0;
                GetDamage(gm.mageAreaDamage);
                GetComponent<DamageNumbersPro.Demo.DNP_Example>().SpawnPopup(gm.mageAreaDamage, "yellow");
            }
        }
      

    }
}
