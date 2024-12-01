using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDestroyer : MonoBehaviour
{
    //just like player bullet destroyerer this is enemy bullet destroyer.
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == gameObject.name)
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
