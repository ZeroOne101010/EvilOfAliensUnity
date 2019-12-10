using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AITask
{
    public UnityAction task;
    public bool isUpdate;
    public AITask()
    {
        isUpdate = true;
    }

    public void updateTask()
    {
        if (isUpdate)
        {
            task();
        }
    }
}
