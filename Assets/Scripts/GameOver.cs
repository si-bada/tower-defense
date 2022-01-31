using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    private void OnEnable()
    {
        ScoreText.text = PlayerManager.sIntance.Score.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("mnu");
    }
}
