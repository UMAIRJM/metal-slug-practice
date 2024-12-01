using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] point  = new Transform[9];
    public GameObject enemy;

    void Start()
    {
        StartCoroutine(IntantiateAnEnemy());

    }

    // Update is called once per frame
    

    IEnumerator  IntantiateAnEnemy()
    {
        yield return new WaitForSeconds(7);
        int random = Random.Range(0, 8);
        Instantiate(enemy, point[random].position, Quaternion.identity);
        StartCoroutine(IntantiateAnEnemy());

    }
}
