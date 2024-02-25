using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpeedController : MonoBehaviour, IService
{
    [SerializeField]  private float _maxSpeed=1.8f;
    public float CurrentMaxAvaliableSpeed { get; private set; } = 0;

    private void Start()
    {
        CurrentMaxAvaliableSpeed = _maxSpeed;
    }
}
