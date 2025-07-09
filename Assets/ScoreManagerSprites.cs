using UnityEngine;

public class ScoreManagerSprites : MonoBehaviour
{
    public ScoreDigit playerDigit1; // Dezena
    public ScoreDigit playerDigit2; // Unidade
    public ScoreDigit enemyDigit1;
    public ScoreDigit enemyDigit2;

    private int playerScore = 0;
    private int enemyScore = 0;

    public void AddPlayerPoint()
    {
        playerScore++;
        UpdateUI();
    }

    public void AddEnemyPoint()
    {
        enemyScore++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        playerDigit1.SetDigit(playerScore / 10); // dezena
        playerDigit2.SetDigit(playerScore % 10); // unidade

        enemyDigit1.SetDigit(enemyScore / 10);
        enemyDigit2.SetDigit(enemyScore % 10);
    }
}