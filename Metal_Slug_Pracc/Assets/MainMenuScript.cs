using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
    
{
    public Text GameLabel;

    public void Start()
    {
        GameLabel.text = "";
    }

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
    public void loadGameScene()
    {
        GameLabel.text = "";
        SceneManager.LoadScene("SampleScene");
    }

    
}
