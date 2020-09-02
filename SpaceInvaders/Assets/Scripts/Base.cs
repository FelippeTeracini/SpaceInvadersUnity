using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    AudioManager audioManager;

    private void Start() {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Alien") {
            audioManager.Play("Hit");
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Bullet") {
            audioManager.Play("Hit");
            Destroy(gameObject);
        }
    }
}
