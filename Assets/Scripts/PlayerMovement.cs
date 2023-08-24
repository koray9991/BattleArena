using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerMovement : MonoBehaviour
{
    public GameManager gm;
    public Rigidbody rb;
    public FloatingJoystick js;
    public float moveSpeed;
     Vector3 mouseDown;
    public bool moving;
    public PlayerAnimation playerAnimation;
    public PlayerAttack playerAttack;
    public PlayerType playerType;
    public bool fighting;
    public Vector3 frameMovement;
    public Energy energyScript;
  
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerAttack = GetComponent<PlayerAttack>();
        energyScript = GetComponent<Energy>();
        playerType = GetComponent<PlayerType>();
        gm = FindObjectOfType<GameManager>();
    }
    private void FixedUpdate()
    {
      
            Movement();

        
    }
    void Movement()
    {
     
            rb.velocity = new Vector3(js.Horizontal * moveSpeed, rb.velocity.y, js.Vertical * moveSpeed);
            if (js.Horizontal != 0 || js.Vertical != 0)
            {
                if (rb.velocity != Vector3.zero)
                {
                    frameMovement = new Vector3(js.Horizontal, 0f, js.Vertical);

                    Quaternion rotation =
                    Quaternion.LookRotation(frameMovement);
                    transform.rotation = rotation;
                if (playerAnimation.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    playerAnimation.currentAnim = PlayerAnimation.State.attack;
                }
                playerAnimation.Walk();
                        moving = true;
                        fighting = false;
                    
                  
                }



            }
            if (js.Horizontal == 0 && js.Vertical == 0)
            {

                if (moving)
                {
                    moving = false;
                }

                if (playerAttack.isEnemyInRange)
                {
                    var lookPos = playerAttack.closestTarget.transform.position - transform.position;
                    lookPos.y = 0;
                    var rotation = Quaternion.LookRotation(lookPos);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 50);
                    if (energyScript.energyIsFull)
                    {
                        playerAnimation.Skill();
                        energyScript.energyIsFull = false;
                        energyScript.energy = 0;
                         
                        //var transposer = gm.vCam.GetCinemachineComponent<CinemachineTransposer>();
                        //transposer.m_FollowOffset = new Vector3(Random.Range(-5f,5f),Random.Range(4f,7f),Random.Range(4f,7f));

                        gm.SlowMo(playerType.slowMoTime);
                        
                     
                      
                        
                        if (playerType.type== PlayerType.Type.Tank)
                        {
                            playerType.WarriorSkill();
                        }
                        if (playerType.type == PlayerType.Type.Mage)
                        {
                            playerType.MageSkill();
                        }
                        if (playerType.type == PlayerType.Type.Archer)
                        {
                            playerType.ArcherSkill();
                        }
                        if (playerType.type == PlayerType.Type.Ninja)
                        {
                            playerType.NinjaSkill();
                        }
                        if (playerType.type == PlayerType.Type.Bomber)
                        {
                            playerType.BomberSkill();
                        }
                        if (playerType.type == PlayerType.Type.Hammer)
                        {
                            playerType.HammerSkill();
                        }
                    }
                    else
                    {
                        playerAnimation.Attack();
                    }
                   
                    fighting = true;
                }
                else
                {
                    playerAnimation.Idle();
                    fighting = false;
                }
              

            }
        


       
    }
}