using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameObject.GetComponent<Text>().text = "Score: " + gameManager.score.ToString();
    }

    void Update()
    {
        gameObject.GetComponent<Text>().text = "Score: " + gameManager.score.ToString();
    }
}
