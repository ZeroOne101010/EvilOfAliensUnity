using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity, IEntityState
{
    public float speed;
    public float jumpForce;
    public AIPlayerController playerController;
    public void start()
    {
        playerController = new AIPlayerController(gameObject, speed, jumpForce);
        addTask(playerController);       
    }

    public void update()
    {

    }
    public void jump()
    {
    }
}
