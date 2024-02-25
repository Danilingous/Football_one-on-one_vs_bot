using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextTranslator : MonoBehaviour
{
    public TranslateData[] Translates;
    
    private TextMeshProUGUI _textComponent;

    public string GetText()
    {
        _textComponent = GetComponent<TextMeshProUGUI>();
        return _textComponent.text;
    }

    private void Awake()
    {
        Language.OnChangeLanguage += ChangeLanguage;
        _textComponent = GetComponent<TextMeshProUGUI>();
        ChangeLanguage(Language.GetLanguage());
    }

    private void OnDestroy()
    {
        Language.OnChangeLanguage -= ChangeLanguage;
    }

    private void ChangeLanguage(string language)
    {
        if (Translates.Length == 0)
        {
            return;
        }
        foreach (var translate in Translates)
        {
            if (translate.Language == language)
            {
                _textComponent.text = translate.Text;
                return;
            }
        }
        _textComponent.text = Translates[0].Text;
    }
}

[Serializable]
public struct TranslateData
{
    public string Language;
    public string Text;
}