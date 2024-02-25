using System.Collections;
using UnityEngine;

public class BallLogic : MonoBehaviour, IService
{
    [SerializeField] private float _maxPunchPower = 5f;
    private bool _isOwnsKeeper = false;
    private bool _canBeAccepted = true;
    public bool IsFree { get; private set; } = true;
    [SerializeField] private Rigidbody2D _rigidbody;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (_canBeAccepted || collision.gameObject.GetComponent<EnemyBallAccepter>() != null) // EnemyCanAcceptBallAfterPunchImmediatly
       // if(_canBeAccepted)
       // { //
        if(collision.gameObject.GetComponent<GoalKeeperLogic>()!=null)
        {
            _isOwnsKeeper = true;
            IsFree = false; // New Parametr!!!
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            collision.gameObject.GetComponent<GoalKeeperLogic>().AcceptBall(transform);
        }
        if (!_isOwnsKeeper)
        {
            if (IsFree)
            {
                if (collision.gameObject.GetComponent<BallAccepter>() != null)
                {
                    if (collision.gameObject.GetComponent<BallAccepter>().CanAcceptBall)
                    {
                        _rigidbody.velocity = Vector2.zero;
                        _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                        transform.SetParent(collision.gameObject.transform);
                        transform.localPosition = new Vector3(0.5f, -0.2f, 0);
                        IsFree = false;
                        // _canBeAccepted = false;
                        collision.gameObject.GetComponent<BallAccepter>().AcceptBall();
                    }
                }
            }
        //}

        if(collision.gameObject.GetComponent<Gate>()!=null)
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            _isOwnsKeeper = true;
            collision.gameObject.GetComponent<Gate>().MakeGoal();
        }
        } //
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_isOwnsKeeper)
        {
            if (collision.gameObject.GetComponent<BallAccepter>() != null)
            {
                float direction = collision.gameObject.GetComponent<IDirectionController>().CurrentDirection;
                PunchBall(direction, 0.5f);
            }
        }
    }

    public void PunchBall(float direction,float power)
    {
        ServiceLocator.CurrentSericeLocator.GetServise<GameSceneSoundManager>().PlayPunchSound();
        _rigidbody.constraints = RigidbodyConstraints2D.None;
        IsFree = true;
      //   StartCoroutine(CoroutineWaitAntilCanBeAccepted());  //
        if (transform.parent == ServiceLocator.CurrentSericeLocator.GetServise<PlayerPositionController>().gameObject.transform)
            ServiceLocator.CurrentSericeLocator.GetServise<ActionJoysticsManager>().ActivateSliceJoystick();
        transform.parent = null;
        transform.rotation = Quaternion.AngleAxis(direction, Vector3.forward);
        _rigidbody.AddForce(power * _maxPunchPower * transform.right, ForceMode2D.Impulse);
    }

    private IEnumerator CoroutineWaitAntilCanBeAccepted()
    {
        yield return new WaitForSeconds(0.2f);
        _canBeAccepted = true;
    }

    public void SetPosition(Vector3 position)
    {
        transform.parent = null;
        _isOwnsKeeper = false;
        IsFree = true;
        _rigidbody.constraints = RigidbodyConstraints2D.None;
        _rigidbody.velocity = Vector2.zero;
        transform.position = position;
        transform.rotation = Quaternion.identity;
    }
        
}
