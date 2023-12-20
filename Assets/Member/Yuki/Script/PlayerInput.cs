using UnityEditor.Animations;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Tooltip("寝てるかどうか")]bool _isSleep = default;
    public bool IsSleep { get => _isSleep; set => _isSleep = value; }
    [SerializeField, Tooltip("アニメーター")] Animator _playerCon = default;
    [SerializeField, Tooltip("現実のアニメーションコントローラー")]AnimatorController _realPlayerCon = default;
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
            if (_isSleep) WakeUp();
            else Sleep();
        }
    }

    /// <summary> Playerが眠る</summary>
    public void Sleep()
    {
        _playerCon.runtimeAnimatorController = _dreamPlayerCon;
        Debug.Log("眠る");
        _isSleep = true;
        _playerCon.SetTrigger("isSleep");
    }

    /// <summary> Playerが目覚める </summary>
    public void WakeUp()
    {
        _playerCon.runtimeAnimatorController = _realPlayerCon;
        Debug.Log("目覚める");
        _isSleep = false;
        _playerCon.SetTrigger("isWakeUp");
    }

}
