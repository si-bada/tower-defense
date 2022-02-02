using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOver : MonoBehaviour
{
    #region Script Parameters
    public TextMeshProUGUI ScoreText;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        ScoreText.text = PlayerManager.sIntance.Score.ToString();
        User currentUser = UserController.sInstance.CurrentUser;
        currentUser.score = PlayerManager.sIntance.Score;
        UserController.sInstance.Save(currentUser.id, currentUser.score, currentUser.level_reached);
    }
    #endregion

    #region Methods
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        SceneManager.LoadScene("LevelSelector");
    }
    #endregion
}
