using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;

        if(currentHealth <=0)
        {
            Death();
        }
    }

    void Death()
    {
        Debug.Log("Player has died!!!");
    }
}
