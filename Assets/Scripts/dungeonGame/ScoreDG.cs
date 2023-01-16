using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDG : MonoBehaviour
{
    float score = 0;
    // Start is called before the first frame update
    void Start()
    {
        EnemyBehaviourDG.addScore.AddListener(setScore);
        ControllerDG.death.AddListener(resetScore);
    }

    // Update is called once per frame
    void setScore(){
        score+=10; // static
        GetComponent<Text>().text = score.ToString();
    }

    void resetScore(){
        score = 0;
        GetComponent<Text>().text = score.ToString();
    }
}
