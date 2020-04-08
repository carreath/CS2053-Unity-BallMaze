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

    public string[] sentences;
    public string[] names;
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

            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextSentence();
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
