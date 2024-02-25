using System.Collections;
using UnityEngine;

public enum  PlayerAnimation
{
    Idle=0,
    Run=1,
    Slide=2,
    Punch=3

}
public class PlayerAnimationController : MonoBehaviour, IService
{
    [SerializeField] private float _maxBodyRotationValue = 5f;
    [SerializeField] private float _speedBodyRotation = 20f;
    [SerializeField] private Transform _bodySpriteTransform;
    [SerializeField] private GameObject _punchLagSprite;
    [SerializeField] private GameObject _sliseObject;
    private bool _isAvaliableChangeAnimation = false;
    private float _bodyRotationValue;
    private PlayerAnimation _currentAniamtion = PlayerAnimation.Idle;

    private void LateUpdate()
    {
        if (ServiceLocator.CurrentSericeLocator.GetServise<PlayerMoveJoystick>().Direction.magnitude > 0) ChangeAnimation(PlayerAnimation.Run);
        else ChangeAnimation(PlayerAnimation.Idle);

        _bodyRotationValue = -_maxBodyRotationValue + Mathf.PingPong(Time.time * _speedBodyRotation, _maxBodyRotationValue * 2);
        AnimationBehavior();
    }


    private void AnimationBehavior()
    {
        switch(_currentAniamtion)
        {
            case PlayerAnimation.Idle:

                break;

            case PlayerAnimation.Run:
                _bodySpriteTransform.localEulerAngles = new(0,0,_bodyRotationValue);
                break;
        }
    }

    public void ChangeAnimation(PlayerAnimation playerAnimation)
    {
        if (_isAvaliableChangeAnimation)
        {
            _currentAniamtion = playerAnimation;
            switch (playerAnimation)
            {
                case PlayerAnimation.Idle:

                    _bodySpriteTransform.localEulerAngles = Vector3.zero;
                    break;

                case PlayerAnimation.Run:

                    break;

                case PlayerAnimation.Punch:
                    StartCoroutine(CoroutinePunchAnimation());
                    break;

                case PlayerAnimation.Slide:
                    StartCoroutine(CoroutineSliseAnimation());
                    break;
                    
            }
        }
    }

    private IEnumerator CoroutinePunchAnimation()
    {
        _isAvaliableChangeAnimation = false;
        _punchLagSprite.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _punchLagSprite.SetActive(false);
        _isAvaliableChangeAnimation = true;
    }

    private IEnumerator CoroutineSliseAnimation()
    {
        _isAvaliableChangeAnimation = false;
       _sliseObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _sliseObject.SetActive(false);
        _isAvaliableChangeAnimation = true;
    }

   public void ChangeAvaliablechangeAnimationStatus(bool value)
    {
        _isAvaliableChangeAnimation = value;
        if (value == false)
        {
            _bodyRotationValue = 0;
            _bodySpriteTransform.localEulerAngles = new(0, 0, _bodyRotationValue);
            _currentAniamtion = PlayerAnimation.Idle;
        }
    }
}
