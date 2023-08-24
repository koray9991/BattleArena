using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Balista : MonoBehaviour
{
    public GameManager gm;
    [SerializeField]
    LayerMask layerMask;
    public bool canAttack;
    public GameObject rangeObject;
    public float range;
    public bool isEnemyInRange;
    public GameObject closestTarget;
    public Transform balistaMesh;
    public Transform arrows;
    int arrowNumber;
    public ParticleSystem hitParticle;

    bool spawned;
    public float timer, spawnTime, shootTime;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        // balistaMesh.DOPunchScale(Vector3.one, 1,3,1);
        DOVirtual.DelayedCall(gm.balistaTime, () => transform.DOScale(Vector3.zero, 0.2f).OnComplete(() => { gameObject.SetActive(false); }), false) ;
        rangeObject.transform.localScale = new Vector3(range * 2, 0.01f, range * 2);

    }


    void Update()
    {
        FindClosestEnemy();

      
    }

    void FindClosestEnemy()
    {
        float distanceClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = FindObjectsOfType<Enemy>();
        if (allEnemies.Length != 0)
        {
            foreach (Enemy currentEnemy in allEnemies)
            {
                float distanceToEnemy = (currentEnemy.transform.position - transform.position).sqrMagnitude;
                if (distanceToEnemy < distanceClosestEnemy)
                {
                    distanceClosestEnemy = distanceToEnemy;
                    closestEnemy = currentEnemy;
                    closestTarget = closestEnemy.gameObject;
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, -transform.position + closestEnemy.transform.position, out hit, 100, layerMask))
                    {
                        if (hit.transform.gameObject.layer == 6)
                        {
                            Debug.DrawRay(transform.position, -transform.position + hit.transform.position, Color.red);
                            canAttack = false;
                        }
                        else
                        {
                            Debug.DrawRay(transform.position, -transform.position + closestEnemy.transform.position, Color.red);
                            canAttack = true;
                        }
                    }
                   
                        if (Vector3.Distance(transform.position, closestTarget.transform.position) < range && canAttack)
                        {
                            isEnemyInRange = true;
                        var lookPos = closestTarget.transform.position - transform.position;
                        lookPos.y = 0;
                        var rotation = Quaternion.LookRotation(lookPos);
                        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 50);
                        timer += Time.deltaTime;
                        if (timer > spawnTime && !spawned)
                        {
                            spawned = true;
                            ArcherArrowSpawn();
                        }
                        if (timer > shootTime)
                        {
                            spawned = false;
                            ArcherArrowMove();
                            timer = 0;
                        }
                    }
                        else
                        {
                            isEnemyInRange = false;
                        }
                    
                   

                }
            }

        }
        else
        {
            isEnemyInRange = false;
            closestTarget = null;
        }



    }

    public void ArcherArrowSpawn()
    {
        arrows.GetChild(arrowNumber).gameObject.SetActive(true);
    }
    public void ArcherArrowMove()
    {
        var myArrow = arrows.GetChild(arrowNumber).transform;
        myArrow.DOMove(closestTarget.transform.position, 0.2f).SetEase(Ease.Linear).OnComplete(() => {
            hitParticle.transform.position = myArrow.transform.position;
            hitParticle.Play();
            myArrow.localPosition = Vector3.zero;
            myArrow.gameObject.SetActive(false);
            if (closestTarget.GetComponent<Enemy>().health > 0)
            {
                closestTarget.GetComponent<Enemy>().GetDamage(gm.balistaDamage);
                closestTarget.GetComponent<DamageNumbersPro.Demo.DNP_Example>().SpawnPopup(gm.balistaDamage, "yellow");
            }

        });
        balistaMesh.DOScale(0.7f, 0.1f).OnComplete(() => { balistaMesh.DOScale(0.5f, 0.1f); });
        arrowNumber += 1;
        if (arrowNumber == arrows.childCount)
        {
            arrowNumber = 0;
        }
    }
}
