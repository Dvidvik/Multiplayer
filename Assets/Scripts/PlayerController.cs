using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{

    public float speed;
    PhotonView view;

    Health health;

    LineRenderer rend;

    void Start()
    {
        view = GetComponent<PhotonView>();
        health = FindObjectOfType<Health>();
        rend = FindObjectOfType<LineRenderer>();
    }

    void Update()
    {
        //Is Local player
        if(view.IsMine)
        {
            //Calculating move position
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 moveAmout = moveInput.normalized * speed * Time.deltaTime;

            transform.position += (Vector3)moveAmout;


            //Start of the laser
            rend.SetPosition(0, transform.position);
        }
        else
        {
            //End of laser
            rend.SetPosition(1, transform.position);
        }
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (view.IsMine)
        {
            //If collides with enemy, take damage
            if (collision.tag == "Enemy")
            {
                health.TakeDamage();
            }
        }
        
    }


}
