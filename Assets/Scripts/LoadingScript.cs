using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    public SceneAsset mainMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // TODO add transition
        NextScene();
    }

    // Update is called once per frame
    void NextScene()
    {
        SceneManager.LoadScene(mainMenu.name, LoadSceneMode.Single);
    }
}
