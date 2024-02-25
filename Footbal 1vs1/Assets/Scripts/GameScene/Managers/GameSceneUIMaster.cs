using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneUIMaster : MonoBehaviour, IService
{
    [SerializeField] private GameObject _canvasWin;
    [SerializeField] private GameObject _canvasLose;
    private bool _isAvaliableClickButton = true;

    [SerializeField] private GameObject _canvasHelpInformation;
    [SerializeField] private GameObject _canvasInGameOn;
    [SerializeField] private GameObject _canvasLeftPannel;
    [SerializeField] private GameObject _canvasMoveJoistik;
    [SerializeField] private GameObject _canvasActionJoistick;

    public void ClickButtonBackToMenuScene()
    {
        if(_isAvaliableClickButton)
        {
            LoadMenuScene();
        }

    }

    public void ClickButtonPlayAgain()
    {
        if(_isAvaliableClickButton)
        {
            LoadGameScene();
        }
    }    

    public void LoadMenuScene() => SceneManager.LoadScene(StringValues.MenuSceneName);
    public void LoadGameScene() => SceneManager.LoadScene(StringValues.GameSceneName);

    public void OpenWinCanvas()
    {
        _canvasWin.SetActive(true);
    }

    public void OpenLoseCanvas()
    {
        _canvasLose.SetActive(true);
    }


    public void ClickInformationButton()
    {
        if(_isAvaliableClickButton)
        {
            Time.timeScale = 0;
            _canvasInGameOn.SetActive(false);
            _canvasLeftPannel.SetActive(false);
            _canvasMoveJoistik.SetActive(false);
            _canvasActionJoistick.SetActive(false);
            _canvasHelpInformation.SetActive(true);
           
        }
    }
    public void ClickButtonBackToGame()
    {
        if (_isAvaliableClickButton)
        {
            Time.timeScale = 1;
            _canvasInGameOn.SetActive(true);
            _canvasLeftPannel.SetActive(true);
            _canvasMoveJoistik.SetActive(true);
            _canvasActionJoistick.SetActive(true);
            _canvasHelpInformation.SetActive(false);
        }
    }
}
