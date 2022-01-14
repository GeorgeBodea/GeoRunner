using System.Collections;
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

    private bool canMove = true; //If player is not hitted
    private bool isStuned;
    private bool wasStuned; //If player was stunned before get stunned another time
    private float pushForce;
    private bool slide = false;

    public AudioSource[] sounds;
    public AudioSource noise1;
    public AudioSource noise2;

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        // Load the material 
        string playerMaterialName = PlayerPrefs.GetString(Constants.BallMaterial);
        GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/" + playerMaterialName);

        sounds = GetComponents<AudioSource>();
        noise1 = sounds[0];   //jump sound
        noise2 = sounds[1];   //collision sound

    }

    // Update is called once per frame
    private void Update()
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
                textScore.text = "Time: " + score;

                //Reset the timer to 0.
                timer = 0;
            }
        }

       
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            rigidBody.AddForce(speed * rigidBody.mass * new Vector3(horizontalInput, 0.0f, verticalInput));

            if (jumpKeyPressed && remainingJumps > 0)
            {
                noise1.Play();
                rigidBody.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
                jumpKeyPressed = false;
                remainingJumps -= 1;
            }
        }

        if(rigidBody.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        
    }

    private void OnCollisionEnter(Collision other) {
        noise2.Play();
        jumpKeyPressed = false;
        remainingJumps = 2;
    }
    
    public void HitPlayer(Vector3 velocityF, float time)
    {
        rigidBody.velocity = new Vector3();
        rigidBody.AddForce(velocityF,ForceMode.VelocityChange);

        pushForce = velocityF.magnitude;
        StartCoroutine(Decrease(pushForce, time));
    }
    private IEnumerator Decrease(float value, float duration)
    {
        if (isStuned)
            wasStuned = true;
        isStuned = true;
        canMove = false;

        float delta = value / duration;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            yield return null;
            if (!slide) //Reduce the force if the ground isn't slide
            {
                pushForce = pushForce - Time.deltaTime * delta;
                pushForce = pushForce < 0 ? 0 : pushForce;
            }
        }

        if (wasStuned)
        {
            wasStuned = false;
        }
        else
        {
            isStuned = false;
            canMove = true;
        }
    }
    
}
