using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BallMovement : MonoBehaviour
{   
    Rigidbody2D rb;
    float thrust = 10f;
    [SerializeField] float addThrust = 5f;
    float timer = 0;
    bool sw = false;
    Vector2 previousPosition;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        rb = GetComponent<Rigidbody2D>();

        Vector2 dir = transform.right; 

        rb.AddForce(dir * thrust, ForceMode2D.Impulse);
        Vector2 previousPosition = transform.position;

    }

    void Update(){
        timer += Time.deltaTime;
        // print("timer math = "+math.floor(timer));
        // print("timer math % = "+math.floor(timer)%2);
        Vector2 currentPosition = transform.position;
        Vector2 dir;
        // float v = (F/ GetComponent<Rigidbody>().mass)*Time.fixedDeltaTime;
        // print("rb.velocity" + rb.velocity.magnitude);
        if (math.floor(timer)%5==0 && rb.velocity.magnitude < 22){
            if (sw == true){
                sw = false;
                dir = (currentPosition-previousPosition).normalized; 
                rb.AddForce(dir * addThrust, ForceMode2D.Impulse);
            }
        }else{
            previousPosition = transform.position;
            sw = true;
        }
    }

    public void setThrust(float thrustSet){
        thrust = thrustSet;
    }
}
