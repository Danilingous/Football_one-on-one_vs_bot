using System;
using System.Collections.Generic;
using System.Net;
using AFMiniJSON;
using UnityEngine;
using UnityEngine.Networking;

public static class Translator
{
    public static Dictionary<string, string> NamesToCode = new Dictionary<string, string>()
    {
        { "Auto", "auto"},
        { "Russian", "ru"},
        { "English", "en"},
        { "French", "fr"},
        { "German", "de"},
        { "Spanish", "es"},
        { "Italian", "it"},
        { "Hindi", "hi"},
        { "Portuguese", "pt"},
        { "Arabic", "ar"},
        { "Bengali", "bn"},
        { "Turkish", "tr"},
        { "Kazakh", "kk"}
    };

    public static string Translate(string textToTranslate, LanguageEnum language)
    {
        return SendRequest(textToTranslate, "auto", NamesToCode[language.ToString()]);
    }

    public static string Translate(string textToTranslate, string language)
    {
        return SendRequest(textToTranslate, "auto", NamesToCode[language]);
    }
    
    public static string Translate(string textToTranslate, LanguageEnum baseLanguage, LanguageEnum targetLanguage)
    {
        return SendRequest(textToTranslate, NamesToCode[baseLanguage.ToString()], NamesToCode[targetLanguage.ToString()]);
    }

    public static string Translate(string textToTranslate, string baseLanguage, string targetLanguage)
    {
        return SendRequest(textToTranslate, NamesToCode[baseLanguage], NamesToCode[targetLanguage]);
    }

    private static string SendRequest(string textToTranslate, string baseLanguageCode, string targetLanguageCode)
    {
       // Debug.Log(textToTranslate);
        if (string.IsNullOrEmpty(textToTranslate))
        {
            Debug.Log("Null");
            return null;
        }
        var url = String.Format("https://translate.google.ru/translate_a/single?client=gtx&dt=t&sl={0}&tl={1}&q={2}",
            baseLanguageCode, targetLanguageCode, WebUtility.UrlEncode(textToTranslate));
        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SendWebRequest();
        while (!www.isDone)
        {
        }
        string response = www.downloadHandler.text;
        
        return GetString(response);
    }

    private static string GetString(string response)
    {
        List<System.Object> test = Json.Deserialize(response) as List<System.Object>;

        return GetAllAnswer(test);
    }

    private static string GetAllAnswer(List<System.Object> defaultList)
    {
        List<System.Object> node = defaultList.Find(node => node is List<System.Object>) as List<System.Object>;
        List<System.Object> nodeSecond = node.FindAll(nodeSecond => nodeSecond is List<System.Object>) as List<System.Object>;

        string fullText = "";
        
        foreach (List<System.Object> VARIABLE in nodeSecond)
        {
            fullText += VARIABLE[0].ToString();
        }
        
        return fullText;
    }
}