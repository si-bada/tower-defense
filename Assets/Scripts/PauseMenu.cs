using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    #region Script Parameters
    public GameObject PauseMenuUI;
    #endregion

    #region Unity Methods
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }
    #endregion

    #region Methods
    public void Toggle()
    {
        PauseMenuUI.SetActive(!PauseMenuUI.activeSelf);
        if(PauseMenuUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelector");
    }
    #endregion
}
