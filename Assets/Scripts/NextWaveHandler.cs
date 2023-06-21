using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWaveHandler : MonoBehaviour
{
    [SerializeField] Transform EnemyContainer;

    bool nextWaveLoaded = false;

    // Update is called once per frame
    void Update()
    {
        if (EnemyContainer.childCount <= 0 && !nextWaveLoaded)
        {
            WaveHandler.NextWave();
            nextWaveLoaded = true;
        }
    }
}
