using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    void Start()
    {
        directionArrow = gameObject.transform.GetChild(0);
        rb = GetComponent<Rigidbody2D>();
        directionArrow.gameObject.SetActive(false);
        thrustUI.SetActive(false);
        thrust = 5.0f;
        StartCoroutine(moveCheck());
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
            thrustUI.SetActive(false);
            directionArrow.gameObject.SetActive(true);
        }else{
            directionArrow.gameObject.SetActive(false);
            thrustUI.SetActive(true);
        }
        
        lastPos = transform.position;

        if (Input.GetKeyDown("space")){
            // impulse
            // thrust = 5.0f;
            spaceHold = true;
            thrustUI.SetActive(true);
            StartCoroutine(thrustStrength());
        }
        if (Input.GetKeyUp("space")){
            spaceHold = false;
            print("thrustEnd = " + thrust);
            rb.AddForce(transform.right *thrust, ForceMode2D.Impulse);
            print("transform.up = "+ transform.up);
        }



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
                thrust++;
            }else{
                thrust--;
            }
            print("thrust = " + thrust);
            thrustUI.GetComponent<Text>().text = thrust.ToString();;
            cont++;
            yield return new WaitForSeconds(1);
        }
        yield break;
    }
}
