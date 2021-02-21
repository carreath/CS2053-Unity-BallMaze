using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterController : MonoBehaviour
{
    public GameObject EmitterBall;
    public float emittTime = 1.5f;

    // Update is called once per frame
    void Update()
    {
        emittTime -= Time.deltaTime;

        if (emittTime <= 0.0f)
        {
            GameObject emitterBall = Instantiate(EmitterBall, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            emitterBall.transform.SetParent(transform);
            //Physics.IgnoreCollision(emitterBall.GetComponent<Collider>(), transform.parent.GetComponent<Collider>());
            emittTime = 1.5f;
        }
    }
}
