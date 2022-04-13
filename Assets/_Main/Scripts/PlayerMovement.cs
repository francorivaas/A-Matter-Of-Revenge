using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private float xMovement;
    private float yMovement;

    private Rigidbody body;

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

    void Move(Vector3 direction)
    {
        body.velocity = direction * speed;
    }
}
