using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsDisplay : MapObject
{
    public Position transform;
    public ControlsDisplay(int xGrid1, int zGrid1) {
        this.transform = new Position(xGrid1, 0, zGrid1, 1, 1, 1);
    }
}
