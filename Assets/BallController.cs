using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    public float launchSpeed = 5f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    public void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
        StartCoroutine(DelayedLaunch());
    }

    private IEnumerator DelayedLaunch()
    {
        yield return new WaitForSeconds(1f);
        LaunchBall();
    }

    private void LaunchBall()
    {
        // Lança em uma direção aleatória (esquerda ou direita)
        float xDirection = Random.Range(0, 2) == 0 ? -1f : 1f;
        float yDirection = Random.Range(-0.5f, 0.5f);
        Vector2 direction = new Vector2(xDirection, yDirection).normalized;
        rb.linearVelocity = direction * launchSpeed;
    }
void FixedUpdate()
{
    if (rb.linearVelocity.magnitude < 2f)
    {
        Vector2 newDirection = rb.linearVelocity.normalized;
        rb.linearVelocity = newDirection * 2f; // mantém a direção, aumenta a velocidade
    }
}


}
