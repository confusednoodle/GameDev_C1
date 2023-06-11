using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //movement
    [SerializeField] float speed = 5f;

    //single laser 
    public LaserBehaviour laserPrefab;
    public Transform spawnPosition;
    public AudioSource laserSound;

    //triple laser 
    public Transform spawnPosition1;
    public Transform spawnPosition2;
    public Transform spawnPosition3;
    public AudioSource TripleLaserSound;

    //special attack (2)

    public Transform spawnLaserBomb;
    public AudioSource laserBombSound;

    void Update()
    {
        //movement
        float verticalMovement = Input.GetAxisRaw("Vertical");
        Vector3 movement = Vector3.up * verticalMovement * speed * Time.deltaTime;
        transform.position += movement;

        //single laser
        if (Input.GetButtonDown("Laser"))
        {
            laserSound.Play();
            Instantiate(laserPrefab, spawnPosition.position, transform.rotation);
        }

        //triple laser
        if (Input.GetButtonDown("TripleLaser"))
        {
            TripleLaserSound.Play();
            Instantiate(laserPrefab, spawnPosition1.position, transform.rotation);
            Instantiate(laserPrefab, spawnPosition2.position, transform.rotation);
            Instantiate(laserPrefab, spawnPosition3.position, transform.rotation);
        }

        /*if (Input.GetButtonDown("2"))
        {
            laserBombSound.Play();
            Instantiate(laserPrefab, spawnPosition.position, transform.rotation);
        }*/
    }
}
