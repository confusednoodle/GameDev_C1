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
         "Wave4"
    };

    static int waveCtr = 0;

    public static void NextWave()
    {
        waveCtr += 1;
        SceneManager.LoadScene(SceneNames[waveCtr]);
    }
}
