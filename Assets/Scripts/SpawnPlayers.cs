using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{

    public GameObject player;
    public float minX, minY, maxX, maxY;

    void Start()
    {
        //Calculating random position
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        //Spawning player in random position, without rotation
        PhotonNetwork.Instantiate(player.name, randomPosition, Quaternion.identity);
    }


}
