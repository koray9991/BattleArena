using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttack : MonoBehaviour
{
 
    public GameObject rangeObject;
    public float range;
    public bool isEnemyInRange;
    public GameObject closestTarget;
   
    public GameManager gm;
    [SerializeField]
    LayerMask layerMask;
    public bool canAttack;
    public bool throwHero;
    
    private void Awake()
    {

        rangeObject.transform.localScale = new Vector3(range*2, 0.01f, range*2);
        gm = FindObjectOfType<GameManager>();
    }
    private void Update()
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
                    if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), -transform.position + closestEnemy.transform.position, out hit, 100, layerMask))
                    {
                        if (hit.transform.gameObject.layer == 6)
                        {
                            Debug.DrawRay(transform.position + new Vector3(0, 1, 0), -transform.position + hit.transform.position, Color.red);
                            canAttack = false;
                        }
                        else
                        {
                            Debug.DrawRay(transform.position, -transform.position + closestEnemy.transform.position, Color.red);
                            canAttack = true;
                        }
                    }
                    if (!throwHero)
                    {
                        if (Vector3.Distance(transform.position, closestTarget.transform.position) < range && canAttack)
                        {
                            isEnemyInRange = true;

                        }
                        else
                        {
                            isEnemyInRange = false;
                        }
                    }
                    else
                    {
                        if (Vector3.Distance(transform.position, closestTarget.transform.position) < range)
                        {
                            isEnemyInRange = true;

                        }
                        else
                        {
                            isEnemyInRange = false;
                        }
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

  
}
