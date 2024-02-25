public class PlayerBallAccepter : BallAccepter
{
    public override void AcceptBall()
    {
        ServiceLocator.CurrentSericeLocator.GetServise<ActionJoysticsManager>().ActivatePunchJoustick();
    }

}
