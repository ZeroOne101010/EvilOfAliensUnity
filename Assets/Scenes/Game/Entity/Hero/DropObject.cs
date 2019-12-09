using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DropObject : MonoBehaviour
{

    public GameObject prifab;


    public void dropObject(Vector2 pos, Quaternion qu, Vector2 direction, float speed)
    {

        Vector2 force = direction * speed;
        GameObject obj = Instantiate(prifab, pos, qu);
        if (obj.GetComponent<Rigidbody2D>())
        {
            obj.GetComponent<Rigidbody2D>().velocity = force;
        }

    }



}
