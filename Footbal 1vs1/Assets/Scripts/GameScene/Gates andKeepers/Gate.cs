using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private bool _isPlayerGate;

    public void MakeGoal()
    {

        if(_isPlayerGate)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<GoalCounter>().AddEnemyGoal();
        }
        else
        {
            ServiceLocator.CurrentSericeLocator.GetServise<GoalCounter>().AddPlayerGoal();
        }

        ServiceLocator.CurrentSericeLocator.GetServise<EnemyBehaviorController>().StartBehaviorAfterGoal();
    }
}
