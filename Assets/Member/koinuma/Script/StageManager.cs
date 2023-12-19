using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StageManager : MonoBehaviour
{
    [SerializeField] float _timeLimit;
    [SerializeField] GameObject _clockHand;
    [SerializeField, Tooltip("[0]:ñÈ [1];ñæÇØï˚ [2]:í©")] Image[] _backGrounds;

    [Header("Dream")]
    [SerializeField, Tooltip("draemInterface")] GameObject _dreamInterface;
    [SerializeField, Tooltip("1âÒÇÃDreamÇ≈ÇÃêßå¿éûä‘")] float _dreamTime;
    [SerializeField, Tooltip("DreamèÛë‘Ç…Ç»ÇÍÇÈâÒêî")] int _dreamCount;
    [SerializeField] Text _dreamCountText;
  
    float _timer;
    float _timePer;

    StageState _stageState = StageState.nomal;

    private void Start()
    {
        _timer = _timeLimit;
        _backGrounds[0].DOFade(0f, _timeLimit / 2).OnComplete(OnHalfTime);
        _backGrounds[1].DOFade(1f, _timeLimit / 2);

        _dreamInterface.SetActive(false);
        _dreamCountText.text = _dreamCount.ToString();
    }

    private void Update()
    {
        _timePer = (_timeLimit - _timer) / _timeLimit;
        if (_timePer <= 1) _clockHand.transform.localRotation = Quaternion.Euler(0, 0, -360 * _timePer);
        _timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.X))
        {
            SwitchDream();
        }
    }

    void OnHalfTime()
    {
        _backGrounds[1].DOFade(0f, _timeLimit / 2);
        _backGrounds[2].DOFade(1f, _timeLimit / 2);
    }

    void SwitchDream()
    {
        if (_stageState == StageState.nomal && _dreamCount > 0)
        {
            _dreamInterface.SetActive(true);
            _stageState = StageState.dream;
            _dreamCount--;
            _dreamCountText.text = _dreamCount.ToString();
            Invoke(nameof(ReturnFromDream), _dreamTime);
        }
        else if (_stageState == StageState.dream)
        {
            _dreamInterface.SetActive(false);
            _stageState = StageState.nomal;
            CancelInvoke(nameof(ReturnFromDream));
        }
    }

    void ReturnFromDream()
    {
        _dreamInterface.SetActive(false);
        _stageState = StageState.nomal;
    }
}

enum StageState
{
    nomal,
    dream
}