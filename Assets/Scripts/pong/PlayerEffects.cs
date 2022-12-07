using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(shrinkPlayerCoroutine());
    }

    IEnumerator shrinkPlayerCoroutine(){
        print("enter coroutine effects");
        Vector3 scaleChange;
        while (transform.localScale.y>1)
        {
            scaleChange = new Vector3(0, -0.1f, 0);
            transform.localScale += scaleChange;
            yield return new WaitForSeconds(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
