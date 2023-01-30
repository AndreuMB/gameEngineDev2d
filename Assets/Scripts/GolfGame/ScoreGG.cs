using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGG : MonoBehaviour
{
    [SerializeField] float iniScore;
    [SerializeField] float shootNum;
    [SerializeField] GameObject restartBtn;
    float quitScore;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        quitScore = iniScore / shootNum;
        BallController.shoot.AddListener(calcScore);
        Goal.endGame.AddListener(showText);
        GameOverGG.gameOver.AddListener(showTextGameOver);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void showText(){
        gameObject.SetActive(true);
        restartBtn.SetActive(true);
    }
    
    void calcScore(){
        iniScore = iniScore - quitScore;
        GetComponent<Text>().text = "Final Score " + iniScore;
    }

    void showTextGameOver(){
        print("enbter GameOver");
        GetComponent<Text>().text = "Game Over";
        gameObject.SetActive(true);
        restartBtn.SetActive(true);
    }
}
