using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : DamageableActor
{
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }
}
