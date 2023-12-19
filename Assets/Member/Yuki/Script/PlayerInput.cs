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

    /// <summary> Player������</summary>
    void Sleep()
    {
        Debug.Log("����");
        _isSleep = true;
        _playerAnimator.SetTrigger("isSleep");
    }

    /// <summary> Player���ڊo�߂� </summary>
    public void WakeUp()
    {
        Debug.Log("�ڊo�߂�");
        _isSleep = false;
        _playerAnimator.SetTrigger("isWakeUp");
    }

}
