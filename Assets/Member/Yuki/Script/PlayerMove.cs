using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D _rb2d = default;
    [SerializeField, Tooltip("ˆÚ“®‘¬“x")] float _speed = 0f;
    float _horizontalInput = default;
    Animator _playerAnim = default;
    AudioManager _audioManager = default;
    [SerializeField] AudioClip _stepSE = default;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<Animator>();
        _audioManager = AudioManager.Instance;
    }

    void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        if (!_playerAnim.GetBool("isJump")) _playerAnim.SetFloat("moveSpeed", Mathf.Abs(_horizontalInput));
        _rb2d.velocity = new Vector2(_horizontalInput * _speed, _rb2d.velocity.y);
        if (_horizontalInput != 0f)
            _rb2d.transform.rotation = _horizontalInput < 0f ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180f, 0);
    }

    public void PlayFootsStepSound()
    {
        _audioManager.SePlay(_stepSE);
    }
}
