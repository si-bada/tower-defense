using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    #region static
    public static PlayerManager sIntance;
    #endregion

    #region Script Parameters
    public int Money;
    public TextMeshProUGUI CurrentMoney;
    public int StartMoney = 400;
    public int Lives;
    public TextMeshProUGUI CurrentLives;
    public int StartLives = 400;
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
    #endregion
}
