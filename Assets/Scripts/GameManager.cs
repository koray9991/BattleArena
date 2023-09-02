using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;
public class GameManager : MonoBehaviour
{
    public List<GameObject> menuChooseCharacters;
    public List<GameObject> characters;
    public GameObject activeCharacter;
    public List<GameObject> passiveCharacters;
    public int activeCharacterNum;
    public CinemachineVirtualCamera vCam;
    public Image[] characterSelectButonImages;
    float CharactersHealthControlTimer;
    public Transform[] spawnPos;
    public CinemachineBrain brain;
    public Vector3 vCamFollowOffset;
    public float gold;
    public TextMeshProUGUI goldText;
    public int enemyCount;
    public GameObject enemyDefault;
    public bool enemiesFinish;

    [Header("Warrior")]
    public float warriorDamage;
    public float warriorHealth;
    public float shieldTime;
    public float warriorEnergyEarn;
    [Header("Archer")]
    public float archerDamage;
    public float archerHealth;
    public float balistaDamage;
    public float balistaTime;
    public float archerEnergyEarn;
    [Header("Mage")]
    public float mageDamage;
    public float mageHealth;
    public float mageFireballDamage;
    public float mageAreaDamage;
    public float mageEnergyEarn;
    [Header("Ninja")]
    public float ninjaDamage;
    public float ninjaHealth;
    public float invisibilityTime;
    public float ninjaEnergyEarn;
    [Header("Wizard")]
    public float wizardDamage;
    public float wizardHealth;
    public float wizardHeal;
    public float wizardHealTime;
    public float wizardEnergyEarn;
    [Header("Bomber")]
    public float bomberDamage;
    public float bomberHealth;
    public float bomberSkillDamage;
    public float bomberEnergyEarn;
    [Header("Hammer")]
    public float hammerDamage;
    public float hammerHealth;
    public float hammerFlameDamage;
    public float hammerFlameTime;
    public float hammerEnergyEarn;
  
   
    private void Awake()
    {
       
        CharacterPrefs();

        foreach (PlayerType fooObj in FindObjectsOfType<PlayerType>())
        {
            characters.Add(fooObj.gameObject);
        }
        activeCharacter = characters[0];
        activeCharacterNum = 0;
        ChangeMoney(0);
    }

    void Start()
    {
        for (int i = 0; i < characterSelectButonImages.Length; i++)
        {
            characterSelectButonImages[i].transform.parent.gameObject.SetActive(false);
        }
        CharacterChange();
    }
    public void ChangeMoney(float amount)
    {
        gold = PlayerPrefs.GetFloat("gold");
        gold += amount;
        goldText.text = gold.ToString();
        PlayerPrefs.SetFloat("gold", gold);
    }

    private void Update()
    {
        CharacterChangeCheck();
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(!enemiesFinish && enemyCount == 0)
        {
            enemyDefault.SetActive(true);
            enemiesFinish = true;
        }

      
    }

