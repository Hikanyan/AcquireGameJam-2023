using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    bool _isSleep = default;
    public bool IsSleep { get => _isSleep; set => _isSleep = value; }
    Animator _playerAnimator = default;

    bool _canWakeUp = false;
    StageManager _stageManager = default;
    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _stageManager = StageManager.Instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            _stageManager.SwitchDream();
            if (_isSleep) WakeUp();
            else Sleep();
        }
    }

    /// <summary> Player������</summary>
    public void Sleep()
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
