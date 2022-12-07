using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Text timerText; 
    // bool playing;
    // float ftimer;
    [SerializeField] int maxTime = 60;
    // Start is called before the first frame update
    void Start()
    {
        // timerText = GetComponent<Text>();
        StartCoroutine(timerCoroutine());
    }

    // coroutine
    IEnumerator timerCoroutine(){
        // start
        Text timerText = GetComponent<Text>();

        // running
        for (int i = maxTime; i >= 0; i--)
        {
            int minutes = Mathf.FloorToInt(i / 60F);
            int seconds = Mathf.FloorToInt(i % 60F);
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            yield return new WaitForSeconds(1);
        }

        // end
        int scoreP1 = int.Parse(GameObject.FindWithTag("ScoreP1").GetComponent<Text>().text);
        int scoreP2 = int.Parse(GameObject.FindWithTag("ScoreP2").GetComponent<Text>().text);
        if (scoreP1>scoreP2){
            GameObject.FindWithTag("Winner").GetComponent<Text>().text = "PLAYER 1 WON";
        }else if(scoreP1<scoreP2){
            GameObject.FindWithTag("Winner").GetComponent<Text>().text = "PLAYER 2 WON";
        }else if(scoreP1==scoreP2){
            GameObject.FindWithTag("Winner").GetComponent<Text>().text = "IT'S A TIE";
        }
        Time.timeScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        // ftimer += Time.deltaTime;
        // int minutes = Mathf.FloorToInt(ftimer / 60F);
        // int seconds = Mathf.FloorToInt(ftimer % 60F);
        // timerText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00");
    }
}
