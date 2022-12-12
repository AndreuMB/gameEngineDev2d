using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementSI : MonoBehaviour
{
    float speed=0.02f;
    Animator animator;
    bool destroyB = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(enemyMovementCoroutine());
    }

    IEnumerator enemyMovementCoroutine(){
        Camera cam = Camera.main;
        float cameraHeight = cam.orthographicSize;
        while (transform.position.y>-cameraHeight-2 && !destroyB) // enemy in screen
        {
            transform.Translate(0,-speed,0);
            yield return new WaitForSeconds(0.01f);
        }
        if (!destroyB)
        {
            GameObject points =  GameObject.FindWithTag("Score");
            points.GetComponent<PointCount>().removePoint();
            Destroy(gameObject);    
        }
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(Vector3.up * Time.deltaTime);
        // transform.Translate(0,-0.01f,0);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (tag == "Enemy")
        {
            animator.SetBool("Destroyed",true);
            destroyB = true;
            // play audio
            FindObjectOfType<AudioManager>().Play("AsteroidExplosion");
            StartCoroutine(destroyAsteroidCoroutine());
        }
    }

    IEnumerator destroyAsteroidCoroutine(){
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime>1)
        {
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
