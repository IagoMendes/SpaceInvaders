using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerBase : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Alien" || collision.tag == "Alien2" || collision.tag == "Alien3")
        {
            gameManager.EndGame();
        }
    }
}
