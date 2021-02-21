using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    public GameObject cubeKing;
    public GameObject player;
    public Text gameOverText;
    public Text restartText;
    public GameObject cage;

    private Animator ckAnim;
    private Animator pAnim;
    private Animator tAnim;
    // Start is called before the first frame update
    void Start()
    {
        pAnim = player.GetComponent<Animator>();
        tAnim = gameOverText.GetComponent<Animator>();
        gameOverText.text = "";
        restartText.text = "";

        if (SceneManager.GetActiveScene().name == "WinOutro")
        {
            ckAnim = cubeKing.GetComponent<Animator>();
            pAnim = player.GetComponent<Animator>();
        }
        else
        {
            pAnim.Play("Empty");
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "WinOutro")
        {
            WinOutroAnim();   
        }
        else if (SceneManager.GetActiveScene().name == "LoseOutro")
        {
            if (cage.transform.position.y <= 0.48 && cage.transform.position.y >= 0.47)
            {
                gameOverText.text = "You Lose!!";
                restartText.text = "Press 'R' to Restart";

                pAnim.Play("loseShakingBall");
                tAnim.Play("winText");                
            }
            Restart();
        }
    }

    void WinOutroAnim()
    {
        if (player.transform.position.x >= -0.3)
        {
            ckAnim.Play("cubeKingFalling");
        }

        if (cubeKing.transform.position.y <= -2.9)
        {
            gameOverText.text = "You Win!!";
            restartText.text = "Press 'R' to Restart";
            tAnim.Play("winText");
            Restart();
            
        }
    }

    void LoseOutroAnim()
    {

    }

    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Intro");
        }
    }
}
