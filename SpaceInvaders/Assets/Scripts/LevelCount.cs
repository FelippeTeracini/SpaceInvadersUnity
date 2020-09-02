using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCount : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Text>().text = "Level: " + gameManager.levelCount.ToString();
    }

    // Update is called once per frame
    public void UpdateText()
    {
        gameObject.GetComponent<Text>().text = "Level: " + gameManager.levelCount.ToString();
    }
}
