using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Text>().text = "Lives: " + player.lives.ToString();
    }

    // Update is called once per frame
    public void UpdateText()
    {
        gameObject.GetComponent<Text>().text = "Lives: " + player.lives.ToString();
    }
}
