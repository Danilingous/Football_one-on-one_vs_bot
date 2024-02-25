using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour,IService
{
    private void Start()
    {
        BeginStartGameBehavior();
        SetGameParametrs();
    }

    private void SetGameParametrs()
    {
        if(ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().GameMode==0)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<Timer>().SetTargetTimeValue(ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().TargetTimeValue * 60);
        }

        if (ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().GameMode == 1)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<GoalCounter>().SetGoalTarget(ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().TargetGoalValue);
        }
    }
    private void BeginStartGameBehavior()
    {
        StartCoroutine(CoroutineBeginStartGameBehavior());
    }


    public void ResumeGameAfterEnemyGoalKeeperAcceptBall()
    {
        StartCoroutine(CoroutineResumeGameAfterEnemyGoalKeeperAcceptBall());
    }

    public void ResumeGameAfterPlayerGoalKeeperAcceptBall()
    {
        StartCoroutine(CoroutineResumeGameAfterPlayerGoalKeeperAcceptBall());
    }



    private IEnumerator CoroutineBeginStartGameBehavior()
    {
        ServiceLocator.CurrentSericeLocator.GetServise<AllObjectPositionController>().SetStartPlayerSidePosition();
        yield return new WaitForSeconds(1.5f);
        StartGamePlay();
    }


    private IEnumerator CoroutineResumeGameAfterEnemyGoalKeeperAcceptBall()
    {
        yield return new WaitForSeconds(0.8f);
        StopGameplay();
        ServiceLocator.CurrentSericeLocator.GetServise<AllObjectPositionController>().SetStartEnemySidePosition();
        

        yield return new WaitForSeconds(0.8f);
        StartGamePlay();
    }
    private IEnumerator CoroutineResumeGameAfterPlayerGoalKeeperAcceptBall()
    {
        yield return new WaitForSeconds(0.8f);
        StopGameplay();
        ServiceLocator.CurrentSericeLocator.GetServise<AllObjectPositionController>().SetStartPlayerSidePosition();


        yield return new WaitForSeconds(0.8f);
        StartGamePlay();
    }


    public void StartWinGameBehavior()
    {
        StartCoroutine(CoroutineStartWinGameBehavior());
    }

    private IEnumerator CoroutineStartWinGameBehavior()
    {
        ServiceLocator.CurrentSericeLocator.GetServise<CoinsCalculater>().CalculateWinCoins(true);
        ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().AddPlayerWinGame();
        ServiceLocator.CurrentSericeLocator.GetServise<GoalCounter>().DrawFinaleScore();
        yield return new WaitForSeconds(1);
        ServiceLocator.CurrentSericeLocator.GetServise<GameSceneUIMaster>().OpenWinCanvas();
    }

    public void StartLoseGameBehavior()
    {
        StartCoroutine(CoroutineStartLoseGameBehavior());
    }

    private IEnumerator CoroutineStartLoseGameBehavior()
    {
        ServiceLocator.CurrentSericeLocator.GetServise<CoinsCalculater>().CalculateWinCoins(false);
        ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().AddEnemyWinGame();
        ServiceLocator.CurrentSericeLocator.GetServise<GoalCounter>().DrawFinaleScore();
        yield return new WaitForSeconds(1);
        ServiceLocator.CurrentSericeLocator.GetServise<GameSceneUIMaster>().OpenLoseCanvas();
    }


    private void StopGameplay()
    {
        ServiceLocator.CurrentSericeLocator.GetServise<BonusController>().DestroyBonuses();
        ServiceLocator.CurrentSericeLocator.GetServise<Timer>().StopTimerWork();
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerDirectionController>().ChangeStatusAvaliableChangeDirection(false);
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerDirectionController>().SetZeroDirection();
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerSpeedController>().ChangeStatusCanMove(false);
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerAnimationController>().ChangeAvaliablechangeAnimationStatus(false);
        ServiceLocator.CurrentSericeLocator.GetServise<ActionJoysticsManager>().OffBothJoistick();

       


    }
    private void StartGamePlay()
    {
        ServiceLocator.CurrentSericeLocator.GetServise<GameSceneSoundManager>().PlaySiffletSound();
        ServiceLocator.CurrentSericeLocator.GetServise<Timer>().StartWorkTimer();
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerDirectionController>().ChangeStatusAvaliableChangeDirection(true);
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerSpeedController>().ChangeStatusCanMove(true);
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerAnimationController>().ChangeAvaliablechangeAnimationStatus(true);
        ServiceLocator.CurrentSericeLocator.GetServise<ActionJoysticsManager>().ActivateSliceJoystick();
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerGoalKeeper>().StartMove();
        ServiceLocator.CurrentSericeLocator.GetServise<EnemyGoalKeeper>().StartMove();
        ServiceLocator.CurrentSericeLocator.GetServise<BonusController>().CreateStartedBonuses();

        ServiceLocator.CurrentSericeLocator.GetServise<EnemyBehaviorController>().ChangeAvaliableChangeBehaviorStatus(true);
    }
}
