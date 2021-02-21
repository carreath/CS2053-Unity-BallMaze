using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : Map
{
    public Level4() : base()
    {
        width = 30;
        height = 25;

        cameraSettings = new CameraSettings(new Vector3(0f, 15f, -10f), new Vector3(60f, 0f, 0f), 2.5f, 2.5f);

        player = new Player(1, 1);
        walls = new Wall[] {
            new Wall(0, 0, width + 2, 0),                   // Bottom Wall
            new Wall(0, 0, 0, height + 2),                  // Left Wall
            new Wall(width + 1, 0, width + 2, height + 2),  // Right Wall
            new Wall(0, height + 1, width + 2, height + 2), // Top Wall 
            
            new Wall(7, 0, 7, 10),
            
            new Wall(7, 10, 7, 12),
            new Wall(7, 12, 10, 12),

            new Wall(10, 13, 10, 15),
            new Wall(10, 15, 13, 15),

            new Wall(13, 16, 13, 18),
            new Wall(13, 18, 16, 18),

            new Wall(16, 19, 16, 21),
            new Wall(16, 21, 19, 21),

            new Wall(20, 8, width + 1, 10)
        };
        goals = new Goal[] {
            new Goal(25, 3)
        };
        obstacles = new Obstacle[] {
            //Emitter at 1, 12
            new Emitter(0, 12, 0.0f),
            //Emitter at 9, 5
            new Emitter(9, 5, 90.0f),
            //Emitter at 9, 1
            new Emitter(9, 1, 90.0f),

            new Hole(11, 11),
            new Hole(14, 14),
            new Hole(17, 17),

            new Hole(25, 5),
            new Hole(25, 1),

            new BlackHole(5, 15),
            new BlackHole(20, 8),

        };

        introDialogue = new Dialogue[] {
            new Dialogue(5, Dialogue.Speaker.King, "Welcome to level 4!"),
            new Dialogue(7, Dialogue.Speaker.Rubik, "So far you have got past us. But now, you must stop."),
            new Dialogue(7, Dialogue.Speaker.King, "Hahahahah. Our cube integrators are after you! Go on, try dodging them."),
            new Dialogue(7, Dialogue.Speaker.Rubik, "This is our last chance of getting you! We are after you...")
        };
        outroDialogue = new Dialogue[] {
            new Dialogue(4, Dialogue.Speaker.King, "You got past our integrators!"),
            new Dialogue(3, Dialogue.Speaker.Rubik, ". . ."),
            new Dialogue(4, Dialogue.Speaker.King, "We'll get you next time!")
        };
        failDialogue = new Dialogue[] {
            new Dialogue(3, Dialogue.Speaker.King, "Ha, our interigators got you!"),
        };

        buildMap();
    }
}