    public void CharacterChangeCheck()
    {
        CharactersHealthControlTimer += Time.deltaTime;
        if (CharactersHealthControlTimer > 0.5f)
        {
            CharactersHealthControlTimer = 0;
            for (int i = 0; i < characterSelectButonImages.Length; i++)
            {
                characterSelectButonImages[i].transform.parent.gameObject.SetActive(false);
            }
            CharacterChange();
        }
    }
    public void CharacterChange()
    {
        characters.Clear();
        foreach (PlayerType fooObj in FindObjectsOfType<PlayerType>())
        {
            characters.Add(fooObj.gameObject);
        }
        if (activeCharacter == null)
        {
            if (passiveCharacters.Count > 0)
            {
                activeCharacter = passiveCharacters[0];
            }
        }
        if (activeCharacter == null)
            return;
        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].GetComponent<PlayerAttack>().rangeObject.SetActive(false);
            characters[i].GetComponent<PlayerMovement>().enabled = false;
            characters[i].GetComponent<NavMeshAgent>().enabled = true;
            characters[i].GetComponent<Ai>().enabled = true;
            characters[i].GetComponent<Ai>().targetPlayer = activeCharacter.transform;
        }
     
        activeCharacter.GetComponent<PlayerAttack>().rangeObject.SetActive(true);
        activeCharacter.GetComponent<PlayerMovement>().enabled = true;
        activeCharacter.GetComponent<NavMeshAgent>().enabled = false;
        activeCharacter.GetComponent<Ai>().enabled = false;
        activeCharacter.GetComponent<Rigidbody>().velocity = Vector3.zero;
        vCam.LookAt = activeCharacter.transform;
        vCam.Follow = activeCharacter.transform;

        passiveCharacters.Clear();
        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i] != activeCharacter)
            {
                passiveCharacters.Add(characters[i]);
            }
        }

        for (int i = 0; i < passiveCharacters.Count; i++)
        {
            characterSelectButonImages[i].transform.parent.gameObject.SetActive(true);
            characterSelectButonImages[i].sprite = passiveCharacters[i].GetComponent<PlayerType>().CharacterImage;
        }
      
           
    }
    
    public void SelectCharacterButton(int index)
    {
        activeCharacter = passiveCharacters[index];
        CharacterChange();
    }


    public void CharacterPrefs()
    {

        if (menuChooseCharacters[PlayerPrefs.GetInt("slotNum1")] != null)
        {
            menuChooseCharacters[PlayerPrefs.GetInt("slotNum1")].gameObject.SetActive(true);
            menuChooseCharacters[PlayerPrefs.GetInt("slotNum1")].transform.position = spawnPos[0].position;
         
        }
        if (menuChooseCharacters[PlayerPrefs.GetInt("slotNum2")] != null)
        {
            menuChooseCharacters[PlayerPrefs.GetInt("slotNum2")].gameObject.SetActive(true);
            menuChooseCharacters[PlayerPrefs.GetInt("slotNum2")].transform.position = spawnPos[1].position;
          
        }
        if (menuChooseCharacters[PlayerPrefs.GetInt("slotNum3")] != null)
        {
            menuChooseCharacters[PlayerPrefs.GetInt("slotNum3")].gameObject.SetActive(true);
            menuChooseCharacters[PlayerPrefs.GetInt("slotNum3")].transform.position = spawnPos[2].position;
         
        }

    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    //public void CinemachineDefaultPos()
    //{
    //    var transposer = vCam.GetCinemachineComponent<CinemachineTransposer>();
    //    transposer.m_FollowOffset = vCamFollowOffset;
    //}

    public void SlowMo(float time)
    {
      //  Time.timeScale = 0.3f;
        DOVirtual.DelayedCall(time, () => Time.timeScale = 1,false);
    }

    public void CharacterStatsPlayerPrefs()
    {
        warriorHealth = PlayerPrefs.GetFloat("warriorHealth");
        warriorDamage = PlayerPrefs.GetFloat("warriorDamage");
        warriorEnergyEarn = PlayerPrefs.GetFloat("warriorEnergy");
        shieldTime = PlayerPrefs.GetFloat("warriorShield");

        archerHealth = PlayerPrefs.GetFloat("archerHealth");
        archerDamage = PlayerPrefs.GetFloat("archerDamage");
        archerEnergyEarn = PlayerPrefs.GetFloat("archerEnergy");
        balistaDamage = PlayerPrefs.GetFloat("archerBalista");
        balistaTime = PlayerPrefs.GetFloat("archerBalistaTime");

        mageHealth = PlayerPrefs.GetFloat("mageHealth");
        mageDamage = PlayerPrefs.GetFloat("mageDamage");
        mageEnergyEarn = PlayerPrefs.GetFloat("mageEnergy");
        mageFireballDamage = PlayerPrefs.GetFloat("mageFireball");
        mageAreaDamage = PlayerPrefs.GetFloat("mageFlame");

        ninjaHealth = PlayerPrefs.GetFloat("ninjaHealth");
        ninjaDamage = PlayerPrefs.GetFloat("ninjaDamage");
        ninjaEnergyEarn = PlayerPrefs.GetFloat("ninjaEnergy");
        invisibilityTime = PlayerPrefs.GetFloat("ninjaInvisibility");

        wizardHealth = PlayerPrefs.GetFloat("wizardHealth");
        wizardDamage = PlayerPrefs.GetFloat("wizardDamage");
        wizardEnergyEarn = PlayerPrefs.GetFloat("wizardEnergy");
        wizardHeal = PlayerPrefs.GetFloat("wizardHealing");
        wizardHealTime = PlayerPrefs.GetFloat("wizardHealingTime");

        bomberHealth = PlayerPrefs.GetFloat("bomberHealth");
        bomberDamage = PlayerPrefs.GetFloat("bomberDamage");
        bomberEnergyEarn = PlayerPrefs.GetFloat("bomberEnergy");
        bomberSkillDamage = PlayerPrefs.GetFloat("bomberMiniBombs");

        hammerHealth = PlayerPrefs.GetFloat("hammerHealth");
        hammerDamage = PlayerPrefs.GetFloat("hammerDamage");
        hammerEnergyEarn = PlayerPrefs.GetFloat("hammerEnergy");
        hammerFlameDamage = PlayerPrefs.GetFloat("hammerRing");
        hammerFlameTime = PlayerPrefs.GetFloat("hammerRingTime");
    }
}
