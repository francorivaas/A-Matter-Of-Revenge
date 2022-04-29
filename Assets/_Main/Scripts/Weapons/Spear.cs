using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : WeaponActor
{
    [SerializeField] private float spearDamage;
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
            if (canAttack)
                damageArea.SetActive(true);

            else
                damageArea.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        #region Get Actor Data

        HealthController actorHealth = other.gameObject.GetComponent<HealthController>();
        GameObject actorLayerObj = other.gameObject.transform.gameObject;

        #endregion Get Actor Data

        if (actorHealth != null && actorLayerObj.layer == LayerMask.NameToLayer("Enemy"))
        {
            actorHealth.TakeDamage(spearDamage);
            Debug.Log($"La vida de {actorHealth.name} es de {actorHealth.CurrentHealth}");
        }
    }
}
