using UnityEngine;

public class GoalDetector : MonoBehaviour
{
    public string scorer; // "Player" ou "Enemy"
    public ScoreManagerSprites scoreManager; // Referência ao ScoreManager

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball_0"))
        {
            Debug.Log(scorer + " marcou um ponto!");

            if (scorer == "Player")
                scoreManager.AddPlayerPoint();
            else if (scorer == "Enemy")
                scoreManager.AddEnemyPoint();

            other.GetComponent<BallController>().ResetBall();
        }
    }
}