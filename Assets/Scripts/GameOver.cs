using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class GameOver : MonoBehaviour
{

    public TMP_Text scoreText;
    public GameObject restartButton;
    public GameObject waitingText;

    PhotonView view;

    void Start()
    {
        view = GetComponent<PhotonView>();

        //Finds object of type "Score", takes value and put it into scoreText
        scoreText.text = FindObjectOfType<Score>().score.ToString();
        
        //If the player is the host show button, otherwise text
        if (PhotonNetwork.IsMasterClient == false)
        {
            restartButton.SetActive(false);
            waitingText.SetActive(true);
        }

    }

    public void ButtonRestart() 
    {
        view.RPC("Restart", RpcTarget.All);
    }

    [PunRPC]
    private void Restart()
    {
        PhotonNetwork.LoadLevel("Game");
    }




}
