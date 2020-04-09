using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EVERY LEVEL WILL BE DEFINED BY A FILE THAT LOOKS LIKE THIS
// ANY CUSTOMIZATION OF AN OBJECT WILL AFFECT EVERY LEVEL IT APPEARS IN
public class BossLevel2 : Map
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
    public BossLevel2() : base() {
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
            new Hole(0, 4),
            new Hole(2, 4),
            new Hole(4, 4),
            new Hole(6, 4),
            new Hole(8, 4),
            new Hole(10, 4),
            new Hole(12, 4),
            new Hole(14, 4),
            new Hole(16, 4),
            new Hole(18, 4),
            new Hole(20, 4),
            new Hole(22, 4),
            new Hole(24, 4),
            new Hole(24, 6),
            new Hole(24, 8),
            new Hole(24, 10),
            new Hole(24, 12),
            new Hole(24, 14),
            new Hole(24, 16),
            new Hole(24, 18),
            new Hole(24, 20),
            new Hole(24, 22),
            new Hole(24, 24),
        };
        introDialogue = new Dialogue[] {
        };
        outroDialogue = new Dialogue[] {
            new Dialogue(5, Dialogue.Speaker.King, "There Is No Way! How Could YOU Beat US!"),
            new Dialogue(7, Dialogue.Speaker.King, "RUBI K. WE NEED TO TALK!"),
            new Dialogue(3, Dialogue.Speaker.Rubik, "Y-Yes?"),
            new Dialogue(7, Dialogue.Speaker.King, "THE GAME HASNT EVEN BEEN COMPLETED YET THEY ALREADY ESCAPED!!!"),
            new Dialogue(1, Dialogue.Speaker.Rubik, ". . ."),
        };
        failDialogue = new Dialogue[] {
            new Dialogue(5, Dialogue.Speaker.King, "Try as much as you like. You will never win!"),
            new Dialogue(5, Dialogue.Speaker.Rubik, "Yes! You Will Never Outsmart Me!!"),
            new Dialogue(5, Dialogue.Speaker.King, "*Aghem*"),
            new Dialogue(5, Dialogue.Speaker.Rubik, "U-Us! You Will Never Outsmart US!")
        };
    
        buildMap();
    }
}
