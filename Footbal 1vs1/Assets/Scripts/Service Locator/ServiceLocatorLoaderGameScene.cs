using UnityEngine;

public class ServiceLocatorLoaderGameScene : MonoBehaviour
{
    [SerializeField] private PlayerMoveJoystick _playerMoveJoystick;
    [SerializeField] private PlayerPunchJoystick _playerPunchJoystick;
    [SerializeField] private PlayerSliceJoystick _playerSliceJoystick;
    [SerializeField] private PunchJoistickHandler _punchJoistickHandler;
    [SerializeField] private SliseJoystickHandler _sliseJoystickHandler;

    [SerializeField] private PlayerAnimationController _playerAnimationController;
    [SerializeField] private PlayerDirectionController _playerDirectionController;
    [SerializeField] private PlayerSpeedController _playerSpeedController;
    [SerializeField] private PlayerPositionController _playerPositionController;

    [SerializeField] private ActionJoysticsManager _actionJoysticsManager;
    [SerializeField] private AllObjectPositionController _allObjectPositionController;
    [SerializeField] private GameSceneManager _gameSceneManager;
    [SerializeField] private PlayerBehaviorManager _playerBehaviorManager;
    [SerializeField] private GameSceneUIMaster _gameSceneUIMaster;
    [SerializeField] private GameParametrs _gameParametrs;
    [SerializeField] private BonusController _bonusController;
    [SerializeField] private GameSceneSoundManager _gameSceneSoundManager;
    
    [SerializeField] private EnemyAnimationController _enemyAnimationController;
    [SerializeField] private EnemyBehaviorController _enemyBehaviorController;
    [SerializeField] private EnemyDirectionController _enemyDirectionController;
    [SerializeField] private EnemyPositionController _enemyPositionController;
    [SerializeField] private EnemySpeedController _enemySpeedController;

    [SerializeField] private BallLogic _ballLogic;
    [SerializeField] private GoalCounter _goalCounter;
    [SerializeField] private Timer _timer;
    [SerializeField] private EnemyGoalKeeper _enemyGoalKeeper;
    [SerializeField] private PlayerGoalKeeper _palyerGoalKeeper;
    [SerializeField] private CoinCounter _coinCounter;
    [SerializeField] private CoinsCalculater _coinsCalculater;

    private void Awake()
    {
        RegisterServices();
    }

    private void RegisterServices()
    {
        ServiceLocator.Initialize();
        // Joystics:
        ServiceLocator.CurrentSericeLocator.RegisterService<PlayerMoveJoystick>(_playerMoveJoystick);
        ServiceLocator.CurrentSericeLocator.RegisterService<PlayerPunchJoystick>(_playerPunchJoystick);
        ServiceLocator.CurrentSericeLocator.RegisterService<PlayerSliceJoystick>(_playerSliceJoystick);
        ServiceLocator.CurrentSericeLocator.RegisterService<PunchJoistickHandler>(_punchJoistickHandler);
        ServiceLocator.CurrentSericeLocator.RegisterService<SliseJoystickHandler>(_sliseJoystickHandler);

        // Player:
        ServiceLocator.CurrentSericeLocator.RegisterService<PlayerAnimationController>(_playerAnimationController);
        ServiceLocator.CurrentSericeLocator.RegisterService<PlayerDirectionController>(_playerDirectionController);
        ServiceLocator.CurrentSericeLocator.RegisterService<PlayerSpeedController>(_playerSpeedController);
        ServiceLocator.CurrentSericeLocator.RegisterService<PlayerPositionController>(_playerPositionController);

        //  Managers:
        ServiceLocator.CurrentSericeLocator.RegisterService<ActionJoysticsManager>(_actionJoysticsManager);
        ServiceLocator.CurrentSericeLocator.RegisterService<AllObjectPositionController>(_allObjectPositionController);
        ServiceLocator.CurrentSericeLocator.RegisterService<GameSceneManager>(_gameSceneManager);
        ServiceLocator.CurrentSericeLocator.RegisterService<PlayerBehaviorManager>(_playerBehaviorManager);
        ServiceLocator.CurrentSericeLocator.RegisterService<GameSceneUIMaster>(_gameSceneUIMaster);
        ServiceLocator.CurrentSericeLocator.RegisterService<GameParametrs>(_gameParametrs);
        ServiceLocator.CurrentSericeLocator.RegisterService<BonusController>(_bonusController);
        ServiceLocator.CurrentSericeLocator.RegisterService<GameSceneSoundManager>(_gameSceneSoundManager);

        // Enemy:
        ServiceLocator.CurrentSericeLocator.RegisterService<EnemyAnimationController>(_enemyAnimationController);
        ServiceLocator.CurrentSericeLocator.RegisterService<EnemyBehaviorController>(_enemyBehaviorController);
        ServiceLocator.CurrentSericeLocator.RegisterService<EnemyDirectionController>(_enemyDirectionController);
        ServiceLocator.CurrentSericeLocator.RegisterService<EnemyPositionController>(_enemyPositionController);
        ServiceLocator.CurrentSericeLocator.RegisterService<EnemySpeedController>(_enemySpeedController);

        // Evrething:
        ServiceLocator.CurrentSericeLocator.RegisterService<BallLogic>(_ballLogic);
        ServiceLocator.CurrentSericeLocator.RegisterService<GoalCounter>(_goalCounter);
        ServiceLocator.CurrentSericeLocator.RegisterService<Timer>(_timer);
        ServiceLocator.CurrentSericeLocator.RegisterService<PlayerGoalKeeper>(_palyerGoalKeeper);
        ServiceLocator.CurrentSericeLocator.RegisterService<EnemyGoalKeeper>(_enemyGoalKeeper);
        ServiceLocator.CurrentSericeLocator.RegisterService<CoinCounter>(_coinCounter);
        ServiceLocator.CurrentSericeLocator.RegisterService<CoinsCalculater>(_coinsCalculater);
    }
}
