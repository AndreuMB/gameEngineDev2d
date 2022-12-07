using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCount : MonoBehaviour
{
    int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countPointsCoroutine());
    }

    IEnumerator countPointsCoroutine(){
        GameObject sys =  GameObject.FindWithTag("System");
        while (!sys.GetComponent<GameSystem>().getGameOver()) // not game over
        {
            points++;
            GetComponent<Text>().text = points.ToString();
            yield return new WaitForSeconds(1);
        }
        // sys.GetComponent<GameSystem>().setGamePoints(points);
    }

    public int getPoints(){
        return points;
    }

    public void removePoint(){
        points = points -2;
    }

    public void addPoint(){
        points = points +1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
