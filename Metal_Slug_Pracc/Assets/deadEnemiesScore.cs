using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deadEnemiesScore : MonoBehaviour
{
    // Start is called before the first frame update
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
