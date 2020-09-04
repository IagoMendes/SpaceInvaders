using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    void Update()
    {
        int actualScore = PlayerPrefs.GetInt("ActualScore");
        int highScore = PlayerPrefs.GetInt("HighScore");
        gameObject.GetComponent<Text>().text = "Actual Score: " + actualScore.ToString() + "\n" + "High Score: " + highScore.ToString();
    }
}
