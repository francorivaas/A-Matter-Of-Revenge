using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : ISteering
{
    private Transform _target;
    private Transform _self;
    public Seek(Transform target, Transform self)
    {
        _self = self;
        SetTarget(target);
    }
    public Vector3 GetDir()
    {
        if(_target == null)
        {
            return Vector3.zero;
        }
        Vector3 dir = _target.position - _self.position;
        return dir.normalized;
    }
    public void SetTarget(Transform newTarget)
    {
        _target = newTarget;
    }
}
