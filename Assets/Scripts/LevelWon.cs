using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWon : MonoBehaviour
{
    #region Script Parameters
    public TextMeshProUGUI ScoreText;
    public GameObject ButtonNext;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        var finalScore = PlayerManager.sIntance.Score + PlayerManager.sIntance.Lives * LevelManager.sIntance.RewardPerLife;
        ScoreText.text = "Score : " + finalScore;
        User currentUser = UserController.sInstance.CurrentUser;
        currentUser.score = finalScore;
        if(GameManager.sIntance.nextLevel > currentUser.level_reached)
        {
            currentUser.level_reached++;
            UserController.sInstance.Save(currentUser.id, currentUser.score, currentUser.level_reached);
        }
        if (GameManager.sIntance.nextLevel > GameManager.sIntance.maxLevels)
        {
            ScoreText.text = "You finished the game !";
            ButtonNext.SetActive(false);
        }
    }
    #endregion

    #region Methods
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Next()
    {
        GameManager.sIntance.currentLevel++;
        GameManager.sIntance.nextLevel++;
        SceneManager.LoadScene("Level"+GameManager.sIntance.currentLevel);
    }

    public void Menu()
    {
        SceneManager.LoadScene("LevelSelector");
    }
    #endregion
}
