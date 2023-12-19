using UnityEngine;

public class PlayerInput : AbstractSingleton<PlayerInput>
{
    bool _isSleep = default;
    public bool IsSleep => _isSleep;
    Animator _playerAnimator = default;

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if(_isSleep)WakeUp();
            else Sleep();
        }
    }

    /// <summary> Playerが眠る</summary>
    void Sleep()
    {
        Debug.Log("眠る");
        _isSleep = true;
        _playerAnimator.SetTrigger("isSleep");
    }

    /// <summary> Playerが目覚める </summary>
    public void WakeUp()
    {
        Debug.Log("目覚める");
        _isSleep = false;
        _playerAnimator.SetTrigger("isWakeUp");
    }

}
