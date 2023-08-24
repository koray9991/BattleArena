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

    void ChangeMoney(float amount)
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
