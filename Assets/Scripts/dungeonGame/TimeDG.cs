using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeDG : MonoBehaviour
{
    int timer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timerCoroutine());
    }

    IEnumerator timerCoroutine(){
        // start
        Text timerText = GetComponent<Text>();
        timer = 0;

        // running
        while (true)
        {
            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer % 60F);
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            yield return new WaitForSeconds(1);
            timer++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
