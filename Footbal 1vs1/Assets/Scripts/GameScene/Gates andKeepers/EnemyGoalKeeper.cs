using UnityEngine;

public class EnemyGoalKeeper : GoalKeeperLogic
{
    private bool _isFreeze = false;
    private void Update()
    {
        if(!_isFreeze)
        Move();
    }
    public override void AcceptBall(Transform ballTransform)
    {
        base.AcceptBall(ballTransform);

        ballTransform.SetParent(this.transform);
        ballTransform.localPosition = new Vector3(0, -0.3f, 0);
        ServiceLocator.CurrentSericeLocator.GetServise<GameSceneManager>().ResumeGameAfterEnemyGoalKeeperAcceptBall();
    }

    public void ChangeFreezeStatus(bool status) => _isFreeze = status;

   

}
