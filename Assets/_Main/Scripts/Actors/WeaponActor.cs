using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponActor : MonoBehaviour, IWeapon
{
    protected bool canAttack;

    [SerializeField] protected float weaponDamage = 10.0f;
    [SerializeField] protected float cooldown = 1.0f;

    protected virtual void Start()
    {
        canAttack = true;
    }

    protected virtual void Update()
    {
        CheckInputs();
    }

    private void CheckInputs()
    {
        if (Input.GetMouseButton(0) && canAttack)
        {
            canAttack = false;
            Attack();
            StartCoroutine(Cooldown(cooldown));
        }
    }

    public virtual void Attack()
    {
    }

    IEnumerator Cooldown (float time)
    {
        yield return new WaitForSeconds(time);
        canAttack = true;
    }
}
