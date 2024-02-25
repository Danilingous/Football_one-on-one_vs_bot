using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBonus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ServiceLocator.CurrentSericeLocator.GetServise<BonusController>().ActivateIceEffect();
            Destroy(gameObject);
        }
    }
}
