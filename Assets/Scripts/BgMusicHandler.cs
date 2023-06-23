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
        SharedState.BgMusicPosition = BgMusic.time;
    }
}
