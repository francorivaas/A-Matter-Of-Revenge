using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
    public class Evade : ISteering
    {
    private Transform _self;
    private Transform _target;
    private IVel _targetVel;
    private float _predictionTime;
    public Transform Target => _target;
    public Evade(Transform target, Transform self, IVel targetVel, float predictionTime)
    {
        _self = self;
        _predictionTime = predictionTime;
        SetTarget(target, targetVel);
    }
    public void SetTarget(Transform target, IVel newTargetVel)
    {
        _targetVel = newTargetVel;
        _target = target;
    }
    public Vector3 GetDir()
    {
        var predictMult = _targetVel.GetVel * _predictionTime;
        var dist = Vector3.Distance(_self.position, _target.position);
        Vector3 point = _target.position + _targetVel.GetFoward * Mathf.Clamp(predictMult, -dist, dist);


        Vector3 dir = _self.position - point;
        return dir.normalized;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
