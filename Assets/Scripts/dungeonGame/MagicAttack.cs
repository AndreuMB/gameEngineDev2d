using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countCoroutine());
    }

    IEnumerator countCoroutine(){
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
