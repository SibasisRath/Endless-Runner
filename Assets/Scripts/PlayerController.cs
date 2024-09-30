using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityModifier;
    [SerializeField] private GameManager gameManager;
    
    private bool _isOnGround;
    private bool _isDoubleJumpable;
    public bool IsDoubleSpeedable { get; set; }

    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;

    private Animator animator;

    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    private AudioSource playerAudio;

    [SerializeField] GameObject gameOverScreen;

    private Vector3 originalGravity;

    void Start()
    {
        gameOverScreen.SetActive(false);
        _rb = GetComponent<Rigidbody>();

        originalGravity = Physics.gravity;  // Store the original gravity
        Physics.gravity *= _gravityModifier;  // Modify the gravity

        _isOnGround = true;
        IsDoubleSpeedable = false;
        _isDoubleJumpable = false;

        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    void OnDestroy()
    {
        Physics.gravity = originalGravity;  // Reset gravity when the scene reloads
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround && gameManager.GameOver == false)
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
            IsDoubleSpeedable = true;
            animator.SetFloat("Speed_Multiplier", 2.0f);
        }
        else if (IsDoubleSpeedable)
        {
            IsDoubleSpeedable = false;
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
        else if (collision.gameObject.CompareTag("Obstacle") && gameManager.GameOver == false)
        {
            gameManager.GameOver = true;
            explosionParticle.Play();
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            gameOverScreen.SetActive(true);
        }
    }
}
