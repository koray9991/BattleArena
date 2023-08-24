using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType : MonoBehaviour
{
    public Enemy enemy;
    public enum Type
    {
        golem
    }
    public Type type;
    public ParticleSystem golemParticle;
    public float damage;
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
}
