using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoalModeCanvas : MonoBehaviour,IService
{
    [SerializeField] private TextMeshProUGUI _textGoalValue;
    [SerializeField] private int _maxValue=3;
    [SerializeField] private int _minValue=1;
    public int GoalValue { get; private set; } = 2;

    private void Start()
    {
        _textGoalValue.text = GoalValue.ToString();
    }
    public void ClickIncreastButton()
    {
        if (ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneMaster>().IsAvaliableClickButton)
        {
            GoalValue++;
            if (GoalValue > _maxValue) GoalValue = _maxValue;
            _textGoalValue.text = GoalValue.ToString();
        }
    }

    public void ClickDecreaseButton()
    {
        if (ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneMaster>().IsAvaliableClickButton)
        {
            GoalValue--;
            if (GoalValue < _minValue) GoalValue = _minValue;
            _textGoalValue.text = GoalValue.ToString();
        }
    }
}
