using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    public float energy, energyCapacity;
    public Image energyBar;
    public float energyIncrease;
    public PlayerAttack playerAttack;
    public bool energyIsFull;
    

    private void Awake()
    {
        playerAttack = GetComponent<PlayerAttack>();
      
    }
    private void Update()
    {
        energyBar.fillAmount = energy / energyCapacity;
    }
}
