using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    #region static
    public static PlayerManager sIntance;
    #endregion

    #region Script Parameters
    public TextMeshProUGUI CurrentMoney;
    public TextMeshProUGUI CurrentLives;
    public TextMeshProUGUI CurrentScore;
    public int StartMoney;  
    public int StartLives;
    public int Money;
    public int Lives;
    public int Score;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        sIntance = this;
    }
    private void Start()
    {
        Money = StartMoney;
        CurrentMoney.text = Money.ToString();

        Lives = StartLives;
        CurrentLives.text = Lives.ToString();

        Score = UserController.sInstance.CurrentUser.score;
        CurrentScore.text = Score.ToString();
    }
    #endregion

    #region Methods
    public void SubMoney(int cost)
    {
        Money -= cost;
        CurrentMoney.text = Money.ToString();
    }
    public void GainMoney(int cost)
    {
        Money += cost;
        CurrentMoney.text = Money.ToString();
    }
    public void LoseLife()
    {
        Lives -= 1;
        CurrentLives.text = Lives.ToString();
    }

    public void UpadateScore(int reward)
    {
        Score += reward;
        CurrentScore.text = Score.ToString();
    }
    #endregion
}
