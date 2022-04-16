using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovableActor : MonoBehaviour
{
    protected Rigidbody body;
    [SerializeField] public float speed;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    protected void Move(Vector3 direction)
    {
        body.velocity = direction * speed;
    }
}
