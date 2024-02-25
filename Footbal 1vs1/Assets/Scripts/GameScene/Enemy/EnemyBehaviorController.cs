using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyBehavior
{
    WaitStart=0,
    Idle=1,
    RunToFreeBall=2,
    RunToPlayer=3,
    Slide=4,
    RunToGate=5,
    Punch=6,
    WaitResumeGame=7
}

public class EnemyBehaviorController: MonoBehaviour, IService
{
    private readonly Vector3 _startDirection = new Vector3(0, 0, -90);
    private EnemyBehavior _currentEnemyBehavior = EnemyBehavior.WaitStart;
    private bool _isAvaliableChangeBehavior = false;
    private readonly Vector3 _gatePosition= new Vector3(0,-3.5f,0);
    private float _currentDirectionAngle= new();
    private bool _isAvaliableSlide = true;
    [SerializeField] private float _yPositionToPunchBall = -2f;
    [SerializeField] private GameObject _punchLagSprite;
    [SerializeField] private GameObject _sliseObject;
    [SerializeField] private float _distanceToMakeSlide = 0.8f;

    [SerializeField] private float _maxBodyRotationValue = 5f;
    [SerializeField] private float _speedBodyRotation = 20f;
    [SerializeField] private Transform _bodySpriteTransform;
    private float _bodyRotationValue;

    private void Update()
    {
        _bodyRotationValue = -_maxBodyRotationValue + Mathf.PingPong(Time.time * _speedBodyRotation, _maxBodyRotationValue * 2);
        ChooseBehavior();
        BehaviorHandler();
    }



    public void SetStartPosition(Vector3 position)
    {
        transform.position = position;
        transform.eulerAngles = _startDirection;
        ChangeAvaliableChangeBehaviorStatus(false);
        _currentEnemyBehavior = EnemyBehavior.WaitStart;

    }

    private void ChooseBehavior()
    {
        if(_isAvaliableChangeBehavior)
        {
            if (ServiceLocator.CurrentSericeLocator.GetServise<BallLogic>().IsFree) // if ball is free run to  it
            {
                _currentEnemyBehavior = EnemyBehavior.RunToFreeBall;
            }
            else if(ServiceLocator.CurrentSericeLocator.GetServise<BallLogic>().gameObject.transform.parent==transform) // if enemy has ball
            {
                if(transform.position.y<= _yPositionToPunchBall)  // chech ready or not to punch
                {
                    _currentEnemyBehavior = EnemyBehavior.Punch;
                }
                else
                {
                    _currentEnemyBehavior = EnemyBehavior.RunToGate;
                }
            }
            else  // PlayerHaveBall
            {
                if (CalculateDistancetoTarget(ServiceLocator.CurrentSericeLocator.GetServise<PlayerPositionController>().gameObject.transform.position) < _distanceToMakeSlide && _isAvaliableSlide)
                {
                    StartCoroutine(CoroutineStartSlideBehavior());
                }
                else _currentEnemyBehavior = EnemyBehavior.RunToPlayer;
            }
        }
    }

    private void BehaviorHandler()
    {
        if (_currentEnemyBehavior != EnemyBehavior.RunToFreeBall && _currentEnemyBehavior != EnemyBehavior.RunToGate && _currentEnemyBehavior != EnemyBehavior.RunToPlayer) _bodySpriteTransform.localEulerAngles = Vector3.zero;
        switch (_currentEnemyBehavior)
        {
            case EnemyBehavior.WaitStart:
               
                break;

            case EnemyBehavior.Idle:

                break;

            case EnemyBehavior.RunToFreeBall:
                 SetDirectionToTarget(ServiceLocator.CurrentSericeLocator.GetServise<BallLogic>().gameObject.transform.position);
                _bodySpriteTransform.localEulerAngles = new(0, 0, _bodyRotationValue);
                transform.position += Time.deltaTime*ServiceLocator.CurrentSericeLocator.GetServise<EnemySpeedController>().CurrentMaxAvaliableSpeed* transform.right;
                break;

            case EnemyBehavior.Punch:
                StartCoroutine(CoroutineStartPunchBehavior());
                break;

            case EnemyBehavior.RunToGate:
                SetDirectionToTarget(_gatePosition);
                transform.position += Time.deltaTime * ServiceLocator.CurrentSericeLocator.GetServise<EnemySpeedController>().CurrentMaxAvaliableSpeed * transform.right;
                _bodySpriteTransform.localEulerAngles = new(0, 0, _bodyRotationValue);
                break;

            case EnemyBehavior.RunToPlayer:
                SetDirectionToTarget(ServiceLocator.CurrentSericeLocator.GetServise<PlayerPositionController>().gameObject.transform.position);
                transform.position += Time.deltaTime * ServiceLocator.CurrentSericeLocator.GetServise<EnemySpeedController>().CurrentMaxAvaliableSpeed * transform.right;
                _bodySpriteTransform.localEulerAngles = new(0, 0, _bodyRotationValue);
                break;

            case EnemyBehavior.Slide:
                transform.position += Time.deltaTime * ServiceLocator.CurrentSericeLocator.GetServise<EnemySpeedController>().CurrentMaxAvaliableSpeed *2f* transform.right;
                break;
               
        }
        
    }

    public void ChangeAvaliableChangeBehaviorStatus(bool value) => _isAvaliableChangeBehavior = value;

    private IEnumerator CoroutineStartPunchBehavior()
    {
        SetDirectionToTarget(_gatePosition);
        ServiceLocator.CurrentSericeLocator.GetServise<BallLogic>().PunchBall(_currentDirectionAngle, 1f);
        _currentEnemyBehavior = EnemyBehavior.Idle;
        _isAvaliableChangeBehavior = false;
        yield return null;
      //  yield return null;
        _punchLagSprite.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _punchLagSprite.SetActive(false);
        _isAvaliableChangeBehavior = true;
    }

    private IEnumerator CoroutineStartSlideBehavior()
    {
        _isAvaliableSlide = false;
        _isAvaliableChangeBehavior = false;
        _currentEnemyBehavior = EnemyBehavior.Slide;
        SetDirectionToTarget(ServiceLocator.CurrentSericeLocator.GetServise<PlayerPositionController>().gameObject.transform.position);
        _sliseObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _sliseObject.SetActive(false);
        _isAvaliableChangeBehavior = true;
        _currentEnemyBehavior = EnemyBehavior.Idle;
        yield return new WaitForSeconds(0.5f);
        _isAvaliableSlide = true;
    }

    private void SetDirectionToTarget(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        _currentDirectionAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(_currentDirectionAngle, Vector3.forward);
    }

    public void StartBehaviorAfterGoal()
    {
        StopAllCoroutines();
        _isAvaliableSlide = true;
        _punchLagSprite.SetActive(false);
        _sliseObject.SetActive(false);
        _isAvaliableChangeBehavior = false;
        _currentEnemyBehavior = EnemyBehavior.WaitResumeGame;
    }

    private float CalculateDistancetoTarget(Vector3 targetPosition)
    {
        Vector3 vectorDistance = targetPosition - transform.position;
        return vectorDistance.magnitude;
    }
}
