using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : Obstacle
{
    public BlackHole(int xGrid, int zGrid) : base(xGrid, zGrid) {
        removeGround = true;
        type = Obstacle.ObstacleType.BlackHole;
        transform.xPos += 1.5f;
        transform.zPos += 1.5f;
    }
}
