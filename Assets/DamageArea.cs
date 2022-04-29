using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter(Collider other)
    {
        #region Get Actor Data

        HealthController actorHealth = other.gameObject.GetComponent<HealthController>();
        GameObject actorLayerObj = other.gameObject.transform.gameObject;

        #endregion Get Actor Data

        if (actorHealth != null && actorLayerObj.layer == LayerMask.NameToLayer("Enemy"))
        {
            actorHealth.TakeDamage(damage);
            Debug.Log($"La vida de {actorHealth.name} es de {actorHealth.CurrentHealth}");
        }
    }
}
