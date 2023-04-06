using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool playerIsAlive;
    public float jumpForce;
    public SoundManager SoundManager;

    private bool grounded;
    private bool ducking;
    private bool jumping;
    private float originalColliderHeight;
    private float originalGravityScale;
    private Animator animator;
    private Rigidbody2D myBody;
    private BoxCollider2D boxCollider;


    private void Start()
    {
        playerIsAlive = true;   
        grounded = true;
        jumping = false;
        ducking = false;
        myBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        originalColliderHeight = boxCollider.size.y;
        originalGravityScale = myBody.gravityScale;
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            SoundManager.PlayDeathSound();
            playerIsAlive = false;
        }
        if(collision.CompareTag("Ground"))
        {
            grounded = true;
            jumping = false;
        }
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && grounded && !ducking) {
            jumping = true;
            grounded = false;
            SoundManager.PlayJumpSound();
        }
        ducking = Input.GetKey(KeyCode.DownArrow);
        UpdateAnimations();   
    }

    private void FixedUpdate() {
        if (jumping) {
            Jump();
        }
        if (ducking && !grounded) {
            Fall();
        }
        if(ducking && grounded){
            Duck();
        }
        if(!ducking && grounded){
            Normal();
        }
        if(!playerIsAlive){
            Dead();
        }
    }


    private void Jump()
    {
       
        myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        jumping = false;
    }

    private void Fall()
    {
        myBody.AddForce(new Vector2(0f, -(jumpForce / 3)), ForceMode2D.Impulse);
        jumping = false;
    }
    private void Duck()
    {  
        boxCollider.size = new Vector2(boxCollider.size.x, originalColliderHeight / 2f);
        myBody.gravityScale = originalGravityScale*10;
    }
    private void Normal()
    {  
        boxCollider.size = new Vector2(boxCollider.size.x, originalColliderHeight);
        myBody.gravityScale = originalGravityScale;
    }

    private void Dead()
    {  
        //Death impl...
    }

    private void UpdateAnimations()
    {
        animator.SetBool("IsJump", !grounded && jumping);
        animator.SetBool("IsRun", grounded && playerIsAlive && !ducking);
        animator.SetBool("IsDuck",grounded && ducking);
        animator.SetBool("IsDead", !playerIsAlive);
    }
}   
