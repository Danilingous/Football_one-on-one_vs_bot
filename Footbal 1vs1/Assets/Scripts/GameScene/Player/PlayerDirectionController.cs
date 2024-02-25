using System.Collections;
using UnityEngine;

public class PlayerDirectionController : IDirectionController, IService
{
    private bool _isAvaliableChangeDirection = false;
  //  public float CurrentDirection { get; private set; } = 0;

    private void Update()
    {
        SetDirection();
    }

    public void SetDirection()
    {
        if(_isAvaliableChangeDirection)
        {
            PlayerMoveJoystick playerMoveJoystick = ServiceLocator.CurrentSericeLocator.GetServise<PlayerMoveJoystick>();
            if (playerMoveJoystick.Horizontal!=0 && playerMoveJoystick.Vertical != 0)
            {
                CurrentDirection = Mathf.Atan2(playerMoveJoystick.Direction.y, playerMoveJoystick.Direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(CurrentDirection, Vector3.forward);
            }
        }
    }

    public void SetZeroDirection() => transform.eulerAngles = new Vector3(0, 0, 90);

    public void SetConstDirectionForActionTime(float actionTime)
    {
        StartCoroutine(CoroutineSetConstDirectionForActionTime(actionTime));
    }

    public void SetDirectionForSliseTime(float actionTime, float direction)
    {
        StartCoroutine(CoroutineSetDirectionForSlice(actionTime, direction));
    }

    private IEnumerator CoroutineSetDirectionForSlice(float actionTime, float direction)
    {
        CurrentDirection = direction;
        transform.rotation = Quaternion.AngleAxis(CurrentDirection, Vector3.forward);
        _isAvaliableChangeDirection = false;
        yield return new WaitForSeconds(actionTime);
        _isAvaliableChangeDirection = true;
    }

    private IEnumerator CoroutineSetConstDirectionForActionTime(float actionTime)
    {
        _isAvaliableChangeDirection = false;
        yield return new WaitForSeconds(actionTime);
        _isAvaliableChangeDirection = true;
    }

    public void ChangeStatusAvaliableChangeDirection(bool value) => _isAvaliableChangeDirection = value;
}
