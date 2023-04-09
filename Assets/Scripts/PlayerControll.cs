using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalMove = 2f;
    private bool facingRight = true;
    public Animator animator;
    [Header("Player Settings")]
    [Range(0,15)]public float speed = 2f;    
    [Range(0,15)]public float jumpforce = 6f;
    [Space]
    [Header("Ground Check Settings")]
    public bool isGrounded = false;
    [Range(-1, 1)] public float checkGroundOffsetY = -0.37f;
    public float CheckGroundRadius = 0.4f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Horizontal", Mathf.Abs(horizontalMove));
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        if (horizontalMove < 0 && facingRight)
        { 
                Flip();
        }
            else if (horizontalMove > 0 && !facingRight)
        {
                Flip();
        }
        if (isGrounded == false)
        {
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }

        
        {
            rb.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
        }
    }
    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(horizontalMove * 2f, rb.velocity.y);
        rb.velocity = targetVelocity;
        CheckGround();  
    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y + checkGroundOffsetY), CheckGroundRadius);
        if (colliders.Length > 1)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

}   
 