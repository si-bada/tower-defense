using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    #region Script Parameters
    public Button[] Levels;
    #endregion

    #region Unity Methods
    private void Start()
    {
        GameManager.sIntance.maxLevels = Levels.Length;

        int levelReached = UserController.sInstance.CurrentUser.level_reached;
        for (int i = levelReached; i < Levels.Length; i++)
        {
            Levels[i].interactable = false;
        }
    }
    #endregion

    #region Methods
    public void Select(int level)
    {
        GameManager.sIntance.currentLevel = level;
        GameManager.sIntance.nextLevel = level+1;
        SceneManager.LoadSceneAsync("Level"+level);
    }
    #endregion
}
