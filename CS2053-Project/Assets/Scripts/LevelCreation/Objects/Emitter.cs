using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : Obstacle
{
    public Emitter(int xGrid, int zGrid, float yRotation) : base(xGrid, zGrid)
    {
        removeGround = false;
        type = Obstacle.ObstacleType.Emitter;
        transform.xPos += 1.5f;
        //transform.yPos += 0.25f;
        transform.zPos += 1.5f;
        rotation = Quaternion.Euler(0.0f, yRotation, 0.0f);
    }
}
