using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    // Start is called before the first frame update
    public static int playerHealth = 10;
    public Image[] heartImage = new Image[10];
    public Animator animator;
    public Transform intialPosition;
    public static bool jumpPowerPotion =false;

    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth < 10)
        {
            heartImage[playerHealth].enabled = false;
            
        }
        if(playerHealth <= 0) {
            animator.SetBool("isPlayerDead", true);
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "jumpPotion")
        {
            jumpPowerPotion = true;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "jumpPotion")
        {
            jumpPowerPotion = true;
        }
        Destroy(collision.gameObject);

    }



    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacles")
        {
            print("you are colliding with obstacles");
            playerHealth--;
            transform.position = intialPosition.position;
        }
    }
}
