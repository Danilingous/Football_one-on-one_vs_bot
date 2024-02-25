using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    [SerializeField] private Sprite _muteSprite;
    [SerializeField] private Sprite _soundOnSprite;
    [SerializeField] private Image _soundStatusImage;
    private bool _isSoundOn=true;

    private void Start()
    {
        if (ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().IsSoundOn == 1)
        {
            _soundStatusImage.sprite = _soundOnSprite;
            _isSoundOn = true;
        }
        else
        {
            _soundStatusImage.sprite = _muteSprite;
            _isSoundOn = false;
        }
    }

    public void ChangeSoundStartus()
    {
        _isSoundOn = !_isSoundOn;
       
        if(_isSoundOn)
        {
            _soundStatusImage.sprite = _soundOnSprite;
        }
        else
        {
            _soundStatusImage.sprite = _muteSprite;
        }
    }

    public void ClickSoundButton()
    {
        if (ServiceLocator.CurrentSericeLocator.CheckServise<MenuSceneMaster>())
        {

            if (ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneMaster>().IsAvaliableClickButton)
            {
                ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().ChangeSoundMode();
                MuteButton[] muteButtons = FindObjectsOfType<MuteButton>();
                for (int i = 0; i < muteButtons.Length; i++) muteButtons[i].ChangeSoundStartus();
            }
        }
        else
        {
            ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().ChangeSoundMode();
            MuteButton[] muteButtons = FindObjectsOfType<MuteButton>();
            for (int i = 0; i < muteButtons.Length; i++) muteButtons[i].ChangeSoundStartus();
        }
    }
}
