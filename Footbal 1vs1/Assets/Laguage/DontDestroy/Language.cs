using System;
using System.Linq;
using UnityEngine;

public static class Language
{
    public static Action<string> OnChangeLanguage;

    private static string _activeLanguage = "English";
    
    private static string[] _languages =
    {
        "Russian", 
        "English", 
        "French",
        "German", 
        "Spanish", 
        "Italian",
        "Hindi",
        "Portuguese", 
        "Arabic", 
        "Bengali", 
        "Turkish", 
        "Kazakh"
    };
    
    /// <summary>
    ///   <para>Russian, English, French, German, Spanish, Italian, Hindi, Portuguese, Arabic, Bengali, Turkish, Kazakh</para>
    /// </summary>
    public static void SwitchLanguage(string newLanguage)
    {
        if (_languages.Contains(newLanguage))
        {
            _activeLanguage = newLanguage;
            OnChangeLanguage?.Invoke(_activeLanguage);
        }
        else
        {
            Debug.LogError("Unknown language");
        }
    }

    public static void SwitchLanguage(LanguageEnum newLanguage)
    {
        if (_languages.Contains(newLanguage.ToString()))
        {
            _activeLanguage = newLanguage.ToString();
            OnChangeLanguage?.Invoke(_activeLanguage);
        }
        else
        {
            Debug.LogError("Unknown language");
        }
    }
    
    public static string GetLanguage()
    {
        return _activeLanguage;
    }
}
