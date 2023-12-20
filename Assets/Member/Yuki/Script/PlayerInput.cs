using UnityEditor.Animations;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Tooltip("寝てるかどうか")]bool _isSleep = default;
    public bool IsSleep { get => _isSleep; }
    [SerializeField, Tooltip("アニメーター")] Animator _playerCon = default;
    [SerializeField, Tooltip("現実のアニメーションコントローラー")]RuntimeAnimatorController _realPlayerCon = default;
    [SerializeField, Tooltip("夢のアニメーションコントローラー")] AnimatorOverrideController _dreamPlayerCon = default;

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

    /// <summary> 夢になる</summary>
    public void Sleep()
    {
        Debug.Log("夢になる");
        _isSleep = true;
        _playerCon.SetTrigger("isSleep");
    }

    /// <summary> 現実になる</summary>
    public void WakeUp()
    {
        Debug.Log("現実になる");
        _isSleep = false;
        _playerCon.SetTrigger("isSleep");
    }

    /// <summary> 眠るアニメーションからアニメーションイベントで呼ぶ </summary>
    public void ChangeController()
    {
        _playerCon.runtimeAnimatorController = StageManager.Instance.GetStageState == StageState.dream ? _realPlayerCon : _dreamPlayerCon;
    }

}
