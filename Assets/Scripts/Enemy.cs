using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// The enemy level. It equates to the base hitpoints that get multiplied later.
enum EnemyLevel
{
    Easy = 1,
    EasyMedium = 3,
    MediumHard = 5,
    Hard = 10,

    Boss = 100
}

/// The enemy type. This equates to the moveset.
enum EnemyType
{
    UpAndDown,
    Square,
    Hourglass,
}

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyLevel Level;
    [SerializeField] EnemyType Type;
    [SerializeField] int speed;
    [Space(10)]
    [SerializeField] Sprite EasySpriteUpAndDown;
    [SerializeField] Sprite EasyMediumSpriteUpAndDown;
    [SerializeField] Sprite MediumHardSpriteUpAndDown;
    [SerializeField] Sprite HardSpriteUpAndDown;
    [SerializeField] Sprite BossSpriteUpAndDown;
    [Space]
    [SerializeField] Sprite EasySpriteSquare;
    [SerializeField] Sprite EasyMediumSpriteSquare;
    [SerializeField] Sprite MediumHardSpriteSquare;
    [SerializeField] Sprite HardSpriteSquare;
    [SerializeField] Sprite BossSpriteSquare;
    [Space]
    [SerializeField] Sprite EasySpriteHourglass;
    [SerializeField] Sprite EasyMediumSpriteHourglass;
    [SerializeField] Sprite MediumHardSpriteHourglass;
    [SerializeField] Sprite HardSpriteHourglass;
    [SerializeField] Sprite BossSpriteHourglass;
    [Space]
    [SerializeField] int HealthMultiplier;
    [Space]
    [SerializeField] SpriteRenderer SRenderer;

    int health = 0;
    bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        health = (int)Level * HealthMultiplier;

        // assign expected sprite to game object
        switch (Type)
        {
            case EnemyType.UpAndDown:
                switch (Level)
                {
                    case EnemyLevel.Easy:
                        SRenderer.sprite = EasySpriteUpAndDown;
                        break;
                    case EnemyLevel.EasyMedium:
                        SRenderer.sprite = EasyMediumSpriteUpAndDown;
                        break;
                    case EnemyLevel.MediumHard:
                        SRenderer.sprite = MediumHardSpriteUpAndDown;
                        break;
                    case EnemyLevel.Hard:
                        SRenderer.sprite = HardSpriteUpAndDown;
                        break;
                    case EnemyLevel.Boss:
                        SRenderer.sprite = BossSpriteUpAndDown;
                        break;
                    default:
                        SRenderer.sprite = EasySpriteUpAndDown;
                        break;
                }
                StartCoroutine(MoveUpAndDown());
                break;
            case EnemyType.Hourglass:
                switch (Level)
                {
                    case EnemyLevel.Easy:
                        SRenderer.sprite = EasySpriteHourglass;
                        break;
                    case EnemyLevel.EasyMedium:
                        SRenderer.sprite = EasyMediumSpriteHourglass;
                        break;
                    case EnemyLevel.MediumHard:
                        SRenderer.sprite = MediumHardSpriteHourglass;
                        break;
                    case EnemyLevel.Hard:
                        SRenderer.sprite = HardSpriteHourglass;
                        break;
                    case EnemyLevel.Boss:
                        SRenderer.sprite = BossSpriteHourglass;
                        break;
                    default:
                        SRenderer.sprite = EasySpriteHourglass;
                        break;
                }
                StartCoroutine(MoveHourglass());
                break;
            case EnemyType.Square:
                switch (Level)
                {
                    case EnemyLevel.Easy:
                        SRenderer.sprite = EasySpriteSquare;
                        break;
                    case EnemyLevel.EasyMedium:
                        SRenderer.sprite = EasyMediumSpriteSquare;
                        break;
                    case EnemyLevel.MediumHard:
                        SRenderer.sprite = MediumHardSpriteSquare;
                        break;
                    case EnemyLevel.Hard:
                        SRenderer.sprite = HardSpriteSquare;
                        break;
                    case EnemyLevel.Boss:
                        SRenderer.sprite = BossSpriteSquare;
                        break;
                    default:
                        SRenderer.sprite = EasySpriteSquare;
                        break;
                }
                StartCoroutine(MoveSquare());
                break;
            default:
                Debug.LogError("Please select an enemy type :)");
                break;
        }
    }

    IEnumerator MoveUpAndDown()
    {
        for (; ; )
        {
            for (int i = 0; i < 50; i++)
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            for (int i = 0; i < 50; i++)
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
    }

    IEnumerator MoveHourglass()
    {
        yield return new WaitForEndOfFrame();
    }

    IEnumerator MoveSquare()
    {
        yield return new WaitForEndOfFrame();
    }
}
