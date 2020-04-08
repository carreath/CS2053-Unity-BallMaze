using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    public enum TransitionType {
        IntroSetup,
        IntroDialogue,
        Intro,
        OutroSetup,
        Outro,
        OutroDialogue,
        OutroCleanup
    }
    public TransitionType transitionType;
    public bool isTransitioning;

    public GameObject mainCamera;
    private GameObject _mainCamera;

    public BallController ball;
    public CameraController camera;
    public DialogueController dialogue;

    public CameraSettings cameraSettings;

    private float timer;
    private float ballX;
    private float ballZ;
    private bool lost;
    private bool checkError;
    private Vector3 previousBallPosition;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Instantiate(mainCamera, new Vector3(-1000f,-100f,-1000f), Quaternion.Euler(90,0,0));
        camera = _mainCamera.GetComponent<CameraController>();
        transitionType = TransitionType.IntroSetup;
        isTransitioning = false;
        lost = false;
        checkError = false;
        dialogue.setCamera(_mainCamera.GetComponent<Camera>());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = camera.transform.position;
        Vector3 newCameraPosition;
        Vector3 ballPosition = ball.transform.position;
        if (isTransitioning) {
            switch (transitionType) {
                case TransitionType.IntroSetup:
                    checkError = true;
                    ballPosition.y = cameraSettings.position.y + 10f;
                    ball.transform.position = ballPosition;

                    cameraPosition = ballPosition;
                    cameraPosition.y += 3f;
                    camera.transform.position = cameraPosition;

                    transitionType = TransitionType.IntroDialogue;

                    camera.GetComponent<Camera>().farClipPlane = cameraSettings.position.y + 7;

                    break;
                case TransitionType.IntroDialogue:
                    if (!dialogue.noDialogue && !dialogue.dialogueStarted) {
                        dialogue.startIntroDialogue();
                    } else if (dialogue.noDialogue || dialogue.isComplete) {
                        transitionType = TransitionType.Intro;
                        dialogue.noDialogue = false;
                    } else {
                        freezeBall();
                    }
                    break;
                case TransitionType.Intro:
                    if ((camera.transform.position - cameraSettings.position).magnitude < 0.1f) {
                        isTransitioning = false;
                    } else if (camera.transform.position.y < cameraSettings.position.y + 5f) {
                        camera.GetComponent<Camera>().farClipPlane  = 1000;
                        cameraPosition = camera.transform.position;
                        newCameraPosition = cameraSettings.position;
                        camera.transform.position = Vector3.Lerp(cameraPosition, newCameraPosition, cameraSettings.introSpeed * Time.deltaTime);
                        
                        if (camera.transform.rotation.eulerAngles.x > cameraSettings.rotation.x) {
                            camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, Quaternion.Euler(cameraSettings.rotation), cameraSettings.introSpeed * Time.deltaTime);
                        }
                    } else {
                        cameraPosition = ball.transform.position;
                        cameraPosition.y += 3f;
                        camera.transform.position = cameraPosition;
                    }

                    break;
                case TransitionType.OutroSetup:
                    ball.transform.rotation = Quaternion.identity;
                    ball.transform.position = new Vector3(ball.ballX, ball.transform.position.y, ballZ);

                    transitionType = TransitionType.Outro;

                    break;
                case TransitionType.Outro:
                    if (ballPosition.y < -15f) {
                        ballPosition.y = -15f;
                    }
                    ball.transform.rotation = Quaternion.identity;
                    ballPosition.x = ball.ballX;
                    ballPosition.z = ball.ballZ;
                    ball.transform.position = ballPosition;
                    if (Mathf.Abs(cameraPosition.x - ball.ballX) > 0.15 || Mathf.Abs(cameraPosition.z - ball.ballZ) > 0.15) {
                        newCameraPosition = ball.transform.position;
                        newCameraPosition.y = 5f;
                        camera.transform.position = Vector3.Lerp(cameraPosition, newCameraPosition, cameraSettings.outroSpeed * Time.deltaTime);

                        
                    } else if (cameraPosition.y - ball.transform.position.y > 3.05f) {
                        newCameraPosition = ball.transform.position;
                        newCameraPosition.y += 3f;
                        camera.transform.position = Vector3.Lerp(cameraPosition, newCameraPosition, cameraSettings.outroSpeed * Time.deltaTime);
                    } else {
                        transitionType = TransitionType.OutroDialogue; 
                    }

                    if (camera.transform.rotation.eulerAngles.x < 89.9f) {
                        camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, Quaternion.Euler(90f, 0f, 0f), cameraSettings.outroSpeed * Time.deltaTime);
                    } else {
                        camera.transform.rotation = Quaternion.Euler(90f, 0, 0);
                    }
                    break;
                case TransitionType.OutroDialogue:
                    if (!dialogue.dialogueStarted) {
                        if (lost) {
                            dialogue.startFailDialogue();
                        } else {
                            dialogue.startOutroDialogue();
                        }
                    } else if (dialogue.isComplete) {
                        timer = 0;
                        transitionType = TransitionType.OutroCleanup;
                    } else {
                        freezeBall();
                    }
                    break;
                case TransitionType.OutroCleanup:
                    freezeBall();
                    timer += Time.deltaTime;
                    if (timer >= 0.5f) {
                        if (lost) {
                            BallController.sanity--;
                            dialogue.setSanityText(BallController.sanity);
                            SceneManager.LoadScene(0);
                        } else {
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                        }
                    }
                    break;
            }
        } 
        previousBallPosition = ball.transform.position;
    }

    public bool isCameraDefault() {
        return camera.transform.position.x == -1000f;
    }

    private void freezeBall() {
        Vector3 ballPosition = camera.transform.position;
        ballPosition.y -= 3;
        ball.transform.position = ballPosition;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    public void Intro() {
        transitionType = TransitionType.IntroSetup;
        isTransitioning = true;
    }

    public void Outro(bool lost) {
        this.lost = lost;
        transitionType = TransitionType.OutroSetup;
        isTransitioning = true;
    }
}
