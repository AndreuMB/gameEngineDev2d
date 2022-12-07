using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Range(0,1)][SerializeField] float speed;
    SpriteRenderer sprite;
    private float cameraWidth;
    private float cameraHeight;
    private Vector3 lastValidPosition;
    private Rigidbody2D rigidbody2d;
    GameObject[] enemies;
    GameObject spawn;
    int gamemode = 0;
    Spawn spawnScript;

    // Start is called before the first frame update
    void Start()
    {
        // transform

        sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.green;
        
        
        // camera size
        Camera cam = Camera.main;

        cameraHeight = cam.orthographicSize;
        cameraWidth = cameraHeight * cam.aspect;


        rigidbody2d = GetComponent<Rigidbody2D>();

        spawn = GameObject.FindWithTag("Respawn");
        spawnScript = spawn.GetComponent<Spawn>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gamemode==0){
            // Debug.Log(transform.position.ToString());
            // Debug.Log("vector3 "+Vector3.right);
            // Debug.Log("left = "+Input.GetKeyDown("a"));
            // Debug.Log("right = "+Input.GetKeyDown("d"));
            
            // transform.position += Vector3.right*speed;

            // Move wasd

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // Space key change color
            // Space key restore game
            // if (Input.GetKeyDown("space")){
            //     // sprite.color=new Color(Random.Range(0,1f),Random.Range(0,1f),Random.Range(0,1f));
            //     Time.timeScale = 1;
            //     // rigidbody2d
            //     rigidbody2d.bodyType = RigidbodyType2D.Static; 
            //     sprite.color=Color.yellow;
            // }
            
            if (transform.position.x >= cameraWidth 
            || transform.position.y >= cameraHeight
            || transform.position.x <= -cameraWidth
            || transform.position.y <= -cameraHeight){
                transform.position = lastValidPosition;
            }else{
                lastValidPosition = transform.position;
                Vector3 direction = new Vector3(horizontal,vertical,0);
                transform.position += direction * speed;
            }

            // Vector3 aux = transform.position;
            // transform.position = aux + Vector3.forward;
        }else if(gamemode == 1){
            eatEnemies();
        }
        

        // "r" key change gamemode to 1
        if (Input.GetKeyDown("r")){
            gamemode = 1;
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            stopEnemies();
        }

        // "i" key change gamemode to 0
        if (Input.GetKeyDown("i")){
            gamemode = 0;
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            resumeEnemies();
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("YOU LOSE :(");
        sprite.color=Color.red;
        // Time.timeScale = 0;
        // Destroy(gameObject);
        // Debug.Log("RESTART WITH SPACE KEY");
    }

    void stopEnemies(){
        spawnScript.enabled = false;
        spawnScript.CancelInvoke();
        // Debug.Log("ENTER R -> "+enemies);
        foreach (var enemy in enemies){
            Debug.Log("enemy"+enemy);
            enemy.GetComponent<EnemyMovement>().enabled = false;
        }
        sprite.color=Color.white;
    }

    void resumeEnemies(){
        spawnScript.enabled = true;
        spawnScript.startSpawn();
        foreach (var enemy in enemies){
            enemy.GetComponent<EnemyMovement>().enabled = true;
        }
        sprite.color=Color.green;
    }

    void eatEnemies(){
        GameObject enemy = GameObject.FindWithTag("Enemy");
        if (enemy) transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, 0.003f);
    }
}
