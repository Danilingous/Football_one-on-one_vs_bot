using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour,IService
{
    [SerializeField] private TextMeshProUGUI _textTimerValue;
    private int _intTimerValue=0;
    private int _targetIntTimerValue = int.MaxValue;

    private void DrawTimeValue() => _textTimerValue.text = (_intTimerValue / 60).ToString() + ":" + (_intTimerValue % 60).ToString("00");
    private IEnumerator CoroutineTimerWork()
    {
        while(_intTimerValue<_targetIntTimerValue)
        {
            yield return new WaitForSeconds(1);
            _intTimerValue++;
            DrawTimeValue();
        }
        // Stop game and Show result

        if(ServiceLocator.CurrentSericeLocator.GetServise<GoalCounter>().CheckPlayerWin())
        {
            ServiceLocator.CurrentSericeLocator.GetServise<GameSceneManager>().StartWinGameBehavior();
        }
        else
        {
            ServiceLocator.CurrentSericeLocator.GetServise<GameSceneManager>().StartLoseGameBehavior();
        }
    }

    public void StartWorkTimer() => StartCoroutine(CoroutineTimerWork());
    public void StopTimerWork() => StopAllCoroutines();
    public void SetTargetTimeValue(int value) => _targetIntTimerValue = value;
}
