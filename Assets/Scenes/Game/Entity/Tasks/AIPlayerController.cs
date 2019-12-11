using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AIPlayerController : AITask
{

    public GameObject gameObject;
    public float speed;
    public float jumpForce;
    public GameObject joystick;
    public GameObject jumpButton;
    private Rigidbody2D rigid;
    public bool boool;

    public AIPlayerController(GameObject gameObject, float speed, float jumpForce)
    {
        this.gameObject = gameObject;
        this.speed = speed;
        this.jumpForce = jumpForce;
        joystick = GameObject.FindGameObjectWithTag("joystick");
        jumpButton = GameObject.FindGameObjectWithTag("jumpbutton");
        rigid = gameObject.GetComponent<Rigidbody2D>();
        task = PlayerMove;
        if (jumpButton != null)
            jumpButton.GetComponent<Button>().onClick.AddListener(jumpForListener);
    }

    public void PlayerMove()
    {
        jump(false);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (rigid != null)
            {
                rigid.velocity = new Vector2(speed, rigid.velocity.y);
            }
            else
            {
                gameObject.transform.position += new Vector3(speed, 0, 0);
            }
            gameObject.transform.localScale = new Vector3(1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (rigid != null)
            {
                rigid.velocity = new Vector2(-speed, rigid.velocity.y);
            }
            else
            {
                gameObject.transform.position += new Vector3(-speed, 0, 0);
            }
            gameObject.transform.localScale = new Vector3(-1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }else if (joystick != null)
        {
            if(joystick.GetComponent<JoyStick>().inputVector.x != 0);
            {
                if (rigid != null)
                    rigid.velocity = new Vector2(joystick.GetComponent<JoyStick>().inputVector.x * speed, rigid.velocity.y);
                else
                    gameObject.transform.position += new Vector3(-speed, 0, 0);


                if (rigid.velocity.x > 0)
                    gameObject.transform.localScale = new Vector3(1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                else
                    gameObject.transform.localScale = new Vector3(-1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }
        }
        else
        {
            if (rigid != null)
            {
                if (rigid.velocity.y == 0)
                    rigid.velocity = new Vector2(0, rigid.velocity.y);
            }
        }


    }
    public void jumpForListener()
    {
        jump(true);
    }
    public void jump(bool listener)
    {
        if (listener == true)
        {
            if (rigid != null)
            {
                if (rigid.velocity.y == 0)
                {
                    rigid.velocity += new Vector2(0, jumpForce);
                }
            }
            else
            {
                gameObject.transform.position += new Vector3(0, jumpForce, 0);
            }
        }
        else
        {
            if (rigid != null)
            {
                if (rigid.velocity.y == 0)
                {
                    if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                        rigid.velocity += new Vector2(0, jumpForce);
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    gameObject.transform.position += new Vector3(0, jumpForce, 0);
                }
                else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    gameObject.transform.position += new Vector3(0, -jumpForce, 0);
                }
            }
        }
        
    }
}
