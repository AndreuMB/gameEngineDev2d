using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject myObject;
    private Vector3 savedPosition;
    private Vector3 distance;
    [SerializeField][Range(0,10)] private float speed;
    private float cameraWidth;
    private float cameraHeight;
    [SerializeField] bool stalker;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {

        myObject = GameObject.FindWithTag("Player");

        // Vector3 direction = new Vector3(0,0,0);
        // transform.LookAt(direction);
        savedPosition = myObject.transform.position;
        distance = savedPosition - transform.position;
        InvokeRepeating("speedUp", 0, 10);
        
        // camera size
        Camera cam = Camera.main;

        // Debug.Log("cam.orthographicSize = " + cam.orthographicSize);
        // Debug.Log("cam.aspect = " + cam.aspect);

        cameraHeight = cam.orthographicSize;
        cameraWidth = cameraHeight * cam.aspect;

        // Debug.Log("width = " + cameraWidth);
        // Debug.Log("height = " + cameraHeight);

        // agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 direction = transform.position; //new Vector3(0,0,0);
        // transform.Translate(Vector3.up*Time.deltaTime, Space.World);
        // transform.Translate(new Vector3(1,1,0)*Time.deltaTime);
        // Debug.Log("savedPosition = "+ savedPosition);
        // Vector3 p = Camera.main.WorldToScreenPoint(new Vector3 (0,0,0)).normalized;
        // transform.Translate(p*Time.deltaTime);
        // Debug.Log("savedPosition = "+ p);
        // transform.position = savedPosition;
        //  transform.Translate(0.0f, 0.0f, 2 * Time.deltaTime);

        if (!stalker){
            transform.Translate(distance.normalized*Time.deltaTime*speed);
        }else{
            transform.position = Vector3.MoveTowards(transform.position, myObject.transform.position, 0.003f);
        }
        cleanEnemies();
        
    }
    void speedUp(){
        speed+=1;
    }

    void cleanEnemies(){
        if (transform.position.x >= cameraWidth 
        || transform.position.y >= cameraHeight){
            // Destroy(GetComponent<SpriteRenderer>());
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("PLAYER COLLISION");
        Destroy(gameObject);
    }

    // void stopObject(){
    //     GameObject.SetActive(false);
    // }
}
