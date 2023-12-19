
using UnityEngine;

public class GameManager: AbstractSingleton<GameManager>
{
    [SerializeField] GameObject _resultUI;
    
    
    CriAudioManager _criAudioManager;
    public void Initialize()
    {
        _criAudioManager = CriAudioManager.Instance;
    }

    public void Title()
    {
        _criAudioManager.PlayBGM(CriAudioManager.CueSheet.Bgm, "");
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