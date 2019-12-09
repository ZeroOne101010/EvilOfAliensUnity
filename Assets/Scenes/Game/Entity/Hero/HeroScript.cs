using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    void Start()
    {

    }


    void Update()
    {
        HeroMove();
    }
    public void HeroMove()
    {
        jump();
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            if(GetComponent<Rigidbody2D>().velocity.y == 0)
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        }
            

    }
    public void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) & GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            GetComponent<Rigidbody2D>().velocity += new Vector2(0, jumpForce);
        }
    }

}
