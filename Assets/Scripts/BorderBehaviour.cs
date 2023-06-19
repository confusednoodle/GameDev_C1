using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderBehaviour : MonoBehaviour
{
    [SerializeField] bool isForLongLaser = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "LongLaser" && isForLongLaser)
        {
            Destroy(collision.gameObject);
        }
    }
}
