using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StageManager : MonoBehaviour
{
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] float _timeLimit;
    [SerializeField] GameObject _clockHand;
    [SerializeField, Tooltip("[0]:–é [1];–¾‚¯•û [2]:’©")] SpriteRenderer[] _backGrounds;

    [Header("Dream")]
    [SerializeField, Tooltip("draemInterface")] GameObject _dreamInterface;
    [SerializeField, Tooltip("1‰ñ‚ÌDream‚Å‚Ì§ŒÀŽžŠÔ")] float _dreamTime;
    [SerializeField, Tooltip("Dreamó‘Ô‚É‚È‚ê‚é‰ñ”")] int _dreamCount;
    [SerializeField] Text _dreamCountText;

    static StageManager _instance;
    public static StageManager Instance{ get => _instance; }

    float _timer;
    float _timePer;
    StageState _stageState = StageState.nomal;

    private void Awake()
    {
        if (TryGetComponent<StageManager>(out var instance))
        {
            _instance = instance;
        }
        else
        {
            GameObject singletonObject = new GameObject();
            instance = singletonObject.AddComponent<StageManager>();
            singletonObject.name = typeof(StageManager).ToString();
        }
    }

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
            //SwitchDream();
        }
    }

    void OnHalfTime()
    {
        _backGrounds[1].DOFade(0f, _timeLimit / 2);
        _backGrounds[2].DOFade(1f, _timeLimit / 2);
    }

    public void SwitchDream()
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

    public void AddDreamCount()
    {
        _dreamCount++;
        _dreamCountText.text = _dreamCount.ToString();
    }
}

enum StageState
{
    nomal,
    dream
}