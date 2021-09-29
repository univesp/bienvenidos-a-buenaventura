using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SceneLoader))]
public class SceneLoaderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SceneLoader sceneLoader = (SceneLoader)target;
        
        //Desenha a caixa de seleção para o bool
        sceneLoader.loadOnStart = EditorGUILayout.Toggle("Load On Start", sceneLoader.loadOnStart);

        //Se esse bool for verdadeiro, ele mostra os outros componentes
        if (sceneLoader.loadOnStart)
        {
            sceneLoader.startSceneIndex = EditorGUILayout.IntField("Scene Index", sceneLoader.startSceneIndex);
        }

    }
}
