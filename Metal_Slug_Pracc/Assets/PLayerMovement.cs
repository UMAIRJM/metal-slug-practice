using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PLayerMovement : MonoBehaviour
{

    //this whole script is responsible for player movement I am using Unity Input system to get horizontal and vertical inputs and perform actions accordingly.

    public Animator animator;
    public Transform cameraTransform;
    private Rigidbody2D rb;

    public float moveSpeed = 5f;
    public float jumpForce = 6f;
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

    //this function is handling player movemtn right and left
    private void HandleMovement()
    {
        float move = Input.GetAxis("Horizontal");

        
        Vector2 velocity = new Vector2(move * moveSpeed, rb.velocity.y);
        rb.velocity = velocity;
        
        if (move > 0)
        {
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
        }
        else if (move < 0)
        {
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
        }
        if (Mathf.Abs(move) > 0.1f) 
        {
            animator.SetBool("isRunning", true);
        }
        else 
        {
            animator.SetBool("isRunning", false);
        }

    }

    //for handling player jump using space button
    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    //for handling player crouch function
    private void HandleCrouch()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            isCrouching = true;
            transform.localScale = crouchScale;
            
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            isCrouching = false;
            transform.localScale = originalScale;
            
        }
    }


    //this function is responsible for following the camera to player.
    private void FollowPlayerWithCamera()
    {
        Vector3 cameraPosition = cameraTransform.position;
        cameraPosition.x = transform.position.x;
        cameraTransform.position = cameraPosition;
    }


}
