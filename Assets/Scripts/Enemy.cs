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
    public bool attack1Frame, idle1Frame, walk1Frame;
    public string state;
    public bool attack;
    float walkTime;
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
        state = "walk";

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
        switch (state)
        {
            case "idle":
                IdleState();
                break;
            case "walk":
                WalkState();
                break;
            case "attack":
                AttackState();
                break;
            case "die":

                break;
        }
       
        FindClosestEnemy();
        if (dead)
        {
            dead = false;
            anim.SetTrigger("Die");
            Destroy(navMesh);
            Destroy(GetComponent<Enemy>());
        }
      

        if (gettingDamage)
        {
            gettingDamageTimer += Time.deltaTime;
            if (gettingDamageTimer > 5)
            {
                attack = false;
                gettingDamage = false;
                gettingDamageTimer = 0;
                walk1Frame = false;
                state = "walk";
            }
        }

        RangeControl();
    }

    public void RangeControl()
    {
        if(Vector3.Distance(transform.position,closestTarget.transform.position)<fieldOfViewRange && canAttack && !attack)
        {
            attack = true;
            state = "attack";
        }
    }
    public void AttackState()
    {
        if (closestTarget != null)
        {
            if (Vector3.Distance(transform.position, closestTarget.transform.position) < range && canAttack)
            {
                if (!attack1Frame)
                {
                    attack1Frame = true;
                    walk1Frame = false;
                    idle1Frame = false;
                    anim.SetTrigger("Attack");
                }
                navMesh.isStopped = true;
                var lookPos = closestTarget.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 50);
            }
            else
            {
                state = "walk";
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
                }
            }
            RaycastHit hit;
            if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), -transform.position + closestTarget.transform.position, out hit, 100, layerMask))
            {
                if (hit.transform.gameObject.layer == 6)
                {
                  //  Debug.DrawRay(transform.position + new Vector3(0, 1, 0), -transform.position + hit.transform.position, Color.red);
                    canAttack = false;
                }
                else
                {
                   // Debug.DrawRay(transform.position, -transform.position + closestTarget.transform.position, Color.red);
                    canAttack = true;
                }
            }

        }
        else
        {
            if (closestTarget != null)
            {
                closestTarget = null;
            }
        }

     

    }

  
  
    public void IdleState()
    {
        if (!idle1Frame)
        {
            idle1Frame = true;
            walk1Frame = false;
            attack1Frame = false;
            anim.SetTrigger("Idle");
            navMesh.isStopped = true;
        }
        idleWaitTimer += Time.deltaTime;
        if (idleWaitTimer > idleWaitTime)
        {
            idleWaitTimer = 0;
            state = "walk";
        }
    }
    public void WalkState()
    {
        walkTime += Time.deltaTime;
        if (walkTime > 10)
        {
            state = "idle";
            idleWaitTime = Random.Range(2f, 5f);
            walkTime = 0;
            attack = false;
        }
        if (!attack)
        {
            if (!walk1Frame)
            {
                walk1Frame = true;
                idle1Frame = false;
                attack1Frame = false;
                
                currentWalkPoint = Random.Range(0, walkPoints.Count);
                navMesh.SetDestination(walkPoints[currentWalkPoint].transform.position);
                target = walkPoints[currentWalkPoint];
                anim.SetTrigger("Walk");
            }
            navMesh.isStopped = false;
            if (Vector3.Distance(transform.position, target.position) < 2) // Go Idle
            {
                state = "idle";
                idleWaitTime = Random.Range(2f, 5f);
            }
        }
        else
        {
            if (!walk1Frame)
            {
                walk1Frame = true;
                idle1Frame = false;
                attack1Frame = false;
                
               
                anim.SetTrigger("Walk");
            }
            if (Vector3.Distance(transform.position, closestTarget.transform.position) < range && canAttack)
            {
                state = "attack";
            }
                navMesh.SetDestination(closestTarget.transform.position);
            navMesh.isStopped = false;
        }
       
    }

    public void GetDamage(float damage)
    {
        gettingDamage = true;
        gettingDamageTimer = 0;
        attack = true;
        state = "attack";


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
