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

    public AudioSource bounceSound;
    public AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    { 
        hitSound = GetComponents<AudioSource>()[2];
        bounceSound = GetComponents<AudioSource>()[3];
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Wall" && GetComponent<Rigidbody>().velocity.magnitude >= 0.5f) {
            hitSound.Play();
        }
        if (collision.gameObject.tag =="BouncyWall" && GetComponent<Rigidbody>().velocity.magnitude >= 0.5f) {
            bounceSound.Play();
        }
    }
}
