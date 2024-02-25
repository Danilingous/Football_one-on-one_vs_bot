using System.Collections;
using UnityEngine;

public class ActionJoysticsManager : MonoBehaviour,IService
{
    public void OffBothJoistick()
    {
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerSliceJoystick>().OffJoistickBehavior();
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerSliceJoystick>().gameObject.SetActive(false);

        ServiceLocator.CurrentSericeLocator.GetServise<PlayerPunchJoystick>().OffJoistickBehavior();
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerPunchJoystick>().gameObject.SetActive(false);
    }

    public void ActivatePunchJoustick()
    {
        StopAllCoroutines();
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerSliceJoystick>().gameObject.SetActive(false);
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerPunchJoystick>().gameObject.SetActive(true);
    }

    public void ActivatePunchJoustickWithDelay()
    {
        StopAllCoroutines();
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerSliceJoystick>().gameObject.SetActive(false);
        StartCoroutine(CoroutineActivatePunchJoistick());
    }


    public void ActivateSliceJoystick()
    {
        StopAllCoroutines();
        OffBothJoistick();
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerSliceJoystick>().gameObject.SetActive(true);
    }
    public void ActivateSliceJoystickWithDelay()
    {
        StopAllCoroutines();
        OffBothJoistick();
        StartCoroutine(CoroutineActivateSliseJoistick());
    }



    private IEnumerator CoroutineActivatePunchJoistick()
    {
       
        yield return new WaitForSeconds(0.4f);
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerPunchJoystick>().gameObject.SetActive(true);
    }

    private IEnumerator CoroutineActivateSliseJoistick()
    {
        yield return new WaitForSeconds(0.4f);
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerSliceJoystick>().gameObject.SetActive(true);
    }
}
