﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MapObject
{
    // REGISTER YOUR NEW OBSTACLE TYPE HERE
    public enum ObstacleType {
        Hole,
        BlackHole
    }
    public Position transform;
    public bool removeGround = false;
    public ObstacleType type;

    public Obstacle(int xGrid, int zGrid) {
        this.transform = new Position(xGrid, zGrid);
    }
}
