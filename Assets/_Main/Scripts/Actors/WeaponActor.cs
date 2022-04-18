using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponActor : MonoBehaviour, IWeapon
{
    public virtual void Attack()
    {
        print(name);
    }
}
