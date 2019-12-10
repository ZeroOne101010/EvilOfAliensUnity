using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMoveToObject : AITask
{

    public GameObject gameObject;
    public GameObject trackedObj;
    public float trackSpeed;
    public bool lookAtRight;
    private Animator animator;
    private Rigidbody2D rigid;

    public AIMoveToObject(GameObject gameObject, GameObject trackedObj, float trackSpeed)
    {
        this.gameObject = gameObject;
        this.trackedObj = trackedObj;
        this.trackSpeed = trackSpeed;
        animator = gameObject.GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        task = Tracking;
    }

    public void Tracking()
    {

        if (gameObject.transform.position.x > trackedObj.transform.position.x)
        {
            if (rigid != null)
            {
                rigid.velocity = new Vector3(-trackSpeed, rigid.velocity.y);
            }
            else
            {
                gameObject.transform.position += new Vector3(-trackSpeed, 0);
            }
            gameObject.transform.localScale = new Vector3(1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            if (animator != null)
            {
                animator.SetBool("MoveTrackObject", true);
                animator.speed = trackSpeed / 5;
            }
            lookAtRight = false;
        }
        else if (gameObject.transform.position.x < trackedObj.transform.position.x)
        {
            if (rigid != null)
            {
                rigid.velocity = new Vector3(trackSpeed, rigid.velocity.y);
            }
            else
            {
                gameObject.transform.position += new Vector3(trackSpeed, 0);
            }
            gameObject.transform.localScale = new Vector3(-1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            if (animator != null)
            {
                animator.SetBool("MoveTrackObject", true);
                animator.speed = trackSpeed / 5;
            }
            lookAtRight = true;
        }
        else
        {
            if(animator != null)
            animator.SetBool("MoveTrackObject", false);
        }
    }

}
