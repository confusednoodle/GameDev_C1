using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] TMP_Text HighScoreText;

    // Start is called before the first frame update
    void Start()
    {
        SharedState.BgMusicPosition = 0f;
        SharedState.BgMusicVolume = 1f;
        WaveHandler.waveCtr = 0;
        HighScoreText.text = "Highscore: " + PlayerPrefs.GetInt("highscore", 0).ToString();
    }

    public void StartScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
