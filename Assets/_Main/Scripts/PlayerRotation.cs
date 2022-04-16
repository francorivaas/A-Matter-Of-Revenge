using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : RotateActor
{
    [SerializeField] private LayerMask _raycastLayerMask;

    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
        print(_mainCamera.farClipPlane);
    }

    private void Update()
    {
        var direction = GetMouseDirection();
        LookAtDirection(direction);
    }

    private Vector3 GetMouseDirection()
    {
        var mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var direction = Vector3.zero;

        if (Physics.Raycast(mousePosition, _mainCamera.transform.forward, out RaycastHit hit, _mainCamera.farClipPlane, _raycastLayerMask))
        {
            direction = new Vector3(hit.point.x - transform.position.x, transform.position.y, hit.point.z - transform.position.z);
        }

        return direction;
    }
}
