using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject circle;
    [SerializeField] float spawnTime;
    // Start is called before the first frame update
    void Start(){
        InvokeRepeating("spawnEnemy", 0, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("width = "+Screen.width+"heigth = "+Screen.height);
        // Debug.Log("Screen.width = "+Screen.width);

        if (Input.GetKeyDown("space")){
            spawnEnemy();
        }
    }

    void spawnEnemy(){
        int x = Random.Range(0,Screen.width);
        int y = Random.Range(0,Screen.height);
        Vector3 v = new Vector3(0,0,0);

        if (Random.Range(0,2)==0){
            v = new Vector3(x,0,0);
        }else{
            v = new Vector3(0,y,0);
        }
        Vector2 p = Camera.main.ScreenToWorldPoint(v);
        Instantiate(circle,(Vector3) p, Quaternion.identity);
        // Instantiate(circle,new Vector3(Random.Range(-5f,5f),Random.Range(-5f,5f)),Quaternion.identity);

        // Vector3 direction = new Vector3(0,0,0);
        // transform.position += direction * 2;
    }

    public void startSpawn(){
        InvokeRepeating("spawnEnemy", 0, spawnTime);
    }
}
