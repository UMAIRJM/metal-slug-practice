using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PLayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 6f;
    public Animator animator;
    public Transform cameraTransform;
    private Rigidbody2D rb;
    private bool isCrouching = false;
    private Vector3 originalScale;
    private Vector3 crouchScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
        crouchScale = new Vector3(originalScale.x, originalScale.y - 1, originalScale.z);

    }
    void Update()
    {
        if (PlayerHealthController.jumpPowerPotion)
        {
            jumpForce = 11f;
        }
        HandleMovement();
        HandleJump();
        HandleCrouch();
        FollowPlayerWithCamera();
    }
    private void HandleMovement()
    {
        float move = Input.GetAxis("Horizontal");

        // Apply movement
        Vector2 velocity = new Vector2(move * moveSpeed, rb.velocity.y);
        rb.velocity = velocity;
        //rotating player left or right based on the horizontal input
        if (move > 0)
        {
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
        }
        else if (move < 0)
        {
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
        }
        if (Mathf.Abs(move) > 0.1f) // If the player is moving
        {
            animator.SetBool("isRunning", true);
        }
        else // If the player is not movingx
        {
            animator.SetBool("isRunning", false);
        }

    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void HandleCrouch()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            isCrouching = true;
            transform.localScale = crouchScale;
            // animator.SetBool("IsCrouching", true);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            isCrouching = false;
            transform.localScale = originalScale;
            // animator.SetBool("IsCrouching", false);
        }
    }
    private void FollowPlayerWithCamera()
    {
        Vector3 cameraPosition = cameraTransform.position;
        cameraPosition.x = transform.position.x;
        cameraTransform.position = cameraPosition;
    }


}
