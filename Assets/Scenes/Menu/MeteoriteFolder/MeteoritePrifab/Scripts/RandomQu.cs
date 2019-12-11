using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomQu : MonoBehaviour
{

    public float minSpeedRotation;
    public float maxSpeedRotation;
    private float randomSpeedRotation;

    void Start()
    {
        randomSpeedRotation = Random.Range(minSpeedRotation, maxSpeedRotation);
    }


    void Update()
    {
        transform.Rotate(new Vector3(0, 0, randomSpeedRotation));
    }
}
