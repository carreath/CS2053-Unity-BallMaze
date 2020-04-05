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
    public bool dialogueStarted;
    public bool isComplete;

    private ActiveDialogue activeDialogue;
    private int dialogueIndex;

    void Start() {
        _canvas = Instantiate(canvas, new Vector3(0,0,0), Quaternion.identity);
        animator = _canvas.transform.GetComponentsInChildren<Animator>()[0];
        nameText = _canvas.transform.GetComponentsInChildren<Text>()[0];
        dialogueText = _canvas.transform.GetComponentsInChildren<Text>()[1];
        sanityText = _canvas.transform.GetComponentsInChildren<Text>()[3];
    }

    // Start is called before the first frame update
    void Update()
    {   if (dialogueStarted && !isComplete) {
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
        if (dialogueIndex >= dialogue[(int)activeDialogue].Length) {
            isComplete = true;
        } else {
            switch (dialogue[(int)activeDialogue][dialogueIndex].speaker) {
                case Dialogue.Speaker.King:
                    nameText.text = "Cube King";
                    break;
                case Dialogue.Speaker.Rubik:
                    nameText.text = "Rubik";
                    break;
                case Dialogue.Speaker.Player:
                    nameText.text = "You";
                    break;               
            }
            StopAllCoroutines();
            StartCoroutine(TypeSentence(dialogue[(int)activeDialogue][dialogueIndex].text, dialogue[(int)activeDialogue][dialogueIndex].speed));
        }
    }

    IEnumerator TypeSentence(string sentence, int speed) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            // Play Voice Sound Here
            dialogueText.text += letter;
            if (speed < 10) {
                for (int i=0; i<100; i+=10*speed) {
                    yield return null;
                }
            }
        }
    }

    public void startIntroDialogue() {
        animator.SetBool("isOpen", true);
        activeDialogue = ActiveDialogue.Intro;
        dialogueIndex = 0;
        dialogueStarted = true;
        isComplete = false;
        showNextSentence();
    }
    
    public void startOutroDialogue() {
        animator.SetBool("isOpen", true);
        activeDialogue = ActiveDialogue.Outro;
        dialogueIndex = 0;
        dialogueStarted = true;
        isComplete = false;
        showNextSentence();
    }

    public void startFailDialogue() {
        animator.SetBool("isOpen", true);
        activeDialogue = ActiveDialogue.Fail;
        dialogueIndex = 0;
        dialogueStarted = true;
        isComplete = false;
        showNextSentence();
    }

    public void setSanityText(int sanity) {
        sanityText.text = "Sanity: " + sanity;
    }
}
