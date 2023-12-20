using UnityEditor.Animations;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Tooltip("�Q�Ă邩�ǂ���")]bool _isSleep = default;
    public bool IsSleep { get => _isSleep; set => _isSleep = value; }
    [SerializeField, Tooltip("�A�j���[�^�[")] Animator _playerCon = default;
    [SerializeField, Tooltip("�����̃A�j���[�V�����R���g���[���[")]AnimatorController _realPlayerCon = default;
    [SerializeField, Tooltip("���̃A�j���[�V�����R���g���[���[")] AnimatorOverrideController _dreamPlayerCon = default;

    StageManager _stageManager = default;
    private void Start()
    {
        _playerCon = GetComponent<Animator>();
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
        _playerCon.runtimeAnimatorController = _dreamPlayerCon;
        Debug.Log("����");
        _isSleep = true;
        _playerCon.SetTrigger("isSleep");
    }

    /// <summary> Player���ڊo�߂� </summary>
    public void WakeUp()
    {
        _playerCon.runtimeAnimatorController = _realPlayerCon;
        Debug.Log("�ڊo�߂�");
        _isSleep = false;
        _playerCon.SetTrigger("isWakeUp");
    }

}
