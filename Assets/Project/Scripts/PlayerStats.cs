using UnityEngine;
using TMPro;
public class PlayerStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] int startMoney = 400;
    [SerializeField] int startLives = 10;
    int lives;
    int money;
    int rounds;
    public int Money { get { return money; } private set { } }
    public int Lives { get { return lives; } private set { } }
    public int Rounds { get { return rounds; } private set { } }

    private void Start()
    {
        money = startMoney;
        lives = startLives;
        UpdateMoneyText();
        UpdateLivesText();
    }
    public void IncreaseRound()
    {
        rounds++;
    }
    public void UpdateMoneyText()
    {
        moneyText.text = "$" + money.ToString();
    }
    public void UpdateLivesText()
    {
        livesText.text = lives.ToString() + " LIVES";
    }
    public void DecreaseMoney(int amount)
    {
        money -= amount;
        UpdateMoneyText();
    }
    public void IncraseMoney(int amount)
    {
        money += amount;
        UpdateMoneyText();
    }
    public void DecreaseLive(int amount)
    {
        lives -= amount;
        UpdateLivesText();
    }
}