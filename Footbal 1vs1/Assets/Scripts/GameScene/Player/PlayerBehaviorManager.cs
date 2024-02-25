using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorManager : MonoBehaviour,IService
{
   public void StartPunchBehavior()
    {
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerAnimationController>().ChangeAnimation(PlayerAnimation.Punch);
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerDirectionController>().SetConstDirectionForActionTime(0.3f);
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerPositionController>().ChangeMoveCondition(PlayerMoveCondition.Punch);
    }
}
