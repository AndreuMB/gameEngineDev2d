using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleController : MonoBehaviour
{
    [Range(0,1)][SerializeField] float speed;
    SpriteRenderer sprite;
    private float cameraWidth;
    private float cameraHeight;
    private Vector3 lastValidPosition;
    private Rigidbody2D rigidbody2d;
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
    }

    // Update is called once per frame
    void Update()
    {

        // float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Space key change color
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
            Vector3 direction = new Vector3(0,vertical,0);
            transform.position += direction * speed;
        }
    }

    // void OnCollisionEnter2D(Collision2D other) {
    //     Time.timeScale = 0;
    //     Debug.Log("YOU LOSE :(");
    //     sprite.color=Color.red;
    //     // Destroy(gameObject);
    //     Debug.Log("RESTART WITH SPACE KEY");
    // }

}
