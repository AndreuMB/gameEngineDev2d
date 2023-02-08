using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class ScoreGG : NetworkBehaviour
{
    [SerializeField] float iniScore;
    [SerializeField] float shootNum;
    [SerializeField] GameObject restartBtn;
    NetworkVariable<float> score = new NetworkVariable<float>(
        readPerm: NetworkVariableReadPermission.Everyone,
        writePerm: NetworkVariableWritePermission.Owner);
    float quitScore;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        BallController.shoot.AddListener(calcScore);
        Goal.endGame.AddListener(showText);
        GameOverGG.gameOver.AddListener(showTextGameOver);
        score.Value = iniScore;
        quitScore = iniScore / shootNum;
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
        score.Value = score.Value - quitScore;
        GetComponent<Text>().text = "Final Score " + score.Value;
    }

    void showTextGameOver(){
        print("enbter GameOver");
        GetComponent<Text>().text = "Game Over";
        gameObject.SetActive(true);
        restartBtn.SetActive(true);
    }
}
