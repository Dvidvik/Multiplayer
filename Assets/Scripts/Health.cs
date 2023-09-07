using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class Health : MonoBehaviour
{
    public int health = 10;
    public TMP_Text healthText; 

    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    //Decreaces health
    public void TakeDamage()
    {
        view.RPC("TakeDamageRPC", RpcTarget.All);
    }


    //This function is synchronized
    [PunRPC]
    public void TakeDamageRPC()
    {
        health--;
        //Update UI
        healthText.text = health.ToString();
    }

}
