
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager: AbstractSingleton<GameManager>
{
    [Tooltip("現在のゲームステート")]
    [SerializeField] private GameState NowGameState = GameState.None;
    [Tooltip("InGameから遷移するシーンの名前を設定")]
    [SerializeField] private string _InGameTOresult = "Result";
    
    [Tooltip("ゲーム開始判定（ゲーム中の時はTrue）")]
    public bool isGame = false;
    [Tooltip("ゲームクリア判定（クリア時にTrue）")]
    public bool isClear = false;
    [Tooltip("制限時間")]
    [SerializeField] private float _time = 180;
    [Tooltip("実際の計算に用いるタイマー変数")]
    private float _timeValue;
    [Tooltip("制限時間を入れるText")]
    [SerializeField] private Text _timeText;
    
    [SerializeField] GameObject _resultUI;
    
    
    //CriAudioManager _criAudioManager;
    public void Initialize()
    {
        //_criAudioManager = CriAudioManager.Instance;
    }

    public void Title()
    {
        //_criAudioManager.PlayBGM(CriAudioManager.CueSheet.Bgm, "");
    }

    public void StartGame()
    {
        //タイマースタート
        //BGM
        //
    }
    public void EndGame()
    {
        //タイマーストップ
        //BGMストップ
        //リザルト
        
    }
    public void PauseGame()
    {
        //タイマーストップ 保持
        //BGMストップ
        //ポーズ画面
        Result();
    }
    
    public void Result()
    {
        //Score表示 評価
        //BGM
        //リザルト画面
        
    }
}

internal enum GameState
{
    None = 0,
    Start,
    InGame,
    Result,
}