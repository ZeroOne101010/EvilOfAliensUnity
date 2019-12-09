using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity, IEntityState
{
    public float speed;
    public float jumpForce;

    public void start()
    {
        addTask(new AIPlayerController(gameObject, speed, jumpForce));
    }

    public void update()
    {

    }
}
