using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothnessMovement;
    [SerializeField] private LayerMask obstacles;
    [SerializeField] private List<GameObject> obstaclesInSight;
    private void Start()
    {
    }
    private void Update()
    {
        Move();
        DetectThings();
    }
    void Move()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 finalPos = Vector3.Lerp(transform.position, desiredPos, smoothnessMovement * Time.deltaTime);
        transform.position = finalPos;
    }
    private void DetectThings()
    {
        Ray ray = new Ray(transform.position, target.position);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if ((obstacles & (1 << hitInfo.collider.gameObject.layer)) > 0)
            {
                hitInfo.collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
                obstaclesInSight.Add(hitInfo.collider.gameObject);
            }

        }
        else
        {
            if(obstaclesInSight.Count > 0)
            {
                return;
            }
            else
            {
                for (int i = 0; i < obstaclesInSight.Count; i++)
                {
                    obstaclesInSight.RemoveAt(i);
                }
            }
        }
    }
}
