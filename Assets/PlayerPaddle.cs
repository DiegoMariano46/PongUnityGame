using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    private float move;

    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>(); // Pega o som que você adicionou no Inspector
    }

    void Update()
    {
        move = Input.GetAxisRaw("Vertical"); // W/S ou seta ↑ ↓
    }

    void FixedUpdate()
    {
        Vector2 newPosition = rb.position + Vector2.up * move * speed * Time.fixedDeltaTime;
        newPosition.y = Mathf.Clamp(newPosition.y, -3.4f, 3.4f); // Limita o movimento vertical
        rb.MovePosition(newPosition);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball_0"))
        {
            audioSource.Play(); // Toca o som ao bater na bola
        }
    }
}
