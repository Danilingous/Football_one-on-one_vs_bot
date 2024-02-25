using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TranslateSO", menuName = "Translator/TranslateSO", order = 1)]
public class TranslateSO : ScriptableObject
{
    public LanguageEnum LanguageToTranslate;
    public string TextToTranslate;
    public LanguageFlags Languages;

    public TranslateData[] Translates = Array.Empty<TranslateData>();

    public void Translate()
    {
        if (string.IsNullOrEmpty(TextToTranslate))
        {
            Debug.Log("Null");
            return;
        }
        
        if ((int)Languages == 0)
        {
            Debug.Log("Nothing");
            return;
        }
        
        if ((int)Languages == -1)
        {
            string[] allLang = "Russian English French German Spanish Italian Hindi".Split();
            Translates = new TranslateData[allLang.Length];
            for (int i = 0; i < Translator.NamesToCode.Count; i++)
            {
                Translates[i].Text = Translator.Translate(TextToTranslate, LanguageToTranslate.ToString(), allLang[i]);
                Translates[i].Language = allLang[i];
            }
            return;
        }
        
        string[] lang = Languages.ToString().Split();
        Translates = new TranslateData[lang.Length];

        for (int i = 0; i < lang.Length-1; i++)
        {
            lang[i] = lang[i].Substring(0, lang[i].Length-1);

            Translates[i].Text = Translator.Translate(TextToTranslate, LanguageToTranslate.ToString(), lang[i]);
            Translates[i].Language = lang[i];
        }
        Translates[lang.Length-1].Text = Translator.Translate(TextToTranslate, LanguageToTranslate.ToString(), lang[lang.Length-1]);
        Translates[lang.Length-1].Language = lang[lang.Length-1];
    }
}