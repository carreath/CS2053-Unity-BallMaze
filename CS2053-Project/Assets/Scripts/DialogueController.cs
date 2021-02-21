using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public Animator animator;

    public Canvas canvas;
    private Text nameText;
    private Text dialogueText;
    private Text sanityText;
    
    private Canvas _canvas;

    public enum ActiveDialogue {
        Intro = 0,
        Outro = 1,
        Fail = 2
    }

    public Dialogue[][] dialogue;
    public int rubikVariant;
    public bool dialogueStarted;
    public bool isComplete;
    public bool noDialogue;

    private ActiveDialogue activeDialogue;
    private int dialogueIndex;

    private GameObject rubik;
    private GameObject king;

    void Start() {
        _canvas = Instantiate(canvas, new Vector3(0,0,0), Quaternion.identity);
        animator = _canvas.transform.GetComponentsInChildren<Animator>()[0];
        nameText = _canvas.transform.GetComponentsInChildren<Text>()[0];
        dialogueText = _canvas.transform.GetComponentsInChildren<Text>()[1];
        sanityText = _canvas.transform.GetComponentsInChildren<Text>()[3];

        foreach(Transform child in _canvas.transform) {
            if (child.name == "DialoguePanel") {
                foreach(Transform child2 in child) {
                    if (child2.name == "Rubik") {
                        rubik = child2.gameObject;
                    } else if (child2.name == "CubeKing") {
                        king = child2.gameObject;
                    }
                }
            }
        }

        Transform rubikContainer = rubik.transform.GetChild(0).GetChild(0).GetChild(0);
        foreach (Transform child in rubikContainer) {
            Debug.Log(child.name);
            if (child.name != "RubiK-" + rubikVariant) {
                child.gameObject.SetActive(false);
            }
        }

        rubik.SetActive(false);
        king.SetActive(false);
    }

    // Start is called before the first frame update
    void Update()
    {   
        if (dialogueStarted && !isComplete) {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                dialogueIndex++;
                showNextSentence();
            }
        } else if (isComplete) {
            dialogueStarted = false;
            animator.SetBool("isOpen", false);
        }
    }

    public void showNextSentence() {
        rubik.SetActive(false);
        king.SetActive(false);
        if (dialogueIndex >= dialogue[(int)activeDialogue].Length) {
            isComplete = true;
        } else {
            switch (dialogue[(int)activeDialogue][dialogueIndex].speaker) {
                case Dialogue.Speaker.King:
                    nameText.text = "Cube King";
                    king.SetActive(true);
                    break;
                case Dialogue.Speaker.Rubik:
                    nameText.text = "Rubi K.";
                    rubik.SetActive(true);
                    break;
                case Dialogue.Speaker.Player:
                    nameText.text = "You";
                    break;               
            }
            StopAllCoroutines();
            StartCoroutine(TypeSentence(dialogue[(int)activeDialogue][dialogueIndex].text, dialogue[(int)activeDialogue][dialogueIndex].speed));
        }
    }

    public void setCamera(Camera camera) {
        _canvas.worldCamera = camera;
    }

    IEnumerator TypeSentence(string sentence, int speed) {
        dialogueText.text = "";
        int count = 0;
        foreach (char letter in sentence.ToCharArray()) {
            // Play Voice Sound Here

            if (king.active && count++ % 6 == 0) {
                king.GetComponent<AudioSource>().Play(0);
            }
            if (rubik.active && count++ % 6 == 0) {
                rubik.GetComponent<AudioSource>().Play(0);
            }

            dialogueText.text += letter;
            for (int i=0; i<100; i+=10*speed) {
                yield return null;
            }
        }
    }

    public void startIntroDialogue() {
        if (dialogue[0].Length == 0) {
            noDialogue = true;
        } else {
            animator.SetBool("isOpen", true);
            activeDialogue = ActiveDialogue.Intro;
            dialogueIndex = 0;
            dialogueStarted = true;
            isComplete = false;
            showNextSentence();
        }
    }
    
    public void startOutroDialogue() {
        if (dialogue[1].Length == 0) {
            noDialogue = true;
        } else {
            animator.SetBool("isOpen", true);
            activeDialogue = ActiveDialogue.Outro;
            dialogueIndex = 0;
            dialogueStarted = true;
            isComplete = false;
            showNextSentence();
        }
    }

    public void startFailDialogue() {
        if (dialogue[2].Length == 0) {
            noDialogue = true;
        } else {
            animator.SetBool("isOpen", true);
            activeDialogue = ActiveDialogue.Fail;
            dialogueIndex = 0;
            dialogueStarted = true;
            isComplete = false;
            showNextSentence();
        }
    }

    public void setSanityText(int sanity) {
        sanityText.text = "Sanity: " + sanity;
    }
}
