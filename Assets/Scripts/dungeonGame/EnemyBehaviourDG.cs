using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourDG : MonoBehaviour
{
void Start()
    {
        // Me suscribo con la función CambiaColor()
        ControllerDG.killAll.AddListener(killAll);
        ControllerDG.kill.AddListener(kill);
    }

    void killAll()
    {
        print("killAll");
        Destroy(gameObject);
    }

    void kill(){
        print("kill");
    }

    void OnCollisionEnter2D(Collision2D other){
        print("enter enemy collision");
        if (other.gameObject.tag == "Attack")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
