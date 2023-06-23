using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusicHandler : MonoBehaviour
{
    [SerializeField] AudioSource BgMusic;

    void Start()
    {
        BgMusic.time = SharedState.BgMusicPosition;
    }

    // Update is called once per frame
    void Update()
    {
        BgMusic.volume = SharedState.BgMusicVolume;
        SharedState.BgMusicPosition = BgMusic.time;
    }

    public static IEnumerator FadeOutBgMusic()
    {
        while (SharedState.BgMusicVolume > 0)
        {
            SharedState.BgMusicVolume -= 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
