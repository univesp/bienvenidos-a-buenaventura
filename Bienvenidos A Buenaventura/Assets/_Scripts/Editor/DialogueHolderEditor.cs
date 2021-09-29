using UnityEngine;
using UnityEditor;
using DialogueSystem;

[CustomEditor(typeof(DialogueHolder))]
public class DialogueHolderEditor : Editor
{
    SerializedProperty json;
    SerializedProperty dialogue;

    SerializedProperty action;
    private void OnEnable()
    {
        json = serializedObject.FindProperty("json");
        dialogue = serializedObject.FindProperty("dialogue");
        action = serializedObject.FindProperty("action");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DialogueHolder dialogueHolder = (DialogueHolder)target;


        EditorGUILayout.PropertyField(json);
        EditorGUILayout.PropertyField(dialogue);

        GUILayout.Label("Avisa se tem ação", EditorStyles.boldLabel);
        dialogueHolder.haveAction = EditorGUILayout.Toggle("have action", dialogueHolder.haveAction);

        if (dialogueHolder.haveAction)
        {
            EditorGUILayout.PropertyField(action);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
