using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnim;
    private AudioSource playerAudio;

    private bool isOnGround = true;

    private float jumpForce = 12;
    private float gravityModifier = 2.5f;

    public ParticleSystem playerExplosion;
    public ParticleSystem playerDirt;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    public bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            playerDirt.Stop();

            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            playerDirt.Play();
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game OVER");

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            playerAudio.PlayOneShot(crashSound, 1.0f);

            playerExplosion.Play();
            playerDirt.Stop();

            isGameOver = true;
        }
    }
}
