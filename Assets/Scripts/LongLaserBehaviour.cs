using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongLaserBehaviour : MonoBehaviour
{
    public float scale = 0.1f;

    private void Update()
    {
        scale += 0.5f;
        transform.localScale = new Vector3(1, scale, 1);
    }
}
