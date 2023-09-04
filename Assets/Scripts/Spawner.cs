using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemy;

    public float startOfTimer;
    float timer;



    void Start()
    {
        timer = startOfTimer;
    }

    // Update is called once per frame
    void Update()
    {
        //Cheks if this is the master of the room, or there are less then 2 players, if not skips the update function
        if (PhotonNetwork.IsMasterClient == false || PhotonNetwork.CurrentRoom.PlayerCount != 2)
        {
            return;
        }


        if(timer <= 0)
        {
            //Picks random position from list
            Vector3 spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            //Creates enemy
            PhotonNetwork.Instantiate(enemy.name, spawnPosition, Quaternion.identity);
            //Resets timer
            timer = startOfTimer;
        }
        else
        {
            //Continue timer
            timer -= Time.deltaTime;
        }
    }
}
