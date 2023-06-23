using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinCosBulletBehaviour : MonoBehaviour
{
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

    }
}
