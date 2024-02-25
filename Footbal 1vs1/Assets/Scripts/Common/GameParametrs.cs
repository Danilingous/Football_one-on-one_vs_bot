using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameParametrs : MonoBehaviour, IService
{
    public int IsSoundOn { get; private set; } = 1; // 0 - false; 1 - True
    public int GameMode { get; private set; } = 0;  // no enum. 0 - Time; 1- GoalCount
    public int PlayerGoalTotalCount { get; private set; } = 0;
    public int EnemyGoalTotalCount { get; private set; } = 0;
    public int PlayerMatchesWonCount { get; private set; } = 0;
    public int EnemyMatchesWonCount { get; private set; } = 0;
    public int TargetTimeValue { get; private set; } = 60;
    public int TargetGoalValue { get; private set; } = 3;
    public int CountBallAvaliable { get; private set; } = 1;
    public int CountFieldAvaliable { get; private set; } = 1;
    public int NumberChosenBall { get; private set; } = 0;
    public int NumberChosenField { get; private set; } = 0;


    private void Awake()
    {
       // SaveParametrs(); // For ResetShop
        LoadParametrs();
    }
    public void SaveParametrs()
    {
        string allParametrs = IsSoundOn.ToString() + "." + GameMode.ToString() + "." + PlayerGoalTotalCount.ToString() + "." +
            EnemyGoalTotalCount.ToString() + "." + PlayerMatchesWonCount.ToString() + "." + EnemyMatchesWonCount.ToString() + "." +
            TargetTimeValue.ToString() + "." + TargetGoalValue.ToString() + "." + CountBallAvaliable.ToString() + "." +
            CountFieldAvaliable.ToString() + "." + NumberChosenBall.ToString() + "." + NumberChosenField.ToString();
        PlayerPrefs.SetString(StringValues.PlayerPrefsGameParametrs, allParametrs);
        PlayerPrefs.Save();
    }

    private void LoadParametrs()
    {
        if (PlayerPrefs.HasKey(StringValues.PlayerPrefsGameParametrs))
        {
            string[] allParametrs = PlayerPrefs.GetString(StringValues.PlayerPrefsGameParametrs).Split('.');
           // for(int i=0;i<allParametrs.Length;i++) Debug.Log(allParametrs[i]);
            StringArrayToValues(allParametrs);
        }
    }

    private void StringArrayToValues(string[] allParametrs)
    {
        IsSoundOn = Convert.ToInt32(allParametrs[0]);
        if (IsSoundOn == 1) AudioListener.volume = 1;
        else AudioListener.volume = 0;
        GameMode = Convert.ToInt32(allParametrs[1]);
        PlayerGoalTotalCount = Convert.ToInt32(allParametrs[2]);
        EnemyGoalTotalCount = Convert.ToInt32(allParametrs[3]);
        PlayerMatchesWonCount = Convert.ToInt32(allParametrs[4]);
        EnemyMatchesWonCount = Convert.ToInt32(allParametrs[5]);
        TargetTimeValue = Convert.ToInt32(allParametrs[6]);
        TargetGoalValue = Convert.ToInt32(allParametrs[7]);
        CountBallAvaliable = Convert.ToInt32(allParametrs[8]);
        CountFieldAvaliable = Convert.ToInt32(allParametrs[9]);
        NumberChosenBall = Convert.ToInt32(allParametrs[10]);
        NumberChosenField = Convert.ToInt32(allParametrs[11]);
    }

    public void ChangeSoundMode()
    {
        if (IsSoundOn == 0)
        {
            IsSoundOn = 1;
            AudioListener.volume = 1;
        }
        else
        {
            IsSoundOn = 0;
            AudioListener.volume = 0;
        }
        SaveParametrs();
    }

    public void ChooseTimeMode(int timeValue)
    {
        GameMode = 0;
        TargetTimeValue = timeValue;
        SaveParametrs();
    }

    public void ChooseGoalMode(int goalValue)
    {
        GameMode = 1;
        TargetGoalValue = goalValue;
        SaveParametrs();
    }

    public void AddPlayerGoal()
    {
        PlayerGoalTotalCount++;
        SaveParametrs();
    }
    public void AddEnemyGoal()
    {
        EnemyGoalTotalCount++;
        SaveParametrs();
    }

    public void AddPlayerWinGame()
    {
        PlayerMatchesWonCount++;
        SaveParametrs();
    }

    public void AddEnemyWinGame()
    {
        EnemyMatchesWonCount++;
        SaveParametrs();
    }

    public void AddAvaliableBall()
    {
        CountBallAvaliable++;
        SaveParametrs();
    }

    public void ChangeChoosenBall(int number)
    {
        NumberChosenBall = number;
        SaveParametrs();
    }

    public void AddAvaliableField()
    {
        CountFieldAvaliable++;
        SaveParametrs();
    }

    public void ChangeChoosenField(int number)
    {
        NumberChosenField = number;
        SaveParametrs();
    }
}
