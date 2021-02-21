using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public GameObject obj;
    public GameObject[] objects;
    public Text startText;

    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI nameText;
    public string currentName;

    public ButtonController btnController;

    public string[] sentences = new string[] {
        "The Cube King has taken you (the top Spherical General of the Revolutionary Army) captive after a long and fierce battle in the war of shapes.",
        "Ha Ha Ha ! I've finally caught you!",
        "To ensure he is able to maintain his edge in the war the King knows he must squeeze every bit of information out of you.",
        "To accomplish this task the Cube King employs his top cube scientist Rubi K... ",
        "Rubi K. has developed a rigorous set of impossible puzzles with the help of the top edgechelon of cube interrogators. ",
        "My King, I've made these puzzles, let's trap him there and make him talk.",
        "These puzzles will break  any sphere that rolls in. Will they break you? Or will you escape and finish the war  once and for all?",
    };
    public string[] names = new string[] {
        "Narrator:", 
        "Cube King",
        "Narrator:",
        "Narrator:",
        "Narrator:",
        "RubiK:",
        "Narrator:",
    };
    public float typingSpeed;
    public GameObject continueBtn;

    private int index;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        objects = GameObject.FindGameObjectsWithTag("Text");
        StartCoroutine(Type());
    }

    private void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueBtn.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                NextSentence();
            }
        }

        if (startText.text == "Start Escape!") {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                btnController.SendMessage("StartGame");
            }
        }
    }

    IEnumerator Type()
    {
        foreach (char name in names[index].ToCharArray())
        {
            nameText.text += name;
            SetName(names[index]);
        }

        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

    }

    public void NextSentence()
    {
        audio.Play();
        continueBtn.SetActive(false);
        if(index<sentences.Length  - 1)
        {
            index++;
            nameText.text = "";
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            EndAnimation();
        }
    }

    private void EndAnimation()
    {
        textDisplay.text = "";
        nameText.text = "";
        continueBtn.SetActive(false);

        obj.SetActive(false);
        foreach (GameObject o in objects)
        {
            o.SetActive(false);
        }

        startText.text = "Start Escape!";
    }

    private void SetName(string name)
    {
        currentName = name.Remove(name.Length - 1);
    }

    public string GetName()
    {
        return currentName;
    }
}
