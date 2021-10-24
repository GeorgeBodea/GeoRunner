using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    private Rigidbody rigidBody;
    private float speed = 5.0f;
    private float verticalInput;
    private float horizontalInput;
    private bool jumpKeyPressed;
    private int remainingJumps = 2;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        rigidBody.AddForce(new Vector3(horizontalInput, 0.0f, verticalInput) * speed);

        if (jumpKeyPressed && remainingJumps > 0)
        {
            rigidBody.AddForce(Vector3.up * speed, ForceMode.VelocityChange);
            jumpKeyPressed = false;
            remainingJumps -= 1;
        }
    }

    private void OnCollisionEnter(Collision other) {
        remainingJumps = 2;
    }
    
}
