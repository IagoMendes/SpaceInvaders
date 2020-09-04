using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var actualScore = PlayerPrefs.GetInt("ActualScore");
        gameObject.GetComponent<Text>().text = "Score: " + actualScore.ToString();
    }
}
