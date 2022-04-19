using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : WeaponActor
{
    [SerializeField] private float shootRange;

    private Transform firePoint;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        
        firePoint = GetComponentInChildren<Transform>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void Attack()
    {
        base.Attack();

        RaycastHit hit;
        if (Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit, shootRange))
        {
            print(hit.transform.name);
        }
    }
}
