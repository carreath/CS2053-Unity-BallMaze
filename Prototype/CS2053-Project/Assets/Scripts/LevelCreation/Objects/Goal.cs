using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MapObject
{
    public Position transform;

    public Goal(int xGrid, int zGrid) {
        this.transform = new Position(xGrid, zGrid);
    }
}
