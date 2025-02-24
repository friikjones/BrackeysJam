using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    [SerializeField] public string mainMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // TODO add transition
        NextScene();
    }

    // Update is called once per frame
    void NextScene()
    {
        SceneManager.LoadScene(mainMenu, LoadSceneMode.Single);
    }
}
