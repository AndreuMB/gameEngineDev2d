using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Unity.Netcode;
using UnityEngine.UI;
public class Player : NetworkBehaviour
{
    NetworkVariable<bool> ready = new NetworkVariable<bool>(
        value: false, writePerm: NetworkVariableWritePermission.Owner);
    public override void OnNetworkSpawn()
    {
        // spawnPlayer.Invoke();
        // GameObject.Find("MenuManager");
        FindObjectOfType<MenuManager>().addPlayerTag();


        if (IsOwner)
        {
            GameObject.Find("ReadyBtn").GetComponent<Button>().onClick.AddListener(setReady);
        }
        ready.OnValueChanged += tagUpdate;
    }

    void setReady(){
        ready.Value = !ready.Value;
    }
// [void,bool,bool]
    void tagUpdate(bool oldValue, bool newValue){
        // call function menuManager
    }





}
