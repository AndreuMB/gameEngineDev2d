using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkController : NetworkBehaviour
{

    public void startServer(){
        NetworkManager.Singleton.StartServer();
    }
    public void startHost(){
        NetworkManager.Singleton.StartHost();
    }

    public void startClient(){
        NetworkManager.Singleton.StartClient();
    }

}