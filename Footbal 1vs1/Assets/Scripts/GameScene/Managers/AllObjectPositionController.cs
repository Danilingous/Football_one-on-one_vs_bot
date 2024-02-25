using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllObjectPositionController : MonoBehaviour,IService
{
    [SerializeField] private Vector3 _startPlayerPostion;
    [SerializeField] private Vector3 _startEnemyPosition;
    [SerializeField] private Vector3 _startBallPositionPlayerSide;
    [SerializeField] private Vector3 _startBallPositionEnemySide;

    public void SetStartPlayerSidePosition()
    {
        SetGoalKeepersPosition();
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerPositionController>().SetPosition(_startPlayerPostion);
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerDirectionController>().SetZeroDirection();

        ServiceLocator.CurrentSericeLocator.GetServise<EnemyBehaviorController>().SetStartPosition(_startEnemyPosition);

        ServiceLocator.CurrentSericeLocator.GetServise<BallLogic>().SetPosition(_startBallPositionPlayerSide);
    }

    public void SetStartEnemySidePosition()
    {
        SetGoalKeepersPosition();
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerPositionController>().SetPosition(_startPlayerPostion);
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerDirectionController>().SetZeroDirection();

        ServiceLocator.CurrentSericeLocator.GetServise<EnemyBehaviorController>().SetStartPosition(_startEnemyPosition);

        ServiceLocator.CurrentSericeLocator.GetServise<BallLogic>().SetPosition(_startBallPositionEnemySide);
    }

    private void SetGoalKeepersPosition()
    {
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerGoalKeeper>().SetStartPosition();
        ServiceLocator.CurrentSericeLocator.GetServise<EnemyGoalKeeper>().SetStartPosition();
    }
}
