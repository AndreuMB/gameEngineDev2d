using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesDG : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnCoroutine());
    }

    IEnumerator spawnCoroutine(){
        print("enter coroutine");
        while (true)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            print("enter while coroutine");
            if (enemies.Length < 3)
            {
                print("enter while if coroutine");
                Instantiate(enemyPrefab, new Vector2(0,0), Quaternion.identity);
            }
            yield return new WaitForSeconds(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // while spawning follow calling coroutine
        // enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // if (enemies.Length < 3)
        // {
        //     StartCoroutine(spawnCoroutine());
        // }
    }
}
