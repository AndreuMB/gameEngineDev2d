using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        // GameObject timer = GameObject.FindWithTag("Timer");

        // if (int.Parse(timer.GetComponent<Text>().text.Split(":")[0])>=1){
        //     int scoreP1 = int.Parse(GameObject.FindWithTag("ScoreP1").GetComponent<Text>().text);
        //     int scoreP2 = int.Parse(GameObject.FindWithTag("ScoreP2").GetComponent<Text>().text);
        //     if (scoreP1>scoreP2){
        //         GameObject.FindWithTag("Winner").GetComponent<Text>().text = "PLAYER 1 WON";
        //     }else if(scoreP1<scoreP2){
        //         GameObject.FindWithTag("Winner").GetComponent<Text>().text = "PLAYER 2 WON";
        //     }else if(scoreP1==scoreP2){
        //         GameObject.FindWithTag("Winner").GetComponent<Text>().text = "IT'S A TIE";
        //     }
        //     Time.timeScale = 0;
        // }
    }

    void OnCollisionEnter2D(Collision2D other) {
        GameObject ball = GameObject.FindWithTag("Ball");
        GameObject scoreP1 = GameObject.FindWithTag("ScoreP1");
        GameObject scoreP2 = GameObject.FindWithTag("ScoreP2");
        string lastPScore = "";
        if (ball.transform.position.x>0){
            scoreP1.GetComponent<Text>().text = (int.Parse(scoreP1.GetComponent<Text>().text) + 1).ToString();
            lastPScore = "Player 1";
        }else{
            scoreP2.GetComponent<Text>().text = (int.Parse(scoreP2.GetComponent<Text>().text) + 1).ToString();
            lastPScore = "Player 2";
        }



        if (int.Parse(scoreP1.GetComponent<Text>().text) >= 10 || int.Parse(scoreP2.GetComponent<Text>().text) >= 10)
        {
            Time.timeScale = 0;
            GameObject.FindWithTag("Winner").GetComponent<Text>().text = lastPScore + " WON";
        }
        ball.transform.position = new Vector2(0,0);
        GameObject.FindWithTag("Ball").GetComponent<BallMovement>().setThrust(10f);
    }
}
