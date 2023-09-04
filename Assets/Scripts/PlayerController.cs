using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{

    public float speed;
    PhotonView view;

    Health health;

    void Start()
    {
        view = GetComponent<PhotonView>();
        health = FindObjectOfType<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(view.IsMine)
        {
            //Calculating move position
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 moveAmout = moveInput.normalized * speed * Time.deltaTime;

            transform.position += (Vector3)moveAmout;
        }
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("a");
        if (view.IsMine)
        {
            print("b");
            //If collides with enemy, take damage
            if (collision.tag == "Enemy")
            {
                print("c");
                health.TakeDamage();
            }
        }
        
    }


}
