using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] GameObject background;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(backgroundMovementCoroutine());
    }

    IEnumerator backgroundMovementCoroutine(){
        Camera cam = Camera.main;
        float cameraHeight = cam.orthographicSize;
        GameObject sys =  GameObject.FindWithTag("System");
        while (!sys.GetComponent<GameSystem>().getGameOver()) // not game over
        {
            Instantiate(background, new Vector2(0, cameraHeight*3), Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
        Instantiate(background, new Vector2(0, cameraHeight*3), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
