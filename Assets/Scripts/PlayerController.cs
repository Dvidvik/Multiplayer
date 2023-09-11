using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public float speed;
    float resetSpeed;
    public float dashSpeed;
    public float dashTime;

    public float minX, minY, maxX, maxY;

    public TMP_Text nameText;

    PhotonView view;
    Health health;
    LineRenderer rend;

    void Start()
    {
        resetSpeed = speed;
        view = GetComponent<PhotonView>();
        health = FindObjectOfType<Health>();
        rend = FindObjectOfType<LineRenderer>();

        if(view.IsMine)
        {
            nameText.text = PhotonNetwork.NickName;
        }
        else
        {
            nameText.text = view.Owner.NickName;
        }
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

            Wrap();

            //Dash
            if(Input.GetKeyDown(KeyCode.Space) && moveInput != Vector2.zero)
            {
                StartCoroutine(Dash());
            }


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

    void Wrap()
    {
        if(transform.position.x < minX)
        {
            transform.position = new Vector2(maxX, transform.position.y);
        }
        else if (transform.position.x > maxX)
        {
            transform.position = new Vector2(minX, transform.position.y);
        }
        else if (transform.position.y < minY)
        {
            transform.position = new Vector2(transform.position.x, maxY);
        }
        else if (transform.position.y > maxY)
        {
            transform.position = new Vector2(transform.position.x,minY);
        }
    }



    IEnumerator Dash()
    {
        //Changes speed for a spesific time and then returns to normal
        speed = dashSpeed;
        yield return new WaitForSeconds(dashTime);
        speed = resetSpeed;
    }


}
