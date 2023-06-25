using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveHandler : MonoBehaviour
{
    static string[] SceneNames = {
        "SampleScene",
        "Wave2",
        "Wave3",
        "Wave4",
        "Wave5Boss",
        "Wave6",
        "Wave7",
        "Wave8",
        "Wave9",
        "Wave10Boss",
        "Wave11",
        "Wave12",
        "Wave13",
        "Wave14",
        "Wave15Boss"
    };

    public static int waveCtr = 0;

    public static void NextWave()
    {
        int oldScore = PlayerPrefs.GetInt("highscore", 0);
        if (oldScore < waveCtr)
        {
            PlayerPrefs.SetInt("highscore", waveCtr);
        }
        waveCtr += 1;
        SceneManager.LoadScene(SceneNames[waveCtr % SceneNames.Length]);
    }
}
