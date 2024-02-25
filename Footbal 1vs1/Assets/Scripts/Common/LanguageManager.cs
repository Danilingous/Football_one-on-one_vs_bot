using UnityEngine;

public class LanguageManager : MonoBehaviour,IService 
{

    private void Start()
    {
        if(PlayerPrefs.HasKey(StringValues.LanguageNumber))
        {
            Language.SwitchLanguage((LanguageEnum)PlayerPrefs.GetInt(StringValues.LanguageNumber));
        }
        else
        {
            PlayerPrefs.SetInt(StringValues.LanguageNumber, (int)LanguageEnum.English);
            PlayerPrefs.Save();
            Language.SwitchLanguage((LanguageEnum.English));
        }
    }

    public void ChangeLanguage(LanguageEnum languageEnum)
    {
        Language.SwitchLanguage(languageEnum);
        PlayerPrefs.SetInt(StringValues.LanguageNumber, (int)languageEnum);
        PlayerPrefs.Save();
    }


}
