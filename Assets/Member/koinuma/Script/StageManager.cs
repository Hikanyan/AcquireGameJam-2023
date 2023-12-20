using UnityEngine;
using DG.Tweening;

public class StageManager : MonoBehaviour
{
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] int _realLayer;
    [SerializeField] int _dreamLayer;

    [SerializeField, Tooltip("realÇ≈å©Ç¶ÇÈobjectÇÃêe")]
    GameObject _realField;

    [SerializeField, Tooltip("dreamÇ≈å©Ç¶ÇÈobjectÇÃêe")]
    GameObject _dreamField;
    
    [SerializeField] GameObject _gool;

    [SerializeField] float _timeLimit;
    [SerializeField] GameObject _clockHand;
    [SerializeField] GameObject _dreamClockHand;

    [SerializeField, Tooltip("[0]:ñÈ [1];ñæÇØï˚ [2]:í©")]
    SpriteRenderer[] _backGrounds;

    [Header("Dream")] [SerializeField, Tooltip("draemInterface")]
    GameObject _dreamInterface;

    [SerializeField] GameObject _realClock;
    [SerializeField] GameObject _dreamClock;

    [SerializeField, Tooltip("1âÒÇÃDreamÇ≈ÇÃêßå¿éûä‘")]
    float _dreamTime;

    [SerializeField, Tooltip("DreamèÛë‘Ç…Ç»ÇÍÇÈâÒêî")]
    int _dreamCount;

    [SerializeField] GameObject _appleUI;
    [SerializeField] GameObject _dreamCountLayoutGroup;

    [Space(10)]
    [Tooltip("ResultUIÇì¸ÇÍÇÈ")]
    [SerializeField]
    private GameObject _resultUI;

    [Tooltip("GameOverUIÇì¸ÇÍÇÈ")]
    [SerializeField]
    private GameObject _gameOverUI;

    [Tooltip("TitleBGMÇì¸ÇÍÇÈ")]
    [SerializeField]
    private AudioClip _titleBgmAudioClip;

    [Tooltip("InGameBGMÇì¸ÇÍÇÈ")]
    [SerializeField]
    private AudioClip _inGameBgmAudioClip;

    [Tooltip("ResultBGMÇì¸ÇÍÇÈ")]
    [SerializeField]
    private AudioClip _resultBgmAudioClip;

    static StageManager _instance;
    public static StageManager Instance
    {
        get => _instance;
    }

    static AudioManager _audioManager;

    bool _isPlaying = true;
    public bool IsPlaying
    {
        get => _isPlaying;
        set => _isPlaying = value;
    }

    Collider2D[] _realColliders;
    Collider2D[] _dreamColliders;

    float _timer;
    float _timePer;
    float _dreamTimer;
    [SerializeField] StageState _stageState = StageState.real;
    public StageState GetStageState => _stageState;

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

        _realColliders = _realField.GetComponentsInChildren<Collider2D>();
        _dreamColliders = _dreamField.GetComponentsInChildren<Collider2D>();
    }

    private void Start()
    {
        _isPlaying = true;
        _timer = _timeLimit;
        _backGrounds[0].DOFade(0f, _timeLimit / 2).OnComplete(OnHalfTime);
        _backGrounds[1].DOFade(1f, _timeLimit / 2);

        _dreamInterface.SetActive(false);
        //_resultUI.SetActive(false);
        //_gameOverUI.SetActive(false);

        SwitchField();
    }

    private void Update()
    {
        _timePer = (_timeLimit - _timer) / _timeLimit;
        if (_timePer <= 1)
        {
            _clockHand.transform.localRotation = Quaternion.Euler(0, 0, -360 * _timePer);
        }
        else if (_isPlaying) GameOver();

        if (_dreamTimer > 0)
        {
            _dreamClockHand.transform.localRotation = Quaternion.Euler(0, 0, -360 * (_dreamTime - _dreamTimer) / _dreamTime);
            _dreamTimer -= Time.deltaTime;
        }

        _timer -= Time.deltaTime;

        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    //SwitchDream();
        //}
    }

    void OnHalfTime()
    {
        _backGrounds[1].DOFade(0f, _timeLimit / 2);
        _backGrounds[2].DOFade(1f, _timeLimit / 2);
    }

    public void SwitchDream()
    {
        //ÉäÉAÉã
        if (_stageState == StageState.real && _dreamCount > 0)
        {
            Debug.Log(_dreamCount + "a");
            _stageState = StageState.dream;
            _gool.SetActive(false);
            SwitchField();

            _dreamCount--;
            UpdateLayoutGroup();
            Invoke(nameof(ReturnFromDream), _dreamTime);
        }
        //ñ≤
        else if (_stageState == StageState.dream)
        {
            Debug.Log(_dreamCount + "b");
            _stageState = StageState.real;
            _gool.SetActive(true);
            SwitchField();

            CancelInvoke(nameof(ReturnFromDream));
        }
    }

    void ReturnFromDream()
    {
        _dreamInterface.SetActive(false);
        _stageState = StageState.real;
        SwitchField();
    }

    void SwitchField() // stageÇêÿÇËë÷Ç¶ÇÈ
    {
        if (_stageState == StageState.real) // to real
        {
            _playerInput.WakeUp();
            Camera.main.cullingMask = ~(1 << _dreamLayer);
            foreach (Collider2D col in _realColliders) col.isTrigger = false;
            foreach (Collider2D col in _dreamColliders) col.isTrigger = true;
            _realClock.SetActive(true);
            _dreamClock.SetActive(false);
            
        }
        else // to dream
        {
            _playerInput.Sleep();
            Camera.main.cullingMask = ~(1 << _realLayer);
            foreach (Collider2D col in _realColliders) col.isTrigger = true;
            foreach (Collider2D col in _dreamColliders) col.isTrigger = false;
            _realClock.SetActive(false);
            _dreamClock.SetActive(true);

            _dreamTimer = _dreamTime;
        }
    }

    public void AddDreamCount()
    {
        _dreamCount++;
        UpdateLayoutGroup();
    }

    void UpdateLayoutGroup()
    {
        foreach (Transform apple in _dreamCountLayoutGroup.transform)
        {
            Destroy(apple.gameObject);
        }

        for (int i = 0;  i < _dreamCount; i++)
        {
            Instantiate(_appleUI, _dreamCountLayoutGroup.transform);
        }
    }

    public void GameOver()
    {
        _isPlaying = false;
        _gameOverUI?.SetActive(true);
    }

    public void GameClear()
    {
        _isPlaying = false;
        _resultUI?.SetActive(true);
    }
}

public enum StageState
{
    real,
    dream
}