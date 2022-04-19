using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class DamageableActor : MonoBehaviour, IDamageable
{
    protected float maxHealth = 100.0f;

    [SerializeField]
    protected float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth > 0.0f)
        {
            currentHealth -= damage;

            if (currentHealth <= 0.0f) Die();
        }
    }

    public void Die()
    {
        Debug.Log($" { name } + ha muerto ");
    }
}
