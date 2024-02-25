using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliseJoystickHandler : MonoBehaviour, IService
{
    public void SliseBall(float direction)
    {
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerAnimationController>().ChangeAnimation(PlayerAnimation.Slide);
        ServiceLocator.CurrentSericeLocator.GetServise<ActionJoysticsManager>().ActivateSliceJoystickWithDelay();
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerDirectionController>().SetDirectionForSliseTime(0.3f, direction);
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerPositionController>().ChangeMoveCondition(PlayerMoveCondition.Slise);
        
    }
}
