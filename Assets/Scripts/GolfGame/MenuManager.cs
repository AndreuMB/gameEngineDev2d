using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject lobby;
    GameObject menu;
    // [SerializeField] GameObject playerTag;
    void Start(){
        menu = GameObject.Find("Menu");
        lobby.SetActive(false);
        // Player.spawnPlayer.AddListener(addPlayerTag);
    }

    public void addPlayerTag(){
        menu.SetActive(false);
        lobby.SetActive(true);
        // lobby.SetActive(true);
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("PlayerTag"))
        {
            player.GetComponent<Text>().text="Waiting...";
        }
        // int numberPlayers = NetworkManager.Singleton.ConnectedClients.Count;
        int numberPlayers = GameObject.FindGameObjectsWithTag("PlayerUI").Length;
        GameObject.Find("PlayerNumber").GetComponent<Text>().text = "Players: " + numberPlayers;

        GameObject[] players = GameObject.FindGameObjectsWithTag("PlayerTag");
        int playerNum = numberPlayers-1;
        print("players.Length = " + players.Length);

        if (players.Length <= 4)
        {
            print("enter playerNum = " + playerNum);
            players[playerNum].GetComponent<Text>().text = "Player "+playerNum;
        }
    }

    // public override void OnNetworkSpawn(){
    //     print("new player" + IsServer);
    //     menu.SetActive(false);
    //     if(IsServer){
    //         lobby.SetActive(true);
    //         print("enter is owner");
    //         print("enter is owner2 = " + menu.activeInHierarchy);
    //         // lobby.SetActive(true);
    //         foreach (GameObject player in GameObject.FindGameObjectsWithTag("PlayerTag"))
    //         {
    //             player.GetComponent<Text>().text="Waiting...";
    //         }
    //         int numberPlayers = NetworkManager.Singleton.ConnectedClients.Count;
    //         GameObject.Find("PlayerNumber").GetComponent<Text>().text = "Players: " + numberPlayers;

    //         GameObject[] players = GameObject.FindGameObjectsWithTag("PlayerTag");
    //         int playerNum = numberPlayers-1;
    //         print("players.Length = " + players.Length);

    //         if (players.Length <= 4)
    //         {
    //             print("enter playerNum = " + playerNum);
    //             players[playerNum].GetComponent<Text>().text = "Player "+playerNum;
    //         }
    //     }

    // }

    void Update()
    {

    }

}