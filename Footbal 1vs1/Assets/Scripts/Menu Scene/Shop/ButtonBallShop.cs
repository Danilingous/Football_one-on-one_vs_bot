using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBallShop : MonoBehaviour
{
    [SerializeField] private GameObject _textBuy;
    [SerializeField] private GameObject _textEquipped;
    [SerializeField] private TextMeshProUGUI _textCost;
    [SerializeField] private GameObject _textApply;
    [SerializeField] private GameObject _imageGreyBack;
    [SerializeField] private GameObject _imageLock;
    [SerializeField] private int _cost = 200;
    [SerializeField] private int _buttonNumber = 1;
    private bool _isBuyed;
    private bool _isEquipped;

    public void SetStatus(bool isBuyed,bool isEquipped)
    {
        _textBuy.SetActive(false);
        GetComponent<Button>().enabled = true;
        _textEquipped.SetActive(false);
        _imageLock.SetActive(false);
        _textApply.SetActive(false);
        _imageGreyBack.SetActive(false);
        _isBuyed = isBuyed;
        _isEquipped = isEquipped;
        _textCost.text = _cost.ToString();
        if(!isBuyed)
        {
            _textBuy.SetActive(true);
            if (ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().CountBallAvaliable + 1 < _buttonNumber)
            {
                //_imageGreyBack.SetActive(true);
                _textBuy.SetActive(false);
                _imageLock.SetActive(true);
                GetComponent<Button>().enabled = false;
            }
            if(ServiceLocator.CurrentSericeLocator.GetServise<CoinCounter>().GetCoinCountInfoarmation()<_cost) GetComponent<Button>().enabled = false;
        }
        else if(isEquipped)
        {
            _textEquipped.SetActive(true);
        }
        else
        {
            _textApply.SetActive(true);
        }
    }

    public void Click()
    {
        if(!_isBuyed)
        {
            if(_buttonNumber-1==ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().CountBallAvaliable)
            {
               if( ServiceLocator.CurrentSericeLocator.GetServise<CoinCounter>().TrySpendCoins(_cost))
                {
                    ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().AddAvaliableBall();
                   // ServiceLocator.CurrentSericeLocator.GetServise<BallButtonController>().SetStatusButtons();

                }
                    
            }
        }
        if(_isBuyed &&!_isEquipped)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().ChangeChoosenBall(_buttonNumber - 1);
        }

        ServiceLocator.CurrentSericeLocator.GetServise<BallButtonController>().SetStatusButtons();
    }
}
