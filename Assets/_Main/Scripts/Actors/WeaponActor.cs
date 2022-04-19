using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponActor : MonoBehaviour, IWeapon
{
    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
        if (Input.GetMouseButton(0)) Attack();
    }

    public virtual void Attack()
    {
    }
}
