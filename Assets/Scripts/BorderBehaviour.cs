using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderBehaviour : MonoBehaviour
{
    [SerializeField] Collider2D collider1;
    [SerializeField] Collider2D collider2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            Physics2D.IgnoreCollision(collider1, collider2);
        }
    }
}
