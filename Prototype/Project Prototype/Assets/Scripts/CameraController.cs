using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool transition;

    public float transitionSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        transition = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transition) {
            if (transform.position.y > 10) {
                transform.position = Vector3.Lerp(transform.position, new Vector3(0, 10, -6), transitionSpeed * Time.deltaTime);
            }
            if (transform.rotation.eulerAngles.x > 60) {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(60f, 0f, 0f), transitionSpeed * Time.deltaTime);
            }
            if (transform.position.y <= 10 && transform.rotation.eulerAngles.x <= 60) {
                transition = false;
            }
        }
    }

    public void OnTransitionComplete() 
    {
        transition = true;
    }
}
