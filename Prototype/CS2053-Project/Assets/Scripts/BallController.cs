using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public GameController gameController;

    public float ballX;
    public float ballZ;

    public static int sanity = 3;

    // Start is called before the first frame update
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        ballX = other.gameObject.transform.position.x;
        ballZ = other.gameObject.transform.position.z;
        if (other.gameObject.tag == "Goal") {
            gameController.Win();      
        } else if (other.gameObject.tag == "Hole") {
            gameController.Lose();      
        }
    }
}
