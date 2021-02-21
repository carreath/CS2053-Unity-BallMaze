using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MapObject
{
    public Position transform;

    public Player(int xGrid, int zGrid) {
        this.transform = new Position(xGrid, 25, zGrid);
        this.transform.xPos -= 0.5f;
        this.transform.zPos -= 0.5f;
    }
}
