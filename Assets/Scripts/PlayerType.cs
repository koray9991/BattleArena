using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerType : MonoBehaviour
{
   public enum Type
    {
        Tank,
        Archer,
        Mage,
        Ninja,
        Wizard,
        Bomber,
        Hammer
    }
    public PlayerAttack playerAttack;
    public PlayerMovement playerMovement;
    public Health playerHealth;
    public Type type;
    public Sprite CharacterImage;
    public GameManager gm;
    public Energy energyScript;
    public float slowMoTime;

    [Header("Warrior")]
    public ParticleSystem warriorHitParticle;
    public GameObject warriorSkillParticle;
    public bool warriorSkillEnable;

    [Header("Archer")]
    public Transform arrows;
    int arrowNumber;
    public ParticleSystem archerHitParticle;
    public GameObject balista;
    public Transform balistaSpawnPos;

    [Header("Mage")]
    public Transform fireballs;
    int fireballNumber;
    public ParticleSystem mageHitParticle;
    public GameObject mageFireball, mageFireArea;
    public ParticleSystem mageSkillParticle;

    [Header("Ninja")]
    public ParticleSystem ninjaHitParticle;
    public Material[] materials;
    public SkinnedMeshRenderer ninjaMesh;
    public bool Invisibilty;

    [Header("Wizard")]
    public ParticleSystem wizardHitParticle;
    public Transform magics;
    int magicNumber;
    public GameObject healField;
    public bool healing;

    [Header("Bomber")]
    public Transform bombPos;
    public GameObject bomb;
    public ParticleSystem bombParticle;
    public GameObject bomberSkill;

    [Header("Hammer")]
    public ParticleSystem hammerHitParticle;
    public GameObject hammerSkill;
    private void Awake()
    {
        playerAttack = GetComponent<PlayerAttack>();
        playerMovement = GetComponent<PlayerMovement>();
        gm = FindObjectOfType<GameManager>();
        energyScript = GetComponent<Energy>();
        playerHealth = GetComponent<Health>();
    }
    private void Start()
    {
       gm.CharacterStatsPlayerPrefs();
        switch (type)
        {
            case Type.Tank:
                playerHealth.maxHealth = gm.warriorHealth;
                playerHealth.SetHealth();
                energyScript.energyIncrease = gm.warriorEnergyEarn;
                break;


            case Type.Archer:
                playerHealth.maxHealth = gm.archerHealth;
                playerHealth.SetHealth();
                energyScript.energyIncrease = gm.archerEnergyEarn;
                break;


            case Type.Mage:
                gm.mageDamage = PlayerPrefs.GetFloat("mageDamage");

                gm.mageHealth = PlayerPrefs.GetFloat("mageHealth");
                playerHealth.health = gm.mageHealth;

                gm.mageFireballDamage = PlayerPrefs.GetFloat("mageFireballDamage");

                gm.mageAreaDamage = PlayerPrefs.GetFloat("mageAreaDamage");

                gm.mageEnergyEarn = PlayerPrefs.GetFloat("mageEnergyEarn");
                energyScript.energyIncrease = gm.mageEnergyEarn;
                break;


            case Type.Ninja:
                gm.ninjaDamage = PlayerPrefs.GetFloat("ninjaDamage");

                gm.ninjaHealth = PlayerPrefs.GetFloat("ninjaHealth");
                playerHealth.health = gm.ninjaHealth;

                gm.invisibilityTime = PlayerPrefs.GetFloat("invisibilityTime");

                gm.ninjaEnergyEarn = PlayerPrefs.GetFloat("ninjaEnergyEarn");
                energyScript.energyIncrease = gm.ninjaEnergyEarn;
                break;


            case Type.Wizard:
                gm.wizardDamage = PlayerPrefs.GetFloat("wizardDamage");

                gm.wizardHealth = PlayerPrefs.GetFloat("wizardHealth");
                playerHealth.health = gm.wizardHealth;

                gm.wizardHeal = PlayerPrefs.GetFloat("wizardHeal");

                gm.wizardHealTime = PlayerPrefs.GetFloat("wizardHealTime");

                gm.wizardEnergyEarn = PlayerPrefs.GetFloat("wizardEnergyEarn");
                energyScript.energyIncrease = gm.wizardEnergyEarn;
                break;


            case Type.Bomber:
                gm.bomberDamage = PlayerPrefs.GetFloat("bomberDamage");

                gm.bomberHealth = PlayerPrefs.GetFloat("bomberHealth");
                playerHealth.health = gm.bomberHealth;

                gm.bomberSkillDamage = PlayerPrefs.GetFloat("bomberSkillDamage");

                gm.bomberEnergyEarn = PlayerPrefs.GetFloat("bomberEnergyEarn");
                energyScript.energyIncrease = gm.bomberEnergyEarn;
                break;


            case Type.Hammer:
                gm.hammerDamage = PlayerPrefs.GetFloat("hammerDamage");

                gm.hammerHealth = PlayerPrefs.GetFloat("hammerHealth");
                playerHealth.health = gm.hammerHealth;

                gm.hammerFlameDamage = PlayerPrefs.GetFloat("hammerFlameDamage");

                gm.hammerFlameTime = PlayerPrefs.GetFloat("hammerFlameTime");

                gm.hammerEnergyEarn = PlayerPrefs.GetFloat("hammerEnergyEarn");
                energyScript.energyIncrease = gm.hammerEnergyEarn;
                break;
        }


    }
    public void HammerHit()
    {
        hammerHitParticle.Play();
        if (playerAttack.closestTarget.GetComponent<Enemy>().health > 0)
        {
            playerAttack.closestTarget.GetComponent<Enemy>().GetDamage(gm.hammerDamage);
            playerAttack.closestTarget.GetComponent<DamageNumbersPro.Demo.DNP_Example>().SpawnPopup(gm.hammerDamage, "yellow");
            DOTween.To(x => energyScript.energy = x, energyScript.energy, energyScript.energy += energyScript.energyIncrease, 0.3f).OnComplete(() =>
            {
                if (energyScript.energy >= energyScript.energyCapacity)
                {
                    energyScript.energy = energyScript.energyCapacity;
                    energyScript.energyIsFull = true;
                }
            });
        }

        //   energyScript.energy += energyScript.energyIncrease;



    }
    public void HammerSkill()
    {
        hammerSkill.gameObject.SetActive(true);
        DOVirtual.DelayedCall(gm.hammerFlameTime, () =>
        {
            hammerSkill.gameObject.SetActive(false);
        }, false);
    }
    public void WarriorHit()
    {
        warriorHitParticle.Play();
        if (playerAttack.closestTarget.GetComponent<Enemy>().health > 0)
        {
            playerAttack.closestTarget.GetComponent<Enemy>().GetDamage(gm.warriorDamage);
            playerAttack.closestTarget.GetComponent<DamageNumbersPro.Demo.DNP_Example>().SpawnPopup(gm.warriorDamage,"yellow");
            DOTween.To(x => energyScript.energy = x, energyScript.energy, energyScript.energy += energyScript.energyIncrease, 0.3f).OnComplete(() =>
            {
                if (energyScript.energy >= energyScript.energyCapacity)
                {
                    energyScript.energy = energyScript.energyCapacity;
                    energyScript.energyIsFull = true;
                }
            });
        }

        //   energyScript.energy += energyScript.energyIncrease;
       

        
    }

 
    public void WarriorSkill()
    {
        warriorSkillEnable = true;
        warriorSkillParticle.gameObject.SetActive(true);
        DOVirtual.DelayedCall(gm.shieldTime, () =>
        {
            warriorSkillEnable = false;
            warriorSkillParticle.gameObject.SetActive(false);
        },false);
    }
    public void NinjaSkill()
    {
        Invisibilty = true;
        ninjaMesh.material = materials[1];
        DOVirtual.DelayedCall(gm.invisibilityTime, () =>
        {
            ninjaMesh.material = materials[0];
            Invisibilty = false;
        }, false);
    }
    public void MageSkill()
    {
        var newFireball = Instantiate(mageFireball, transform.position + new Vector3(40, 40, 40), Quaternion.identity);
        newFireball.transform.DOMove(playerAttack.closestTarget.transform.position, 1.3f).SetEase(Ease.Linear).OnComplete(() => {
            if (playerAttack.closestTarget.GetComponent<Enemy>().health > 0)
            {
                playerAttack.closestTarget.GetComponent<Enemy>().GetDamage(gm.mageFireballDamage);
                playerAttack.closestTarget.GetComponent<DamageNumbersPro.Demo.DNP_Example>().SpawnPopup(gm.mageFireballDamage, "yellow");
                Instantiate(mageFireArea, playerAttack.closestTarget.transform.position, Quaternion.Euler(-90, 0, 0));
                newFireball.SetActive(false);
            }
        });
        mageSkillParticle.Play();
    }
    public void ArcherSkill()
    {
       
    }
    public void ArcherInstantBalista()
    {
        var newBalista = Instantiate(balista, balistaSpawnPos.transform.position, Quaternion.identity);
    }
    public void NinjaHit()
    {
        ninjaHitParticle.Play();
        if (playerAttack.closestTarget.GetComponent<Enemy>().health > 0)
        {
            playerAttack.closestTarget.GetComponent<Enemy>().GetDamage(gm.ninjaDamage);
            playerAttack.closestTarget.GetComponent<DamageNumbersPro.Demo.DNP_Example>().SpawnPopup(gm.ninjaDamage, "yellow");
            DOTween.To(x => energyScript.energy = x, energyScript.energy, energyScript.energy += energyScript.energyIncrease, 0.3f).OnComplete(() =>
            {
                if (energyScript.energy >= energyScript.energyCapacity)
                {
                    energyScript.energy = energyScript.energyCapacity;
                    energyScript.energyIsFull = true;
                }
            });
        }
     
    }
    public void ArcherArrowSpawn()
    {
        arrows.GetChild(arrowNumber).gameObject.SetActive(true);
    }
    public void BomberBomb()
    {
        bomb.transform.parent = null;
        bomb.transform.DOJump(playerAttack.closestTarget.transform.position, Vector3.Distance(transform.position, playerAttack.closestTarget.transform.position), 1, 1).SetEase(Ease.Linear).OnComplete(() => {
            bombParticle.transform.position = playerAttack.closestTarget.transform.position;
            bombParticle.Play();
            
            
            bomb.transform.parent = bombPos;
            bomb.transform.localPosition = Vector3.zero;
            bomb.transform.localRotation = Quaternion.Euler(Vector3.zero);
            if (playerAttack.closestTarget.GetComponent<Enemy>().health > 0)
            {
                playerAttack.closestTarget.GetComponent<Enemy>().GetDamage(gm.bomberDamage);
                playerAttack.closestTarget.GetComponent<DamageNumbersPro.Demo.DNP_Example>().SpawnPopup(gm.bomberDamage, "yellow");
                DOTween.To(x => energyScript.energy = x, energyScript.energy, energyScript.energy += energyScript.energyIncrease, 0.3f).OnComplete(() =>
                {
                    if (energyScript.energy >= energyScript.energyCapacity)
                    {
                        energyScript.energy = energyScript.energyCapacity;
                        energyScript.energyIsFull = true;
                    }
                });
            }
        });
    }

    public void BomberSkill()
    {
      
       
    }
    public void InstantBomberSkill()
    {
        var newSkill = Instantiate(bomberSkill, transform.position, Quaternion.identity);
        newSkill.transform.localScale = Vector3.zero;
        newSkill.transform.DOScale(Vector3.one/2, 1);
        newSkill.transform.DOMoveY(5, 1);
        newSkill.transform.DORotate(new Vector3(0, 70, 0), 1).OnComplete(() => {

            for (int i = 0; i < newSkill.transform.childCount; i++)
            {
                var thisBomb = newSkill.transform.GetChild(i);
                DOVirtual.DelayedCall((float)i/10, () => {

                   
                   
                   // Debug.Log(thisBomb.name);
                    thisBomb.DOMove(playerAttack.closestTarget.transform.position, 0.3f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        thisBomb.GetComponent<Bomb>().bombParticle.Play();
                        thisBomb.GetComponent<MeshRenderer>().enabled = false;
                        if (playerAttack.closestTarget.GetComponent<Enemy>().health > 0)
                        {
                            playerAttack.closestTarget.GetComponent<Enemy>().GetDamage(gm.bomberSkillDamage);
                            playerAttack.closestTarget.GetComponent<DamageNumbersPro.Demo.DNP_Example>().SpawnPopup(gm.bomberSkillDamage, "yellow");
                           
                        }
                    });
                });
            }
        });
    }

    public void ArcherArrowMove()
    {
        var myArrow = arrows.GetChild(arrowNumber).transform;
        myArrow.DOMove(playerAttack.closestTarget.transform.position, 0.2f).SetEase(Ease.Linear).OnComplete(() => {
            archerHitParticle.transform.position = myArrow.transform.position;
            archerHitParticle.Play();
            myArrow.localPosition = Vector3.zero;
            myArrow.gameObject.SetActive(false);
            if (playerAttack.closestTarget.GetComponent<Enemy>().health > 0)
            {
                playerAttack.closestTarget.GetComponent<Enemy>().GetDamage(gm.archerDamage);
                playerAttack.closestTarget.GetComponent<DamageNumbersPro.Demo.DNP_Example>().SpawnPopup(gm.archerDamage, "yellow");
                DOTween.To(x => energyScript.energy = x, energyScript.energy, energyScript.energy += energyScript.energyIncrease, 0.3f).OnComplete(() =>
                {
                    if (energyScript.energy >= energyScript.energyCapacity)
                    {
                        energyScript.energy = energyScript.energyCapacity;
                        energyScript.energyIsFull = true;
                    }
                });
            }
          
        });
        arrowNumber += 1;
        if (arrowNumber == arrows.childCount)
        {
            arrowNumber = 0;
        }
    }
    public void MageFireball()
    {
        var myFireball = fireballs.GetChild(fireballNumber).transform;
        myFireball.gameObject.SetActive(true);
        myFireball.DOMove(playerAttack.closestTarget.transform.position, 0.2f).SetEase(Ease.Linear).OnComplete(() => {
            mageHitParticle.transform.position = myFireball.transform.position;
            mageHitParticle.Play();
            myFireball.localPosition = Vector3.zero;
            myFireball.gameObject.SetActive(false);
            if (playerAttack.closestTarget.GetComponent<Enemy>().health > 0)
            {
                playerAttack.closestTarget.GetComponent<Enemy>().GetDamage(gm.mageDamage);
                playerAttack.closestTarget.GetComponent<DamageNumbersPro.Demo.DNP_Example>().SpawnPopup(gm.mageDamage, "yellow");
                DOTween.To(x => energyScript.energy = x, energyScript.energy, energyScript.energy += energyScript.energyIncrease, 0.3f).OnComplete(() =>
                {
                    if (energyScript.energy >= energyScript.energyCapacity)
                    {
                        energyScript.energy = energyScript.energyCapacity;
                        energyScript.energyIsFull = true;
                    }
                });
            }
          
        });
        fireballNumber += 1;
        if (fireballNumber == fireballs.childCount)
        {
            fireballNumber = 0;
        }
    }

    public void WizardHit()
    {
        var mymagic = magics.GetChild(magicNumber).transform;
        mymagic.gameObject.SetActive(true);
        mymagic.DOMove(playerAttack.closestTarget.transform.position, 0.2f).SetEase(Ease.Linear).OnComplete(() => {
            wizardHitParticle.transform.position = mymagic.transform.position;
            wizardHitParticle.Play();
            mymagic.localPosition = Vector3.zero;
            mymagic.gameObject.SetActive(false);
            if (playerAttack.closestTarget.GetComponent<Enemy>().health > 0)
            {
                playerAttack.closestTarget.GetComponent<Enemy>().GetDamage(gm.wizardDamage);
                playerAttack.closestTarget.GetComponent<DamageNumbersPro.Demo.DNP_Example>().SpawnPopup(gm.wizardDamage, "yellow");
                DOTween.To(x => energyScript.energy = x, energyScript.energy, energyScript.energy += energyScript.energyIncrease, 0.3f).OnComplete(() =>
                {
                    if (energyScript.energy >= energyScript.energyCapacity)
                    {
                        energyScript.energy = energyScript.energyCapacity;
                        energyScript.energyIsFull = true;
                    }
                });
            }

        });
        magicNumber += 1;
        if (magicNumber == magics.childCount)
        {
            magicNumber = 0;
        }
    }
    public void WizardSkill()
    {
       
    }
    public void HealActive()
    {
        healField.SetActive(true);
        healing = true;
        DOVirtual.DelayedCall(gm.wizardHealTime, () => { healField.SetActive(false); healing = false; }, false);
    }
}
