using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterBall : MonoBehaviour
{
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * -1 * Time.deltaTime * 5.0f;

        Object.Destroy(gameObject, 10.0f);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Wall") {
            Object.Destroy(gameObject);
        }
        if (collision.gameObject.tag =="BouncyWall") {
            Object.Destroy(gameObject);
        }
    }
}
