using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Flee : ISteering
{
    private Transform _self;
    private Transform _target;

    public Flee(Transform target, Transform self)
    {
        _self = self;
        SetTarget(target);
    }
    public void SetTarget(Transform target)
    {
        _target = target;
    }
    public Vector3 GetDir()
    {
        Vector3 dir = _self.position - _target.position;
        return dir;
    }

}

