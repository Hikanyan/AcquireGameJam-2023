using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization; // シーン管理のために必要

public class GameManager : AbstractSingleton<GameManager>
{
    [FormerlySerializedAs("NowGameState")] [Tooltip("現在のゲームステート")] [SerializeField]
    private GameState nowGameState = GameState.None;

    [FormerlySerializedAs("_InGameToResult")] [Tooltip("InGameから遷移するシーンの名前を設定")] [SerializeField]
    private string inGameToResult = "Result";

    [Tooltip("ゲーム開始判定（ゲーム中の時はTrue）")] [SerializeField]
    private bool isGame = false;

    [Tooltip("ゲームクリア判定（クリア時にTrue）")] [SerializeField]
    private bool isClear = false;

    [Tooltip("実際の計算に用いるタイマー変数")] private float _timeValue;

    [FormerlySerializedAs("_resultUI")] [Tooltip("ResultUIを入れる")] [SerializeField]
    private GameObject resultUI;

    AudioManager _audioManager;

    [Tooltip("TitleBGMを入れる")] [SerializeField]
    private AudioClip titleBgmAudioClip;

    [Tooltip("InGameBGMを入れる")] [SerializeField]
    private AudioClip inGameBgmAudioClip;

    [Tooltip("ResultBGMを入れる")] [SerializeField]
    private AudioClip resultBgmAudioClip;

    public void Initialize()
    {
        nowGameState = GameState.Title;
    }

    public void Awake()
    {
        _audioManager = AudioManager.Instance;
        UpdateTimeText();
    }

    private void Update()
    {
        StateChange();
    }


    private void StateChange()
    {
        switch (nowGameState)
        {
            case GameState.Title:
                SceneChange("TitleScene");
                _audioManager.BgmPlay(titleBgmAudioClip);
                break;
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
        _timeValue = StageManager.Instance.TimeLimit;
        if (_timeValue < 0)
        {
            EndGame();
        }
    }

    private void UpdateTimeText()
    {
    }

    public void StartGame()
    {
        isGame = true;
        nowGameState = GameState.InGame;
        // タイマースタート
        if (isGame)
        {
            UpdateGameTimer();
        }

        // BGM再生など
        _audioManager.BgmPlay(inGameBgmAudioClip);
    }


    public void EndGame()
    {
        isGame = false;
        StageManager.Instance.IsPlaying = false;
        nowGameState = GameState.Result;
        // タイマーストップ
        // BGMストップ
        // リザルトUIを表示
        resultUI.SetActive(true);
        SceneChange(inGameToResult);
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
        _audioManager.BgmPlay(resultBgmAudioClip);
        resultUI.SetActive(true);
    }

    //Sceneを切り替える
    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

internal enum GameState
{
    None = 0,
    Title,
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