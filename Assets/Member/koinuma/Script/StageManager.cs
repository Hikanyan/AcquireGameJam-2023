using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Serialization;

public class StageManager : MonoBehaviour
{
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] int _realLayer;
    [SerializeField] int _dreamLayer;

    [SerializeField, Tooltip("realで見えるobjectの親")]
    GameObject _realField;

    [SerializeField, Tooltip("dreamで見えるobjectの親")]
    GameObject _dreamField;

    [SerializeField] float _timeLimit;
    [SerializeField] GameObject _clockHand;

    [SerializeField, Tooltip("[0]:夜 [1];明け方 [2]:朝")]
    SpriteRenderer[] _backGrounds;

    [Header("Dream")] [SerializeField, Tooltip("draemInterface")]
    GameObject _dreamInterface;

    [SerializeField, Tooltip("1回のDreamでの制限時間")]
    float _dreamTime;

    [SerializeField, Tooltip("Dream状態になれる回数")]
    int _dreamCount;

    [SerializeField] Text _dreamCountText;

    [Tooltip("ゲーム開始判定（ゲーム中の時はTrue）")]
    [SerializeField]
    private bool isGame = false;

    [Tooltip("ゲームクリア判定（クリア時にTrue）")]
    [SerializeField]
    private bool isClear = false;


    [Tooltip("ResultUIを入れる")]
    [SerializeField]
    private GameObject resultUI;

    [Tooltip("TitleBGMを入れる")]
    [SerializeField]
    private AudioClip titleBgmAudioClip;

    [Tooltip("InGameBGMを入れる")]
    [SerializeField]
    private AudioClip inGameBgmAudioClip;

    [Tooltip("ResultBGMを入れる")]
    [SerializeField]
    private AudioClip resultBgmAudioClip;


    static StageManager _instance;
    static AudioManager _audioManager;

    public static StageManager Instance
    {
        get => _instance;
    }

    public float TimeLimit
    {
        get => _timeLimit;
    }

    public bool IsPlaying
    {
        get => _isPlaying;
        set => _isPlaying = value;
    }

    Collider2D[] _realColliders;
    Collider2D[] _dreamColliders;

    float _timer;
    float _timePer;
    bool _isPlaying = false;
    StageState _stageState = StageState.real;
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
        _dreamCountText.text = _dreamCount.ToString();

        SwitchField();
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

    public void SwitchDream()
    {
        if (_stageState == StageState.real && _dreamCount > 0)
        {
            _stageState = StageState.dream;
            _dreamInterface.SetActive(true);
            SwitchField();

            _dreamCount--;
            _dreamCountText.text = _dreamCount.ToString();
            Invoke(nameof(ReturnFromDream), _dreamTime);
        }
        else if (_stageState == StageState.dream)
        {
            _stageState = StageState.real;
            _dreamInterface.SetActive(false);
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

    void SwitchField() // stageを切り替える
    {
        if (_stageState == StageState.real) // to real
        {
            _playerInput.WakeUp();
            Camera.main.cullingMask = ~(1 << _dreamLayer);
            foreach (Collider2D col in _realColliders) col.isTrigger = false;
            foreach (Collider2D col in _dreamColliders) col.isTrigger = true;
        }
        else // to dream
        {
            _playerInput.Sleep();
            Camera.main.cullingMask = ~(1 << _realLayer);
            foreach (Collider2D col in _realColliders) col.isTrigger = true;
            foreach (Collider2D col in _dreamColliders) col.isTrigger = false;
        }
    }

    public void AddDreamCount()
    {
        _dreamCount++;
        _dreamCountText.text = _dreamCount.ToString();
    }
}

public enum StageState
{
    real,
    dream
}