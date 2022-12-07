using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSpace : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timerCoroutine());
    }

    IEnumerator timerCoroutine(){
        // start
        Text timerText = GetComponent<Text>();
        GameObject sys =  GameObject.FindWithTag("System");
        int i = 0;

        // running
        while (!sys.GetComponent<GameSystem>().getGameOver())
        {
            int minutes = Mathf.FloorToInt(i / 60F);
            int seconds = Mathf.FloorToInt(i % 60F);
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            yield return new WaitForSeconds(1);
            i++;
        }

        // end
        // int scoreP1 = int.Parse(GameObject.FindWithTag("ScoreP1").GetComponent<Text>().text);
        // int scoreP2 = int.Parse(GameObject.FindWithTag("ScoreP2").GetComponent<Text>().text);
        // if (scoreP1>scoreP2){
        //     GameObject.FindWithTag("Winner").GetComponent<Text>().text = "PLAYER 1 WON";
        // }else if(scoreP1<scoreP2){
        //     GameObject.FindWithTag("Winner").GetComponent<Text>().text = "PLAYER 2 WON";
        // }else if(scoreP1==scoreP2){
        //     GameObject.FindWithTag("Winner").GetComponent<Text>().text = "IT'S A TIE";
        // }
        // Time.timeScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
