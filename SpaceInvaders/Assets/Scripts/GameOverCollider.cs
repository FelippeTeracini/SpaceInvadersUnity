using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCollider : MonoBehaviour
{
    GameManager gameManager;

    private void Start() {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Alien") {
            gameManager.Lose();
        }
    }
}
