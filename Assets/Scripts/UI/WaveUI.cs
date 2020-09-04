using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    void Update()
    {
        var actualWave = PlayerPrefs.GetInt("Wave");
        gameObject.GetComponent<Text>().text = "Wave: " + actualWave.ToString();
    }
}
