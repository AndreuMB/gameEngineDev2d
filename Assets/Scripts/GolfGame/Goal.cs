using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Unity.Netcode;

public class Goal : NetworkBehaviour
{
    public static UnityEvent endGame = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Ball")
        {
            Time.timeScale = 0;
            endGame.Invoke();
        }
    }

}
