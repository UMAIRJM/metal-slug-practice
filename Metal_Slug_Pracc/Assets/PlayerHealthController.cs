using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    // Start is called before the first frame update
    public static int playerHealth = 10;
    public Image[] heartImage = new Image[10];
    public Animator animator;

    
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
            animator.SetBool("isPlayerDead",true);
        }
        
    }
}
