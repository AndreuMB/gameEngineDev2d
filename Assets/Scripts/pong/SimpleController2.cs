using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleController2 : MonoBehaviour
{
    GameObject ball;
    // Start is called before the first frame update
    void Start(){
        ball = GameObject.FindWithTag("Ball");
    }

    // Update is called once per frame
    void Update(){
        transform.position = new Vector3(transform.position.x, ball.transform.position.y, transform.position.z);
    }


}
