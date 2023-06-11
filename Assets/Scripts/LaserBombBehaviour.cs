using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBombBehaviour : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
