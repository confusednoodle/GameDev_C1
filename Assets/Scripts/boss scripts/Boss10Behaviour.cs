using System.Collections;
using UnityEngine;

public class Boss10Behaviour : MonoBehaviour
{
    // General
    [SerializeField] float Speed = 3f;
    [SerializeField] float TimeBetweenShots = .75f;
    [SerializeField] float TimeBetweenLongLasers = 5f;
    [SerializeField] int Health = 20;
    [Space]
    // Attacks
    [SerializeField] EnemyLaser EnemyLaserPrefab;
    [Space]
    // Localization
    [SerializeField] Transform SingleLaserUp;
    [SerializeField] Transform SingleLaserDown;
    [SerializeField] Transform LongLaserUp;
    [SerializeField] Transform LongLaserDown;
    // Other Objects
    [Space]
    [SerializeField] Transform Player;
    [SerializeField] float PlayerPosThreshold = 0.5f;
    [SerializeField] TextMesh HealthLabel;

    void Start()
    {
        StartCoroutine(AttackSimple());
        StartCoroutine(AttackLongLasers());
    }

    void Update()
    {
        if (Health >= 0) { HealthLabel.text = Health.ToString(); } else { HealthLabel.text = ""; };

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
            Instantiate(EnemyLaserPrefab, SingleLaserUp.position, Quaternion.Euler(0, 0, 90));
            yield return new WaitForSeconds(TimeBetweenShots);
            Instantiate(EnemyLaserPrefab, SingleLaserDown.position, Quaternion.Euler(0, 0, 90));
            yield return new WaitForSeconds(TimeBetweenShots);
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
