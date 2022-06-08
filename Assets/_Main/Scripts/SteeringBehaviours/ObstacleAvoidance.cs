using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class ObstacleAvoidance
{
    private Transform _self;
    private IVel _target;
    private ObstacleAvoidanceSO _properties;
    private Dictionary<Steerings, ISteering> _behaviourDict = new Dictionary<Steerings, ISteering>();
    private ISteering _actualBehaviour;
    public ISteering ActualBehaviour => _actualBehaviour;
    public ObstacleAvoidance(Transform self, IVel target, ObstacleAvoidanceSO properties, Dictionary<Steerings, ISteering> behaviourDict)
    {
        _properties = properties;
        _self = self;
        _target = target;
        _behaviourDict = behaviourDict;
    }
    public void SetActualBehaviour(Steerings desiredBehaviour)
    {
        _actualBehaviour = _behaviourDict[desiredBehaviour];
    }
    public ISteering GetBehaviour(Steerings behaviour)
    {
        if (!_behaviourDict.ContainsKey(behaviour))
        {
            Debug.Log("No existe ese Behaviour");
            return null;

        }
        else
        {
            return _behaviourDict[behaviour];
        }
    }
    public Vector3 GetDir()
    {
        
        Collider[] obj = Physics.OverlapSphere(_self.position, _properties.Radius, _properties.ObstacleLayers);
        Collider closestObj = null;
        float nearDistance = 0;
        for (int i = 0; i < obj.Length; i++)
        {
            Collider currObs = obj[i];
            Vector3 dir = currObs.transform.position - _self.position;
            float currentAngle = Vector3.Angle(_self.forward, dir);
            if (currentAngle < _properties.Angle / 2)
            {
                float currentDistance = Vector3.Distance(_self.position, currObs.transform.position);
                if (closestObj == null || currentDistance < nearDistance)
                {
                    closestObj = currObs;
                    nearDistance = currentDistance;
                }
            }
        }
        if (closestObj != null)
        {
            if (nearDistance == _properties.Radius)
            {
                nearDistance = _properties.Radius - 0.00001f;
            }
            var point = closestObj.ClosestPoint(_self.position);
            Vector3 dir = ((_self.position + _self.right * 0.0000000001f) - point);
            return dir.normalized;
        }

        return Vector3.zero;
    }
    public Vector3 GetFixedDir()
    {
        var direction = (GetDir() * _properties.AvoidanceMult + _actualBehaviour.GetDir() * _properties.BehaviourMult).normalized;
        return direction;
    }
    public Vector3 GetFixedDir(Vector3 dir)
    {
        var direction = (GetDir() * _properties.AvoidanceMult + dir * _properties.BehaviourMult).normalized;
        return direction;
    }

    public void SetTarget(IVel target)
    {
        _target = target;
        _actualBehaviour.SetTarget(target.GetTarget);
    }
    public void SetTarget(Transform target)
    {
        _actualBehaviour.SetTarget(target);
    }
}
