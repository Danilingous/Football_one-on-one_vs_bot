using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsCalculater : MonoBehaviour,IService
{
    [SerializeField] private TextMeshProUGUI _winCanvasCoinCount;
    [SerializeField] private TextMeshProUGUI _loseCanvasCoinCount;

    public void CalculateWinCoins(bool isPlayerWingame)
    {
        int winCoinCount;

        if(isPlayerWingame)
        {
            winCoinCount = ServiceLocator.CurrentSericeLocator.GetServise<GoalCounter>().PlayerGoalCount * 10;
            _winCanvasCoinCount.text = "+ " + winCoinCount.ToString();
        }
        else
        {
            winCoinCount = ServiceLocator.CurrentSericeLocator.GetServise<GoalCounter>().PlayerGoalCount * 2;
            _loseCanvasCoinCount.text = "+ " + winCoinCount.ToString();
        }
        ServiceLocator.CurrentSericeLocator.GetServise<CoinCounter>().AddCoin(winCoinCount);
    }
}
