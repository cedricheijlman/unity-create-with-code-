using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public float gravityModifier;
    private Rigidbody playerRb;
    public bool isOnGround = true;
    private Animator playerAnim;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAudio.PlayOneShot(jumpSound, 1);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            
        }

    }
    public bool gameOver = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1);
        }
    }

}
