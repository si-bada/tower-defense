using UnityEngine;
using TMPro;
public class LevelManager : MonoBehaviour
{
    #region Static
    public static LevelManager sIntance;
    #endregion

    #region Script Parameters
    public GameObject GameOverUI;
    public GameObject LevelWonUI;
    public int RewardPerLife;
    public TextMeshProUGUI LevelText;
    #endregion


    #region Unity Methods
    private void Awake()
    {
        LevelText.text = "Level"+GameManager.sIntance.currentLevel;
        sIntance = this;
    }
    private void Update()
    {
        if (PlayerManager.sIntance.Lives <= 0)
        {
            GameOver();
        }
    }
    #endregion

    #region Methods
    public void GameOver()
    {
        GameManager.sIntance.SetGameState(GameState.GameOver);
        GameOverUI.SetActive(true);
    }
    public void WinLevel()
    {
        if (GameManager.sIntance.GetGameState() != GameState.GameOver)
        {
            GameManager.sIntance.SetGameState(GameState.LevelWon);
            LevelWonUI.SetActive(true);
        }
    }
    public void Restart()
    {
        GameManager.sIntance.SetGameState(GameState.Started);
    }
    #endregion
}
