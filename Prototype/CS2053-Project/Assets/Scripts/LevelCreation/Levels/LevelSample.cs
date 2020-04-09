using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EVERY LEVEL WILL BE DEFINED BY A FILE THAT LOOKS LIKE THIS
// ANY CUSTOMIZATION OF AN OBJECT WILL AFFECT EVERY LEVEL IT APPEARS IN
public class LevelSample : Map
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
    public LevelSample() : base() {
        width = 20;
        height = 20;

        cameraSettings = new CameraSettings(new Vector3(0f, 10f, -6.75f), new Vector3(60f, 0f, 0f), 2.5f, 2.5f);

        player = new Player(10, 10);
        walls = new Wall[] {
            // new Wall(x1, z1, x2, z2)
            new Wall(0, 0, 22, 0),  // Bottom Wall
            new Wall(0, 0, 0, 22),  // Left Wall
            new Wall(21, 0, 22, 22),// Right Wall
            new Wall(0, 21, 22, 22),// Top Wall
        };
        goals = new Goal[] {
            new Goal(0, 0)
        };
        obstacles = new Obstacle[] {
            new Hole(0, 18),
            new Hole(18, 18),
            new Hole(18, 0),
            //new Hole(19, 26),
            //new Hole(19, 26),
            //new BlackHole(0, 22),
        };
        introDialogue = new Dialogue[] {
            new Dialogue(10, Dialogue.Speaker.Rubik, "HA-HA-HA, Look my lord! He is but a little mouse in my impossible maze!"),
            new Dialogue(5, Dialogue.Speaker.King, "Excellent work Rubi K. By the way why are there holes in the prison?"),
            new Dialogue(10, Dialogue.Speaker.Rubik, "Yes, about those. I thought it would be dull if he was stuck in this little room forever so I gave him something to do."),
            new Dialogue(9, Dialogue.Speaker.Rubik, "He will be rolling around aimlessly falling through holes until he goes insane!"),
            new Dialogue(5, Dialogue.Speaker.King, "I see..."),
            new Dialogue(5, Dialogue.Speaker.King, "Don't make me regret assigning you to this task."),
        };
        outroDialogue = new Dialogue[] {
            new Dialogue(5, Dialogue.Speaker.Rubik, "Wait... WHAT!!!"),
            new Dialogue(7, Dialogue.Speaker.Rubik, "How did you figure this puzzle out so quickly?"),
            new Dialogue(7, Dialogue.Speaker.Rubik, "I better make this next one harder."),
            new Dialogue(1, Dialogue.Speaker.King, ". . ."),
        };
        failDialogue = new Dialogue[] {
            new Dialogue(5, Dialogue.Speaker.Rubik, "SCRAMBLE Me Sideways! You really are stupid!"),
            new Dialogue(5, Dialogue.Speaker.King, "You know what they say Rubi K. You are only as sharp as your pointiest vertex."),
            new Dialogue(5, Dialogue.Speaker.Rubik, "Your wisdom knows no bounds my lord."),
        };
    
        buildMap();
    }
}
