using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private float lives = 1.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Alien" || collision.tag == "Alien2" || collision.tag == "Alien3")
        {
            lives = 0.0f;
            Destroy(gameObject);
        }
        if (collision.tag == "AlienBullet")
        {
            lives -= 0.5f;
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Bullet")
        {
            lives -= 0.75f;
            Destroy(collision.gameObject);
        }
        if (lives <= 0)
        {
            Destroy(gameObject);
        }
    }
}
