using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharacterUpgrades : MonoBehaviour
{
    public float gold;
    public TextMeshProUGUI goldText;

    [Header("Warrior")]
    public int warriorLevel;
    public TextMeshProUGUI warriorLevelMenuText, warriorLevelInfoText;

    public ParticleSystem warriorUpgradeParticle;

    public float warriorHealth;
    public List<float> warriorHealthList;
    public TextMeshProUGUI warriorHealthText;

    public float warriorDamage;
    public List<float> warriorDamageList;
    public TextMeshProUGUI warriorDamageText;

    public float warriorEnergy;
    public List<float> warriorEnergyList;
    public TextMeshProUGUI warriorEnergyText;

    public float warriorShield;
    public List<float> warriorShieldList;
    public TextMeshProUGUI warriorShieldText;

    public List<float> warriorUpgradePriceList;
    public TextMeshProUGUI warriorUpgradePriceText;

    [Header("Archer")]
    public int archerLevel;
    public TextMeshProUGUI archerLevelMenuText, archerLevelInfoText;

    public ParticleSystem archerUpgradeParticle;

    public float archerHealth;
    public List<float> archerHealthList;
    public TextMeshProUGUI archerHealthText;

    public float archerDamage;
    public List<float> archerDamageList;
    public TextMeshProUGUI archerDamageText;

    public float archerEnergy;
    public List<float> archerEnergyList;
    public TextMeshProUGUI archerEnergyText;

    public float archerBalista;
    public List<float> archerBalistaList;
    public TextMeshProUGUI archerBalistaText;

    public float archerBalistaTime;
    public List<float> archerBalistaTimeList;
    public TextMeshProUGUI archerBalistaTimeText;

    public List<float> archerUpgradePriceList;
    public TextMeshProUGUI archerUpgradePriceText;

    [Header("Mage")]
    public int mageLevel;
    public TextMeshProUGUI mageLevelMenuText, mageLevelInfoText;

    public ParticleSystem mageUpgradeParticle;

    public float mageHealth;
    public List<float> mageHealthList;
    public TextMeshProUGUI mageHealthText;

    public float mageDamage;
    public List<float> mageDamageList;
    public TextMeshProUGUI mageDamageText;

    public float mageEnergy;
    public List<float> mageEnergyList;
    public TextMeshProUGUI mageEnergyText;

    public float mageFireball;
    public List<float> mageFireballList;
    public TextMeshProUGUI mageFireballText;

    public float mageFlame;
    public List<float> mageFlameList;
    public TextMeshProUGUI mageFlameText;

    public List<float> mageUpgradePriceList;
    public TextMeshProUGUI mageUpgradePriceText;

    [Header("Ninja")]
    public int ninjaLevel;
    public TextMeshProUGUI ninjaLevelMenuText, ninjaLevelInfoText;

    public ParticleSystem ninjaUpgradeParticle;

    public float ninjaHealth;
    public List<float> ninjaHealthList;
    public TextMeshProUGUI ninjaHealthText;

    public float ninjaDamage;
    public List<float> ninjaDamageList;
    public TextMeshProUGUI ninjaDamageText;

    public float ninjaEnergy;
    public List<float> ninjaEnergyList;
    public TextMeshProUGUI ninjaEnergyText;

    public float ninjaInvisibility;
    public List<float> ninjaInvisibilityList;
    public TextMeshProUGUI ninjaInvisibilityText;

    public List<float> ninjaUpgradePriceList;
    public TextMeshProUGUI ninjaUpgradePriceText;

    [Header("Wizard")]
    public int wizardLevel;
    public TextMeshProUGUI wizardLevelMenuText, wizardLevelInfoText;

    public ParticleSystem wizardUpgradeParticle;

    public float wizardHealth;
    public List<float> wizardHealthList;
    public TextMeshProUGUI wizardHealthText;

    public float wizardDamage;
    public List<float> wizardDamageList;
    public TextMeshProUGUI wizardDamageText;

    public float wizardEnergy;
    public List<float> wizardEnergyList;
    public TextMeshProUGUI wizardEnergyText;

    public float wizardHealing;
    public List<float> wizardHealingList;
    public TextMeshProUGUI wizardHealingText;

    public float wizardHealingTime;
    public List<float> wizardHealingTimeList;
    public TextMeshProUGUI wizardHealingTimeText;

    public List<float> wizardUpgradePriceList;
    public TextMeshProUGUI wizardUpgradePriceText;

    [Header("Bomber")]
    public int bomberLevel;
    public TextMeshProUGUI bomberLevelMenuText, bomberLevelInfoText;

    public ParticleSystem bomberUpgradeParticle;

    public float bomberHealth;
    public List<float> bomberHealthList;
    public TextMeshProUGUI bomberHealthText;

    public float bomberDamage;
    public List<float> bomberDamageList;
    public TextMeshProUGUI bomberDamageText;

    public float bomberEnergy;
    public List<float> bomberEnergyList;
    public TextMeshProUGUI bomberEnergyText;

    public float bomberMiniBombs;
    public List<float> bomberMiniBombsList;
    public TextMeshProUGUI bomberMiniBombsText;

    public List<float> bomberUpgradePriceList;
    public TextMeshProUGUI bomberUpgradePriceText;

    [Header("Hammer")]
    public int hammerLevel;
    public TextMeshProUGUI hammerLevelMenuText, hammerLevelInfoText;

    public ParticleSystem hammerUpgradeParticle;

    public float hammerHealth;
    public List<float> hammerHealthList;
    public TextMeshProUGUI hammerHealthText;

    public float hammerDamage;
    public List<float> hammerDamageList;
    public TextMeshProUGUI hammerDamageText;

    public float hammerEnergy;
    public List<float> hammerEnergyList;
    public TextMeshProUGUI hammerEnergyText;

    public float hammerRing;
    public List<float> hammerRingList;
    public TextMeshProUGUI hammerRingText;

    public float hammerRingTime;
    public List<float> hammerRingTimeList;
    public TextMeshProUGUI hammerRingTimeText;

    public List<float> hammerUpgradePriceList;
    public TextMeshProUGUI hammerUpgradePriceText;

    void Start()
    {
        gold = PlayerPrefs.GetFloat("gold");
        ChangeMoney(0);

        warriorLevel = PlayerPrefs.GetInt("warriorLevel"); 
        if (warriorLevel == 0) 
        { warriorLevel = 1; PlayerPrefs.SetInt("warriorLevel", warriorLevel); }
        SetWarrior();

        archerLevel = PlayerPrefs.GetInt("archerLevel");
        if (archerLevel == 0)
        { archerLevel = 1; PlayerPrefs.SetInt("archerLevel", archerLevel); }
        SetArcher();

        mageLevel = PlayerPrefs.GetInt("mageLevel");
        if (mageLevel == 0)
        { mageLevel = 1; PlayerPrefs.SetInt("mageLevel", mageLevel); }
        SetMage();

        ninjaLevel = PlayerPrefs.GetInt("ninjaLevel");
        if (ninjaLevel == 0)
        { ninjaLevel = 1; PlayerPrefs.SetInt("ninjaLevel", ninjaLevel); }
        SetNinja();

        wizardLevel = PlayerPrefs.GetInt("wizardLevel");
        if (wizardLevel == 0)
        { wizardLevel = 1; PlayerPrefs.SetInt("wizardLevel", wizardLevel); }
        SetWizard();

        bomberLevel = PlayerPrefs.GetInt("bomberLevel");
        if (bomberLevel == 0)
        { bomberLevel = 1; PlayerPrefs.SetInt("bomberLevel", bomberLevel); }
        SetBomber();

        hammerLevel = PlayerPrefs.GetInt("hammerLevel");
        if (hammerLevel == 0)
        { hammerLevel = 1; PlayerPrefs.SetInt("hammerLevel", hammerLevel); }
        SetHammer();
    }
    public void UpgradeWarrior()
    {
        if (gold >= warriorUpgradePriceList[warriorLevel])
        {
            ChangeMoney(-warriorUpgradePriceList[warriorLevel]);
            warriorLevel += 1;
            SetWarrior();
            warriorUpgradeParticle.Play();
        }
    }
    public void UpgradeArcher()
    {
        if (gold >= archerUpgradePriceList[archerLevel])
        {
            ChangeMoney(-archerUpgradePriceList[archerLevel]);
            archerLevel += 1;
            SetArcher();
            archerUpgradeParticle.Play();
        }
    }
    public void UpgradeMage()
    {
        if (gold >= mageUpgradePriceList[mageLevel])
        {
            ChangeMoney(-mageUpgradePriceList[mageLevel]);
            mageLevel += 1;
            SetMage();
            mageUpgradeParticle.Play();
        }
    }
    public void UpgradeNinja()
    {
        if (gold >= ninjaUpgradePriceList[ninjaLevel])
        {
            ChangeMoney(-ninjaUpgradePriceList[ninjaLevel]);
            ninjaLevel += 1;
            SetNinja();
            ninjaUpgradeParticle.Play();
        }
    }
    public void UpgradeWizard()
    {
        if (gold >= wizardUpgradePriceList[wizardLevel])
        {
            ChangeMoney(-wizardUpgradePriceList[wizardLevel]);
            wizardLevel += 1;
            SetWizard();
            wizardUpgradeParticle.Play();
        }
    }
    public void UpgradeBomber()
    {
        if (gold >= bomberUpgradePriceList[bomberLevel])
        {
            ChangeMoney(-bomberUpgradePriceList[bomberLevel]);
            bomberLevel += 1;
            SetBomber();
            bomberUpgradeParticle.Play();
        }
    }
    public void UpgradeHammer()
    {
        if (gold >= hammerUpgradePriceList[hammerLevel])
        {
            ChangeMoney(-hammerUpgradePriceList[hammerLevel]);
            hammerLevel += 1;
            SetHammer();
            hammerUpgradeParticle.Play();
        }
    }
    void SetWarrior()
    {
        PlayerPrefs.SetInt("warriorLevel", warriorLevel);
        warriorLevelMenuText.text = "LEVEL " + warriorLevel; warriorLevelInfoText.text = "LEVEL " + warriorLevel;

        warriorHealth = warriorHealthList[warriorLevel];
        warriorHealthText.text = warriorHealth.ToString();
        PlayerPrefs.SetFloat("warriorHealth", warriorHealth);

        warriorDamage = warriorDamageList[warriorLevel];
        warriorDamageText.text = warriorDamage.ToString();
        PlayerPrefs.SetFloat("warriorDamage", warriorDamage);

        warriorEnergy = warriorEnergyList[warriorLevel];
        warriorEnergyText.text = warriorEnergy.ToString();
        PlayerPrefs.SetFloat("warriorEnergy", warriorEnergy);

        warriorShield = warriorShieldList[warriorLevel];
        warriorShieldText.text = warriorShield.ToString() + "s";
        PlayerPrefs.SetFloat("warriorShield", warriorShield);

        warriorUpgradePriceText.text = warriorUpgradePriceList[warriorLevel].ToString();
    }
    void SetArcher()
    {
        PlayerPrefs.SetInt("archerLevel", archerLevel);
        archerLevelMenuText.text = "LEVEL " + archerLevel; archerLevelInfoText.text = "LEVEL " + archerLevel;

        archerHealth = archerHealthList[archerLevel];
        archerHealthText.text = archerHealth.ToString();
        PlayerPrefs.SetFloat("archerHealth", archerHealth);

        archerDamage = archerDamageList[archerLevel];
        archerDamageText.text = archerDamage.ToString();
        PlayerPrefs.SetFloat("archerDamage", archerDamage);

        archerEnergy = archerEnergyList[archerLevel];
        archerEnergyText.text = archerEnergy.ToString();
        PlayerPrefs.SetFloat("archerEnergy", archerEnergy);

        archerBalista = archerBalistaList[archerLevel];
        archerBalistaText.text = archerBalista.ToString();
        PlayerPrefs.SetFloat("archerBalista", archerBalista);

        archerBalistaTime = archerBalistaTimeList[archerLevel];
        archerBalistaTimeText.text = archerBalistaTime.ToString() + "s";
        PlayerPrefs.SetFloat("archerBalistaTime", archerBalistaTime);

        archerUpgradePriceText.text = archerUpgradePriceList[archerLevel].ToString();
    }
    void SetMage()
    {
        PlayerPrefs.SetInt("mageLevel", mageLevel);
        mageLevelMenuText.text = "LEVEL " + mageLevel; mageLevelInfoText.text = "LEVEL " + mageLevel;

        mageHealth = mageHealthList[mageLevel];
        mageHealthText.text = mageHealth.ToString();
        PlayerPrefs.SetFloat("mageHealth", mageHealth);

        mageDamage = mageDamageList[mageLevel];
        mageDamageText.text = mageDamage.ToString();
        PlayerPrefs.SetFloat("mageDamage", mageDamage);

        mageEnergy = mageEnergyList[mageLevel];
        mageEnergyText.text = mageEnergy.ToString();
        PlayerPrefs.SetFloat("mageEnergy", mageEnergy);

        mageFireball = mageFireballList[mageLevel];
        mageFireballText.text = mageFireball.ToString();
        PlayerPrefs.SetFloat("mageFireball", mageFireball);

        mageFlame = mageFlameList[mageLevel];
        mageFlameText.text = mageFlame.ToString();
        PlayerPrefs.SetFloat("mageFlame", mageFlame);

        mageUpgradePriceText.text = mageUpgradePriceList[mageLevel].ToString();
    }
    void SetNinja()
    {
        PlayerPrefs.SetInt("ninjaLevel", ninjaLevel);
        ninjaLevelMenuText.text = "LEVEL " + ninjaLevel; ninjaLevelInfoText.text = "LEVEL " + ninjaLevel;

        ninjaHealth = ninjaHealthList[ninjaLevel];
        ninjaHealthText.text = ninjaHealth.ToString();
        PlayerPrefs.SetFloat("ninjaHealth", ninjaHealth);

        ninjaDamage = ninjaDamageList[ninjaLevel];
        ninjaDamageText.text = ninjaDamage.ToString();
        PlayerPrefs.SetFloat("ninjaDamage", ninjaDamage);

        ninjaEnergy = ninjaEnergyList[ninjaLevel];
        ninjaEnergyText.text = ninjaEnergy.ToString();
        PlayerPrefs.SetFloat("ninjaEnergy", ninjaEnergy);

        ninjaInvisibility = ninjaInvisibilityList[ninjaLevel];
        ninjaInvisibilityText.text = ninjaInvisibility.ToString() + "s";
        PlayerPrefs.SetFloat("ninjaInvisibility", ninjaInvisibility);

        ninjaUpgradePriceText.text = ninjaUpgradePriceList[ninjaLevel].ToString();
    }
    void SetWizard()
    {
        PlayerPrefs.SetInt("wizardLevel", wizardLevel);
        wizardLevelMenuText.text = "LEVEL " + wizardLevel; wizardLevelInfoText.text = "LEVEL " + wizardLevel;

        wizardHealth = wizardHealthList[wizardLevel];
        wizardHealthText.text = wizardHealth.ToString();
        PlayerPrefs.SetFloat("wizardHealth", wizardHealth);

        wizardDamage = wizardDamageList[wizardLevel];
        wizardDamageText.text = wizardDamage.ToString();
        PlayerPrefs.SetFloat("wizardDamage", wizardDamage);

        wizardEnergy = wizardEnergyList[wizardLevel];
        wizardEnergyText.text = wizardEnergy.ToString();
        PlayerPrefs.SetFloat("wizardEnergy", wizardEnergy);

        wizardHealing = wizardHealingList[wizardLevel];
        wizardHealingText.text = wizardHealing.ToString();
        PlayerPrefs.SetFloat("wizardHealing", wizardHealing);

        wizardHealingTime = wizardHealingTimeList[wizardLevel];
        wizardHealingTimeText.text = wizardHealingTime.ToString() + "s";
        PlayerPrefs.SetFloat("wizardHealingTime", wizardHealingTime);

        wizardUpgradePriceText.text = wizardUpgradePriceList[wizardLevel].ToString();
    }
    void SetBomber()
    {
        PlayerPrefs.SetInt("bomberLevel", bomberLevel);
        bomberLevelMenuText.text = "LEVEL " + bomberLevel; bomberLevelInfoText.text = "LEVEL " + bomberLevel;

        bomberHealth = bomberHealthList[bomberLevel];
        bomberHealthText.text = bomberHealth.ToString();
        PlayerPrefs.SetFloat("bomberHealth", bomberHealth);

        bomberDamage = bomberDamageList[bomberLevel];
        bomberDamageText.text = bomberDamage.ToString();
        PlayerPrefs.SetFloat("bomberDamage", bomberDamage);

        bomberEnergy = bomberEnergyList[bomberLevel];
        bomberEnergyText.text = bomberEnergy.ToString();
        PlayerPrefs.SetFloat("bomberEnergy", bomberEnergy);

        bomberMiniBombs = bomberMiniBombsList[bomberLevel];
        bomberMiniBombsText.text = bomberMiniBombs.ToString() + "x8";
        PlayerPrefs.SetFloat("bomberMiniBombs", bomberMiniBombs);

        bomberUpgradePriceText.text = bomberUpgradePriceList[bomberLevel].ToString();
    }
    void SetHammer()
    {
        PlayerPrefs.SetInt("hammerLevel", hammerLevel);
        hammerLevelMenuText.text = "LEVEL " + hammerLevel; hammerLevelInfoText.text = "LEVEL " + hammerLevel;

        hammerHealth = hammerHealthList[hammerLevel];
        hammerHealthText.text = hammerHealth.ToString();
        PlayerPrefs.SetFloat("hammerHealth", hammerHealth);

        hammerDamage = hammerDamageList[hammerLevel];
        hammerDamageText.text = hammerDamage.ToString();
        PlayerPrefs.SetFloat("hammerDamage", hammerDamage);

        hammerEnergy = hammerEnergyList[hammerLevel];
        hammerEnergyText.text = hammerEnergy.ToString();
        PlayerPrefs.SetFloat("hammerEnergy", hammerEnergy);

        hammerRing = hammerRingList[hammerLevel];
        hammerRingText.text = hammerRing.ToString();
        PlayerPrefs.SetFloat("hammerRing", hammerRing);

        hammerRingTime = hammerRingTimeList[hammerLevel];
        hammerRingTimeText.text = hammerRingTime.ToString() + "s";
        PlayerPrefs.SetFloat("hammerRingTime", hammerRingTime);

        hammerUpgradePriceText.text = hammerUpgradePriceList[hammerLevel].ToString();
    }
   public void ChangeMoney(float amount)
    {
        gold += amount;
        goldText.text = gold.ToString();
        PlayerPrefs.SetFloat("gold", gold);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ChangeMoney(1000);
        }
    }
}
