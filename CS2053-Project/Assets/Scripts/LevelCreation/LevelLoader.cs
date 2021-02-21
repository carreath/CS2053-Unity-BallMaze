using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MAKE SURE TO ASSIGN NEW INSTANCES PARENT TO gc.gameObject.transform
public class LevelLoader
{
    // SET DEBUG TO TRUE TO SEE INDIVIDUAL GROUND SEGMENTS EASIER
    // GREEN == ODD
    private const bool DEBUG = false;


    private GameController gc;
    private Level level;

    // DEFINE PREFAB OBJECTS HERE
    private GameObject Ball;
    private GameObject Goal;
    private GameObject BlackHole;
    private GameObject Hole;
    private GameObject Wall;
    private GameObject WallBouncyObj;
    private GameObject Emitter;
    private GameObject Ground;
    private GameObject ControlsDisplayObj;
    private GameObject CubeKingPrefab;

    private GameObject Instantiate(GameObject obj, Vector3 position, Quaternion rot) {
        return gc.Instantiate_helper(obj, position, rot);
    }

    public LevelLoader(GameController gc, Level level, GameObject[] prefabs) {
        this.gc = gc;
        this.level = level;
        
        // Maps Prefab objects to their own variables
        // CREATE A CASE FOR YOUR NEW OBJECT
        foreach (GameObject prefab in prefabs) {
            switch (prefab.name) {
                case "Ball":
                    Ball = prefab;
                    break;
                case "Goal":
                    Goal = prefab;
                    break;
                case "BlackHoleMesh":
                    BlackHole = prefab;
                    break;
                case "HoleMesh":
                    Hole = prefab;
                    break;
                case "Wall":
                    Wall = prefab;
                    break;
                case "WallBouncy":
                    WallBouncyObj = prefab;
                    break;
                case "Emitter":
                    Emitter = prefab;
                    break;
                case "Ground Segment":
                    Ground = prefab;
                    break;
                case "ControlsDisplay":
                    ControlsDisplayObj = prefab;
                    break;
                case "CubeKingPrefab":
                    CubeKingPrefab = prefab;
                    break;
            }
        }

        createLevel();
    }

    // CREATE A CASE FOR YOUR NEW OBJECTS IF NECESSARY
    private void createLevel() {
        try {
            createPlayer();
        } catch (Exception e) {
            Debug.Log("Error Instantiating Player: " + e);
        }

        try {
            createCubeKing();
        } catch (Exception e) {
            Debug.Log("Error Instantiating Player: " + e);
        }

        if (level.controls != null) {
            try {
                createControls();
            } catch (Exception e) {
                Debug.Log("Error Instantiating Controls: " + e);
            }
        }

        // IF YOUR OBJECT IS AN OBSTACLE MAKE SURE IT IMPLEMENTS OBSTACLE << MyClass : Obstacle >>
        // MAKE SURE TO UPDATE createObstacle METHOD WITH YOUR NEW OBJECT
        foreach (Obstacle obstacle in level.obstacles) {
            try {
                createObstacle(obstacle);
            } catch (Exception e) {
                Debug.Log("Error Instantiating Obstacle: " + e);
            }
        }
        
        foreach (Wall wall in level.walls) {
            try {
                createWall(wall);
            } catch (Exception e) {
                Debug.Log("Error Instantiating Wall: " + e);
            }
        }

        foreach (WallBouncy wallBouncy in level.wallsBouncy) {
            try {
                createWallBouncy(wallBouncy);
            } catch (Exception e) {
                Debug.Log("Error Instantiating WallBouncy: " + e);
            }
        }

        foreach (Goal goal in level.goals) {
            try {
                createGoal(goal);                
            } catch (Exception e) {
                Debug.Log("Error Instantiating Goal: " + e);
            }
        }
        
        for (int i=0; i<level.height; i++) {
            for (int j=0; j<level.width; j++) {
                try {
                    createGround(i, j);
                } catch (Exception e) {
                    Debug.Log("Error Instantiating Ground: " + e);
                }
            }
        }
    }


    private void createPlayer() {
        GameObject ballObj = Instantiate(Ball, level.player.transform.position, Quaternion.identity);
        ballObj.transform.SetParent(gc.gameObject.transform);
    }

    private void createCubeKing() {
        GameObject ballObj = Instantiate(CubeKingPrefab, level.king.transform.position, Quaternion.identity);
        ballObj.transform.SetParent(gc.gameObject.transform);
    }

    private void createControls() {
        GameObject controlObj = Instantiate(ControlsDisplayObj, Vector3.zero, Quaternion.identity);
        controlObj.transform.SetParent(gc.gameObject.transform);
    }

    // ADD A CASE FOR YOUR OBSTACLE HERE
    private void createObstacle(Obstacle obstacle) {
        switch (obstacle.type) {
            case Obstacle.ObstacleType.Hole:
                Instantiate(Hole, obstacle.transform.position, Quaternion.Euler(-90, 0, 0)).transform.SetParent(gc.gameObject.transform);
                break;
            case Obstacle.ObstacleType.BlackHole:
                Instantiate(BlackHole, obstacle.transform.position, Quaternion.Euler(-90, 0, 0)).transform.SetParent(gc.gameObject.transform);
                break;
            case Obstacle.ObstacleType.Emitter:
                Vector3 pos = obstacle.transform.position;
                pos.y -= 0.233f;
                Instantiate(Emitter, pos, obstacle.rotation).transform.SetParent(gc.gameObject.transform);
                break;
        }
    }

    private void createWall(Wall wall) {
        GameObject w = Instantiate(Wall, wall.transform.position, Quaternion.identity);
        w.transform.SetParent(gc.gameObject.transform);
        w.transform.localScale = wall.transform.scale;
    }

    private void createWallBouncy(WallBouncy wallBouncy){
        GameObject wb = Instantiate(WallBouncyObj, wallBouncy.transform.position, Quaternion.identity);
        wb.transform.SetParent(gc.gameObject.transform);
        wb.transform.localScale = wallBouncy.transform.scale;
    }

    private void createGoal(Goal goal) {
        Instantiate(Goal, goal.transform.position, Quaternion.Euler(-90, 0, 0)).transform.SetParent(gc.gameObject.transform);
    }

    private void createGround(int i, int j) {
        if (level.ground[i,j]) {
            GameObject ground = Instantiate(Ground, new Vector3((float) j * 0.5f + level.xOffset - 0.25f, 0, (float) i * 0.5f + level.zOffset - 0.25f), Quaternion.identity);
            ground.transform.SetParent(gc.gameObject.transform);
            Material[] mats = ground.GetComponent<Renderer>().materials;

            if (DEBUG && (i+j) % 2 == 0) {
                mats[0] = gc.debugMaterial;
                ground.GetComponent<Renderer>().materials = mats;
            }
        }
    }
}
