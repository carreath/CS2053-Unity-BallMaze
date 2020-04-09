using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level1 : Map
{
    public Level1() : base() {
        width = 27;
        height = 30;
        cameraSettings = new CameraSettings(new Vector3(0f, 15f, -10f), new Vector3(60f, 0f, 0f), 2.5f, 2.5f);
        // (0, 15, -10)

        player = new Player(1, 1);
        walls = new Wall[] {
            // new Wall(x1, z1, x2, z2)
            // 1:start from x > 2:start from z ^  
            // 3: >  4:^ 
            new Wall(0, 0, 28, 0),  // Bottom Wall
            new Wall(0, 0, 0, 31),  // Left Wall
            new Wall(27, 0, 28, 31),// Right Wall
            new Wall(0, 30, 28, 31),// Top Wall

            new Wall(5, 0, 6, 10), // Internal Wall: start
            new Wall(0, 15, 12, 16),
            new Wall(12, 8, 13, 16),

            new Wall(18, 5, 19, 20),
            new Wall(18, 9, 17, 15),
            
            
        };


        wallsBouncy = new WallBouncy[] {
            new WallBouncy(5, 5, 18, 6),
        };

        goals = new Goal[] {
            new Goal(15, 15)
        };

        obstacles = new Obstacle[] {
            //place 2 holes near beginning
            //place 2  holes at end for either side depending on which side you take
            new Hole(17, 1),

            
        };
        introDialogue = new Dialogue[] {
            new Dialogue(9, Dialogue.Speaker.Rubik, "Welcome To your doom!"),
            new Dialogue(5, Dialogue.Speaker.Rubik, "We're going to have some fun you and I!"),
            new Dialogue(5, Dialogue.Speaker.Rubik, "Because now the walls turn against you! You thought you could find solace against these edges, but now they will push you to your sanity’s edge! HAHAHA!"),

        };
        outroDialogue = new Dialogue[] {
            new Dialogue(5, Dialogue.Speaker.Rubik, "I have more planned for you, you just wait and see. You'll crack like Humpty Dumpty did in our maze!"),
        };

        failDialogue = new Dialogue[] {
            new Dialogue(5, Dialogue.Speaker.King, "Hey Rubik, I have a great new idea! You ever try to fit a round peg in a square hole?"),
            new Dialogue(5, Dialogue.Speaker.Rubik, "I think I know where you're pointing to! I gotta say, it sounds FITTING!"),
            new Dialogue(5, Dialogue.Speaker.King, "Well, thank cube very much! Now get to it!"),

        };
    
        buildMap();
        
    }
}
