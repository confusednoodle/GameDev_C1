using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //movement
    [SerializeField] float speed = 5f;

    //single laser 
    public LaserBehaviour laserPrefab;
    public Transform spawnPosition;
    public AudioSource laserSound;
    [SerializeField] float fireRate = 0.125f;

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

    //special attack (2)

    public Transform spawnLaserBomb;
    public AudioSource laserBombSound;

    private void Start()
    {
        timer = cooldown;
    }

    void Update()
    {
        //movement
        float verticalMovement = Input.GetAxisRaw("Vertical");
        Vector3 movement = Vector3.up * verticalMovement * speed * Time.deltaTime;
        transform.position += movement;

        //single laser
        if (Input.GetButtonDown("Laser"))
        {
            InvokeRepeating("Shoot", .001f, fireRate);
        }
        else if (Input.GetButtonUp("Laser"))
        {
            CancelInvoke("Shoot");
        }

        //triple laser
        if (Input.GetButtonDown("TripleLaser") && !active)
        {
            TripleLaserSound.Play();
            Instantiate(laserPrefab, spawnPosition1.position, transform.rotation);
            Instantiate(laserPrefab, spawnPosition2.position, transform.rotation);
            Instantiate(laserPrefab, spawnPosition3.position, transform.rotation);
            active = true;
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

        /*if (Input.GetButtonDown("2"))
        {
            laserBombSound.Play();
            Instantiate(laserPrefab, spawnPosition.position, transform.rotation);
        }*/
    }

    void Shoot()
    {
        laserSound.Play();
        Instantiate(laserPrefab, spawnPosition.position, transform.rotation);
    }
}
