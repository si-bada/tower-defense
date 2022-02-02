using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Static
    public static GameManager sIntance;
    #endregion

    #region Proprieties
    public int currentLevel { get; set; }
    public int nextLevel { get; set; }
    public int maxLevels { get; set; }
    #endregion

    #region Script Parameters
    public GameConfig configuration;
    #endregion

    #region Fields
    private GameState currentState;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        currentState = GameState.MainMenu;
        sIntance = this;
    }

    #endregion

    #region Methoods
    public GameState GetGameState()
    {
        return currentState;
    }

    public void SetGameState(GameState state)
    {
        currentState = state;
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
