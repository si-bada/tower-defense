using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Static
    public static GameManager sIntance;
    #endregion

    #region Proprieties
    public string nextLevel { get; set; }
    public int levelToUnlock { get; set; }
    #endregion
    #region Script Parameters
    public GameObject GameOverUI;
    public GameObject LevelWonUI;
    public int RewardPerLife;
    public GameConfig configuration;
    #endregion

    #region Fields
    private GameState CurrentState;
    private bool gameEnded = false;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        CurrentState = GameState.MainMenu;
        sIntance = this;
        levelToUnlock = PlayerPrefs.GetInt("ReachedLevel", 1) + 1;
        nextLevel = "Level" + levelToUnlock;
        Debug.LogWarning(levelToUnlock);
        Debug.LogWarning(nextLevel);
    }

    private void Update()
    {
        if (gameEnded)
            return;

        if(PlayerManager.sIntance.Lives <= 0)
        {
            GameOver();
        }
    }
    #endregion

    #region Methoods
    public void GameOver()
    {
        CurrentState = GameState.GameOver;
        GameOverUI.SetActive(true);
    }

    public void Restart()
    {
        CurrentState = GameState.Started;
    }

    public GameState GetGameState()
    {
        return CurrentState;
    }

    public void SetGameState(GameState state)
    {
        CurrentState = state;
    }

    public void WinLevel()
    {
        CurrentState = GameState.LevelWon;
        LevelWonUI.SetActive(true);
        PlayerPrefs.SetInt("ReachedLevel", levelToUnlock);
    }
    #endregion
}

public enum GameState
{
    MainMenu,
    Started,
    Paused,
    GameOver,
    LevelWon,
}
