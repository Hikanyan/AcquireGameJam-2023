using UnityEditor.Animations;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Tooltip("�Q�Ă邩�ǂ���")]bool _isSleep = default;
    public bool IsSleep { get => _isSleep; }
    [SerializeField, Tooltip("�A�j���[�^�[")] Animator _playerCon = default;
    [SerializeField, Tooltip("�����̃A�j���[�V�����R���g���[���[")]RuntimeAnimatorController _realPlayerCon = default;
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
            //if (_isSleep) WakeUp();
            //else Sleep();
        }
    }

    /// <summary> ���ɂȂ�</summary>
    public void Sleep()
    {
        Debug.Log("���ɂȂ�");
        _isSleep = true;
        _playerCon.SetTrigger("isSleep");
    }

    /// <summary> �����ɂȂ�</summary>
    public void WakeUp()
    {
        Debug.Log("�����ɂȂ�");
        _isSleep = false;
        _playerCon.SetTrigger("isSleep");
    }

    /// <summary> ����A�j���[�V��������A�j���[�V�����C�x���g�ŌĂ� </summary>
    public void ChangeController()
    {
        _playerCon.runtimeAnimatorController = StageManager.Instance.GetStageState == StageState.dream ? _realPlayerCon : _dreamPlayerCon;
    }

}
