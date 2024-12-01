using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deadEnemiesScore : MonoBehaviour
{
    //this script is only contain static variable and is resposible for counting deatdenemies to display player score
    public static int deadEnemiesCounter = 0;
    public Text deadEnemiesText;
    void Start()
    {
        deadEnemiesText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        deadEnemiesText.text = deadEnemiesCounter.ToString();
    }
}
