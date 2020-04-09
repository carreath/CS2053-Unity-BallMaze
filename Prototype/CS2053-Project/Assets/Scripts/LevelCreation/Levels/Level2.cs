using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TO DO:
// ADD A ZERGLING TO EMPTY BOX AREA NEAR TOP OF MAZE
public class Level2 : Map
{
    public GameObject zergling;
    public Level2() : base() {
        width = 35;
        height = 55;
        cameraSettings = new CameraSettings(new Vector3(4f, 20f, -15f), new Vector3(60f, 0f, 0f), 2.5f, 2.5f);

        player = new Player(1, 1);
        walls = new Wall[] {
            // new Wall(x1, z1, x2, z2)
            // 1:start from x > 2:start from z ^  
            // 3: >  4:^ 
            new Wall(0, 0, 37, 0),  // Bottom Wall
            new Wall(0, 0, 0, 57),  // Left Wall
            new Wall(36, 0, 37, 57),// Right Wall
            new Wall(0, 56, 37, 57),// Top Wall


            new Wall(0, 4, 20, 4), // Internal Wall: start
            // new Wall(22, 0, 22, 8), // *** Bouncy Wall
            
            new Wall(6, 12, 27, 13), //wall: L
            // new Wall(6, 12, 6, 20),// *** Bouncy Wall
            // new Wall(0, 24, 17, 25),//*** Bouncy Wall: second that protrudes from left wall
            // new Wall(23, 24, 32, 25),// *** Bouncy Wall: wall opposite
            new Wall(17, 20, 18, 30), //wall: T
            new Wall(17, 20, 29, 21),// wall: upside down L
            new Wall(29, 7, 30, 21),// wall: upside down L
            new Wall(17, 30, 27, 31),//wall: protrude right from corridor

            //final stretch
            new Wall(13, 34, 32, 35),
            new Wall(13, 30, 14, 34),
            new Wall(13, 30, 14, 34),
            new Wall(4, 30, 13, 31),
            new Wall(3, 30, 4, 52),
            // new Wall(3, 52, 33, 53),// *** Bouncy Wall



            //fast/hard corridor
            // new Wall(26, 3, 27, 12), // *** Bouncy Wall
            // new Wall(26, 3, 32, 4), // *** Bouncy Wall
            // new Wall(32, 3, 33, 52),// *** Bouncy Wall
            
        };


        wallsBouncy = new WallBouncy[] {
            new WallBouncy(22, 0, 22, 8),
            new WallBouncy(6, 12, 6, 20),
            new WallBouncy(0, 24, 17, 25),
            new WallBouncy(23, 24, 32, 25),

            new WallBouncy(3, 52, 33, 53),
            new WallBouncy(26, 3, 27, 12),
            new WallBouncy(26, 3, 32, 4), 
            new WallBouncy(32, 3, 33, 52),
        };

        goals = new Goal[] {
            new Goal(33, 53)
        };

        obstacles = new Obstacle[] {
            //place 2 holes near beginning
            //place 2  holes at end for either side depending on which side you take
            new Hole(17, 1),
            new Hole(17, 6),
            new Hole(10, 4),
            new Hole(0, 12),
            new Hole(5, 20),
            new Hole(12, 15),
            new Hole(25, 17),
            new Hole(26, 3),

            new Hole(22, 26),
            new Hole(24, 26),
            new Hole(26, 26),
            new Hole(28, 26),

            //final stretch
            new Hole(12, 26),
            new Hole(3, 24),
            new Hole(31, 53),


            //fast/hard corridor
            new Hole(22, 6),
            new Hole(23, 3),
            new Hole(22, 1),

            //final stretch of fast/hard
            new Hole(32, 0),
            new Hole(33, 4),
            new Hole(33, 6),
            new Hole(33, 8),
            new Hole(33, 10),

            new Hole(32, 14),
            new Hole(32, 16),

            new Hole(33, 20),
            new Hole(33, 22),
            new Hole(33, 24),
            new Hole(33, 26),

            new Hole(32, 30),
            new Hole(32, 32),

            new Hole(33, 36),
            new Hole(33, 38),
            new Hole(33, 40),
            new Hole(33, 42),
            new Hole(33, 44),

            new Hole(32, 48),
            new Hole(33, 51),

            
        };
        introDialogue = new Dialogue[] {
            new Dialogue(9, Dialogue.Speaker.Rubik, "Welcome To Level 2 Torture!!"),
            new Dialogue(5, Dialogue.Speaker.Rubik, "You may have survived thus far, but we’re just getting started!"),
            new Dialogue(5, Dialogue.Speaker.Rubik, "MORE WALLS, MORE DANGER!!!!"),

        };
        outroDialogue = new Dialogue[] {
            new Dialogue(5, Dialogue.Speaker.Rubik, "AGH!!! You won't be able to get aROUND us next time!"),
        };
        failDialogue = new Dialogue[] {
            new Dialogue(70, Dialogue.Speaker.Rubik, "Humpty Dumpty bumped into my walls & Humpty Dumpty had a great fall"),
            new Dialogue(70, Dialogue.Speaker.Rubik, "All the king's horses and all the king's men, couldn't put Humpty together again"),
            new Dialogue(70, Dialogue.Speaker.Rubik, "You my good broken Spherical General are now like Humpty Dumpty! HAHAHAHA"),
            new Dialogue(70, Dialogue.Speaker.King, "Well done Rubik! Just like how I like my eggs."),
        };
    
        buildMap();
        
        
    }
}
