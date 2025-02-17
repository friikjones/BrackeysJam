using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMusicController : MonoBehaviour
{

    public static BGMusicController instance;

    public AudioClip bgmusic, gamemusic;
    private bool sceneChange;
    private Scene lastScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        CreateSingleton();
    }

    void CreateSingleton()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != lastScene.name)
        {
            if (SceneManager.GetActiveScene().name.Contains("Menu"))
            {
                this.GetComponent<AudioSource>().clip = bgmusic;
            }
            if (SceneManager.GetActiveScene().name.Contains("Game"))
            {
                this.GetComponent<AudioSource>().clip = gamemusic;
            }
            this.GetComponent<AudioSource>().Play(0);
        }
        lastScene = SceneManager.GetActiveScene();

    }

    void CheckCurrentScene()
    {

        int countLoaded = SceneManager.sceneCount;
        Scene[] loadedScenes = new Scene[countLoaded];

        for (int i = 0; i < countLoaded; i++)
        {
            loadedScenes[i] = SceneManager.GetSceneAt(i);
        }
        foreach (var item in loadedScenes)
        {
            print(item.name);
        }
    }
}
