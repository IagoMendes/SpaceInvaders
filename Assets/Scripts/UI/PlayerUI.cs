using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        float lives = player.GetComponent<Player>().lives;
        gameObject.GetComponent<Text>().text = "Lives: " + lives.ToString();
    }
}
