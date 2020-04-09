using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public GameObject cage; 

    private Animator animm;
    // Start is called before the first frame update
    void Start()
    {
        animm = GetComponent<Animator>();
        
       /// animm.Play("Empty");
    }

    // Update is called once per frame
    void Update()
    {
        if (cage.transform.position.y >= 0.867 && cage.transform.position.y <= 0.871)
        {
            animm.Play("shaking");
        }
        else
        {
            animm.Play("Empty");
        }
    }
}
