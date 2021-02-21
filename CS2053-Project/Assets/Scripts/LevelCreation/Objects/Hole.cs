using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : Obstacle
{
    public Hole(int xGrid, int zGrid) : base(xGrid, zGrid) {
        removeGround = true;
        type = Obstacle.ObstacleType.Hole;
    }
}
