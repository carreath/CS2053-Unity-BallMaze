using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
      
        Debug.Log(anim);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
