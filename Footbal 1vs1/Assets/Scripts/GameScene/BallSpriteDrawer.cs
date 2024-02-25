using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpriteDrawer : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private SpriteRenderer _ballSprite;

    private void Start()
    {
        _ballSprite.sprite = _sprites[ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().NumberChosenField];
    }
}
