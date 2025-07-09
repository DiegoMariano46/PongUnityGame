using UnityEngine;
using System.Collections;

public class BallPowerUp : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 originalScale;
    private float originalSpeed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
        originalSpeed = rb.linearVelocity.magnitude;
    }

    public void ApplyPowerUp(PowerUpType type, float duration, float multiplier)
    {
        switch (type)
        {
            case PowerUpType.BallBigger:
                StartCoroutine(ApplyBallBigger(duration, multiplier));
                break;
            case PowerUpType.BallFaster:
                StartCoroutine(ApplyBallFaster(duration, multiplier));
                break;
            case PowerUpType.PaddleBigger:
                // Podemos estender depois para ativar na raquete
                break;
        }
    }

    IEnumerator ApplyBallBigger(float duration, float scaleMult)
    {
        transform.localScale = originalScale * scaleMult;
        yield return new WaitForSeconds(duration);
        transform.localScale = originalScale;
    }

   IEnumerator ApplyBallFaster(float duration, float speedMult)
{
    float multiplier = speedMult;

    // Aplica multiplicador na velocidade atual
    rb.linearVelocity *= multiplier;

    yield return new WaitForSeconds(duration);

    // Corrige: usa a direção e velocidade ATUAL para diminuir
    rb.linearVelocity /= multiplier;
}
}
