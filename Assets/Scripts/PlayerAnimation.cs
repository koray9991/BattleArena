using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerAnimation : MonoBehaviour
{
    public GameManager gm;
    public PlayerMovement playerMovement;
    public Animator anim;
    public string idleName;
    public string walkName;
    public string attackName;
    public string deadName;
    public string SkillName;
    public bool skill;
    public enum State { idle, walk, attack, skill, dead }
    public State currentAnim;
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
        gm = FindObjectOfType<GameManager>();
    }
  

 
    public void Idle()
    {
        if (currentAnim != State.idle && !skill)
        {
            currentAnim = State.idle;
            anim.SetTrigger(idleName);
        }

    }
    public void Walk()
    {
        if (currentAnim != State.walk && !skill)
        {
            currentAnim = State.walk;
            anim.SetTrigger(walkName);
        }

    }
    public void Attack()
    {
        if (currentAnim != State.attack && !skill)
        {
            currentAnim = State.attack;
            anim.SetTrigger(attackName);
        }
    }
    public void Skill()
    {
        if (currentAnim != State.skill)
        {
            currentAnim = State.skill;
            anim.SetTrigger(SkillName);
            playerMovement.rb.isKinematic = true;
            skill = true;
        }
    
    }

    public void Death()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            anim.SetTrigger(deadName);
        }
    }

    public void SkillFinish()
    {
        playerMovement.rb.isKinematic = false;
        skill = false;
        if (playerMovement.moving)
        {
            Walk();
        }
        else
        {
            Idle();
        }
      




    }
    public void Dead()
    {
       
        Destroy(transform.GetComponent<PlayerMovement>());
        Destroy(GetComponent<PlayerAttack>());
        Destroy(GetComponent<PlayerType>());
        Destroy(GetComponent<Ai>());
        Destroy(GetComponent<NavMeshAgent>());
        Destroy(GetComponent<Health>());
        playerMovement.rb.constraints = RigidbodyConstraints.FreezePosition;
        Death();
    }
}
