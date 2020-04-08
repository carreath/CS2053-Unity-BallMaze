using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Load Level1");
        Debug.Log("Unload this scene");
        SceneManager.LoadScene("Level 1");
    }
}
