using UnityEngine;

public class YoshidaPlayer : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetButton("Jump"))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y + 1);
        }
    }
}
