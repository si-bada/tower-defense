using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] Levels;
    public void Select(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("ReachedLevel", 1);
        for (int i = levelReached; i < Levels.Length; i++)
        {
            Levels[i].interactable = false;
        }
    }
}
