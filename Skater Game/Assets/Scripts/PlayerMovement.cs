using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpPower = 7f;
    [SerializeField] float maxJumpTime = 0.25f;
    [SerializeField] float rotateStep = 45f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] ParticleSystem particles;
    [SerializeField] private AudioSource rollingAudioSource;


    Rigidbody2D rb;
    Collider2D col;
    Animator anim;
    bool isJumping = false;
    float jumpTimeCounter = 0f;
    bool spaceHeldLastFrame = false;
    bool isGrounded = false;

    private Death deathScript;

    void Start()
    {
        deathScript = FindFirstObjectByType<Death>();

        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();

        particles.Play();
    }

    void Update()
    {
        bool spaceHeld = Input.GetKey(KeyCode.Space);
        isGrounded = col.IsTouchingLayers(groundLayer);

        if (spaceHeld && !spaceHeldLastFrame && isGrounded)
        {
            isJumping = true;
            jumpTimeCounter = maxJumpTime;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            anim.SetBool("isJumping", true);
        }


        if (spaceHeld && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
                anim.SetBool("isJumping", false);
            }
        }
        

        if (!spaceHeld)
        {
            isJumping = false;
            anim.SetBool("isJumping", false);
        }

        if (spaceHeld && !spaceHeldLastFrame && !isGrounded && !deathScript.isDead)
        {
            transform.Rotate(0, 0, rotateStep);
        }

        spaceHeldLastFrame = spaceHeld;

        // Particles
        if (!particles.isPlaying && isGrounded)
        {
            particles.Play();
        }
        else if (particles.isPlaying && !isGrounded)
        {
                particles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

        //Sound
        if (isGrounded && !deathScript.isDead)
        {
            if (!rollingAudioSource.isPlaying)
                rollingAudioSource.Play();
        }
        else
        {
            if (rollingAudioSource.isPlaying)
                rollingAudioSource.Stop();
        }

    }
}
