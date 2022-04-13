using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableActor : MonoBehaviour
{
    protected Rigidbody body;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void Move(Vector3 direction)
    {
        body.velocity = direction * speed;
    }
}
