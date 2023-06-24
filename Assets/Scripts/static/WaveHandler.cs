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

    static int waveCtr = 0;

    public static void NextWave()
    {
        int oldScore = PlayerPrefs.GetInt("highscore", 0);
        PlayerPrefs.SetInt("highscore", oldScore + 1);
        waveCtr += 1;
        SceneManager.LoadScene(SceneNames[waveCtr % SceneNames.Length]);
    }
}
