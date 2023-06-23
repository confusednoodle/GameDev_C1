using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinCosBulletBehaviour : MonoBehaviour
{
    [SerializeField] float Speed = 5;
    [SerializeField] float Amplitude = 1f;
    public bool IsCos = false;
    [Space]
    [SerializeField] Sprite SinSprite;
    [SerializeField] Sprite CosSprite;
    [SerializeField] SpriteRenderer SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        if (IsCos)
        {
            SpriteRenderer.sprite = CosSprite;
        }
        else
        {
            SpriteRenderer.sprite = SinSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Speed * Time.deltaTime;

        if (IsCos)
        {
            transform.position += Vector3.up * Mathf.Cos(transform.position.x) * Amplitude * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.up * Mathf.Sin(transform.position.x) * Amplitude * Time.deltaTime;
        }
    }
}
