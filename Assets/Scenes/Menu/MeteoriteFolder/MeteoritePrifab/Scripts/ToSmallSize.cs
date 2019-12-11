using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToSmallSize : MonoBehaviour
{

    public float a;
    public int time;
    private int timer;

    void Start()
    {
        timer = time;
    }


    void Update()
    {
        timer--;
        if(timer < 0)
        {
            transform.localScale -= new Vector3(a, a, 0);
            if (transform.localScale.x < 0 || transform.localScale.y < 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
