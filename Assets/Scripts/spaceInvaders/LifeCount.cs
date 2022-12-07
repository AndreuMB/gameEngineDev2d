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
        GetComponent<Text>().text = life.GetComponent<SimpleControllerX>().getLife().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
