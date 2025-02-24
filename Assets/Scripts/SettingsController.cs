using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
{
    public string mainMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenu, LoadSceneMode.Single);
    }
}
