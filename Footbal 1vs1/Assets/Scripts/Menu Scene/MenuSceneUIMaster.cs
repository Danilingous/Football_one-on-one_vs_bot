using System.Collections;
using UnityEngine;

public class MenuSceneUIMaster : MonoBehaviour, IService
{
    [SerializeField] private GameObject _imageCanvasMainMenu;
    [SerializeField] private GameObject _imageCanvasSettings;
    [SerializeField] private GameObject _imageCanvasStatistics;
    [SerializeField] private GameObject _imageCanvasGameMode;
    [SerializeField] private GameObject _imageCanvasMainShop;
    [SerializeField] private GameObject _imageCanvasShopField;
    [SerializeField] private GameObject _imageCanvasShopBall;
    [SerializeField] private GameObject _imageCanvasShopPlayer;
    [SerializeField] private GameObject _imageCanvasHelpGameMode;
    [SerializeField] private GameObject _imageCanvasTimeMode;
    [SerializeField] private GameObject _imageCanvasGoalMode;
    [SerializeField] private GameObject _canvasPrivacyPolice;
    [SerializeField] private GameObject _canvasTermOfUse;
    [SerializeField] private GameObject _canvasLanguage;


    #region Methods for Change Canvases

    public void ChangeMainCanvasToSettingsCanvas() => StartCoroutine(CoroutineChangeCanvas(_imageCanvasMainMenu, _imageCanvasSettings));
    public void ChangeMainCanvasToGameModeCanvas() => StartCoroutine(CoroutineChangeCanvas(_imageCanvasMainMenu, _imageCanvasGameMode));
    public void ChangeMainCanvasToMainShopCanvas() => StartCoroutine(CoroutineChangeCanvas(_imageCanvasMainMenu, _imageCanvasMainShop));
    public void ChangeMainCanvasToStatisticCanvas() => StartCoroutine(CoroutineChangeCanvas(_imageCanvasMainMenu, _imageCanvasStatistics));

    public void ChangeMainShopCanvasToMainCanvas() => StartCoroutine(CoroutineChangeCanvas(_imageCanvasMainShop, _imageCanvasMainMenu));
    public void ChangeGameModeCanvasToMainCanvas() => StartCoroutine(CoroutineChangeCanvas(_imageCanvasGameMode, _imageCanvasMainMenu));
    public void ChangeSettingsCanvasToMainCanvas() => StartCoroutine(CoroutineChangeCanvas(_imageCanvasSettings, _imageCanvasMainMenu));
    public void ChangeStatisticCanvasToMainCanvas() => StartCoroutine(CoroutineChangeCanvas(_imageCanvasStatistics, _imageCanvasMainMenu));
    public void ChangeTimeModeCanvasToMainCanvas()=> StartCoroutine(CoroutineChangeCanvas(_imageCanvasTimeMode, _imageCanvasMainMenu));
    public void ChangeGoalModeCanvasToMainCanvas()=> StartCoroutine(CoroutineChangeCanvas(_imageCanvasGoalMode, _imageCanvasMainMenu));

    public void ChangeMainShopCanvasToShopField() => StartCoroutine(CoroutineChangeCanvas(_imageCanvasMainShop,_imageCanvasShopField));
    public void ChangeMainShopCanvasToShopBall() => StartCoroutine(CoroutineChangeCanvas(_imageCanvasMainShop,_imageCanvasShopBall));
    public void ChangeMainShopCanvasToShopPlayer() => StartCoroutine(CoroutineChangeCanvas(_imageCanvasMainShop,_imageCanvasShopPlayer));

    public void ChangeCanvasShopPlayerToMainShop() => StartCoroutine(CoroutineChangeCanvas(_imageCanvasShopPlayer,_imageCanvasMainShop));
    public void ChangeCanvasShopBallToMainShop() => StartCoroutine(CoroutineChangeCanvas(_imageCanvasShopBall,_imageCanvasMainShop));
    public void ChangeCanvasShopFieldToMainShop() => StartCoroutine(CoroutineChangeCanvas(_imageCanvasShopField,_imageCanvasMainShop));

