using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    // int gamePoints = 0;
    bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public int getGamePoints(){
    //     return gamePoints;
    // }

    // public void setGamePoints(int points){
    //     gamePoints = points;
    // }

    public bool getGameOver(){
        return gameOver;
    }

    public void setGameOver(bool over){
        gameOver = over;
        if (over)
        {
            // GameObject points =  GameObject.FindWithTag("Score");
            // int gamePoints = points.GetComponent<PointCount>().getPoints();
            // GameObject.FindWithTag("Finish").GetComponent<Text>().text = "GAME OVER " + gamePoints;
            GameObject.FindWithTag("Finish").GetComponent<Text>().text = "GAME OVER :("; 
        }
    }
}
