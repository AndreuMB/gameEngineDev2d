using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject upgrade;
    [SerializeField] GameObject life;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemyCoroutine());
        StartCoroutine(spawnHelpCoroutine());
    }

    IEnumerator spawnEnemyCoroutine(){
        Camera cam = Camera.main;
        float cameraHeight = cam.orthographicSize;
        float cameraWidth = cameraHeight * cam.aspect;
        float spawnZone;
        Vector2 spawnPoint;

        GameObject sys =  GameObject.FindWithTag("System");
        float faster = 0f;
        float spawnTime = 1f;
        float increase=0;
        enemy.GetComponent<EnemyMovementSI>().setSpeed(1);
        while (!sys.GetComponent<GameSystem>().getGameOver()) // not game over
        {
            spawnZone = Random.Range(-cameraWidth,cameraWidth);
            spawnPoint = new Vector2(spawnZone, cameraHeight+2);

            

            GameObject enemyX = Instantiate(enemy, spawnPoint, Quaternion.identity);
            float speedEnemy = enemyX.GetComponent<EnemyMovementSI>().getSpeed();
            if (speedEnemy < 0.7) increase += 0.001f;
            speedEnemy += increase;
            enemyX.GetComponent<EnemyMovementSI>().setSpeed(speedEnemy);

            if ((spawnTime-faster) > 0.3) faster += 0.01f;
            yield return new WaitForSeconds(spawnTime-faster);
        };
    }

    IEnumerator spawnHelpCoroutine(){
        Camera cam = Camera.main;
        float cameraHeight = cam.orthographicSize;
        float cameraWidth = cameraHeight * cam.aspect;
        float spawnZone;
        Vector2 spawnPoint;
        // GameObject help = GameObject.FindWithTag("Upgrade");
        GameObject help = upgrade;
        GameObject spaceship = GameObject.FindWithTag("Player");

        GameObject sys =  GameObject.FindWithTag("System");
        while (!sys.GetComponent<GameSystem>().getGameOver()) // not game over
        {
            SimpleControllerX spaceshipFunc = spaceship.GetComponent<SimpleControllerX>();
            if (spaceshipFunc.getUpgrade())
            {
                // help = GameObject.FindWithTag("LifeUp");
                help = life;
            }else{
                // spaceshipFunc.setUpgrade(true);
                // help = GameObject.FindWithTag("Upgrade");
                help = upgrade;
            }
            spawnZone = Random.Range(-cameraWidth,cameraWidth);
            spawnPoint = new Vector2(spawnZone, cameraHeight+2);
            Instantiate(help, spawnPoint, Quaternion.identity);
            // yield return new WaitForSeconds(5);
            yield return new WaitForSeconds(Random.Range(7,15));
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
