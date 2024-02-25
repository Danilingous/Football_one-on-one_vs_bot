#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TranslateSO))]
[CanEditMultipleObjects]
public class TranslateSOEditor : Editor
{
    private SerializedProperty languages;
    private SerializedProperty language;

    private void OnEnable()
    {
        languages = serializedObject.FindProperty("Languages");
        language = serializedObject.FindProperty("LanguageToTranslate");
    }
    
    public override void OnInspectorGUI()
    {
        GUIStyle labelStyle = new GUIStyle
        {
            fontSize = 16,
            fontStyle = FontStyle.Bold,
            normal = new GUIStyleState()
            {
                textColor = Color.green
            }
        };

        serializedObject.Update();
        
        var main = target as TranslateSO;
        
        // EditorGUILayout.LabelField("Russian", labelStyle);
        EditorGUILayout.PropertyField(language);
        main.TextToTranslate = EditorGUILayout.TextArea(main.TextToTranslate, EditorStyles.textArea);
        EditorGUILayout.PropertyField(languages);
        
        if (GUILayout.Button("Translate"))
        {
            main.Translate();
        }

        for (int i = 0; i < main.Translates.Length; i++)
        {
            EditorGUILayout.LabelField(main.Translates[i].Language, labelStyle);

            EditorGUILayout.Separator();

            EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 1), Color.gray);
            EditorGUILayout.TextArea(main.Translates[i].Text, EditorStyles.wordWrappedLabel);

            if (GUILayout.Button("Copy"))
                EditorGUIUtility.systemCopyBuffer = main.Translates[i].Text;

            EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 1), Color.gray);
            EditorGUILayout.Separator();
        }
        
        serializedObject.ApplyModifiedProperties();
    }
}

#endif