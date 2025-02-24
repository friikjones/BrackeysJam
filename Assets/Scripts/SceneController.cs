using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // public Scene mainMenu, gameScene, settingsScene;
    // public GameObject bgmusicHodler;
    public List<string> sceneList;
    public GameObject bgmusic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // if (SceneManager.GetSceneByName(sceneList[0].name) != null)
        for (int n = 0; n < SceneManager.sceneCount; ++n)
        {
            var scene = SceneManager.GetSceneAt(n);
            if (scene.name == sceneList[0])
            {
                SceneManager.UnloadSceneAsync(sceneList[0]);
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
        SceneManager.LoadScene(sceneList[3], LoadSceneMode.Single);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(sceneList[1], LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Application.Quit();
    }


}
