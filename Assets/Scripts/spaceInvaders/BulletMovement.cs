using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    float speed=0.1f;
    int level = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        bool upgrade = player.GetComponent<SimpleControllerX>().getUpgrade();
        if (upgrade) setLevel1();
        StartCoroutine(bulletMovementCoroutine());
    }

    IEnumerator bulletMovementCoroutine(){
        Camera cam = Camera.main;
        float cameraHeight = cam.orthographicSize;
        while (transform.position.y<cameraHeight+2) // bullet in screen
        {
            transform.Translate(0,speed,0);
            yield return new WaitForSeconds(0.01f);
        }
        if (level < 1)
        {
            GameObject points =  GameObject.FindWithTag("Score");
            points.GetComponent<PointCount>().removePoint();
        }
        Destroy(gameObject);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject.FindWithTag("Score").GetComponent<PointCount>().addPoint();
            if (level < 1)
            {
                Destroy(gameObject);
            }
        }
    }

    public void setLevel1(){
        print("enter set level1");
        level = 1;
        GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Bullet2C") as RuntimeAnimatorController;
    }
}
