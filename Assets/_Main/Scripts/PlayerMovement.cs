using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float xMovement;
    private float yMovement;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xMovement = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;

        transform.position += new Vector3(xMovement, yMovement);
    }
}
