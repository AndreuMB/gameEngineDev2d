using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NetworkController : MonoBehaviour
{
    void Start(){
        // foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        // {
        //     player.GetComponent<Text>().text="";
        // }
    }

    public void startServer(){
        NetworkManager.Singleton.StartServer();
    }
    public void startHost(){
        print("start host");
        NetworkManager.Singleton.StartHost();
    }

    public void startClient(){
        NetworkManager.Singleton.StartClient();
    }

    // public override void OnNetworkSpawn(){
    //     // print("new player");
    //     // if(IsOwner){
    //     //     GameObject.Find("Menu").SetActive(false);
    //     // }

    // }

    void Update(){
        // if (IsServer)
        // {
        //     GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        //     print(players.Length);
        //     print("NetworkManager.Singleton.ConnectedClients = "+NetworkManager.Singleton.ConnectedClients.Count);
        //     int playerNum = NetworkManager.Singleton.ConnectedClients.Count-1;

        //     if (players.Length < 4)
        //     {
        //         GameObject.FindGameObjectsWithTag("Player")[playerNum].GetComponent<Text>().text = "Player "+playerNum;
                
        //     }
        // }
    }

}