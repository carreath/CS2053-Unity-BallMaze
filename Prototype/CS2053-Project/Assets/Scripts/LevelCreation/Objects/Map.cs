using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ADD REQUIRED CODE TO MAKE YOUR NEW OBJECT WORK PROPERLY
// This class must be implemented in every level
// It ensures proper spacing for all objects on the board
public abstract class Map : Level
{
    public int width {get; set; }
    public int height {get; set; }
    public Vector3 mapScale {get; set; }

    public ControlsDisplay controls {get; set; }
    public Player player {get; set; }
    public Wall[] walls {get; set; }
    public WallBouncy[] wallsBouncy {get; set; }
    public Goal[] goals {get; set; }
    public Obstacle[] obstacles {get; set; }
    public Dialogue[] introDialogue {get; set; }
    public Dialogue[] outroDialogue {get; set; }
    public Dialogue[] failDialogue {get; set; }
    public bool[,] ground {get; set; }
    
    
    public float xOffset {get; set;}
    public float zOffset {get; set;}

    public CameraSettings cameraSettings { get; set; }

    public void buildMap() {
        

        // IF YOUR OBJECT IS NOT A SUB-SET OF ANY OTHER TYPE ADD OFFSET RULES HERE
        xOffset = (float) -width/4f + 0.5f;
        zOffset = (float) -height/4f + 0.5f;

        player.transform.xPos += xOffset;
        player.transform.zPos += zOffset;

        foreach (Wall wall in walls) {
            wall.transform.xPos += xOffset;
            wall.transform.zPos += zOffset;
        }

        
        // try {
        //     int len = wallsBouncy.Length;
        //     Debug.Log(len);
        // } catch{
        //     Debug.Log("Error getting length: ");
        // }
        foreach (WallBouncy wallbouncy in wallsBouncy) {
            wallbouncy.transform.xPos += xOffset;
            wallbouncy.transform.zPos += zOffset;
        }

        foreach (Goal goal in goals) {
            goal.transform.xPos += xOffset;
            goal.transform.zPos += zOffset;
        }
        foreach (Obstacle obstacle in obstacles) {    
            obstacle.transform.xPos += xOffset;
            obstacle.transform.zPos += zOffset;
        }

        // IF YOUR OBJECT REMOVES GROUND TILES DO THAT HERE
        mapScale = new Vector3((float) width / 10f, 1f, (float) height / 10f);
        this.ground = new bool[height, width];
        for (int i=0; i<height; i++) {
            for (int j=0; j<width; j++) {
                this.ground[i, j] = true;
            }
        }

        foreach (Goal goal in goals) {
            for (int i=0; i<2; i++) {
                for (int j=0; j<2; j++) {
                    ground[goal.transform.zGrid + i, goal.transform.xGrid + j] = false;
                }
            }
        }

        foreach (Obstacle obstacle in obstacles) {
            switch (obstacle.type) {
                case Obstacle.ObstacleType.Hole:
                    for (int i=0; i<2; i++) {
                        for (int j=0; j<2; j++) {
                            ground[obstacle.transform.zGrid + i, obstacle.transform.xGrid + j] = false;
                        }
                    }
                    break;
                case Obstacle.ObstacleType.BlackHole:
                    for (int i=0; i<8; i++) {
                        for (int j=0; j<8; j++) {
                            ground[obstacle.transform.zGrid + i, obstacle.transform.xGrid + j] = false;
                        }
                    }
                    break;
                default:
                    ground[obstacle.transform.zGrid, obstacle.transform.xGrid] = !obstacle.removeGround;
                    break;
            }
        }
    }
}
