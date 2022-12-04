using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    // Variables Called....
    private Rigidbody playerRb;
    private AudioSource playerAudio;   
    // This will get the animator component for our player.
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        // Then we initialize the player animation here.
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        // This will contain our audio effects for jump and crash..
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            // This makes the player jump..
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // This refers to the player on air and not the ground....
            isOnGround = false;

            // And when we finished initializing the animator component, we can activate the animation using the space bar...   
            playerAnim.SetTrigger("Jump_trig");

            // When we're in the air, deactivate particles.
            dirtParticle.Stop();

            // When we jump there is a sound..
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // This basically says that if we collide with a gameobject named Ground, we are on the ground...
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            // When we're on the ground, play particle...
            dirtParticle.Play();

        } else if (collision.gameObject.CompareTag("Obstacle")) 
        {
            // This basically says that if we came across a gameobject named Obstacle, our game is over..
            gameOver = true;
            Debug.Log("Game Over");

            // To trigger a death animation:
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            // This basically states that when we collide with the obstacle, an explosion effect will occur..
            explosionParticle.Play();

            // When we hit obstacles, stop particle...
            dirtParticle.Stop();

            // When we hit a obstacle, crash sound is heard..
            playerAudio.PlayOneShot(crashSound, 1.0f);

        }
       
    }
}
