using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyProfile : ScriptableObject
{
    public int maxHealth = 10;
    public int currentHealth = 10;
    public bool isDead = false;

    public Sprite EnemyVisual;
    public GameObject[] EnemiesAttacks;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
        }
    }
}
