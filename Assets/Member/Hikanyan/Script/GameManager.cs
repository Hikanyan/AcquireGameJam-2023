using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // シーン管理のために必要

public class GameManager : AbstractSingleton<GameManager>
{
    [Tooltip("現在のゲームステート")] [SerializeField]
    private GameState NowGameState = GameState.None;

    [Tooltip("InGameから遷移するシーンの名前を設定")] [SerializeField]
    private string _InGameToResult = "Result";

    [Tooltip("ゲーム開始判定（ゲーム中の時はTrue）")] public bool isGame = false;
    [Tooltip("ゲームクリア判定（クリア時にTrue）")] public bool isClear = false;
    [Tooltip("制限時間")] [SerializeField] private float _time = 180;
    [Tooltip("実際の計算に用いるタイマー変数")] private float _timeValue;

    [Tooltip("制限時間を入れるText")] [SerializeField]
    private Text _timeText;

    [SerializeField] private GameObject _resultUI;

    CriAudioManager _criAudioManager;

    public void Awake()
    {
        _criAudioManager = CriAudioManager.Instance;
        _timeValue = _time;
        UpdateTimeText();
    }

    private void Update()
    {
        StateChange();
    }


    private void StateChange()
    {
        switch (NowGameState)
        {
            case GameState.Start:
                StartGame();
                break;
            case GameState.Result:
                Result();
                break;
            default:
                break;
        }
    }


    private void UpdateGameTimer()
    {
        if (_timeValue > 0)
        {
            _timeValue -= Time.deltaTime;
            UpdateTimeText();
        }
        else
        {
            EndGame();
        }
    }

    private void UpdateTimeText()
    {
        _timeText.text = Mathf.Ceil(_timeValue).ToString();
    }

    public void StartGame()
    {
        isGame = true;
        NowGameState = GameState.InGame;
        // タイマースタート
        if (isGame)
        {
            UpdateGameTimer();
        }
        // BGM再生など
        _criAudioManager.CriBgmPlay(0);
    }


    public void EndGame()
    {
        isGame = false;
        NowGameState = GameState.Result;
        // タイマーストップ
        // BGMストップ
        // リザルトUIを表示
        _resultUI.SetActive(true);
        SceneManager.LoadScene(_InGameToResult);
    }

    public void PauseGame()
    {
        isGame = false;
        // タイマー保持
        // BGMストップ
        // ポーズ画面表示など
    }

    public void Result()
    {
        // スコア表示
        // BGM再生
        // リザルト画面表示など
        _criAudioManager.CriBgmStop();
        _resultUI.SetActive(true);
    }
}

internal enum GameState
{
    None = 0,
    Start,
    InGame,
    Result,
}

public enum ResultRank
{
    None = 0,
    S,
    A,
    B,
    C,
    D,
}