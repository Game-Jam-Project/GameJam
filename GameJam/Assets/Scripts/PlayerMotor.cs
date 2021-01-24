using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour
{
    #region Varibals.
    [Header("General Movment")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumoForce = 18f;
    [SerializeField] private int extraJumps = 1;
    [SerializeField] private float groundCheckRadias = 0.02f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;

    [Header("Dash Configrations")]
    [SerializeField] private float dashSpeed = 5000f;
    [SerializeField] private float startDashTime = 0.02f;
    [SerializeField] private float dashRate = 0.3f;
    [SerializeField] private int dashs = 1;

    [Header("Sounds Name")]
    [SerializeField] private string jumoSound = "Jump";
    [SerializeField] private string landingSound = "Landing";
    [SerializeField] private string dashSound = "Dash";

    private bool facingRight = true;
    private bool isGrounded;
    private bool wasGrounded;
    private bool isLanding;
    private int extraJumpsValue;
    private int dir;
    private float dashTime;
    private int dashsValue;
    private float nextDashTime;

    private Rigidbody2D rb;
    private AudioManger audioManger;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioManger = AudioManger.instance;

        extraJumpsValue = extraJumps;
        dashsValue = dashs;
    }

    #region Moving.
    private void LateUpdate()
        {
            wasGrounded = isGrounded;
        }

        private void Update()
        {
        if (wasGrounded != isGrounded && isGrounded == true)
        {
            audioManger.Play(landingSound);                
        }
    }

    private void FixedUpdate()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadias, whatIsGround);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != GetComponent<BoxCollider2D>().gameObject)
            {
                isGrounded = true;
            }
        }
    }

    public void Move(float move, bool jump)
    {
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (move > 0.001f && !facingRight)
        {
            Flip();
        }
        else if (move < -0.001f && facingRight)
        {
            Flip();
        }

        if (jump && extraJumpsValue > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumoForce);
            audioManger.Play(jumoSound);
            extraJumpsValue--;
        }
        else if (jump && extraJumpsValue == 0 &&isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumoForce);
            audioManger.Play(jumoSound);
        }

        if (isGrounded)
        {
            extraJumpsValue = extraJumps;
            dashsValue = dashs;
        }
    }
    # endregion

    #region Dashing.
    public void Dash(bool dash)
    {
        if (dashsValue > 0)
        {
            if (dir == 0)
            {
                if (dash)
                {
                    if (Time.time >= nextDashTime)
                    {
                        if (facingRight)
                            dir = 1;
                        else if (!facingRight)
                            dir = 2;

                        nextDashTime = Time.time + 1f / dashRate;
                    }
                }
            }
            else
            {
                if (dashTime <= 0)
                {
                    dashTime = startDashTime;
                    rb.velocity = Vector2.zero;
                    rb.gravityScale = 1f;
                    dashsValue--;
                    dir = 0;
                }
                else
                {
                    dashTime -= Time.deltaTime;
                    rb.gravityScale = 0f;
                    audioManger.Play(dashSound);

                    if (dir == 1)
                        rb.AddForce(Vector2.right * dashSpeed);
                    else if (dir == 2)
                        rb.AddForce(Vector2.left * dashSpeed);
                }
            }
        }
    }
    #endregion

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}