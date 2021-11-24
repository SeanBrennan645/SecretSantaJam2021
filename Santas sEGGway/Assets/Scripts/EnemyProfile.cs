using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyProfile : ScriptableObject
{
    public int maxHealth;
    public int currentHealth;

    public Sprite EnemyVisual;
    public GameObject[] EnemiesAttacks;
}
