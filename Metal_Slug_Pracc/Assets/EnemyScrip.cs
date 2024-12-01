using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScrip : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform mainPlayer; 
    public float movementSpeed = 2f; 
    //public bool stoppingDistance  = false;
    public  int EnemyHeath = 4;
    public bool isDEad = false;
    public Animator animator;
    public GameObject enemyBullet;
    public float bulletSpeed = 8f;
    private bool isFacingRight = true;
    public GameObject jumpUpPower;
    public void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(shoot());
    }
    void Update()
    {
        
        /* float distance = Vector3.Distance(mainPlayer.position, transform.position);
         if (distance < 5f)
         {
             stoppingDistance = true;
         }
         else
         {
             stoppingDistance = false;
         }*/
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


    
     

    IEnumerator destroyEnemyBody()
    {
        yield return new WaitForSeconds(1);
        deadEnemiesScore.deadEnemiesCounter++;

        Destroy(gameObject);
    }

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

