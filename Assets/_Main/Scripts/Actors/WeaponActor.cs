using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponActor : MonoBehaviour, IWeapon
{
    public virtual void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Attack();
        }
    }

    public virtual void Attack()
    {
    }
}
