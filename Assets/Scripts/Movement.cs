using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;

    public float speed;
    public float runningSpeed;
    public float horizontalValue;
    public float jumpForce;
    public float jumpMultiplier;
    public float xVal;
    public float moveInput;

    public bool facingRight = true;
    //public bool isGrounded;
    public bool isRunning;
    public bool can;

    public Transform groundCheck;
    public LayerMask groundLayer;


    
    private BoxCollider2D boxCollider2d;
    private Animator anim;
    
    Rigidbody2D rb;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (CanMove() == false)
        {
            horizontalValue = 0f;
            return;
        }
        else if (CanMove() == true)
        {
            horizontalValue = Input.GetAxisRaw("Horizontal");
            anim.SetBool("isWalking", false);
            anim.SetBool("isJumping", false);

            //Jump
            jumpMultiplier = 1.0f;
            jumpForce = 40f * jumpMultiplier;
                
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (GroundChecker.isGrounded)
                {
                    Jump();
                    
                }
                
            }   
            
            //Walk
            if (horizontalValue != 0 && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
                isRunning = false;
                anim.SetBool("isWalking", true);
                anim.SetBool("isRunning", false);
            }

            //Sprint
            if (horizontalValue != 0 && Input.GetKey(KeyCode.LeftShift))
            {
                runningSpeed = speed * 2f;
                Sprint();
                if (xVal == 0)
                    isRunning = false;
                anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", true);
            }
            else


            //Attack
            if (Input.GetKeyDown(KeyCode.E))
            {
                AttackTest();
                can = false;
                //anim.SetBool("isAttacking", false);
            }

        }

    }
    

    bool CanMove()
    {

        can = true;
        return can;
    }

    void FixedUpdate()
    {
        Move(horizontalValue);
        GroundChecker.isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); 
    }

    void Move(float dir)
    {
        if(!isRunning)
        {
            xVal = dir * speed;
        }
        else
        {
            xVal = dir * runningSpeed;
        }
        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        rb.velocity = targetVelocity;

        //Store Current Scale Value
        Vector3 currentScale = transform.localScale;

        //Flip Left
        if (facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }

        //Flip Right
        else if (!facingRight && dir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }

    }

    void Walk()
    {
        //Debug.Log(horizontalValue);
        rb.velocity = new Vector2(horizontalValue * speed, rb.velocity.y);
    }
    
    void Sprint()
    {
        isRunning = true;
        //animatorzxc.SetBool("isFastasFuckBoi", true);
        rb.velocity = new Vector2(horizontalValue * runningSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        anim.SetTrigger("pressedJump");
        anim.SetBool("isJumping", true);
    }

    void AttackTest()
    {
        anim.SetTrigger("pressedAttack");
        anim.SetBool("isAttacking", true);
    }
}

