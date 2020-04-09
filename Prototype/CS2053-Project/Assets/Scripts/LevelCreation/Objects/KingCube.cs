using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingCube
{
    public Position transform;
    public int variant = 1;

    public KingCube(int xGrid, int zGrid, int variant) {
        this.transform = new Position(xGrid, 1, zGrid);
        this.transform.xPos -= 0.5f;
        this.transform.zPos -= 0.5f;

        this.variant = variant;
    }
}
