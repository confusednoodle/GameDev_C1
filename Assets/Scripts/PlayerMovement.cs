using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //movement
    [SerializeField] float speed = 5f;
    [SerializeField] Transform TopBorder;
    [SerializeField] Transform BottomBorder;
    [Space]

    //single laser
    public LaserBehaviour laserPrefab;
    [SerializeField] LongLaserBehaviour longLaserPrefab;
    public Transform spawnPosition;
    public AudioSource laserSound;
    [SerializeField] float fireRate = 0.125f;
    [Space]

    //triple laser
    public Transform spawnPosition1;
    public Transform spawnPosition2;
    public Transform spawnPosition3;
    public AudioSource TripleLaserSound;
    [SerializeField] float cooldown = 0.8f;
    bool active = false;
    float timer;
    [SerializeField] Image cool;
    bool firstRound = true;
    [Space]

    //special attack (2)
    public Transform longSpawnPosition;
    public AudioSource longLaserSound;
    [SerializeField] Collider2D collider1;
    [SerializeField] Collider2D collider2;
    [Space]

    // special attack (4)
    [SerializeField] SinCosBulletBehaviour SinCosBulletPrefab;
    [Space]

    // Destruction
    [SerializeField] AudioSource DestructionSound;
    [SerializeField] AudioSource GameMusicSound;
    [SerializeField] SpriteRenderer SpriteRenderer;
    [SerializeField] ParticleSystem ParticleSystem;
    [SerializeField] CapsuleCollider2D CapsuleCollider2D;

    // GodMode
    [SerializeField] GameObject HaloContainer;

    bool godMode = false;
    bool dontMove = false;

    private void Start()
    {
        if (SharedState.GodMode)
        {
            godMode = true;
            HaloContainer.SetActive(true);
        }
        timer = cooldown;
    }

    void Update()
    {
        // check for god mode activation/deactivation
        if (Input.GetButtonDown("GodMode"))
        {
            SharedState.GodMode = !SharedState.GodMode;
            HaloContainer.SetActive(!godMode);
            godMode = !godMode;
        }

        //movement)
        float verticalMovement = Input.GetAxisRaw("Vertical");
        Vector3 movement = Vector3.up * verticalMovement * speed * Time.deltaTime;

        if (!dontMove)
        {
            if (transform.position.y > BottomBorder.position.y && verticalMovement != 1)
            {
                transform.position += movement;
            }
            else if (transform.position.y < TopBorder.position.y && verticalMovement != -1)
            {
                transform.position += movement;
            }
        }

        //single laser
        if (Input.GetButtonDown("Laser"))
        {
            InvokeRepeating("Shoot", .001f, fireRate);
        }
        else if (Input.GetButtonUp("Laser"))
        {
            CancelInvoke("Shoot");
        }

        // special attacks
        if (!active)
        {
            if (Input.GetButtonDown("TripleLaser"))
            {
                TripleLaserSound.Play();
                Instantiate(laserPrefab, spawnPosition1.position, transform.rotation);
                Instantiate(laserPrefab, spawnPosition2.position, transform.rotation);
                Instantiate(laserPrefab, spawnPosition3.position, transform.rotation);
                active = true;
            }
            else if (Input.GetButtonDown("LongLaser"))
            {
                longLaserSound.Play();
                Instantiate(longLaserPrefab, longSpawnPosition.position, transform.rotation);
                active = true;
            }
            else if (Input.GetButtonDown("AoE"))
            {
                TripleLaserSound.Play();
                for (int i = 0; i < 19; i++)
                {
                    Quaternion laserRot = Quaternion.Euler(0f, 0f, i * -10f);
                    Instantiate(laserPrefab, spawnPosition.position, laserRot);
                }
                active = true;
            }
            else if (Input.GetButtonDown("SinCosStream"))
            {
                dontMove = true;
                StartCoroutine(SinCosStream());
                active = true;
            }
        }
        else if (active)
        {
            //have cooldown start at full and decrease
            if (firstRound)
            {
                cool.fillAmount = 0.8f;
                firstRound = false;
            }
            timer -= Time.deltaTime;
            cool.fillAmount -= Time.deltaTime;
            if (timer < 0)
            {
                active = false;
                timer = cooldown;
                cool.fillAmount = 0f;
                firstRound = true;
            }
        }
    }

    void Shoot()
    {
        laserSound.Play();
        Instantiate(laserPrefab, spawnPosition.position, transform.rotation);
    }

    IEnumerator SinCosStream()
    {
        for (int i = 0; i < 5; i++)
        {
            SinCosBulletPrefab.IsCos = false;
            Instantiate(SinCosBulletPrefab, spawnPosition.position, Quaternion.identity);
            SinCosBulletPrefab.IsCos = true;
            Instantiate(SinCosBulletPrefab, spawnPosition.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
        dontMove = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.gameObject.tag == "EnemyLaser" || col.gameObject.tag == "EnemyLongLaser") && !godMode)
        {
            dontMove = true;
            StartCoroutine(BgMusicHandler.FadeOutBgMusic());
            StartCoroutine(ReturnToMainMenu());
            SpriteRenderer.enabled = false;
            CapsuleCollider2D.enabled = false;
            ParticleSystem.Play();
            DestructionSound.Play();
            Destroy(col.gameObject);
        }
    }

    IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu");
    }
}
