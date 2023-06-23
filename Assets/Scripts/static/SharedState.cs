using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedState : MonoBehaviour
{
    public static float BgMusicPosition = 0f;
    public static float BgMusicVolume = 1f;

    public static bool GodMode = false;

    public static ParticleSystem.PlaybackState StarFieldPlaybackState;
    public static ParticleSystem.Particle[] StarFieldParticles = { };
    public static ParticleSystem.Trails StarFieldTrails;
}
