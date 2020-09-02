using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliens : MonoBehaviour
{
    public float speed = 0.5f;
    public float wait = 0.4f;
    public float bound = 7.9f;
    private bool invert = false;
    public float shootProb = 0.02f;
    public GameObject bullet;
    public GameManager gameManager;
    public GameObject alien;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AliensAttack", 0, wait);
    }

    public void spawnAliens()
    {
        for (int i = -6; i <= 6; i += 2)
        {
            for (double j = 3.5; j >= 1.5; j -= 1)
            {
                Vector3 alienPosition = new Vector3(i, (float)j, 0);
                GameObject newalien = Instantiate(alien, alienPosition, Quaternion.identity);
                newalien.transform.parent = gameObject.transform;
            }
        }
    }

    // Update is called once per frame
    void AliensAttack()
    {
        if (invert)
        {
            speed = -speed;
            gameObject.transform.position += Vector3.down * Mathf.Abs(speed);
            invert = false;
            return;
        }
        else
        {
            gameObject.transform.position += Vector3.right * speed;
        }

        foreach (Transform alien in gameObject.transform)
        {
            if (alien.position.x < -bound || alien.position.x > bound)
            {
                invert = true;
                break;
            }

            if (Random.value < shootProb)
            {
                Instantiate(bullet, alien.position, alien.rotation);
            }
        }
    }
}
