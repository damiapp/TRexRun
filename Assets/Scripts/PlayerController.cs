using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool playerIsAlive;
    public float jumpHeight;
    public float jumpDuration;
    public float jumpDelay;
    public float fallMultiplier;
    public float duckHight;

    private float originalColliderHeight;
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    private Animator animator;
    private bool grounded;
    private bool isJumping = false;
    private float jumpStartTime = 0f;
    private Vector2 jumpStartPosition;

    private void Start()
    {
        grounded = true;
        playerIsAlive = true;
        boxCollider = GetComponent<BoxCollider2D>();
        originalColliderHeight = boxCollider.size.y;
        rigidbody = GetComponent<Rigidbody2D>();    
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            animator.SetBool("IsDead", true);
            playerIsAlive = false;
        }
        else if (collision.CompareTag("Ground"))
        {
            animator.SetBool("IsJump", false);
            grounded = true;
        }
    }

    private void Update()
    {
        Jump();
        if (Input.GetKeyDown(KeyCode.DownArrow))
            Duck();
        else if (Input.GetKeyUp(KeyCode.DownArrow)) 
        { 
            animator.SetBool("IsDuck", false);
            boxCollider.size = new Vector2(boxCollider.size.x, originalColliderHeight);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isJumping)
        {
            isJumping = true;
            jumpStartTime = Time.time + jumpDelay;
            jumpStartPosition = transform.position;
        }

        if (isJumping)
        {
            animator.SetBool("IsJump", true);
            float jumpProgress = (Time.time - jumpStartTime) / jumpDuration;

            if (jumpProgress < 1f)
            {
                float jumpHeightProgress = Mathf.Sin(jumpProgress * Mathf.PI);
                Vector2 jumpVector = new Vector2(0f, jumpHeight * jumpHeightProgress);

                if (Input.GetKey(KeyCode.DownArrow) && jumpVector.y < 0f)
                {
                    jumpVector *= fallMultiplier;
                }

                rigidbody.MovePosition(jumpStartPosition + jumpVector);
            }
            else
            {
                isJumping = false;
                animator.SetBool("IsJump", false);
            }
        }
    }
    private void Duck()
    {
        if (!isJumping)
        {
            boxCollider.size = new Vector2(boxCollider.size.x, originalColliderHeight / 2f);

            transform.Translate(Vector2.down*duckHight);
            animator.SetBool("IsDuck", true);
        }
    }
}
