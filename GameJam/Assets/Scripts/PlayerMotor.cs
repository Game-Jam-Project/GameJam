﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour
{
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

    private bool facingRight = true;
    private bool isGrounded;
    private int extraJumpsValue;
    private int dir;
    private float dashTime;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJumpsValue = extraJumps;
    }

    private void FixedUpdate()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadias, whatIsGround);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != GetComponentInChildren<BoxCollider2D>().gameObject)
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
            extraJumpsValue--;
        }
        else if (jump && extraJumpsValue == 0 &&isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumoForce);
        }

        if (isGrounded)
        {
            extraJumpsValue = extraJumps;
        }
    }

    public void Dash(bool dash)
    {
        if (dir == 0)
        {
            if (dash)
            {
                if (facingRight)
                    dir = 1;
                else if (!facingRight)
                    dir = 2;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
                rb.gravityScale = 1f;
                dir = 0;
            }
            else
            {
                dashTime -= Time.deltaTime;
                rb.gravityScale = 0f;

                if (dir == 1)
                    rb.AddForce(Vector2.right * dashSpeed);
                else if (dir == 2)
                    rb.AddForce(Vector2.left * dashSpeed);
                
            }
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}