using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour,IService
{
    private int _coinCount;
    [SerializeField] private TextMeshProUGUI _textCoinCount;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (PlayerPrefs.HasKey(StringValues.PlayerPrefsCoinCount))
        {
            _coinCount = PlayerPrefs.GetInt(StringValues.PlayerPrefsCoinCount);

        }
        else _coinCount = 0;

        DrawCoinCount();
    }

    public void AddCoin(int value)
    {
        _coinCount += value;
        DrawCoinCount();
        SaveCoinCount();
    }
    public bool TrySpendCoins(int cost)
    {
        if (_coinCount >= cost)
        {
            _coinCount -= cost;
            DrawCoinCount();
            SaveCoinCount();
            return true;
        }
        else return false;
    }

    private void DrawCoinCount()
    {
        if(_textCoinCount!=null)
        _textCoinCount.text = _coinCount.ToString();
    }

    private void SaveCoinCount()
    {
        PlayerPrefs.SetInt(StringValues.PlayerPrefsCoinCount, _coinCount);
        PlayerPrefs.Save();
    }

    public int GetCoinCountInfoarmation() => _coinCount;
}
