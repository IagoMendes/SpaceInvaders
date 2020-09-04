using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliens : MonoBehaviour
{
    public float speed = 0.5f;
    public float wait = 0.4f;
    public float random = 0.02f;
    public bool invert = false;
    public GameObject alienBullet;
    public GameObject alien;
    public GameObject alien2;
    public GameObject alien3;

    public int wave;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AliensAttack", 0, wait);
        wave = 1;
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

        if (gameObject.transform.childCount > 0)
        {
            foreach (Transform alien in gameObject.transform)
            {
                if (alien.position.x < -9 || alien.position.x > 9)
                {
                    invert = true;
                    break;
                }

                if (Random.value < random)
                {
                    Instantiate(alienBullet, alien.position, alien.rotation);
                }
            }
        }
        else
        {
            gameObject.transform.position = new Vector3(0, 0);
            NewWave();
        }

    }

    public void NewWave()
    {
        var actualWave = PlayerPrefs.GetInt("Wave");
        int wave = actualWave + 1;
        PlayerPrefs.SetInt("Wave", wave);
        
        float x, y;
        x = 6f;
        y = 4f;

        for (int j = 0; j <= 2; j++)
        {
            x = 6f;
            for (int i = 0; i <= 6; i++)
            {
                if (wave <= 2)
                {
                    GameObject newAlien = Instantiate(alien, new Vector3(x, y, 0), Quaternion.identity);
                    newAlien.transform.SetParent(transform);
                }
                else if (wave <= 5)
                {
                    speed = 0.8f;
                    random = 0.04f;
                    GameObject newAlien = Instantiate(alien2, new Vector3(x, y, 0), Quaternion.identity);
                    newAlien.transform.SetParent(transform);
                }
                else
                {
                    speed = 1.2f;
                    random = 0.1f;
                    GameObject newAlien = Instantiate(alien3, new Vector3(x, y, 0), Quaternion.identity);
                    newAlien.transform.SetParent(transform);
                }
                x -= 2f;
            }
            y -= 1.5f;
        }
    }
}
