using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerPunchJoystick : Joystick, IService
{

    public override void OnPointerUp(PointerEventData eventData)
    {
        float punchDirection= Mathf.Atan2(Direction.y,Direction.x) * Mathf.Rad2Deg;
        float playerDirection = ServiceLocator.CurrentSericeLocator.GetServise<PlayerDirectionController>().CurrentDirection;
        if ((punchDirection>=0 && playerDirection>=0)||(punchDirection <= 0 && playerDirection <= 0))
        {
            ServiceLocator.CurrentSericeLocator.GetServise<PunchJoistickHandler>().PunchBall(punchDirection, Direction.magnitude);
           // Debug.Log(Direction.magnitude + "  " + Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg);
        }
        else
        {

        }
        base.OnPointerUp(eventData);
    }
}