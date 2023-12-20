using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    private Rigidbody2D _rigidbody2D;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerDead>();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (transform.localScale.x == -1)
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x + _speed, _rigidbody2D.velocity.y);
            }
            else
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x + -_speed, _rigidbody2D.velocity.y);
            }
        }
    }
}
