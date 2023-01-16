using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBehaviourDG : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    float damage = 1;
    float scoreValue = 10;
    public static UnityEvent addScore = new UnityEvent();
    
    void Start()
    {
        ControllerDG.killAll.AddListener(killAll);
        ControllerDG.kill.AddListener(kill);
    }

    void killAll()
    {
        print("killAll");
        death();
    }

    void kill(){
        print("kill");
    }
    void death(){
        addScore.Invoke();
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other){
        print("enter enemy collision");
        if (other.gameObject.tag == "Attack")
        {
            death();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        // transform.LookAt(target.transform); // only work 3d
        transform.right = target.transform.position - transform.position;

        Vector2 newPosition = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        rigidbody.MovePosition(newPosition);

    }

    public float getDamage(){
        return damage;
    }

    public float getScoreValue(){
        return scoreValue;
    }
}
