using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Level
{
    int width {get; set; }
    int height {get; set; }
    Vector3 mapScale {get; set;}

    ControlsDisplay controls {get; set; }
    Player player {get; set; }
    Wall[] walls {get; set; }
    Goal[] goals {get; set; }
    Obstacle[] obstacles {get; set; }
    Dialogue[] introDialogue {get; set; }
    Dialogue[] outroDialogue {get; set; }
    Dialogue[] failDialogue {get; set; }
    bool[,] ground {get; set; }

    float xOffset {get; set;}
    float zOffset {get; set;}

    CameraSettings cameraSettings { get; set; }
}
