using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
{

    //this script is handling player shooting with mouse left click and also managing fires in multiple directions.
    public GameObject bulletPrefab; 
    public Transform bulletSpawnPoint;
    public GameObject player;
    public Animator playerAnimator;

    public float bulletSpeed = 8f;
    private bool isFacingRight = true;  

  

    public void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
    }

    void Update()
    {
  
        if (Input.GetMouseButtonDown(0))  
        {
            playerAnimator.SetBool("isAttacking", true);
            print("I a firing the bullets");
            Invoke("FireBullet", 0.4f);
            
            Invoke("StopAttackAnimation", 0.5f);
        }
       
       
        
        if (Input.GetAxis("Horizontal") > 0 ) 
        {
            isFacingRight = true;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            isFacingRight = false;
        }
        print("Facing right" + isFacingRight);
    }

    //player shooting function 
    void FireBullet()
    {
       
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
