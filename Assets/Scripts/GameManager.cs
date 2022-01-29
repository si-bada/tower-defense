using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Static
    public static GameManager sIntance;
    #endregion

    #region Fields
    private GameState CurrentState;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        CurrentState = GameState.MainMenu;
        sIntance = this;
    }
    #endregion

    #region Methoods
    public void GameOver()
    {
        CurrentState = GameState.GameOver;
        Debug.LogWarning("Game Over");
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
