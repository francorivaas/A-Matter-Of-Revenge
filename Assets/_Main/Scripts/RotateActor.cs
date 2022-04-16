using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RotateActor : MonoBehaviour
{
    [SerializeField]
    protected float rotationSpeed = 5.0f;

    protected void LookAtDirection(Vector3 direction)
    {
        var wantedDirection = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, wantedDirection, rotationSpeed * Time.deltaTime);
    }
}
