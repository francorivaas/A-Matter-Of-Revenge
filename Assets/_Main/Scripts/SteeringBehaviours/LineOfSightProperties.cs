using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
[CreateAssetMenu (fileName = "LOSProperties", menuName = "Line Of Sight Properties", order = 1)]
public class LineOfSightProperties : ScriptableObject
{
    [SerializeField] private float _detectionDistance;
    public float DetectionDistance => _detectionDistance;

    [SerializeField] private float _aperture;
    public float Aperture => _aperture;

    [SerializeField] private LayerMask _obstacleLayers;
    public LayerMask ObstacleLayer => _obstacleLayers;

    [SerializeField] private LayerMask _targetLayer;
    public LayerMask TargetLayer => _targetLayer;
}
