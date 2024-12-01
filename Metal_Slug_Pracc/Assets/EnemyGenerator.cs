using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyGenerator : MonoBehaviour
{
    //this script is generating enemies from 9 fixed point each point is picked randomly and enemy is generated on picked poit 
    public Transform[] point  = new Transform[9];
    public GameObject enemy;
    public static int enemyCount = 0;

    void Start()
    {
        StartCoroutine(IntantiateAnEnemy());

    }

    // Update is called once per frame
    

    IEnumerator  IntantiateAnEnemy()
    {
        while (true)
        {
            if (enemyCount <= 7)
            {
                yield return new WaitForSeconds(7);
                int random = Random.Range(0, 8);
                Instantiate(enemy, point[random].position, Quaternion.identity);
                //StartCoroutine(IntantiateAnEnemy());
                enemyCount++;
            }
        }
        

    }
}
