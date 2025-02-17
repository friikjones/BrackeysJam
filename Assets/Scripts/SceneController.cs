using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // public SceneAsset mainMenu, gameScene, settingsScene;
    // public GameObject bgmusicHodler;
    public List<SceneAsset> sceneList;
    public GameObject bgmusic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // if (SceneManager.GetSceneByName(sceneList[0].name) != null)
        for (int n = 0; n < SceneManager.sceneCount; ++n)
        {
            var scene = SceneManager.GetSceneAt(n);
            if (scene.name == sceneList[0].name)
            {
                SceneManager.UnloadSceneAsync(sceneList[0].name);
            }
        }
        if (!BGMusicController.instance.GetComponent<AudioSource>().isPlaying)
        {
            BGMusicController.instance.GetComponent<AudioSource>().Play(0);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadSettings()
    {
        SceneManager.LoadScene(sceneList[3].name, LoadSceneMode.Single);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(sceneList[1].name, LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Application.Quit();
    }


}
