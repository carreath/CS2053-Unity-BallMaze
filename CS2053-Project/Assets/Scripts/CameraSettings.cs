using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings
{
    public Vector3 position;
    public Vector3 rotation;
    public float introSpeed;
    public float outroSpeed;

    public CameraSettings(Vector3 position, Vector3 rotation, float introSpeed, float outroSpeed) {
        this.position = position;
        this.rotation = rotation;
        this.introSpeed = introSpeed;
        this.outroSpeed = outroSpeed;
    }
}
