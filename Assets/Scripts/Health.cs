using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class Health : MonoBehaviour
{
    PlayerAnimation playerAnimation;
    PlayerType playerType;
    public GameManager gm;
    public bool dead;
    public float health;
    public float maxHealth;
    public GameObject canvas;
    public Image healthBar;
    public TextMeshProUGUI healthText;
    public float healTimer;
    private void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        playerType = GetComponent<PlayerType>();
        gm = FindObjectOfType<GameManager>();
    }
   
    public void SetHealth()
    {
        health = maxHealth;
        healthBar.fillAmount = health / maxHealth;
        healthText.text = health.ToString();
    }


    private void Update()
    {
        if (playerType.healing)
        {
            healTimer += Time.deltaTime;
            if (healTimer > 1)
            {
                healTimer = 0;
                GetDamage(gm.wizardHeal);
                GetComponent<DamageNumbersPro.Demo.DNP_Example>().SpawnPopup(-gm.wizardHeal, "green");
            }
        }
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        healthBar.fillAmount = health / maxHealth;
        healthText.text = health.ToString();

       

        if (health <= 0 && !dead)
        {
            DOVirtual.DelayedCall(2, () => canvas.SetActive(false), false);
            healthText.text = "0";
            dead = true;
            playerAnimation.Dead();
            if (gameObject == gm.activeCharacter)
            {
                gm.activeCharacter = null;
                gm.CharacterChange();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Heal>())
        {
            healTimer += Time.deltaTime;
            if (healTimer > 1)
            {
                healTimer = 0;
                GetDamage(gm.wizardHeal);
                GetComponent<DamageNumbersPro.Demo.DNP_Example>().SpawnPopup(-gm.wizardHeal,"green");
            }
        }


    }
}
