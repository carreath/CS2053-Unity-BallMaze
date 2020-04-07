using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI nameText;

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
        StartCoroutine(Type());
    }

    private void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueBtn.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach (char name in names[index].ToCharArray())
        {
            nameText.text += name;
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
            textDisplay.text = "";
            nameText.text = "";
            continueBtn.SetActive(false);
        }
    }
}
