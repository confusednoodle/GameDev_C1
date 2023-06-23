using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss5Behaviour : MonoBehaviour
{
    int leeway = 6;
    float AttackCooldown = 0f;
    public Transform spawnPosition;
    public EnemyLaser enemyLPrefab;
    [SerializeField] int health;
    [SerializeField] TextMesh HealthLabel;
    [SerializeField] AudioSource DestructionAudio;
    [SerializeField] ParticleSystem ParticleSystem;
    bool destroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        health = 30;
    }

    private void Update()
    {
        if (health >= 0) { HealthLabel.text = health.ToString(); } else { HealthLabel.text = ""; };

        if (health <= 0 && !destroyed)
        {
            destroyed = true;
            StopAllCoroutines();
            StartCoroutine(DestroyEnemy());
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //bob up and down
        if (leeway > 0)
        {
            transform.position -= new Vector3(0, 0.01f, 0);
            leeway -= 1;
        }
        else if (leeway > -5)
        {
            transform.position += new Vector3(0, 0.01f, 0);
            leeway -= 1;
        }
        else leeway = 5;

        //Radiance Attack
        if (AttackCooldown > 0)
        {
            AttackCooldown -= 0.1f;
        }
        else
        {
            int temp = Random.Range(0, 5);
            for (int i = 0; i < 5; i++)
            {
                if (i != temp)
                {
                    Instantiate(enemyLPrefab,new Vector3(spawnPosition.position.x,spawnPosition.position.y + i,0f),Quaternion.Euler(0f,0f,90f));
                    Instantiate(enemyLPrefab, new Vector3(spawnPosition.position.x, spawnPosition.position.y - i, 0f), Quaternion.Euler(0f, 0f, 90f));
                }
            }
            AttackCooldown = 10f;
        }
        
    }
    IEnumerator DestroyEnemy()
    {
        HealthLabel.text = "";
        DestructionAudio.Play();
        ParticleSystem.Play();
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Laser" || col.gameObject.tag == "LongLaser")
        {
            health -= 1;
        }
    }
}
