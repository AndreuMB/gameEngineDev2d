using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDG : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(horizontal,vertical);
        transform.Translate(direction * speed * Time.deltaTime);

        // Other wall to move
        // Vector3 direction = new Vector3(horizontal,vertical,0);
        // transform.position += direction * speed;
    }
}
