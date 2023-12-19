using UnityEngine;

public class SpringController : MonoBehaviour
{
    [SerializeField] private float _jumpPower = 10;
    [SerializeField, Tooltip("[0]�ʏ펞�̃o�l�X�v���C�g [1]����ł鎞�̃o�l�X�v���C�g")]
    private Sprite[] _springImage;
    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _spriteRenderer.sprite = _springImage[1];
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent<Rigidbody2D>(out var rigidbody))
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y + _jumpPower);
                _spriteRenderer.sprite = _springImage[0];
            }
            else
            {
                Debug.LogWarning("Rigidbody���擾�ł��܂���ł���");
            }
        }
    }
}