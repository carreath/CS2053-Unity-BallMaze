using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float maxRotation = 30f;
    public float rotationSpeed = 1f;
    public float returnRotationSpeed = 10f;
    public bool autoLevel = true;
    public GameObject dialogueController;
    public GameObject transitionController;
    public GameObject[] levelPrefabs;

    public int level = 0;
    
    public Material debugMaterial;
    public int rubikVariant = 0;

    private BallController ball;
    private DialogueController dialogueScript;
    private TransitionController transitionScript;
    private GameObject _dialogueController;
    private GameObject _transitionController;

    private bool loading;
 
    // Start is called before the first frame update
    void Start()
    {
        Level level = GetLevel();
        LevelLoader loader = new LevelLoader(this, level, levelPrefabs);

        ball = this.GetComponentInChildren<BallController>();
        ball.gameController = this;

        _dialogueController = Instantiate(dialogueController, new Vector3(0,0,0), Quaternion.identity);
        dialogueScript = _dialogueController.GetComponent<DialogueController>();
        dialogueScript.dialogue = new Dialogue[][] {level.introDialogue, level.outroDialogue, level.failDialogue};
        dialogueScript.rubikVariant = rubikVariant;

        _transitionController = Instantiate(transitionController, new Vector3(0,0,0), Quaternion.identity);
        transitionScript = _transitionController.GetComponent<TransitionController>();
        transitionScript.ball = ball;
        transitionScript.dialogue = dialogueScript;
        transitionScript.cameraSettings = level.cameraSettings;


        loading = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (loading) {
            transitionScript.Intro();
            loading = false;
        } else if (transitionScript.isCameraDefault()) {
            SceneManager.LoadScene(0);
        }
        // Check if Game is being reset
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        // Tilt Controls
        float zDir = 0f;
        float xDir = 0f;

        // If the Ball is in a transition scene disable controls
        if (!transitionScript.isTransitioning)
        {
            // Get Inputs
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

        // If no Z input from player Rotate back to 0 quickly
        // Otherwise Lerp towards input destination
        if (zDir != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, 0f, maxRotation * zDir), Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, 0f, 0f), Time.deltaTime * returnRotationSpeed);
        }

        // If no X input from player Rotate back to 0 quickly
        // Otherwise Lerp towards input destination
        if (xDir != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(maxRotation * xDir, 0f, transform.rotation.eulerAngles.z), Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z), Time.deltaTime * returnRotationSpeed);
        }
    }

    public void Win() {
        transitionScript.Outro(false);
    }

    public void Lose() {
        transitionScript.Outro(true);
    }
    
    public GameObject Instantiate_helper(GameObject obj, Vector3 position, Quaternion rot) {
        return Instantiate(obj, position, rot);
    }

    private Level GetLevel() {
        switch (level) {
            case 0:
                return new Level0();
            case 1:
                return new Level1();
            case 2:
                return new Level1();
            case 3:
                return new Level1();
            case 4:
                return new Level4();
            case 5:
                return new Level5();
            case 6:
                return new BossLevel();
        }
        return new Level1();
    }
}
