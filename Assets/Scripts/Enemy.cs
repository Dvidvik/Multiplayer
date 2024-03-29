using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Enemy : MonoBehaviour
{
    PlayerController[] players;
    PlayerController nearestPlayer;
    Score score;
    public float speed;

    void Start()
    {
        //Gets list of all players
        players = FindObjectsOfType < PlayerController>();
        score = FindObjectOfType< Score>();
    }

    private void Update()
    {
        //Calculating distance
        float distanceOne = Vector2.Distance(transform.position, players[0].transform.position);
        float distanceTwo = Vector2.Distance(transform.position, players[1].transform.position);

        //Setting current target
        if (distanceOne < distanceTwo)
        {
            nearestPlayer = players[0];
        }
        else
        {
            nearestPlayer = players[1];
        }

        //Move towards target
        if(nearestPlayer != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, nearestPlayer.transform.position, speed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(PhotonNetwork.IsMasterClient)
        {
            if (collision.tag == "Laser")
            {
                PhotonNetwork.Destroy(this.gameObject);
                score.ScoreIncrease();
            }
        }
        
    }



}
