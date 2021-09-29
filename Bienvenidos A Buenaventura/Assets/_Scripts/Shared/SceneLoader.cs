using UnityEngine;
using UnityEngine.SceneManagement;

//Esse script carrega as cenas no decorrer do jogo. Ele tem um custom inspector
public class SceneLoader : MonoBehaviour {

    public bool loadOnStart;
    public int startSceneIndex;

    private void Start()
    {
        if(loadOnStart)
        {
            SceneManager.LoadScene(startSceneIndex, LoadSceneMode.Single);
        }
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
}