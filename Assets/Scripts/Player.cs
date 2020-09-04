using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float bound = 9f;
    public Vector3 position;
    public float speed = 0.3f;

    public GameObject bullet;
    public float wait = 0.2f;
    private float timer = 0;

    public float lives;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Wave", 1);
        PlayerPrefs.SetInt("ActualScore", 0);
        lives = 3f;
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position += Vector3.right * Input.GetAxis("Horizontal") * speed;

        if (Input.GetAxis("Mouse X") != 0)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.x = worldPosition.x;
        }

        float dh = Input.GetAxis("Horizontal");
        if ((gameObject.transform.position.x > -bound || dh > 0) &&
           (gameObject.transform.position.x < bound || dh < 0))
        {
            gameObject.transform.position += Vector3.right * dh * speed * Time.deltaTime;
        }

        timer += Time.deltaTime;
        if (timer > wait && Input.GetButton("Fire1"))
        {
            timer = 0;
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

        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "AlienBullet")
        {
            lives -= 1;
            Destroy(collision.gameObject);
        }

        if (lives <= 0)
        {
            if (PlayerPrefs.GetInt("ActualScore") > PlayerPrefs.GetInt("HighScore"))
                PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("ActualScore"));
            gameManager.EndGame();
        }
    }
}
