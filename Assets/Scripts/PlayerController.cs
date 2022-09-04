
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    //variables
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;

    public float jumpForce = 10f;
    public float gravityModifier;
    public bool isGrounded = true;
    public bool gameOver;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    public bool jumpedOnce = true;
    public int jumpCount = 0;

    private MoveLeft backgroundMoveLeft;

   

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        backgroundMoveLeft = GameObject.Find("Background").GetComponent<MoveLeft>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && !jumpedOnce)
        {
            PlayerJump();
            isGrounded = false;
            jumpCount++;
        } 

        if(jumpCount > 1){
            jumpedOnce = true;
        }
       
       if(Input.GetKeyDown(KeyCode.Q)){
           playerDash();
       }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            dirtParticle.Play();

            //sets the jumpCount to zero once it's on the ground and resets the jumpedOnce boolean
            jumpCount = 0;
            jumpedOnce = false;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
           
        }

    }

    // A function that handles the player's jump
    private void PlayerJump(){
         playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
    }

    private void playerDash(){
        Debug.Log("Player Dashing");
        backgroundMoveLeft.speed = 100f;
    }
}
