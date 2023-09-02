using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemyType : MonoBehaviour
{
    public Enemy enemy;
    

   
    public float damage;


    [Header("Golem")]
    public ParticleSystem golemParticle;
    [Header("Bloom")]
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public GameObject throwObject1;
    public GameObject throwObject2;
    public GameObject throwObject3;
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    public void GolemHit()
    {
        golemParticle.Play();
        if (enemy.closestTarget != null)
        {
            if (enemy.closestTarget.GetComponent<Health>().health > 0)
            {
                if (enemy.closestTarget.GetComponent<PlayerType>().warriorSkillEnable)
                {
                    enemy.closestTarget.GetComponent<Health>().GetDamage(0);
                    enemy.closestTarget.GetComponent<DamageNumbersPro.Demo.DNP_Example>().SpawnPopup(0,"red");
                }
                else
                {
                    enemy.closestTarget.GetComponent<Health>().GetDamage(damage);
                    enemy.closestTarget.GetComponent<DamageNumbersPro.Demo.DNP_Example>().SpawnPopup(damage,"red");
                }
                
            }
        }
    }
    public void Blossom2Head()
    {
        throwObject1.transform.position = spawnPoint1.position;
        throwObject2.transform.position = spawnPoint2.position;
        throwObject1.SetActive(true);
        throwObject2.SetActive(true);
        if (enemy.closestTarget != null)
        {
            throwObject1.transform.DOMove(enemy.closestTarget.transform.position+new Vector3(0,1,0), 0.1f).OnComplete(() => {
                if (enemy.closestTarget.GetComponent<Health>().health > 0)
                {
                    if (enemy.closestTarget.GetComponent<PlayerType>().warriorSkillEnable)
                    {
                        enemy.closestTarget.GetComponent<Health>().GetDamage(0);
                        enemy.closestTarget.GetComponent<DamageNumbersPro.Demo.DNP_Example>().SpawnPopup(0, "red");
                    }
                    else
                    {
                        enemy.closestTarget.GetComponent<Health>().GetDamage(damage);
                        enemy.closestTarget.GetComponent<DamageNumbersPro.Demo.DNP_Example>().SpawnPopup(damage, "red");
                    }

                }
                throwObject1.SetActive(false);
            });
            throwObject2.transform.DOMove(enemy.closestTarget.transform.position + new Vector3(0, 1, 0), 0.1f).OnComplete(() => {
                if (enemy.closestTarget.GetComponent<Health>().health > 0)
                {
                    if (enemy.closestTarget.GetComponent<PlayerType>().warriorSkillEnable)
                    {
                        enemy.closestTarget.GetComponent<Health>().GetDamage(0);
                        enemy.closestTarget.GetComponent<DamageNumbersPro.Demo.DNP_Example>().SpawnPopup(0, "red");
                    }
                    else
                    {
                        enemy.closestTarget.GetComponent<Health>().GetDamage(damage);
                        enemy.closestTarget.GetComponent<DamageNumbersPro.Demo.DNP_Example>().SpawnPopup(damage, "red");
                    }

                }
                throwObject2.SetActive(false);
            });
        }


      
          
        
    }
}
