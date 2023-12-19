using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D _rb2d = default;
    [SerializeField, Tooltip("ˆÚ“®‘¬“x")] float _speed = 0f;
    float _horizontalInput = default;
    Animator _playerAnim = default;

    private void Awake()
    {
         _rb2d = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        _playerAnim.SetFloat("moveSpeed", _horizontalInput);
        _rb2d.velocity = new Vector2(_horizontalInput * _speed, _rb2d.velocity.y);
    }
}
