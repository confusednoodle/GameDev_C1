using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFieldHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem ParticleSystem;
    [SerializeField] bool DontGetState = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!DontGetState)
        {
            ParticleSystem.SetPlaybackState(SharedState.StarFieldPlaybackState);
            ParticleSystem.SetParticles(SharedState.StarFieldParticles);
            ParticleSystem.SetTrails(SharedState.StarFieldTrails);
        }
    }
    void Update()
    {
        SharedState.StarFieldPlaybackState = ParticleSystem.GetPlaybackState();
        ParticleSystem.GetParticles(SharedState.StarFieldParticles);
        SharedState.StarFieldTrails = ParticleSystem.GetTrails();
    }
}
