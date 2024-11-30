using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
{
    public GameObject bulletPrefab;  // Reference to the bullet prefab
    public Transform bulletSpawnPoint;  // Point from where bullet will be instantiated
    public float bulletSpeed = 8f;
    // Bullet speed
    public GameObject player;
    public Animator playerAnimator;
    private bool isFacingRight = true;  // To track which direction player is facing

  

    public void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        // Check for input (e.g., mouse click or a specific key)
        if (Input.GetMouseButtonDown(0))  // Example: Left mouse button click
        {
            playerAnimator.SetBool("isAttacking", true);
            print("I a firing the bullets");
            Invoke("FireBullet", 0.4f);
            //FireBullet();
            Invoke("StopAttackAnimation", 0.5f);
        }
       
       
        // Update the player facing direction (example: based on input or animation)
        if (Input.GetAxis("Horizontal") > 0 ) // You can adjust this as per your input system
        {
            isFacingRight = true;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            isFacingRight = false;
        }
        print("Facing right" + isFacingRight);
    }

    void FireBullet()
    {
        // Instantiate the bullet at the player's position
       // GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // Get the bullet's Rigidbody2D component to apply movement
      //  Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        // Set the bullet's movement direction based on the player's facing direction
        if (isFacingRight)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = new Vector2(bulletSpeed, 0);
           

        }
        else
        {
            Vector2 position  = bulletSpawnPoint.position;
            position.x -= 0.5f;
            GameObject bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            print("I am facing left");
            bulletRb.velocity = new Vector2(-bulletSpeed, 0);
           
            // Move left
        }
    }
    void StopAttackAnimation()
    {
        playerAnimator.SetBool("isAttacking", false);
    }


}
