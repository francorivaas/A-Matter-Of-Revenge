using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : WeaponActor
{
    [SerializeField] private float shootRange;

    private Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        firePoint = GetComponentInChildren<Transform>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void Attack()
    {
        base.Attack();
        print("hola");
        RaycastHit hit;
        if (Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit, shootRange))
        {
            print(hit.transform.name);
        }
    }
}
