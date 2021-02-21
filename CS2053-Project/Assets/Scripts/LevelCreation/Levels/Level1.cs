﻿using System.Collections;
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
            // new Wall(0, 30, 28, 31),// Top Wall

            new Wall(5, 0, 6, 10), // Internal Wall: start
            new Wall(0, 15, 12, 16),
            new Wall(12, 8, 13, 16),

            new Wall(18, 5, 19, 20),
            new Wall(10, 20, 19, 21),
            new Wall(0, 25, 23, 26),
            
            
            
            
        };


        wallsBouncy = new WallBouncy[] {
            new WallBouncy(0, 30, 27, 31),//top wall
            new WallBouncy(5, 5, 18, 6),
            new WallBouncy(22, 5, 23, 26),
        }; 

        goals = new Goal[] {
            new Goal(1, 27),
        };

        obstacles = new Obstacle[] {
            new Hole(8, 6),
            new Hole(23, 6),
            new Hole(23, 15),
            new Hole(23, 22),
            new Hole(21, 26),

        };
        introDialogue = new Dialogue[] {
            new Dialogue(70, Dialogue.Speaker.Rubik, "Welcome To your doom!"),
            new Dialogue(50, Dialogue.Speaker.Rubik, "We're going to have some fun you and I!"),
            new Dialogue(50, Dialogue.Speaker.Rubik, "Because now the walls turn against you! You thought you could find solace against these edges, but now they will push you to your sanity’s edge! HAHAHA!"),

        };
        outroDialogue = new Dialogue[] {
            new Dialogue(50, Dialogue.Speaker.Rubik, "I have more planned for you, you just wait and see. You'll crack like Humpty Dumpty did in our maze!"),
        };

        failDialogue = new Dialogue[] {
            new Dialogue(50, Dialogue.Speaker.King, "Hey Rubik, I have a great new idea! You ever try to fit a round peg in a square hole?"),
            new Dialogue(50, Dialogue.Speaker.Rubik, "I think I know where you're pointing to! I gotta say, it sounds FITTING!"),
            new Dialogue(50, Dialogue.Speaker.King, "Well, thank cube very much! Now get to it!"),

        };
    
        buildMap();
        
    }
}
