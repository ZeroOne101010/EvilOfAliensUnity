using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRunToTheHero : MonoBehaviour
{
    public GameObject trackedObj;
    public float trackSpeed;
    public Animator animator;

    private int timer;
    private int time = 50;
    private bool lookAtRight;
    public float force;

    void Start()
    {
        timer = time;
    }

    void Update()
    {
        Tracking();
        dropKnife();
    }

    public void dropKnife()
    {
        if (GetComponent<DropObject>())
        {
            timer--;
            if (timer < 0)
            {
                DropObject dropObject = GetComponent<DropObject>();
                Vector2 pos = transform.position;
                Quaternion qu = new Quaternion(0, 0, 0, 0);
                if (lookAtRight)
                {
                    pos += new Vector2(7.55f - 5.67f, 0);
                    qu = new Quaternion(0, 0, 180, 0);
                }
                else
                {
                    pos -= new Vector2(7.55f - 5.67f, 0);
                }
                Vector2 direction = ((trackedObj.transform.position + new Vector3(0, 1)) - transform.position).normalized;
                dropObject.dropObject(pos, qu, direction, force);
                timer = time;
                Debug.Log(123);
            }
            
        }
    }

    public void Tracking()
    {
        if(transform.position.x > trackedObj.transform.position.x)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(-trackSpeed, GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            animator.SetBool("IsRun", true);
            animator.speed = trackSpeed / 5;
            lookAtRight = false;
        }
        else if(transform.position.x < trackedObj.transform.position.x)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(trackSpeed, GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            animator.SetBool("IsRun", true);
            animator.speed = trackSpeed / 5;
            lookAtRight = true;
        }
        else
        {
            animator.SetBool("IsRun", false);
        }
    }
}
