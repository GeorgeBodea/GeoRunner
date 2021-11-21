using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;


public class SphereMovement : MonoBehaviour
{
    private Rigidbody rigidBody;
    private float speed = 5.0f;
    private float jumpHeight = 5.0f;
    private float verticalInput;
    private float horizontalInput;
    private bool jumpKeyPressed;
    private int remainingJumps = 2;
    private bool isGrounded;

    public Text textScore;
    private int score;
    private string yourScore;
    private float timer;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();


        // Load the material 
        string playerMaterialName = PlayerPrefs.GetString(Constants.BallMaterial);
        GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/" + playerMaterialName);

        
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

        
        //check if the ball started moving
        if((horizontalInput > 0.0f) || (verticalInput > 0.0f))
        {
            isMoving = true;
        }

        if(isMoving)
        {
            //increasing score per second
            timer += Time.deltaTime;

            if (timer > 1f)
            {

                score += 1;

                yourScore = "Score: " + score.ToString();
                textScore.text = yourScore;

                //Reset the timer to 0.
                timer = 0;
            }
        }

       
    }

    void FixedUpdate()
    {
        rigidBody.AddForce(new Vector3(horizontalInput, 0.0f, verticalInput) * speed);

        if (jumpKeyPressed && remainingJumps > 0)
        {
            rigidBody.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
            jumpKeyPressed = false;
            remainingJumps -= 1;
        }
    }

    private void OnCollisionEnter(Collision other) {
        jumpKeyPressed = false;
        remainingJumps = 2;
    }
    
}
