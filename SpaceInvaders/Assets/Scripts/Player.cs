using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0.5f;
    private Vector3 position;
    private float bound = 8;

    public bool paused = false;

    public GameObject bullet;
    public GameObject explosion;
    public float wait = 0.3f;
    private float timer = 0;
    public int lives = 3;
    public PlayerLives playerLives;
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        position += Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if (Input.GetAxis("Mouse X") != 0)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.x = worldPosition.x;
        }

        timer += Time.deltaTime;
        if (timer > wait && Input.GetButton("Fire1") && !paused)
        {
            timer = 0;
            audioManager.Play("Shoot");
            Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        }




        if (position.x < -bound)
        {
            position.x = -bound;
        }
        else if (position.x > bound)
        {
            position.x = bound;
        }

        if (!paused) {
            transform.position = position;
        }
    }

    public void UpdateLife()
    {
        lives -= 1;
        playerLives.UpdateText();
        audioManager.Play("Explosion");
        Instantiate(explosion, transform.position, transform.rotation);
        if (lives <= 0)
        {
            Destroy(gameObject);
        }
    }
}
