using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Ai : MonoBehaviour
{
    public GameManager gm;
    public NavMeshAgent navmesh;
    public Transform targetPlayer;
    public PlayerAnimation playerAnimation;
    public PlayerAttack playerAttack;
    private void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        navmesh = GetComponent<NavMeshAgent>();

        gm = FindObjectOfType<GameManager>();
        playerAttack = GetComponent<PlayerAttack>();
    }
   
    private void Update()
    {

        if (gm.activeCharacter.GetComponent<PlayerMovement>().moving)
        {
            navmesh.stoppingDistance = 2;
            if (Vector3.Distance(gm.activeCharacter.transform.position, transform.position) < 2)
            {
                playerAnimation.Idle();
            }
            else
            {
                navmesh.SetDestination(gm.activeCharacter.transform.position);
                playerAnimation.Walk();
            }
        }
        else
        {
            if (gm.activeCharacter.GetComponent<PlayerMovement>().fighting)
            {
                if (Vector3.Distance(transform.position, playerAttack.closestTarget.transform.position) < playerAttack.range && playerAttack.canAttack)
                {
                    if (!playerAttack.throwHero)
                    {
                        if (playerAttack.canAttack)
                        {
                            var lookPos = playerAttack.closestTarget.transform.position - transform.position;
                            lookPos.y = 0;
                            var rotation = Quaternion.LookRotation(lookPos);
                            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 50);
                            playerAnimation.Attack();
                            navmesh.stoppingDistance = playerAttack.range;
                        }
                    }
                    else
                    {
                        var lookPos = playerAttack.closestTarget.transform.position - transform.position;
                        lookPos.y = 0;
                        var rotation = Quaternion.LookRotation(lookPos);
                        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 50);
                        playerAnimation.Attack();
                        navmesh.stoppingDistance = playerAttack.range;
                    }
                      
     
                }
                else
                {
                    navmesh.SetDestination(playerAttack.closestTarget.transform.position);
                    playerAnimation.Walk();
                    navmesh.stoppingDistance = 2;

                }



            }
            else
            {
              
                if (Vector3.Distance(transform.position, playerAttack.closestTarget.transform.position) < playerAttack.range )
                {
                    if (!playerAttack.throwHero)
                    {
                        if (playerAttack.canAttack)
                        {
                            var lookPos = playerAttack.closestTarget.transform.position - transform.position;
                            lookPos.y = 0;
                            var rotation = Quaternion.LookRotation(lookPos);
                            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 50);
                            playerAnimation.Attack();
                            navmesh.stoppingDistance = playerAttack.range;
                        }

                    }
                    else
                    {
                        var lookPos = playerAttack.closestTarget.transform.position - transform.position;
                        lookPos.y = 0;
                        var rotation = Quaternion.LookRotation(lookPos);
                        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 50);
                        playerAnimation.Attack();
                        navmesh.stoppingDistance = playerAttack.range;
                    }
                   
        
                }
                else
                {
                    navmesh.stoppingDistance = 3;
                    if (Vector3.Distance(gm.activeCharacter.transform.position, transform.position) < 3)
                    {
                        playerAnimation.Idle();
         
                    }
                    else
                    {
                        navmesh.SetDestination(gm.activeCharacter.transform.position);
                        playerAnimation.Walk();
       
                    }
                }

            }
        }


        
    }
    private void OnEnable()
    {
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    private void OnDisable()
    {
        if (GetComponent<Rigidbody>() && !playerAnimation.skill)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
