using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    GameManager gameManager;
    public GameObject explosion;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        gameObject.transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Alien")
        {
            collision.GetComponent<Alien>().TakeHit();
            Destroy(gameObject);
        }

        if (collision.tag == "Boss")
        {
            collision.GetComponent<Boss>().TakeHit();
            Destroy(gameObject);
        }

        if (collision.tag == "Base")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Bullet")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
}
