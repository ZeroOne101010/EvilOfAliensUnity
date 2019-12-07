using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject trackedObj;
    public float trackSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        Tracking(trackedObj);
    }
    public void Tracking(GameObject obj)
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, obj.transform.position.x, trackSpeed), Mathf.Lerp(transform.position.y, obj.transform.position.y, trackSpeed), transform.position.z);
    }
}
