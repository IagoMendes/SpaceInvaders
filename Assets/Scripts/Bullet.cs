using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;

    void Start()
    {
        AudioSource piu = GetComponent<AudioSource>();
        if (piu == null) piu = gameObject.AddComponent<AudioSource>();
        piu.clip = Resources.Load<AudioClip>("Bullet");
        piu.Play();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.up * speed * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Alien")
        {
            //Logic
            var actualScore = PlayerPrefs.GetInt("ActualScore");
            PlayerPrefs.SetInt("ActualScore", actualScore + 25);

            AudioSource slap = collision.GetComponent<AudioSource>();
            if (slap == null) slap = gameObject.AddComponent<AudioSource>();
            slap.clip = Resources.Load<AudioClip>("AlienDies");
            AudioSource.PlayClipAtPoint(slap.clip, transform.position, 0.5f);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.tag == "Alien2")
        {
            //Logic
            var actualScore = PlayerPrefs.GetInt("ActualScore");
            PlayerPrefs.SetInt("ActualScore", actualScore + 50);

            AudioSource slap = collision.GetComponent<AudioSource>();
            if (slap == null) slap = gameObject.AddComponent<AudioSource>();
            slap.clip = Resources.Load<AudioClip>("AlienDies");
            AudioSource.PlayClipAtPoint(slap.clip, transform.position, 0.5f);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.tag == "Alien3")
        {
            //Logic
            var actualScore = PlayerPrefs.GetInt("ActualScore");
            PlayerPrefs.SetInt("ActualScore", actualScore + 75);

            AudioSource slap = collision.GetComponent<AudioSource>();
            if (slap == null) slap = gameObject.AddComponent<AudioSource>();
            slap.clip = Resources.Load<AudioClip>("AlienDies");
            AudioSource.PlayClipAtPoint(slap.clip, transform.position, 0.5f);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.tag == "AlienBullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
