using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBouncy : MapObject {
     
    public Position transform;
    public WallBouncy(int xGrid1, int zGrid1, int xGrid2, int zGrid2) {
        float xScale = (xGrid2 - xGrid1) / 2f;
        if (xGrid1 == xGrid2) {
            xScale = 0.5f;
        }
        float zScale = (zGrid2 - zGrid1) / 2f;
        if (zGrid1 == zGrid2) {
            zScale = 0.5f;
        }

        float tempXPos = (float) xGrid1/2f + 0.5f * xScale - 1f;
        float tempZPos = (float) zGrid1/2f + 0.5f * zScale - 1f;

        this.transform = new Position(xGrid1, 0, zGrid1, xScale, 1, zScale);
        this.transform.xPos = tempXPos;
        this.transform.zPos = tempZPos;
    }
    
}