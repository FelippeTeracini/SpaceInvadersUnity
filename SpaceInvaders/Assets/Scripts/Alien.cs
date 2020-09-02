using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    GameManager gameManager;
    public GameObject explosion;
    public GameObject hit;
    AudioManager audioManager;

    public int health = 1;

    private SpriteRenderer myRenderer;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;
    public int scoreValue = 10;

    public float shootProb = 0.02f;

    public float wait = 0.1f;
    private float timer = 0;
    private bool damage = false;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default");
    }


    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > wait && damage)
        {
            damage = false;
            timer = 0;
            normalSprite();
        }
    }

    public void TakeHit()
    {
        gameManager.score += scoreValue;

        health -= 1;

        if (health <= 0)
        {
            Die();
        }
        else
        {
            damage = true;
            audioManager.Play("Hit");
            timer = 0;
            whiteSprite();
            Instantiate(hit, transform.position, transform.rotation);
        }
    }

    public void Die()
    {
        audioManager.Play("Explosion");

        Instantiate(explosion, transform.position, transform.rotation);

        Destroy(gameObject);
    }

    void whiteSprite()
    {
        myRenderer.material.shader = shaderGUItext;
        myRenderer.color = Color.white;
    }

    void normalSprite()
    {
        myRenderer.material.shader = shaderSpritesDefault;
        myRenderer.color = Color.white;
    }
}
