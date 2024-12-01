using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDestroyer : MonoBehaviour
{
    //this code is attached to player bullet detecting collision and performing certain action acooringly.
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            print("it is player");
        }
        else
        {
            if(collision.gameObject.tag == "enemy")
            {
                EnemyScrip es  = collision.gameObject.GetComponent<EnemyScrip>();
                es.EnemyHeath--;
            }
            Destroy(gameObject);
        }
    }
}
