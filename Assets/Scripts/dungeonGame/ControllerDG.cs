using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControllerDG : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float rotationSpeed = 5f;
    public static UnityEvent kill = new UnityEvent();
    public static UnityEvent killAll = new UnityEvent();
    public static UnityEvent setLife = new UnityEvent();
    public static UnityEvent death = new UnityEvent();
    [SerializeField] GameObject magic;
    float life = 3;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // StartCoroutine(specialCoroutine());
    }

    // IEnumerator specialCoroutine(){
    //     while (true)
    //     {
    //         yield return new WaitForSeconds(1);
    //     }
        
    //     yield break;
    // }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(horizontal, vertical);

        if (Input.GetKeyDown("space")){
            // attack
            kill.Invoke();
        }

        if (Input.GetKeyDown("f")){
            // special attack
            killAll.Invoke();
        }

        if (Input.GetKeyDown("g")){
            // magic attack
            Instantiate(magic, transform.GetChild(0).position, transform.rotation);
        }

        // if NOT physics/rigidbody
        //transform.Translate(direction * speed * Time.deltaTime);
        // Other wall to move
        // Vector3 direction = new Vector3(horizontal,vertical,0);
        // transform.position += direction * speed;

    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(horizontal, vertical);
        direction.Normalize();

        // rotate with movement BW
        // if (direction != Vector2.zero)
        // {
        //     // print("direction x = " + direction.x 
        //     // + "direction y = " + direction.y);

        //     if(direction.x>0){
        //         rigidbody.MoveRotation(270); // right
        //     }else if(direction.x<0){
        //         rigidbody.MoveRotation(90); // left
        //     }else if(direction.y>0){
        //         rigidbody.MoveRotation(0); // up
        //     }else if(direction.y<0){
        //         rigidbody.MoveRotation(180); // down
        //     }
        // }

        // rotate with movement GW not idea what is happening
        if (direction != Vector2.zero) {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
            toRotation, rotationSpeed * Time.deltaTime);
        }

        // transform.right = transform.GetChild(0).position - transform.position;
        rb.MovePosition((Vector2) transform.position + direction * speed * Time.deltaTime);

    }

    //no pyshics collision
    // void OnTriggerEnter2D(Collider2D other){
    //     print("enter player collision");
    //     if (other.gameObject.tag == "Enemy")
    //     {
    //         life = life - other.gameObject.GetComponent<EnemyBehaviourDG>().getDamage();
    //         setLife.Invoke();
    //         // if (life <= 0){
    //         //     Destroy(gameObject);
    //         // }
    //     }
    // }

    void OnCollisionEnter2D(Collision2D other){
        print("enter player collision");
        if (other.gameObject.tag == "Enemy")
        {
            life = life - other.gameObject.GetComponent<EnemyBehaviourDG>().getDamage();
            setLife.Invoke();
            if (life <= 0){
                GameObject playerSpawn = GameObject.FindWithTag("PlayerSpawn");
                transform.position = playerSpawn.transform.position;

                life = 3;
                setLife.Invoke();
                death.Invoke();
                transform.rotation = Quaternion.identity;
                // Destroy(gameObject);
                // transform.position
            }
        }
    }

    public float getLife(){
        return life;
    }

}
