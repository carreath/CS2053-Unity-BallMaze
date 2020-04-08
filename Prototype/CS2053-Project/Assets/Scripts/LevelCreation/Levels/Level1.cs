using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EVERY LEVEL WILL BE DEFINED BY A FILE THAT LOOKS LIKE THIS
// ANY CUSTOMIZATION OF AN OBJECT WILL AFFECT EVERY LEVEL IT APPEARS IN
public class Level1 : Map
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
    public Level1() : base() {
        width = 30;
        height = 30;

        cameraSettings = new CameraSettings(new Vector3(0f, 15f, -10f), new Vector3(60f, 0f, 0f), 2.5f, 2.5f);

        player = new Player(1, 1);
        walls = new Wall[] {
            // new Wall(x1, z1, x2, z2)
            new Wall(0, 0, 32, 0),  // Bottom Wall
            new Wall(0, 0, 0, 32),  // Left Wall
            new Wall(31, 0, 32, 32),// Right Wall
            new Wall(0, 31, 32, 32),// Top Wall

            new Wall(3, 0, 3, 10), // Internal Wall
            
            new Wall(6, 0, 18, 10), // Filler Wall
        };
        goals = new Goal[] {
            new Goal(20, 14)
        };
        obstacles = new Obstacle[] {
            new Hole(14, 14),
            new Hole(22, 26),
            new Hole(24, 26),
            new Hole(26, 26),
            new Hole(28, 26),
            new BlackHole(0, 22),
        };
        introDialogue = new Dialogue[] {
            new Dialogue(5, Dialogue.Speaker.King, "Welcome To Level 1!"),
            new Dialogue(10, Dialogue.Speaker.Rubik, "Yes Welcome! We Have Everything A Sphere Like Yourself Would Need To Go Insane. Just Try To Escape."),
            new Dialogue(9, Dialogue.Speaker.King, "Hold On Rubik, This Is Only A Demo. The Real Game Will Be Completed Soon."),
            new Dialogue(5, Dialogue.Speaker.Rubik, "Alright..."),
            new Dialogue(5, Dialogue.Speaker.Rubik, "I Will Keep Building My Puzzles..."),
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
