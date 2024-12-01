using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
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
