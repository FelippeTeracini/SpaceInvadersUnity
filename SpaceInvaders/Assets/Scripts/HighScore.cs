using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameObject.GetComponent<Text>().text = "HighScore: " + gameManager.highscore.ToString();
    }

    void Update()
    {
        gameObject.GetComponent<Text>().text = "HighScore: " + gameManager.highscore.ToString();
    }
}
