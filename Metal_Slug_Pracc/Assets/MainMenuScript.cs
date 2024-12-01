using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
    
{
    //my main menu script only contain label which will show if player completed the game
    public Text GameLabel;

    public void Start()
    {
        GameLabel.text = "";
    }

    //checking whether player has won the game or not
    public void Update()
    {
        if (PlayerHealthController.GameWon)
        {
            GameLabel.text = "Game Completed";
        }
        else
        {
            GameLabel.text = "";
        }
    }
    //loading game scene
    public void loadGameScene()
    {
        GameLabel.text = "";
        SceneManager.LoadScene("SampleScene");
    }

    
}
