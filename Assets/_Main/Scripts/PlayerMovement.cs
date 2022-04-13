using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MovableActor
{
    private float xMovement;
    private float yMovement;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        xMovement = Input.GetAxisRaw("Horizontal");
        yMovement = Input.GetAxisRaw("Vertical");

        Move(new Vector3(xMovement, 0.0f, yMovement));
    }
}
