using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LifeCountDG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        setLife();
        ControllerDG.setLife.AddListener(setLife);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setLife(){
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float life = player.GetComponent<ControllerDG>().getLife();
        GetComponent<Text>().text = life.ToString();
    }
}
