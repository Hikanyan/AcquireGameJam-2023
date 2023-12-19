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

    /// <summary> Player‚ª–°‚é</summary>
    public void Sleep()
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
