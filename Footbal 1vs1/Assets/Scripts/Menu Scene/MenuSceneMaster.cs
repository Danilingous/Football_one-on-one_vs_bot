using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.SceneManagement;


public class MenuSceneMaster : MonoBehaviour, IService
{
   public bool IsAvaliableClickButton { get; private set; } = true;

    #region Methods for Click UIButtons
        #region Button for Change Canvases
    public void ClickButtonOpenMainShopCanvas() 
    {
        if (IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().ChangeMainCanvasToMainShopCanvas();
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
        }
    }

    public void ClickButtonOpenSettingsCanvas()
    {
        if (IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().ChangeMainCanvasToSettingsCanvas();
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
        }
    }

    public void ClickButtonOpenStatisticksCanvas()
    {
        if (IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().ChangeMainCanvasToStatisticCanvas();
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
        }
    }

    public void ClickButtonOpenGameModeCanvas()
    {
        if (IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().ChangeMainCanvasToGameModeCanvas();
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
        }
    }

    public void ClickButtonBackToMainCanvasFromGameMode()
    {
        if (IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().ChangeGameModeCanvasToMainCanvas();
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
        }
    }

    public void ClickButtonBackToMainCanvasFromStatistics()
    {
        if (IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().ChangeStatisticCanvasToMainCanvas();
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
        }
    }
    public void ClickButtonBackToMainCanvasFromSettings()
    {
        if (IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().ChangeSettingsCanvasToMainCanvas();
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
        }
    }
    public void ClickButtonBackToMainCanvasFromMainShop()
    {
        if (IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().ChangeMainShopCanvasToMainCanvas();
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
        }
    }

    public void ClickButtonOpenFieldShop()
    {
        if (IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().ChangeMainShopCanvasToShopField();
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
        }
    }

    public void ClickButtonOpenBallShop()
    {
        if (IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().ChangeMainShopCanvasToShopBall();
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
        }
    }

    public void ClickButtonOpenPlayerShop()
    {
        if (IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().ChangeMainShopCanvasToShopPlayer();
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
        }
    }

    public void ClickButtonBackToMainShopFromPlayerShop()
    {
        if (IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().ChangeCanvasShopPlayerToMainShop();
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
        }
    }

    public void ClickButtonBackToMainShopFromBallShop()
    {
        if (IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().ChangeCanvasShopBallToMainShop();
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
        }
    }

    public void ClickButtonBackToMainShopFromFieldShop()
    {
        if (IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().ChangeCanvasShopFieldToMainShop();
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
        }
    }

    public void ClickButtonInformation()
    {
        if(IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().ChangeGameModeCanvasToHelpInformationCanvas();
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
        }
    }

    public void ClickButtonBackToGameModeCanvas()
    {
        if(IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().BackTogameModeCanvas();
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
        }
    }

    public void ClickButtonTimeMode()
    {
        if(IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().ChangeGameModeCanvasToTimeModeCanvas();
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
        }
    }
    public void ClickButtonGoalMode()
    {
        if (IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().ChangeGameModeCanvasToGoalModeCanvas();
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
        }
    }
    public void ClickButtonBackToMainMenuFromTimeMode()
    {
        if(IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().ChangeTimeModeCanvasToMainCanvas();
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
        }
    }
    public void ClickButtonBackToMainMenuFromGoalMode()
    {
        if (IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().ChangeGoalModeCanvasToMainCanvas();
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
        }
    }
    #endregion

    // OldVersionStartGame:
    //public void ClickButtonStartGame()
    //{
    //    if(IsAvaliableClickButton)
    //    {
    //        ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
    //        ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().CloseGameModeCanvasAndLoadGameScene();
    //    }
    //}


    public void ClickButtonStartTimeModeGame()
    {
        if(IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
            ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().ChooseTimeMode(ServiceLocator.CurrentSericeLocator.GetServise<TimeModeCanvas>().TimeValue);
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().CloseTimeModeCanvasAndStartGame();
        }
    }

    public void ClickButtonStartGoalModeGame()
    {
        if (IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
            ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().ChooseGoalMode(ServiceLocator.CurrentSericeLocator.GetServise<GoalModeCanvas>().GoalValue);
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().CloseGoalModeCanvasAndStartGame();
        }
    }


    public void ClickPrivacyPolice()
    {
        if(IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().OpenCanvasPrivacy();
        }
    }

    public void ClickTermsOfUse()
    {
        if(IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().OpenCanvasTermsOfUse();
        }
    }

    public void ClickCloseCanvasTerms() => ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().CloseCanvasTermsOfUse();
    public void ClickCloseCanvasPrivacy() => ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().CloseCanvasPrivacy();

    public void ClickCloseCanvasLanguage() => ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().CloseLanguageCanvas();

    public void ClickLanguageButton()
    {
        if(IsAvaliableClickButton)
        {
            ServiceLocator.CurrentSericeLocator.GetServise<SoundMasterMenuScene>().PlayClickUISound();
            ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().OpenLanguageCanvas();
        }
    }

    public void ClickChangeLanguageButton(int languageNumber)
    {
        ServiceLocator.CurrentSericeLocator.GetServise<LanguageManager>().ChangeLanguage((LanguageEnum)languageNumber);
        ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneUIMaster>().CloseLanguageCanvas();
    }


    public void ClickRateUsButton()
    {
        if(IsAvaliableClickButton)
        {
            Device.RequestStoreReview();
        }
    }

    #endregion

    public void LoadGameScene() => SceneManager.LoadScene(StringValues.GameSceneName);

    public void LetClickButton() => IsAvaliableClickButton = true;
    public void ForbidClickButton() => IsAvaliableClickButton = false;
}
