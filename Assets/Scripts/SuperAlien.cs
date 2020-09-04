using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperAlien : MonoBehaviour
{
    public float speed = 3f;
    public float wait = 0.2f;
    public bool invert = false;
    public GameObject alienBullet;

    private float lives = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AliensAttack", 0, wait);
    }

    void AliensAttack()
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

        if (gameObject.transform.position.x < -8 || gameObject.transform.position.x > 8)
        {
            invert = true;
        }

        if (Random.value < 0.1f)
        {
            Instantiate(alienBullet, gameObject.transform.position, gameObject.transform.rotation);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            lives -= 1;
            Destroy(collision.gameObject);

            if (lives <= 0) 
            {
                //Sound
                AudioSource yodahi = collision.GetComponent<AudioSource>();
                if (yodahi == null) yodahi = gameObject.AddComponent<AudioSource>();
                yodahi.clip = Resources.Load<AudioClip>("SuperAlienDies");
                AudioSource.PlayClipAtPoint(yodahi.clip, transform.position);

                //Score
                var actualScore = PlayerPrefs.GetInt("ActualScore");
                PlayerPrefs.SetInt("ActualScore", actualScore + 500);

                Destroy(gameObject);
            }
        }
    }
}
