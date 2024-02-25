using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BonusController : MonoBehaviour,IService
{
    [SerializeField] private GameObject _prefabSnowBonus;
    [SerializeField] private GameObject _prefabLightningBonus;

    [SerializeField] private GameObject _iceEffect;
    [SerializeField] private GameObject _iceUIObject;
    [SerializeField] private TextMeshProUGUI _textTimeIceBonusLeft;
    [SerializeField] private Image _fieldImageIce;

    [SerializeField] private GameObject _lightningUIObject;
    [SerializeField] private TextMeshProUGUI _textTimeLightningBonusLeft;
    [SerializeField] private Image _fieldImageLightning;

    public void CreateIceBonus()
    {
        Instantiate(_prefabSnowBonus, new Vector3(Random.Range(-1.8f,1.8f), Random.Range(0.3f,2.5f), 0), Quaternion.identity);
    }

    public void CreateLightningBonus()
    {
        Instantiate(_prefabLightningBonus, new Vector3(Random.Range(-1.8f, 1.8f), Random.Range(-2.5f,-0.3f), 0), Quaternion.identity);
    }

    public void CreateStartedBonuses()
    {
        CreateIceBonus();
        CreateLightningBonus();
    }

    public void DestroyBonuses()
    {

        StopAllCoroutines();
        ServiceLocator.CurrentSericeLocator.GetServise<GameSceneSoundManager>().StopIceSound();
        ServiceLocator.CurrentSericeLocator.GetServise<GameSceneSoundManager>().StopAccelerationSound();
        _iceEffect.SetActive(false);
        _iceUIObject.SetActive(false);
        ServiceLocator.CurrentSericeLocator.GetServise<EnemyGoalKeeper>().ChangeFreezeStatus(false);
        if (FindObjectOfType<SnowBonus>()) Destroy(FindObjectOfType<SnowBonus>().gameObject);

        if (FindObjectOfType<LightningBonus>()) Destroy(FindObjectOfType<LightningBonus>().gameObject);
        _lightningUIObject.SetActive(false);
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerSpeedController>().ChangeAccelearationStatus(false);

    }

    public void ActivateIceEffect()
    {
        StartCoroutine(CoroutineIceBonus());
    }

    private IEnumerator CoroutineIceBonus()
    {
        ServiceLocator.CurrentSericeLocator.GetServise<GameSceneSoundManager>().PlayIceSound();
        ServiceLocator.CurrentSericeLocator.GetServise<EnemyGoalKeeper>().ChangeFreezeStatus(true);
        _fieldImageIce.fillAmount = 1;
        int timeValue = 3;
        _textTimeIceBonusLeft.text = timeValue.ToString();
        float fillAmountValue = 1;
        _iceEffect.SetActive(true);
        _iceUIObject.SetActive(true);
        for(int i=1;i<31;i++)
        {
            if(i%10==0)
            {
                timeValue--;
                _textTimeIceBonusLeft.text = timeValue.ToString();
            }
            fillAmountValue -= 0.033f;
            _fieldImageIce.fillAmount = fillAmountValue;
            yield return new WaitForSeconds(0.1f);
        }

        _iceEffect.SetActive(false);
        _iceUIObject.SetActive(false);
        ServiceLocator.CurrentSericeLocator.GetServise<EnemyGoalKeeper>().ChangeFreezeStatus(false);
        CreateIceBonus();
    }

    public void ActivateLightningEffect()
    {
        StartCoroutine(CoroutineLightningBonus());
    }

    private IEnumerator CoroutineLightningBonus()
    {
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerSpeedController>().ChangeAccelearationStatus(true);
        ServiceLocator.CurrentSericeLocator.GetServise<GameSceneSoundManager>().PlayAccelerationSound();
        _fieldImageLightning.fillAmount = 1;
        int timeValue = 3;
        _textTimeIceBonusLeft.text = timeValue.ToString();
        float fillAmountValue = 1;
        _lightningUIObject.SetActive(true);
        for (int i = 1; i < 31; i++)
        {
            if (i % 10 == 0)
            {
                timeValue--;
                _textTimeLightningBonusLeft.text = timeValue.ToString();
            }
            fillAmountValue -= 0.033f;
            _fieldImageLightning.fillAmount = fillAmountValue;
            yield return new WaitForSeconds(0.1f);
        }
        _lightningUIObject.SetActive(false);
        ServiceLocator.CurrentSericeLocator.GetServise<PlayerSpeedController>().ChangeAccelearationStatus(false);
        CreateLightningBonus();
    }
}
