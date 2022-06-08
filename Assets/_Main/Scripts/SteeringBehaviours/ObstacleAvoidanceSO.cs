using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
[CreateAssetMenu(fileName = "ObstacleAvoidance",menuName = "ObstacleAvoidance", order = 0)]
public class ObstacleAvoidanceSO : ScriptableObject
{
    [SerializeField]private LayerMask obstacleLayers;
    public LayerMask ObstacleLayers => obstacleLayers;

    [SerializeField] private float radius = 1;
    public float Radius => radius;

    [SerializeField] private float angle;
    public float Angle => angle;
    [SerializeField] private float predictionTime;
    public float PredictionTime => predictionTime;

    [SerializeField] private float avoidanceMult;
    public float AvoidanceMult => avoidanceMult;

    [SerializeField] private float behaviourMult;
    public float BehaviourMult => behaviourMult;

    [SerializeField] private float chaseTime;
    public float ChaseTime => chaseTime;

    [SerializeField] private float seekDistance;
    public float SeekDistance => seekDistance;

    [SerializeField] private float chaseDistance;
    public float ChaseDistance => seekDistance;

    [SerializeField] private float shootDistance;
    public float ShootDistance => shootDistance;

    [SerializeField] private float explodeDistance;
    public float ExplodeDistance => explodeDistance;
}
