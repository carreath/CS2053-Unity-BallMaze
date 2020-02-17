using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float maxRotation = 30f;
    public float rotationSpeed = 1f;
    public float returnRotationSpeed = 10f;
    public bool autoLevel = true;

    private BallController ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = this.GetComponentInChildren<BallController>();
    }

    // Update is called once per frame
    void Update()
    {
        float zDir = 0f;
        float xDir = 0f;
        if (!ball.isTransitioning())
        {
            if (Input.GetKey("left"))
            {
                zDir = 1f;
            }
            else if (Input.GetKey("right"))
            {
                zDir = -1f;
            }

            if (Input.GetKey("up"))
            {
                xDir = 1f;
            }
            else if (Input.GetKey("down"))
            {
                xDir = -1f;
            }
        }

        if (zDir != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, 0f, maxRotation * zDir), Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, 0f, 0f), Time.deltaTime * returnRotationSpeed);
        }


        if (xDir != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(maxRotation * xDir, 0f, transform.rotation.eulerAngles.z), Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z), Time.deltaTime * returnRotationSpeed);
        }
    }
}
