using UnityEngine;

public class BallAccepter : MonoBehaviour,IService
{
    public bool CanAcceptBall { get; private set; } = true;

    public virtual void AcceptBall()
    {

    }

    public void ChangeCanAcceptBallStatus(bool status) => CanAcceptBall = status;
}
