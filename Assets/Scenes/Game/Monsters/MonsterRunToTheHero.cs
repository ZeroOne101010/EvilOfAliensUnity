using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRunToTheHero : MonoBehaviour
{
    public GameObject trackedObj;
    public float trackSpeed;
    public Animator animator;
    void Start()
    {
        
    }

    void Update()
    {
        Tracking();
    }
    public void Tracking()
    {
        if(transform.position.x > trackedObj.transform.position.x)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(-trackSpeed, GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            animator.SetBool("IsRun", true);
            animator.speed = trackSpeed / 5;
        }
        else if(transform.position.x < trackedObj.transform.position.x)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(trackSpeed, GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            animator.SetBool("IsRun", true);
            animator.speed = trackSpeed / 5;
        }
        else
        {
            animator.SetBool("IsRun", false);
        }
    }
}
