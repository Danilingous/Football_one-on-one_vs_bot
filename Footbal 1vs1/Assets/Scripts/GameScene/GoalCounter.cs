using TMPro;
using UnityEngine;

public class GoalCounter : MonoBehaviour,IService
{
    private int _targetGoalCount = int.MaxValue;
    public int PlayerGoalCount { get; private set; } = 0;
    [SerializeField] private TextMeshProUGUI _textPlayerGoalCount;
    public int EnemyGoalCount { get; private set; } = 0;
    [SerializeField] private TextMeshProUGUI _textEnemyGoalCount;

    [SerializeField] private TextMeshProUGUI _textScoreWinCanvas;
    [SerializeField] private TextMeshProUGUI _textScoreLoseCanvas;

    public void SetGoalTarget(int value) => _targetGoalCount = value;

    public void AddPlayerGoal()
    {
        PlayerGoalCount++;
        ServiceLocator.CurrentSericeLocator.GetServise<GameSceneSoundManager>().PlayGoalSound();
        _textPlayerGoalCount.text = PlayerGoalCount.ToString();
        ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().AddPlayerGoal();
        if(PlayerGoalCount==_targetGoalCount)
        {
            // win game
            ServiceLocator.CurrentSericeLocator.GetServise<GameSceneManager>().StartWinGameBehavior();
        }
        else
        {
            ServiceLocator.CurrentSericeLocator.GetServise<GameSceneManager>().ResumeGameAfterEnemyGoalKeeperAcceptBall();
        }
    }

    public void AddEnemyGoal()
    {
        EnemyGoalCount++;
        ServiceLocator.CurrentSericeLocator.GetServise<GameSceneSoundManager>().PlayGoalSound();
        ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().AddEnemyGoal();
        _textEnemyGoalCount.text = EnemyGoalCount.ToString();
        if(EnemyGoalCount==_targetGoalCount)
        {
            //lose game
            ServiceLocator.CurrentSericeLocator.GetServise<GameSceneManager>().StartLoseGameBehavior();

        }
        else
        {
            ServiceLocator.CurrentSericeLocator.GetServise<GameSceneManager>().ResumeGameAfterPlayerGoalKeeperAcceptBall();
        }
    }

    public void DrawFinaleScore()
    {
        _textScoreLoseCanvas.text = PlayerGoalCount.ToString() + " : " + EnemyGoalCount.ToString();
        _textScoreWinCanvas.text = PlayerGoalCount.ToString() + " : " + EnemyGoalCount.ToString();
    }

    public bool CheckPlayerWin()
    {
        if (PlayerGoalCount > EnemyGoalCount) return true;
        else return false;

    }
}
