using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedController : MonoBehaviour, IService
{
    [SerializeField] private float _maxRunSpeed = 3f;
   [SerializeField] private float _currentRunSpeed = 0;
    private bool _isCanMove = false;
    private bool _isAccelerated = false;

    private void Update()
    {
        if (_isCanMove)
        {
            _currentRunSpeed = _maxRunSpeed * ServiceLocator.CurrentSericeLocator.GetServise<PlayerMoveJoystick>().Direction.magnitude;
            if (_isAccelerated) _currentRunSpeed *= 1.5f;
            ServiceLocator.CurrentSericeLocator.GetServise<PlayerPositionController>().NormalMove(_currentRunSpeed);
            ServiceLocator.CurrentSericeLocator.GetServise<PlayerPositionController>().SliseMove(_maxRunSpeed * 2);
        }
    }

    public void ChangeStatusCanMove(bool value) => _isCanMove = value;

    public void ChangeAccelearationStatus(bool status) => _isAccelerated = status;
}
