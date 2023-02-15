using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] GameObject playerTag;

    // Start is called before the first frame update
    void Start()
    {
         foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
         {
            player.SetActive(false);
         }
    }

    public override void OnNetworkSpawn(){
        print("new player");
        // Instantiate(playerTag);
        GameObject.FindGameObjectsWithTag("Player")[0].SetActive(true);
        if (GameObject.FindGameObjectsWithTag("Player")[0].activeInHierarchy)
        {
            GameObject.FindGameObjectsWithTag("Player")[1].SetActive(true);
        }else{
            GameObject.FindGameObjectsWithTag("Player")[0].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
