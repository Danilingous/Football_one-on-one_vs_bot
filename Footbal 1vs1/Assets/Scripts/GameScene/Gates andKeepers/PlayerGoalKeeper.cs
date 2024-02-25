using UnityEngine;

public class PlayerGoalKeeper :GoalKeeperLogic
{
    private void Update()
    {
        Move();
    }
    public override void AcceptBall(Transform ballTransform)
    {
        base.AcceptBall(ballTransform);

        ballTransform.SetParent(this.transform);
        ballTransform.localPosition = new Vector3(0, 0.3f, 0);
        ServiceLocator.CurrentSericeLocator.GetServise<GameSceneManager>().ResumeGameAfterPlayerGoalKeeperAcceptBall();
    }
}