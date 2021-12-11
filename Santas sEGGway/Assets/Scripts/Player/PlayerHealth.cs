using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int healAmount;
    public int currentHealth;
    public int maxHealth;
    public bool isDead = false;
    public Text text;
    private int damageMultiplier = 1;

    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage * damageMultiplier;
        text.text = currentHealth.ToString();

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Death();
        }
    }

    public void Heal()
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        damageMultiplier = 2;
        text.text = currentHealth.ToString();
    }

    public void ResetMultiplier()
    {
        damageMultiplier = 1;
    }

    void Death()
    {
        Debug.Log("Player has died!!!");
        isDead = true;
    }
}
