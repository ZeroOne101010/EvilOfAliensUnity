using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public Vector2 size;
    public List<AITask> task;
    private IEntityState state;

    void Start()
    {
        task = new List<AITask>();
        state = this as IEntityState;
        if (state != null)
        {
            state.start();
        }
    }


    void Update()
    {
        for (int x = 0; x < task.Count; x++)
        {
            task[x].updateTask();
        }
        if(state != null)
        {
            state.update();
        }
    }

    public void addTask(AITask task)
    {
        this.task.Add(task);
    }

}