  //  public void CloseGameModeCanvasAndLoadGameScene() => StartCoroutine(CoroutineCloseGameModeCanvasAndLoadGameScene()); // old Version

    public void ChangeGameModeCanvasToHelpInformationCanvas() => StartCoroutine(CoroutineChangeCanvas(_imageCanvasGameMode, _imageCanvasHelpGameMode));
    public void BackTogameModeCanvas() => StartCoroutine(CoroutineChangeCanvas(_imageCanvasHelpGameMode, _imageCanvasGameMode));

    public void ChangeGameModeCanvasToTimeModeCanvas() => StartCoroutine(CoroutineChangeCanvas(_imageCanvasGameMode, _imageCanvasTimeMode));
    public void ChangeGameModeCanvasToGoalModeCanvas() => StartCoroutine(CoroutineChangeCanvas(_imageCanvasGameMode, _imageCanvasGoalMode));


    public void CloseTimeModeCanvasAndStartGame() => StartCoroutine(CoroutineCloseCanvasAndLoadGameScene(_imageCanvasTimeMode));
    public void CloseGoalModeCanvasAndStartGame() => StartCoroutine(CoroutineCloseCanvasAndLoadGameScene(_imageCanvasGoalMode));


    public void OpenCanvasTermsOfUse() => _canvasTermOfUse.SetActive(true);
    public void OpenCanvasPrivacy() => _canvasPrivacyPolice.SetActive(true);

    public void CloseCanvasTermsOfUse() => _canvasTermOfUse.SetActive(false);
    public void CloseCanvasPrivacy() => _canvasPrivacyPolice.SetActive(false);

    public void OpenLanguageCanvas() => _canvasLanguage.SetActive(true);
    public void CloseLanguageCanvas() => _canvasLanguage.SetActive(false);
    #endregion
    #region Coroutines For Change Canvases
    private IEnumerator CoroutineChangeCanvas(GameObject imageOldCanvas, GameObject imageNewCanvas)
    {
        ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneMaster>().ForbidClickButton();
        float currentScaleValue = 1;
        for (int i = 0; i < 5; i++)
        {
            currentScaleValue += 0.066f;
            imageOldCanvas.GetComponent<RectTransform>().localScale = new Vector3(currentScaleValue, currentScaleValue, currentScaleValue);
            yield return new WaitForSeconds(0.02f);
        }

        for (int i = 0; i < 10; i++)
        {
            currentScaleValue -= 0.125f;
            imageOldCanvas.GetComponent<RectTransform>().localScale = new Vector3(currentScaleValue, currentScaleValue, currentScaleValue);
            yield return new WaitForSeconds(0.02f);
        }
        imageOldCanvas.GetComponent<RectTransform>().localScale = Vector3.zero;
        currentScaleValue = 0;
        for (int i = 0; i < 8; i++)
        {
            currentScaleValue += 0.125f;
            imageNewCanvas.GetComponent<RectTransform>().localScale = new Vector3(currentScaleValue, currentScaleValue, currentScaleValue);
            yield return new WaitForSeconds(0.02f);
        }
        imageNewCanvas.GetComponent<RectTransform>().localScale = Vector3.one;
        ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneMaster>().LetClickButton();
    }

    private IEnumerator CoroutineCloseCanvasAndLoadGameScene(GameObject imageCanvas)
    {
        ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneMaster>().ForbidClickButton();
        float currentScaleValue = 1;
        for (int i = 0; i < 5; i++)
        {
            currentScaleValue += 0.066f;
            imageCanvas.GetComponent<RectTransform>().localScale = new Vector3(currentScaleValue, currentScaleValue, currentScaleValue);
            yield return new WaitForSeconds(0.02f);
        }

        for (int i = 0; i < 8; i++)
        {
            currentScaleValue -= 0.125f;
            imageCanvas.GetComponent<RectTransform>().localScale = new Vector3(currentScaleValue, currentScaleValue, currentScaleValue);
            yield return new WaitForSeconds(0.02f);
        }
        imageCanvas.GetComponent<RectTransform>().localScale = Vector3.zero;
        ServiceLocator.CurrentSericeLocator.GetServise<MenuSceneMaster>().LoadGameScene();
    }

    
    #endregion
}
