using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss15Behaviour : MonoBehaviour
{
    // General
    [SerializeField] float Speed = 3f;
    [SerializeField] float TimeBetweenShots = .75f;
    [SerializeField] float TimeBetweenLongLasers = 5f;
    [SerializeField] float RadianceCooldown = 10f;
    [SerializeField] int Health = 50;
    [Space]
    // Attacks
    [SerializeField] EnemyLaser EnemyLaserPrefab;
    [SerializeField] LongLaserBehaviour EnemyLongLaserPrefab;
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
    [SerializeField] SpriteRenderer[] SpriteRenderers;
    [SerializeField] ParticleSystem DestroyParticleSystem;
    [SerializeField] ParticleSystem ThrustParticleSystem;
    [SerializeField] AudioSource DestructionAudio;
    [SerializeField] Transform spawnPosition;

    bool destroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AttackSimple());
        StartCoroutine(AttackLongLasers());
    }

    // Update is called once per frame
    void Update()
    {
        if (Health >= 0) { HealthLabel.text = Health.ToString(); } else { HealthLabel.text = ""; };

        if (Health <= 0 && !destroyed)
        {
            StartCoroutine(DestroyEnemy());
            destroyed = true;
        }

        if (Player.position.y - PlayerPosThreshold > transform.position.y && Health > 0)
        {
            transform.position += Vector3.up * Speed * Time.deltaTime;
        }
        else if (Player.position.y + PlayerPosThreshold < transform.position.y && Health > 0)
        {
            transform.position += Vector3.down * Speed * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        //Radiance Attack
        if (RadianceCooldown > 0)
        {
            RadianceCooldown -= 0.1f;
        }
        else
        {
            int temp = Random.Range(0, 5);
            for (int i = 0; i < 5; i++)
            {
                if (i != temp)
                {
                    Instantiate(EnemyLaserPrefab, new Vector3(spawnPosition.position.x, spawnPosition.position.y + i, 0f), Quaternion.Euler(0f, 0f, 90f));
                    Instantiate(EnemyLaserPrefab, new Vector3(spawnPosition.position.x, spawnPosition.position.y - i, 0f), Quaternion.Euler(0f, 0f, 90f));
                }
            }
            RadianceCooldown = 10f;
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
            yield return new WaitForSeconds(TimeBetweenLongLasers);
            Instantiate(EnemyLongLaserPrefab, LongLaserUp.position, Quaternion.Euler(0, 0, 90));
            Instantiate(EnemyLongLaserPrefab, LongLaserDown.position, Quaternion.Euler(0, 0, 90));
        }
    }

    IEnumerator DestroyEnemy()
    {
        foreach (SpriteRenderer r in SpriteRenderers)
        {
            r.enabled = false;
        }
        HealthLabel.text = "";
        DestructionAudio.Play();
        ThrustParticleSystem.Stop();
        DestroyParticleSystem.Play();
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Laser" || col.gameObject.tag == "LongLaser")
        {
            Health -= 1;
        }
    }
}
