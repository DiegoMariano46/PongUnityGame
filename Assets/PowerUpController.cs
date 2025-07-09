using UnityEngine;

public enum PowerUpType { BallBigger, BallFaster, PaddleBigger }

public class PowerUpController : MonoBehaviour
{
    public PowerUpType powerUpType;
    public float duration = 5f;
    public float multiplier = 1.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball_0"))
        {
            BallPowerUp ballPowerUp = other.GetComponent<BallPowerUp>();
            if (ballPowerUp != null)
            {
                ballPowerUp.ApplyPowerUp(powerUpType, duration, multiplier);
            }

            Destroy(gameObject); // Some após ser coletado
        }
    }
}