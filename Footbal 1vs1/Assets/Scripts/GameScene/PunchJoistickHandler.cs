using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchJoistickHandler : MonoBehaviour,IService
{
    public void PunchBall(float direction, float power)
    {
        ServiceLocator.CurrentSericeLocator.GetServise<BallLogic>().PunchBall(direction, power);
        ServiceLocator.CurrentSericeLocator.GetServise<ActionJoysticsManager>().ActivateSliceJoystickWithDelay();
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerBehaviorManager>().StartPunchBehavior();
        
    }
}
