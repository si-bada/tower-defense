using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "LevelSelector";
    public void Play()
    {
        SceneManager.LoadScene(levelToLoad);
    }

}
