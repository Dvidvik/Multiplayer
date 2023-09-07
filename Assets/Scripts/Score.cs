using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class Score : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;

    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    //Decreaces health
    public void ScoreIncrease()
    {
        view.RPC("ScoreIncreaseRPC", RpcTarget.All);
    }


    //This function is synchronized
    [PunRPC]
    public void ScoreIncreaseRPC()
    {
        score++;
        //Update UI
        scoreText.text = score.ToString();
    }


}
