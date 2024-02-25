using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocatorLoaderMenuScene : MonoBehaviour
{
    [SerializeField] private SoundMasterMenuScene _soundMasterMenuScene;
    [SerializeField] private MenuSceneMaster _menuSceneMaster;
    [SerializeField] private MenuSceneUIMaster _menuSceneUIMaster;
    [SerializeField] private GameParametrs _gameParametrs;
    [SerializeField] private GoalModeCanvas _goalModeCanvas;
    [SerializeField] private TimeModeCanvas _timeModeCanvas;
    [SerializeField] private CoinCounter _coinCounter;

    [SerializeField] private BallButtonController _ballButtonController;
    [SerializeField] private DuttonsFieldController _duttonsFieldController;
    [SerializeField] private LanguageManager _languageManager;

    private void Awake()
    {
        RegisterServices();
    }

    private void RegisterServices()
    {
        ServiceLocator.Initialize();
        ServiceLocator.CurrentSericeLocator.RegisterService<SoundMasterMenuScene>(_soundMasterMenuScene);
        ServiceLocator.CurrentSericeLocator.RegisterService<MenuSceneMaster>(_menuSceneMaster);
        ServiceLocator.CurrentSericeLocator.RegisterService<MenuSceneUIMaster>(_menuSceneUIMaster);
        ServiceLocator.CurrentSericeLocator.RegisterService<GameParametrs>(_gameParametrs);
        ServiceLocator.CurrentSericeLocator.RegisterService<GoalModeCanvas>(_goalModeCanvas);
        ServiceLocator.CurrentSericeLocator.RegisterService<TimeModeCanvas>(_timeModeCanvas);
        ServiceLocator.CurrentSericeLocator.RegisterService<CoinCounter>(_coinCounter);

        ServiceLocator.CurrentSericeLocator.RegisterService<BallButtonController>(_ballButtonController);
        ServiceLocator.CurrentSericeLocator.RegisterService<DuttonsFieldController>(_duttonsFieldController);
        ServiceLocator.CurrentSericeLocator.RegisterService<LanguageManager>(_languageManager);
    }
}
