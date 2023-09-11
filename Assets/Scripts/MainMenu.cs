using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class MainMenu : MonoBehaviourPunCallbacks
{

    public TMP_InputField createInput;
    public TMP_InputField joinInput;

    public TMP_InputField nickNameNameInput;


    public void ChangeNickname()
    {
        PhotonNetwork.NickName = nickNameNameInput.text;
    }


    public void CreateRoom()
    {
        //Set maximum players to 2
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;

        //Creates the room with options we defined above
        PhotonNetwork.CreateRoom(createInput.text, roomOptions);
    }


    //
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    //Automaticly loads the game scene "Game"
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }


}
