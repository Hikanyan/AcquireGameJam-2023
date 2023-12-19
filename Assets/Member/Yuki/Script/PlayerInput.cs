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

    /// <summary> Player‚ª–°‚é</summary>
    void Sleep()
    {
        Debug.Log("–°‚é");
        _isSleep = true;
        _playerAnimator.SetTrigger("isSleep");
    }

    /// <summary> Player‚ª–ÚŠo‚ß‚é </summary>
    public void WakeUp()
    {
        Debug.Log("–ÚŠo‚ß‚é");
        _isSleep = false;
        _playerAnimator.SetTrigger("isWakeUp");
    }

}
