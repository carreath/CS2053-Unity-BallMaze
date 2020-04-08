using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Dialog dialog;
    private Material mat;

    GameObject cage; 

    private Animator anim;
    private string currentName;
    private bool first;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        cage = GameObject.FindGameObjectWithTag("Cage");
        first = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentName = dialog.GetName();

        if(currentName == gameObject.name)
        {
            anim.Play("Floating");
        }
        else
        {
            anim.Play("Empty");
        }
    }

}
