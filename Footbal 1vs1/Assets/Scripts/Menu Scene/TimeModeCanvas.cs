using TMPro;
using UnityEngine;

public class TimeModeCanvas : MonoBehaviour,IService
{
    [SerializeField] private TextMeshProUGUI _textTimeValue;
    [SerializeField] private int _maxValue = 3;
    [SerializeField] private int _minValue = 1;
    public int TimeValue { get; private set; } = 2;

    private void Start()
    {
        _textTimeValue.text= TimeValue.ToString();
    }
    public void ClickIncreastButton()
    {
        if (ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneMaster>().IsAvaliableClickButton)
        {
            TimeValue++;
            if (TimeValue > _maxValue) TimeValue = _maxValue;
            _textTimeValue.text = TimeValue.ToString();
        }
    }

    public void ClickDecreaseButton()
    {
        if (ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneMaster>().IsAvaliableClickButton)
        {
            TimeValue--;
            if (TimeValue < _minValue) TimeValue = _minValue;
            _textTimeValue.text = TimeValue.ToString();
        }
    }
}
