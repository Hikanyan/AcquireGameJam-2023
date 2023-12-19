using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    Rigidbody2D _rb2d = default;
    [SerializeField] float _jumpForce = default;
    [SerializeField] int _jumpCount = 0;
    int _jumpCountMax = 2;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    void Jump()
    {
        if (_jumpCount < _jumpCountMax)
        {
            _rb2d.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") _jumpCount = 0;
    }
}
