using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    private void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
    }
}
