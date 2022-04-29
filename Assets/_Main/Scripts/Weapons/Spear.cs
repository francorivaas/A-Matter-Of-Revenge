using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : WeaponActor
{
    [SerializeField] private GameObject damageArea;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        ActivateDamageArea();
    }

    public override void Attack()
    {
        base.Attack();
    }

    private void ActivateDamageArea()
    {
        if (damageArea != null)
        {
            if (!canAttack)
                damageArea.SetActive(true);

            else
                damageArea.SetActive(false);
        }
    }
}
