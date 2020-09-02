using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour
{
    public float speed = 5f;
    private Player player;
    Vector3 direction = Vector3.down;
    
    // private void Start() {
    //     direction = Vector3.down;
    // }

    void Update()
    {
        gameObject.transform.position += direction * speed * Time.deltaTime;
    }

    public void ChangeDirection(Vector3 dir) {
        direction = dir;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = collision.GetComponent<Player>();
            player.UpdateLife();
            Destroy(gameObject);

        }
        if (collision.tag == "Base")
        {
            Destroy(gameObject);
        }

    }
}
