using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LifeCount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject life =  GameObject.FindWithTag("Player");
        // GetComponent<Text>().text = life.GetComponent<SimpleControllerX>().getLife().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLife(){
        GameObject player =  GameObject.FindWithTag("Player");
        int life = player.GetComponent<SimpleControllerX>().getLife();
        print("enter life = " + life);
        Sprite[] heartBar = Resources.LoadAll<Sprite>("heartBar");
        Sprite life3 =  heartBar[0];
        Sprite life2 =  heartBar[1];
        Sprite life1 =  heartBar[2];
        Sprite life0 =  heartBar[3];
        switch (life)
        {
            case 0:
                gameObject.GetComponent<Image>().sprite = life0;
            break;
            case 1:
                gameObject.GetComponent<Image>().sprite = life1;
            break;
            case 2:
                gameObject.GetComponent<Image>().sprite = life2;
            break;
            case 3:
                gameObject.GetComponent<Image>().sprite = life3;
            break;            
            default:
                gameObject.GetComponent<Image>().sprite = life3;
            break;
        }
    }
}
