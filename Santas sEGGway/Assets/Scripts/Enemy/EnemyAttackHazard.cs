﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHazard : MonoBehaviour
{
    public int Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("This Working???");
        if(collision.GetComponent<PlayerHealth>())
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(Damage);
        }
    }
}
