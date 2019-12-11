using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{

    public float minSpeed;
    public float maxSpeed;

    private IMeteoriteState state;

    void Start()
    {
        state = this as IMeteoriteState;
        if(state != null)
        {
            state.meteoriteStart();
        }
    }


    void Update()
    {
        if(state != null)
        {
            state.meteoriteUpdate();
        }
    }
}
