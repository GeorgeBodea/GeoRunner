using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SphereMovement : MonoBehaviour
{
    public Text textScore;
    public Text textHighScore;

    public AudioSource[] sounds;
    public AudioSource noise1;
    public AudioSource noise2;

    private float ball_bought_speed;

    private bool canMove = true; //If player is not hitted
    private int highScore;
    private float horizontalInput;
    private bool isGrounded;
    private bool isStuned;
    private readonly float jumpHeight = 5.0f;
    private bool jumpKeyPressed;
    private float pushForce;
    private int remainingJumps = 1;
    private Rigidbody rigidBody;
    private int score;
    private readonly bool slide = false;
    private readonly float speed = 8.5f;
    private float timer;
    private float verticalInput;
    private bool wasStuned; //If player was stunned before get stunned another time

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        textScore.text = "0";

        if (!PlayerPrefs.HasKey("highScore"))
        {
            PlayerPrefs.SetInt("highScore", 0);
            highScore = 0;
            textHighScore.text = highScore.ToString();
        }
        else
        {
            highScore = PlayerPrefs.GetInt("highScore");
            textHighScore.text = highScore.ToString();
        }

        // Load the material 
        var playerMaterialName = PlayerPrefs.GetString(Constants.BallMaterial);
        GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/" + playerMaterialName);

        sounds = GetComponents<AudioSource>();
        noise1 = sounds[0]; //jump sound
        noise2 = sounds[1]; //collision sound

        if (!PlayerPrefs.HasKey("bought_speed")) PlayerPrefs.SetFloat("bought_speed", 1F);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) jumpKeyPressed = true;

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if ((int) transform.position.z > score)
        {
            score = (int) transform.position.z;
            textScore.text = score.ToString();
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            if (!PlayerPrefs.HasKey("bought_speed")) PlayerPrefs.SetFloat("bought_speed", 1F);

            ball_bought_speed = PlayerPrefs.GetFloat("bought_speed");
            ball_bought_speed = 1;
            rigidBody.AddForce(speed * ball_bought_speed * rigidBody.mass *
                               new Vector3(horizontalInput, 0.0f, verticalInput));

            if (jumpKeyPressed && remainingJumps > 0)
            {
                noise1.Play();
                rigidBody.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
                jumpKeyPressed = false;
                remainingJumps -= 1;
            }
        }

        if (rigidBody.position.y < -1f) FindObjectOfType<GameManager>().EndGame();
    }

    private void OnCollisionEnter(Collision other)
    {
        noise2.Play();
        if (other.gameObject.CompareTag("Platform"))
        {
            jumpKeyPressed = false;
            remainingJumps = 1;
        }
    }

    public void HitPlayer(Vector3 velocityF, float time)
    {
        rigidBody.velocity = new Vector3();
        rigidBody.AddForce(velocityF, ForceMode.VelocityChange);

        pushForce = velocityF.magnitude;
        StartCoroutine(Decrease(pushForce, time));
    }

    private IEnumerator Decrease(float value, float duration)
    {
        if (isStuned)
            wasStuned = true;
        isStuned = true;
        canMove = false;

        var delta = value / duration;

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

    public int getScore()
    {
        if (score > highScore)
        {
            highScore = score;
            textScore.text = score.ToString();
        }

        return score;
    }
}