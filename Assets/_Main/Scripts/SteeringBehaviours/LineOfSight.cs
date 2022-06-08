using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class LineOfSight : MonoBehaviour
{
    [SerializeField] private Transform origin;
    [SerializeField] private LineOfSightProperties _properties;
    int _lastFrame;
    bool cache;
    public LineOfSightProperties Properties => _properties;
    public bool CanSeeTarget(Transform target)
    {
        if (_lastFrame == Time.frameCount)
        {
            //retorno el cache
            return cache;
        }
        {
            _lastFrame = Time.frameCount;
            Vector3 diff = target.position - origin.position;
            float distance = diff.magnitude;

            if (distance > _properties.DetectionDistance)
            {
                cache = false;
                return false;
            }

            var angleToTarget = Vector3.Angle(diff, origin.forward);
            if (angleToTarget > _properties.Aperture / 2)
            {
                cache = false;
                return false;
            }

            if (Physics.Raycast(origin.position, diff.normalized, distance, _properties.ObstacleLayer)) 
            {
                cache = false;
                return false; 
            }
            cache = true;
            return true;
        }

    }
    public List<Transform> CheckTargets()
    {
        Collider[] colls = Physics.OverlapSphere(origin.position, _properties.DetectionDistance, _properties.TargetLayer);
        List<Transform> targets = new List<Transform>();
        for (int i = 0; i < colls.Length; i++)
        {
            if (CanSeeTarget(colls[i].transform))
            {
                targets.Add(colls[i].transform);
            }
            else
            {
                continue;
            }
        }
        return targets;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _properties.DetectionDistance);

        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, _properties.Aperture / 2, 0) * transform.forward * _properties.DetectionDistance);
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, -_properties.Aperture / 2, 0) * transform.forward * _properties.DetectionDistance);
    }
    public bool CanSeeManyTargets()
    {
        if (CheckTargets().Count <= 0)
        {
            return false;
        }
        return true;
    }
    public bool CheckForOneTarget()
    {
        var target = GetTheFirstTarget();
        if (target == null)
        {
            return false;
        }
        if (!CanSeeTarget(target))
        {
            return false;
        }
        return true;
    }
    public Transform GetTheFirstTarget()
    {
        if (CheckTargets().Count <= 0)
        {
            return null;
        }
        return CheckTargets()[0];
    }
    public Transform GetTheLastTarget()
    {
        if (CheckTargets().Count < 1)
        {
            return GetTheFirstTarget();
        }
        return CheckTargets()[CheckTargets().Count - 1];
    }
}
