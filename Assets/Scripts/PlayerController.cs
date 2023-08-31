using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityModifier;
    
    private bool _isOnGround;
    private bool _isDoubleJumpable;
    public bool _isDoubleSpeedable;
    public bool gameOver = false;
    
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    private Animator animator;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    [SerializeField] GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false) ;
        gameOver = false;
        _rb = GetComponent<Rigidbody>();
        Physics.gravity *= _gravityModifier;
        
        _isOnGround = true;
        _isDoubleSpeedable = false;
        
        _isDoubleJumpable = false;

        animator = GetComponent<Animator>();

        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround && gameOver == false)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isOnGround = false;
            animator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            _isDoubleJumpable = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && _isOnGround == false && _isDoubleJumpable == true)
        {
            _isDoubleJumpable = false;
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            animator.Play("Running_Jump", 3, 0f);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _isDoubleSpeedable = true;
            animator.SetFloat("Speed_Multiplier", 2.0f);
        }
        else if (_isDoubleSpeedable)
        {
            _isDoubleSpeedable = false;
            animator.SetFloat("Speed_Multiplier", 1.0f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle") && gameOver == false)
        {
            Debug.Log("You hit a obstacle.");
            gameOver = true;
            explosionParticle.Play();
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            gameOverScreen.SetActive(true);
        }
    }
}
