using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float currentHP;
    [SerializeField] private float maxHP = 100f;

    [SerializeField] private Image healthBar;

    public UnityEvent onDamaged;
    public UnityEvent onDeath;

    private void Awake()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(float dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0)
        {
            currentHP = 0;
            onDeath.Invoke(); //TRIGGER DEATH HERE
        }
        else
        {
            onDamaged.Invoke();
        }
    }

    public void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHP / maxHP;
    }
}
