#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MainSettings))]
[CanEditMultipleObjects]
public class MainSettingsEditor : Editor
{
    private SerializedProperty languages;
    private SerializedProperty startLanguage;
    private SerializedProperty complete;
    private SerializedProperty processing;
    private SerializedProperty safeMode;
    
    private void OnEnable()
    {
        languages = serializedObject.FindProperty("Languages");
        startLanguage = serializedObject.FindProperty("StartLanguage");
        complete = serializedObject.FindProperty("_complete");
        processing = serializedObject.FindProperty("_processing");
        safeMode = serializedObject.FindProperty("SafeMode");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        var mainSettings = target as MainSettings;
        
        EditorGUILayout.PropertyField(startLanguage);
        EditorGUILayout.PropertyField(languages);

        if (GUILayout.Button("Translate"))
        {
            mainSettings.Translate();
        }

        if (processing.boolValue)
        {
            EditorGUILayout.LabelField("Processing!");
        }

        if (complete.boolValue)
        {
            EditorGUILayout.LabelField("Complete!");
        }
        EditorGUILayout.PropertyField(safeMode);
        
        serializedObject.ApplyModifiedProperties();
    }
}
#endif