using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControllerDG : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    public static UnityEvent kill = new UnityEvent();
    public static UnityEvent killAll = new UnityEvent();
    [SerializeField] GameObject magic;

    // Start is called before the first frame update
    void Start()
    {
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
        Rigidbody2D rigidboy = GetComponent<Rigidbody2D>();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(horizontal, vertical);

        if (direction != Vector2.zero)
        {
            // print("direction x = " + direction.x 
            // + "direction y = " + direction.y);

            if(direction.x>0){
                rigidboy.MoveRotation(270);
            }else if(direction.x<0){
                rigidboy.MoveRotation(90);
            }else if(direction.y>0){
                rigidboy.MoveRotation(0);
            }else if(direction.y<0){
                rigidboy.MoveRotation(180);
            }
        }
        
        // if rigidbody
        rigidboy.MovePosition((Vector2) transform.position + direction * speed * Time.deltaTime);

    }

}
