using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSliceJoystick :Joystick,IService
{
    public override void OnPointerUp(PointerEventData eventData)
    {
        float sliceDirection = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        float playerDirection = ServiceLocator.CurrentSericeLocator.GetServise<PlayerDirectionController>().CurrentDirection;
        if ((sliceDirection >= 0 && playerDirection >= 0) || (sliceDirection <= 0 && playerDirection <= 0))
        {
            ServiceLocator.CurrentSericeLocator.GetServise<SliseJoystickHandler>().SliseBall(sliceDirection);
            // Debug.Log(Direction.magnitude + "  " + Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg);
        }
        else
        {

        }
        base.OnPointerUp(eventData);
    }
}