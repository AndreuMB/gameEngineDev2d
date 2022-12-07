using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(backgroundMovementCoroutine());
    }

    IEnumerator backgroundMovementCoroutine(){
        Camera cam = Camera.main;
        float cameraHeight = cam.orthographicSize;
        GameObject sys =  GameObject.FindWithTag("System");
        if (!sys.GetComponent<GameSystem>().getGameOver())
        {
            while (transform.position.y>-cameraHeight*3) // backgrund in screen * 3
            {
                transform.Translate(0,-speed,0);
                yield return new WaitForSeconds(0.01f);
            } 
            Destroy(gameObject);
        }else{
            while (transform.position.y>=0.3) // backgrund stop
            {
                transform.Translate(0,-speed,0);
                yield return new WaitForSeconds(0.01f);
            } 
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
