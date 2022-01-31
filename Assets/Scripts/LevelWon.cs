using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWon : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    private void OnEnable()
    {
        ScoreText.text = (PlayerManager.sIntance.Score + PlayerManager.sIntance.Lives * GameManager.sIntance.RewardPerLife).ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Next()
    {
        SceneManager.LoadScene(GameManager.sIntance.nextLevel);
    }

    public void Menu()
    {
        Debug.Log("mnu");
    }
}
