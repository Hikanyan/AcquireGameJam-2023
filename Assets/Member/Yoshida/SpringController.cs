using UnityEngine;

public class SpringController : MonoBehaviour
{
    [SerializeField] private float _jumpPower = 10;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent<Rigidbody2D>(out var rigidbody))
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y + _jumpPower);
            }
            else
            {
                Debug.LogWarning("Rigidbody‚ðŽæ“¾‚Å‚«‚Ü‚¹‚ñ‚Å‚µ‚½");
            }
        }
    }
}
