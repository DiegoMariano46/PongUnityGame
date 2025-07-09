using UnityEngine;

public class EnemyPaddle : MonoBehaviour
{
    public Transform Ball_0;
    public float speed = 5f;
    public float followThreshold = 0.3f;

    private AudioSource audioSource;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (Ball_0 != null)
        {
            float direction = Ball_0.position.y - transform.position.y;

            if (Mathf.Abs(direction) > followThreshold)
            {
                Vector2 movement = new Vector2(0, Mathf.Sign(direction) * speed * Time.fixedDeltaTime);
                Vector2 newPosition = rb.position + movement;
                newPosition.y = Mathf.Clamp(newPosition.y, -3.4f, 3.4f);
                rb.MovePosition(newPosition);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball_0"))
        {
            audioSource.Play();
        }
    }
}