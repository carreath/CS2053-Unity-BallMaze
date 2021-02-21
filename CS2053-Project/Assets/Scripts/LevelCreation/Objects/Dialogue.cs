using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue
{
    public enum Speaker {
        King,
        Rubik,
        Player
    };

    public int speed;
    public Speaker speaker;
    public string text;

    public Dialogue(int speed, Speaker speaker, string text) {
        this.speed = speed;
        this.speaker = speaker;
        this.text = text;
    }
}
