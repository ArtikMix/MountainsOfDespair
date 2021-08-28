using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : CharacterStats
{

    void Start()
    {   
    }
    void Update()
    {

    }
    public override void Die()
    {
        base.Die();
        EnemyStats.currentHealth = 100;
        //death, ragdol(?)
        Destroy(gameObject);
    }
}
