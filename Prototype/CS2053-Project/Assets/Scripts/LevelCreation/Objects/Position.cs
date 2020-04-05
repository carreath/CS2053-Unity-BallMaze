using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Position is usually refferred to as transform in the objects I have defined
// I couldnt use Transform as it conflicted with the Unity Transform class
// Sorry...
public class Position
{
    public int xGrid {get; set;}
    public int yGrid {get; set;}
    public int zGrid {get; set;}

    public float xPos {get; set;}
    public float yPos {get; set;}
    public float zPos {get; set;}
    
    private Vector3 _position;
    public Vector3 position {
        get => new Vector3(xPos, yPos, zPos);
    }

    public float xScale {get; set;}
    public float yScale {get; set;}
    public float zScale {get; set;}

    private Vector3 _scale;
    public Vector3 scale {
        get => new Vector3(xScale, yScale, zScale);
    }

    public Position(int xGrid, int zGrid) {
        this.xGrid = xGrid;
        this.yGrid = 0;
        this.zGrid = zGrid;

        this.xPos = (float) xGrid * 0.5f;
        this.yPos = 0;
        this.zPos = (float) zGrid * 0.5f;
        this.xScale = 1;
        this.yScale = 1;
        this.zScale = 1;
    }

    public Position(int xGrid, int yGrid, int zGrid) {
        this.xGrid = xGrid;
        this.yGrid = yGrid;
        this.zGrid = zGrid;

        this.xPos = (float) xGrid * 0.5f;
        this.yPos = (float) yGrid * 0.5f;
        this.zPos = (float) zGrid * 0.5f;
        this.xScale = 1;
        this.yScale = 1;
        this.zScale = 1;
    }

    public Position(int xGrid, int yGrid, int zGrid, float xScale, float yScale, float zScale) {
        this.xGrid = xGrid;
        this.yGrid = yGrid;
        this.zGrid = zGrid;

        this.xPos = (float) xGrid * 0.5f;
        this.yPos = (float) yGrid * 0.5f;
        this.zPos = (float) zGrid * 0.5f;
        this.xScale = xScale;
        this.yScale = yScale;
        this.zScale = zScale;
    }
}
