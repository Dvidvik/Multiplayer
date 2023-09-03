using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    void Start()
    {
        //Connects to server
        PhotonNetwork.ConnectUsingSettings();
    }

    //After connected to server start this
    public override void OnConnectedToMaster()
    {
        // Loads Main Menu
        SceneManager.LoadScene("MainMenu");
    }

}
