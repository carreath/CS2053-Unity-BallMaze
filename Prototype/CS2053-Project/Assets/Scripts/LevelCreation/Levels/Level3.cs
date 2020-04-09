using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : Map
{
    public Level3() : base()
    {
        width = 20;  // default: 30
        height = 15; // default: 30

        cameraSettings = new CameraSettings(new Vector3(0f, 15f, -10f), new Vector3(60f, 0f, 0f), 2.5f, 2.5f);

        player = new Player(1, 1);
        walls = new Wall[] {
            new Wall(0, 0, width + 2, 0),                   // Bottom Wall
            new Wall(0, 0, 0, height + 2),                  // Left Wall
            new Wall(width + 1, 0, width + 2, height + 2),  // Right Wall
            new Wall(0, height + 1, width + 2, height + 2), // Top Wall           

            new Wall(7, 0, 15, 4), // Bottom of BlackHole Wall

            new Wall(0, 8, 3, 9),  // Left blocking wall
        };
        goals = new Goal[] {
            new Goal(16, 2)
        };
        obstacles = new Obstacle[] {
            //Emitter will go at (2,12)
            new Emitter(2,8, 180.0f),

            new Hole(3, 5),
            new Hole(8, 12),
            new Hole(15, 8),

            new BlackHole(6, 3),
        };

        introDialogue = new Dialogue[] {
            new Dialogue(5, Dialogue.Speaker.King, "Welcome to level 4!"),
            new Dialogue(7, Dialogue.Speaker.Rubik, "So far so good, but meet my little friends."),
            new Dialogue(7, Dialogue.Speaker.King, "Hahahahah. Let us introduce our interrogators! Go on, try dodging them."),
            new Dialogue(7, Dialogue.Speaker.Rubik, "Try and get arround this black hole We are after you")
        };
        outroDialogue = new Dialogue[] {
            new Dialogue(4, Dialogue.Speaker.King, "You got past our integrators!"),
            new Dialogue(3, Dialogue.Speaker.Rubik, ". . ."),
            new Dialogue(4, Dialogue.Speaker.King, "This was just training!")
        };
        failDialogue = new Dialogue[] {
            new Dialogue(3, Dialogue.Speaker.King, "Ha, our interigators got you!"),
        };

        buildMap();
    }
}
