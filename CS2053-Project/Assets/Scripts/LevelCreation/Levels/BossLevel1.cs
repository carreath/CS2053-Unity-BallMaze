using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EVERY LEVEL WILL BE DEFINED BY A FILE THAT LOOKS LIKE THIS
// ANY CUSTOMIZATION OF AN OBJECT WILL AFFECT EVERY LEVEL IT APPEARS IN
public class BossLevel1 : Map
{
    // Important Notes:
    // The map is a grid of size width x height
    //     every cell of the grid spawns a Ground Segment prefab unless otherwise specified
    //
    // There are 2 grid locations that an object spawns on
    //     Walls have a grid that is [width + 2]x[height + 2]
    //         This allows the walls to seamlessly surround the map as well as take up exactly one tile when placed
    //     Every other object will spawn on the corners of tiles
    //         ie: The ball, goals, etc... will spawn on the vertex of 4 tiles
    //             While walls will spawn completely covering tiles
    //
    // Objects that take up multiple tiles such as black holes and goals/holes are placed based on their top left corner
    //     So the black hole if spawned at 16, 16 will delete ground between [8,16]x and [8,16]z 64 total ground segments
    public BossLevel1() : base() {
        width = 30;
        height = 30;

        cameraSettings = new CameraSettings(new Vector3(0f, 15f, -10f), new Vector3(60f, 0f, 0f), 2.5f, 2.5f);

        king = new KingCube(15, 15, 0);
        player = new Player(1, 1);
        walls = new Wall[] {
            // new Wall(x1, z1, x2, z2)
            new Wall(0, 0, 32, 0),  // Bottom Wall
            new Wall(0, 0, 0, 32),  // Left Wall
            new Wall(31, 0, 32, 32),// Right Wall
            new Wall(0, 31, 32, 32),// Top Wall

        };
        goals = new Goal[] {
            new Goal(14, 14)
        };
        obstacles = new Obstacle[] {
            new BlackHole(6, 6),
            new BlackHole(16, 6),
            new BlackHole(6, 16),
            new BlackHole(16, 16),
            new Emitter(0,27, 90.0f),
            new Emitter(27,0, 270.0f),
            new Emitter(12,0, 180.0f),
            new Emitter(0,12, 0.0f),
        };
        introDialogue = new Dialogue[] {
            new Dialogue(50, Dialogue.Speaker.King, "COME FACE ME HETHEN!"),
        };
        outroDialogue = new Dialogue[] {
            new Dialogue(30, Dialogue.Speaker.Rubik, "Lord... LORD!!!"),
            new Dialogue(10, Dialogue.Speaker.Rubik, "WHAT HAPPENED! HOW COULD WE LOSE!!!!"),
        };
        failDialogue = new Dialogue[] {
            new Dialogue(50, Dialogue.Speaker.King, "It's a beutiful day outside indeed"),
            new Dialogue(50, Dialogue.Speaker.Rubik, "Sire, I am sorry I failed you.."),
            new Dialogue(50, Dialogue.Speaker.King, "Enough! We may have won this round but he is a tenacious one."),
        };
    
        buildMap();
    }
}
