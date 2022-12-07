using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(countDown());
    }

    IEnumerator countDown(){
        GameObject countDown = GameObject.FindWithTag("CountDown");
        for (int i = 0; i < 3; i++)
        {
            countDown.GetComponent<Text>().text = "Game start in " + (3-i);
            yield return new WaitForSecondsRealtime(1);
        }
        countDown.GetComponent<Text>().text = "";
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
