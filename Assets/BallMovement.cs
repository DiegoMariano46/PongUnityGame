using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f;
    public float speedIncrement = 0.5f;
    public float maxSpeed = 15f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        Vector2 direction = new Vector2(Random.value < 0.5f ? -1 : 1, Random.Range(-1f, 1f)).normalized;
        rb.linearVelocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Se colidir com raquete
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 currentDir = rb.linearVelocity.normalized;
            float currentSpeed = rb.linearVelocity.magnitude + speedIncrement;
            rb.linearVelocity = currentDir * Mathf.Min(currentSpeed, maxSpeed);
        }

        // Se colidir com parede (topo/fundo)
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 currentDir = rb.linearVelocity.normalized;
            float currentSpeed = rb.linearVelocity.magnitude + (speedIncrement / 2f);
            rb.linearVelocity = currentDir * Mathf.Min(currentSpeed, maxSpeed);
        }
    }
}