using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public GameObject aliens;
    public GameObject player;
    public GameManager gameManager;
    // Update is called once per frame
    void Start()
    {
        gameObject.GetComponent<Text>().text = " ";
    }

    public void UpdateText(string text) {
        gameObject.GetComponent<Text>().text = text;
    }
}
