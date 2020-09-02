using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed = 0.5f;
    public float moveWait = 0.4f;
    public float attackWait = 0.1f;
    public float bound = 7.9f;
    private bool invert = false;

    public float bulletRate = 5f;
    public GameObject bullet;
    Player player;

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

    public int pauseCounter = 10;
    bool attacking = false;

    void Start()
    {
        InvokeRepeating("BossMovement", 0, moveWait);
        InvokeRepeating("BossAttack", 0, attackWait);

        player = GameObject.FindObjectOfType<Player>();

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

    void BossMovement()
    {
        if (invert)
        {
            speed = -speed;
            invert = false;
            return;
        }
        else
        {
            gameObject.transform.position += Vector3.right * speed;
        }

        if (transform.position.x < -bound || transform.position.x > bound)
        {
            invert = true;
        }
    }

    void BossAttack() {
        if (attacking) {
            Vector3 dirShot = (player.transform.position - transform.position).normalized;

            GameObject b = Instantiate(bullet, transform.position, Quaternion.LookRotation(Vector3.forward, -dirShot));
            b.GetComponent<AlienBullet>().ChangeDirection(dirShot);
            pauseCounter--;

            if (pauseCounter < 0) {
                attacking = false;
            }
        } else {
            pauseCounter += 2;
            if (pauseCounter > 10) {
                attacking = true;
            }
        }
    }

    // void BossAttack2() {
    //     GameObject b = Instantiate(bullet, transform.position, transform.rotation);
    //     b.GetComponent<AlienBullet>().ChangeDirection((player.transform.position - transform.position).normalized);
    // }
}
