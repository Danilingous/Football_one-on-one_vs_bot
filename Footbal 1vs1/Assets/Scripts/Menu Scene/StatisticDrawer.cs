using TMPro;
using UnityEngine;

public class StatisticDrawer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textPlayerWonMatchesCount;
    [SerializeField] private TextMeshProUGUI _textEnemyWonMatchesCount;
    [SerializeField] private TextMeshProUGUI _textPlayerGoalCount;
    [SerializeField] private TextMeshProUGUI _textEnemyGoalCount;

    private void Start()
    {
        DrawStatisticks();
    }

    private void DrawStatisticks()
    {
        _textPlayerGoalCount.text = ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().PlayerGoalTotalCount.ToString();
        _textEnemyGoalCount.text = ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().EnemyGoalTotalCount.ToString();
        _textPlayerWonMatchesCount.text = ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().PlayerMatchesWonCount.ToString();
        _textEnemyWonMatchesCount.text = ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().EnemyMatchesWonCount.ToString();
    }
}
