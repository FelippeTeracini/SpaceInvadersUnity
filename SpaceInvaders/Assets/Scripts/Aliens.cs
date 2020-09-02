using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliens : MonoBehaviour
{
    public float speed = 0.5f;
    public float wait = 0.4f;
    public float bound = 7.9f;
    private bool invert = false;

    public float bulletRate = 5f;
    public GameObject bullet;
    public GameManager gameManager;
    public GameObject alien;
    public GameObject alien2;
    public GameObject alien3;
    public GameObject boss;

    void Start()
    {
        InvokeRepeating("AliensAttack", 0, wait);
    }

    public void spawnAliens()
    {
        if (gameManager.levelCount == 1)
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
        else if (gameManager.levelCount == 2)
        {
            for (int i = -6; i <= 6; i += 2)
            {
                Vector3 alienPosition = new Vector3(i, 3.5f, 0);
                GameObject newalien = Instantiate(alien2, alienPosition, Quaternion.identity);
                newalien.transform.parent = gameObject.transform;

            }
            for (int i = -6; i <= 6; i += 2)
            {
                for (double j = 2.5; j >= 1.5; j -= 1)
                {
                    Vector3 alienPosition = new Vector3(i, (float)j, 0);
                    GameObject newalien = Instantiate(alien, alienPosition, Quaternion.identity);
                    newalien.transform.parent = gameObject.transform;
                }
            }
        }
        else if (gameManager.levelCount == 3)
        {
            for (int i = -6; i <= 6; i += 2)
            {
                for (double j = 3.5; j >= 1.5; j -= 1)
                {
                    Vector3 alienPosition = new Vector3(i, (float)j, 0);
                    GameObject newalien = Instantiate(alien2, alienPosition, Quaternion.identity);
                    newalien.transform.parent = gameObject.transform;
                }
            }
        }

        else if (gameManager.levelCount == 4)
        {
            for (int i = -6; i <= 6; i += 2)
            {
                Vector3 alienPosition = new Vector3(i, 3.5f, 0);
                GameObject newalien = Instantiate(alien3, alienPosition, Quaternion.identity);
                newalien.transform.parent = gameObject.transform;

            }
            for (int i = -6; i <= 6; i += 2)
            {
                for (double j = 2.5; j >= 1.5; j -= 1)
                {
                    Vector3 alienPosition = new Vector3(i, (float)j, 0);
                    GameObject newalien = Instantiate(alien2, alienPosition, Quaternion.identity);
                    newalien.transform.parent = gameObject.transform;
                }
            }
        }

        else if (gameManager.levelCount >= 5)
        {
            for (int i = -6; i <= 6; i += 2)
            {
                for (double j = 3.5; j >= 1.5; j -= 1)
                {
                    Vector3 alienPosition = new Vector3(i, (float)j, 0);
                    GameObject newalien = Instantiate(alien3, alienPosition, Quaternion.identity);
                    newalien.transform.parent = gameObject.transform;
                }
            }
        }

        else if (gameManager.levelCount >= 5) {

        }
    }


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

            if (Random.value < alien.GetComponent<Alien>().shootProb)
            {
                Instantiate(bullet, alien.position, alien.rotation);
            }

            // if (gameObject.transform.childCount < 11)
            // {
            //     wait *= 2f;
            // }
        }
    }
}
