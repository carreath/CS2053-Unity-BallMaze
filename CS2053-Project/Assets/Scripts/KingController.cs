using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingController : MonoBehaviour
{
    public AudioSource deathSound;
    public Animator animator;

    public float timer = 2f;
    public int hp = 3;
    public bool isHit;

    // Start is called before the first frame update
    void Start()
    {
        deathSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit) {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                isHit = false;
                animator.SetBool("isDead", false);
                timer = 2f;
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
    }

    public void DIE() {
        deathSound.Play();
        animator.SetBool("isDead", true);
        if (!isHit) {
            isHit = true;
            hp--;
            if (hp <= 0) {
                Destroy(gameObject, 2f);
            }
        }
    }
}
