using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderBehaviour : MonoBehaviour
{
    [SerializeField] bool isForLongLaser = false;
    [SerializeField] bool isForLongEnemyLaser = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser" || collision.gameObject.tag == "EnemyLaser")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "LongLaser" && isForLongLaser)
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "EnemyLongLaser" && isForLongEnemyLaser)
        {
            Destroy(collision.gameObject);
        }
    }
}
