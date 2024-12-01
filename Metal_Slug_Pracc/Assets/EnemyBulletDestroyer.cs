using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDestroyer : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            print("it is enemy");
        }
        else
        {
            if(collision.gameObject.tag == "player") {

                PlayerHealthController.playerHealth--;
            }

            
            Destroy(gameObject);
        }
    }
}
