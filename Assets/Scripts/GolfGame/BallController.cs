using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    Transform directionArrow;
    Rigidbody2D rb;
    float thrust;
    bool spaceHold;
    [SerializeField] GameObject thrustUI; 
    Vector3 lastPos;
    bool move;
    public static UnityEvent shoot = new UnityEvent();
    [SerializeField] GameObject thrustBar;
    Animator animator;
    void Start()
    {
        directionArrow = gameObject.transform.GetChild(0);
        rb = GetComponent<Rigidbody2D>();
        directionArrow.gameObject.SetActive(false);
        thrustUI.SetActive(false);
        thrust = 5.0f;
        StartCoroutine(moveCheck());
        animator = thrustBar.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        float horizontal = Input.GetAxis("Horizontal");
        // float vertical = Input.GetAxis("Vertical");
        // directionArrow.gameObject.SetActive(true);
        transform.Rotate(0, 0, -horizontal, Space.World);

        if (!move)
        {
            // thrustUI.SetActive(false);
            directionArrow.gameObject.SetActive(true);
            if (Input.GetKeyDown("space")){
                // impulse
                // thrust = 5.0f;
                thrustUI.SetActive(true);
                animator.SetBool("thrustStart",true);
                spaceHold = true;
                StartCoroutine("thrustStrength");
            }
            if (Input.GetKeyUp("space")){
                animator.SetBool("thrustStart",false);
                spaceHold = false;
                rb.AddForce(transform.right *thrust, ForceMode2D.Impulse);
                shoot.Invoke();
            }
        }else{
            directionArrow.gameObject.SetActive(false);
        }
        // print("spaceHold = " + spaceHold);
        
        lastPos = transform.position;

        



    }

    IEnumerator moveCheck() {
        while (true)
        {
            Vector3 p1 = transform.position;
            yield return new WaitForSeconds(0.5f);
            Vector3 p2 = transform.position;
            
            move = (p1 != p2);
        }
    }

    IEnumerator thrustStrength(){
        thrust = 5.0f;
        float cont = 0;
        bool sw = false;
        while (spaceHold)
        {
            if (cont%5 == 0)
            {
                sw = !sw;
            }

            if (sw)
            {
                thrust+=4;
            }else{
                thrust+=-4;
            }
            // thrustUI.GetComponent<Text>().text = thrust.ToString();
            cont++;
            // print("thrust = " + thrust);
            yield return new WaitForSeconds(0.20f);
        }
        yield break;
    }
}
