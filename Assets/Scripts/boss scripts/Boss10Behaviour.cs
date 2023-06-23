using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss10Behaviour : MonoBehaviour
{
    [SerializeField] float Speed = 3f;
    [SerializeField] float TimeBetweenShots = .75f;
    [SerializeField] float TimeBetweenLongLasers = 5f;
    [SerializeField] Transform Player;
    [SerializeField] float PlayerPosThreshold = 0.5f;

    void Start()
    {
        StartCoroutine(AttackSimple());
        StartCoroutine(AttackLongLasers());
    }

    void Update()
    {
        if (Player.position.y - PlayerPosThreshold > transform.position.y)
        {
            transform.position += Vector3.up * Speed * Time.deltaTime;
        }
        else if (Player.position.y + PlayerPosThreshold < transform.position.y)
        {
            transform.position += Vector3.down * Speed * Time.deltaTime;
        }
    }

    IEnumerator AttackSimple()
    {
        for (; ; )
        {
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator AttackLongLasers()
    {
        for (; ; )
        {
            yield return new WaitForEndOfFrame();
        }
    }
}
