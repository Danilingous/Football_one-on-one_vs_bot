using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuttonsFieldController : MonoBehaviour,IService
{
    [SerializeField] private FieldShopButton[] _buttons;
    private void Start()
    {
        SetStatusButtons();
    }
    public void SetStatusButtons()
    {
        for (int i = 0; i < ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().CountFieldAvaliable; i++)
        {
            _buttons[i].SetStatus(true, false);
        }
        for (int i = ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().CountFieldAvaliable; i < _buttons.Length; i++)
        {
            _buttons[i].SetStatus(false, false);
        }

        _buttons[ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().NumberChosenField].SetStatus(true, true);
    }
}
