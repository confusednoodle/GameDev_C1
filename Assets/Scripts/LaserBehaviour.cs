using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    private void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }
}
