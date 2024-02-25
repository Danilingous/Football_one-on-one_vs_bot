using System.Collections;
using UnityEngine;

public enum  PlayerMoveCondition
{
    Run=0,
    Slise=1,
    Punch=2
}
public class PlayerPositionController : MonoBehaviour, IService
{
    private PlayerMoveCondition _curentMoveCondition = PlayerMoveCondition.Run;
    private bool _isAvaliableChangeCondition = true;

   

    public void ChangeMoveCondition(PlayerMoveCondition playerMoveCondition)
    {
        if(_isAvaliableChangeCondition)
        {
            _curentMoveCondition = playerMoveCondition;
            if (playerMoveCondition == PlayerMoveCondition.Punch) StartCoroutine(CoroutineSetPunchCondition());
            if (playerMoveCondition == PlayerMoveCondition.Slise) StartCoroutine(CoroutineSetSliseCondition());
        }
    }

    public void NormalMove(float _speed)
    {
        if(_curentMoveCondition== PlayerMoveCondition.Run )
        {
            transform.position += Time.deltaTime*_speed*transform.right ;
            ClampPosition();
        }
    }

    public void SliseMove(float _speed)
    {
        if ( _curentMoveCondition == PlayerMoveCondition.Slise)
        {
            transform.position += Time.deltaTime * _speed * transform.right;
            ClampPosition();
        }
    }

    private void ClampPosition()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-1.8f,1.8f), Mathf.Clamp(transform.position.y, -3f, 2.8f), 0);
    }

    public void SetPosition(Vector3 position) => transform.position = position;

    private IEnumerator CoroutineSetPunchCondition()
    {
        _isAvaliableChangeCondition = false;
        yield return new WaitForSeconds(0.3f);
        _isAvaliableChangeCondition = true;
        ChangeMoveCondition(PlayerMoveCondition.Run);
    }

    private IEnumerator  CoroutineSetSliseCondition()
    {
        _isAvaliableChangeCondition = false;
        yield return new WaitForSeconds(0.3f);

        _isAvaliableChangeCondition = true;
        ChangeMoveCondition(PlayerMoveCondition.Run);
    }

}
