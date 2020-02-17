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
    private bool win = false;

    public float outroSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 25f, transform.position.z);
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
            if (transform.position.y > 10)
            {
                gameCamera.transform.position = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z);
            }
            else if (transform.position.y < 0.5)
            {
                intro = false;
            }
            else
            {
                gameCamera.gameObject.SendMessage("OnTransitionComplete");
            }
        }
        if (outro) {
            gameCamera.farClipPlane = 50f;
            if (outroStep1 && (gameCamera.transform.position - new Vector3(holeX, 2f, holeZ)).magnitude > 0.01) {
                transform.position = Vector3.Lerp(transform.position, new Vector3(holeX, transform.position.y, holeZ), outroSpeed * Time.deltaTime);
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
                    if (win)
                    {
                        int scene = ((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
                        SceneManager.LoadScene(scene);
                    }
                    else
                    {
                        Scene scene = SceneManager.GetActiveScene();
                        SceneManager.LoadScene(scene.name);
                    }
                }
            }
        }
    }

    public bool isTransitioning()
    {
        return intro || outro;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal" || other.gameObject.tag == "Hole") {
            win = (other.gameObject.tag == "Goal");
            outro = true;
            holeX = other.transform.position.x;
            holeZ = other.transform.position.z;
        }
    }
}
