using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    private Camera gameCamera;
    private bool intro;
    private bool outro;
    private bool outroStep1;
    private float freezeY;
    private float holeX;
    private float holeZ;

    public float outroSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        gameCamera = Camera.main;
        intro = true;
        outro = false;
        freezeY = 0f;
        holeX = 0f;
        holeZ = 0f;
        outroStep1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (intro) {
            if (transform.position.y > 10) {
                gameCamera.transform.position = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z);
            } else {
                intro = false;
                gameCamera.gameObject.SendMessage("OnTransitionComplete");
            }
        }
        if (outro) {
            if (outroStep1 && (gameCamera.transform.position - new Vector3(holeX, 2f, holeZ)).magnitude > 0.01) {
                Debug.Log((gameCamera.transform.position - new Vector3(holeX, 2f, holeZ)).magnitude);
                gameCamera.transform.rotation = Quaternion.Lerp(gameCamera.transform.rotation, Quaternion.Euler(90f, 0f, 0f), outroSpeed * (30f/(90 - gameCamera.transform.rotation.eulerAngles.x)) * Time.deltaTime);
                gameCamera.transform.position = Vector3.Lerp(gameCamera.transform.position, new Vector3(holeX, 2f, holeZ), outroSpeed * (10f/(gameCamera.transform.position - new Vector3(holeX, 2f, holeZ)).magnitude) * Time.deltaTime);
            } else {
                outroStep1 = false;
                if (freezeY == 0f) {
                    outroSpeed = 1;
                    freezeY = transform.position.y;
                }
                gameCamera.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
                transform.position = new Vector3(holeX, freezeY, holeZ);
                transform.rotation = Quaternion.identity;

                gameCamera.transform.position = Vector3.Lerp(gameCamera.transform.position, new Vector3(transform.position.x, transform.position.y + 4, transform.position.z), outroSpeed * (15f/(gameCamera.transform.position - transform.position).magnitude) * Time.deltaTime);
                if ((gameCamera.transform.position - transform.position).magnitude <= 4.1) {
                    Scene scene = SceneManager.GetActiveScene(); 
                    SceneManager.LoadScene(scene.name);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TAG: " + other.gameObject.tag);
        if (other.gameObject.tag == "Goal" || other.gameObject.tag == "Hole") {
            outro = true;
            holeX = other.transform.position.x;
            holeZ = other.transform.position.z;
        }
    }
}
