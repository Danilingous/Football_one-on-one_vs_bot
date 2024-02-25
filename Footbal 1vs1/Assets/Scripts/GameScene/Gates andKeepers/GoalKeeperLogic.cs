using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeperLogic : MonoBehaviour,IService
{
    [SerializeField] protected float _speed=0.5f;
    [SerializeField] protected Vector3 _startPosition;
    protected  bool _isCanMove = false;

    protected void Move()
    {
        if(_isCanMove)
        {
            transform.position = new Vector3(-0.9f+Mathf.PingPong(Time.time*_speed,1.8f),transform.position.y,0);
        }
    }
   

    public void StartMove()
    {
        _isCanMove = true;
    }

    public void SetStartPosition()
    {
        _isCanMove = false;
        transform.position = _startPosition;
    }

    public virtual void AcceptBall(Transform ballTransform)
    {
        ServiceLocator.CurrentSericeLocator.GetServise<EnemyBehaviorController>().StartBehaviorAfterGoal();
    }
}
