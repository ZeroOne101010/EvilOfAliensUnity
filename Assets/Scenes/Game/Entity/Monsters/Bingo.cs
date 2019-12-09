using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bingo : Entity, IEntityState
{

    public GameObject trackedObject;
    public float trackSpeed;

    public void start()
    {
        addTask(new AIMoveToObject(gameObject, trackedObject, trackSpeed));
    }

    public void update()
    {

    }
}
    
