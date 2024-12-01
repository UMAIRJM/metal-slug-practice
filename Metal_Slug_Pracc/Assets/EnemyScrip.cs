using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScrip : MonoBehaviour
{
    //this script is attached to enemy responsible for enemy animations enemy shooting and initializing of jump potion etc.
    public Transform mainPlayer;
    public Animator animator;
    public GameObject enemyBullet;
    public GameObject jumpUpPower;


    public float movementSpeed = 2f; 
    public  int EnemyHeath = 4;
    public bool isDEad = false;
    public float bulletSpeed = 8f;
    private bool isFacingRight = true;
    
    public void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(shoot());
    }
    void Update()
    {
        
       
        if (mainPlayer != null && !isDEad)
        {
            Vector2 direction = (mainPlayer.position - transform.position).normalized;

            Vector2 newPosition = Vector2.MoveTowards(transform.position, mainPlayer.position, movementSpeed * Time.deltaTime);

            if(mainPlayer.position.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180f, 0));
                isFacingRight = false;
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0f, 0));
                isFacingRight = true;
            }
            transform.position = newPosition;

        }
        if(EnemyHeath <=0) {
            if(deadEnemiesScore.deadEnemiesCounter == 4)
            {
                Instantiate(jumpUpPower, transform.position, Quaternion.identity);
                PlayerHealthController.jumpPowerPotion = true;

            }
            isDEad = true;
            animator.SetBool("enemyDead", true);
            StartCoroutine(destroyEnemyBody());
        }
        
    }


    
     
    //detroying enemy body if dead in a coroutine
    IEnumerator destroyEnemyBody()
    {
        yield return new WaitForSeconds(1);
        deadEnemiesScore.deadEnemiesCounter++;
        EnemyGenerator.enemyCount--;
        Destroy(gameObject);
    }

    //shooting method of enemy shooting after every three seconds
    IEnumerator shoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(3);
            if (!isDEad) {
                if (isFacingRight)
                {
                    Vector2 position = transform.position;
                    position.x += 0.5f;
                    GameObject bullet = Instantiate(enemyBullet, position, Quaternion.identity);
                    Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                    bulletRb.velocity = new Vector2(bulletSpeed, 0);


                }
                else
                {
                    Vector2 position = transform.position;
                    position.x -= 0.5f;
                    GameObject bullet = Instantiate(enemyBullet, position, Quaternion.identity);
                    Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                    print("I am facing left");
                    bulletRb.velocity = new Vector2(-bulletSpeed, 0);

                    // Move left
                }
            }
             
        }
    }
}

