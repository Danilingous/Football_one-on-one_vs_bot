#if UNITY_EDITOR
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "MainSettings", menuName = "Translator/MainSettings", order = 0)]
public class MainSettings : ScriptableObject
{
    public LanguageFlags Languages;
    public LanguageEnum StartLanguage;
    public bool _processing = false;
    public bool _complete = false;
    public bool SafeMode;

    public async void Translate()
    {
        _complete = false;
        _processing = true;
        var allTexts = FindObjectsOfType<TextTranslator>(true);
        foreach (var text in allTexts)
        {
            if (SafeMode)
            {
                await Task.Delay(10);
            }
            TranslateText(text, text.GetText(), Languages, StartLanguage);
        }

        _processing = false;
        _complete = true;

        ClearStrings();
    }

    private void CheckBeforeTranslate(TextTranslator textComponent, string text, LanguageFlags languages, LanguageEnum startLanguage)
    {
        if (textComponent.Translates.Length > 0 && text == textComponent.Translates[0].Text)
        {
            string[] lang = languages.ToString().Split();
            if (lang.Length + 1 == textComponent.Translates.Length)
            {
                for (int i = 0; i < lang.Length-1; i++)
                {
                    lang[i] = lang[i].Substring(0, lang[i].Length-1);
                }
                
                foreach (var translate in textComponent.Translates)
                {
                    if (translate.Language == startLanguage.ToString())
                    {
                        continue;
                    }
                    if (!lang.Contains(translate.Language))
                    {
                        TranslateText(textComponent, text, languages, startLanguage);
                        return;
                    }                
                }
            }
            else
            {
                TranslateText(textComponent, text, languages, startLanguage);
            }
        }
        else
        {
            TranslateText(textComponent, text, languages, startLanguage);
        }
    }
    
    private void TranslateText(TextTranslator textComponent, string text, LanguageFlags languages, LanguageEnum startLanguage)
    {
        if (string.IsNullOrEmpty(text))
        {
            Debug.Log("Null");
            return;
        }
        
        if ((int)languages == 0)
        {
            Debug.Log("Nothing");
            return;
        }
        
        if ((int)languages == -1)
        {
            string[] allLang = "Russian English French German Spanish Italian Hindi Portuguese Arabic Bengali Turkish Kazakh".Split();
            textComponent.Translates = new TranslateData[allLang.Length + 1];
            textComponent.Translates[0] = new TranslateData
            {
                Language = startLanguage.ToString(),
                Text = text
            };
            for (int i = 0; i < Translator.NamesToCode.Count; i++)
            {
                textComponent.Translates[i+1].Text = Translator.Translate(textComponent.Translates[0].Text, allLang[i]);
                textComponent.Translates[i+1].Language = allLang[i];
            }
            return;
        }
        
        string[] lang = languages.ToString().Split();
        textComponent.Translates = new TranslateData[lang.Length + 1];
        textComponent.Translates[0] = new TranslateData
        {
            Language = startLanguage.ToString(),
            Text = text
        };

        for (int i = 0; i < lang.Length-1; i++)
        {
            lang[i] = lang[i].Substring(0, lang[i].Length-1);
            textComponent.Translates[i+1].Text = Translator.Translate(textComponent.Translates[0].Text, lang[i]);
            textComponent.Translates[i+1].Language = lang[i];
        }
        textComponent.Translates[lang.Length].Text = Translator.Translate(textComponent.Translates[0].Text, lang[lang.Length-1]);
        textComponent.Translates[lang.Length].Language = lang[lang.Length-1];
    }

    private async void ClearStrings()
    {
        await Task.Delay(2000);
        _processing = false;
        _complete = false;
    }
}

#endif