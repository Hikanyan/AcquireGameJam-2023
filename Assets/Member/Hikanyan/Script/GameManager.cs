using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization; // シーン管理のために必要

public class GameManager : AbstractSingleton<GameManager>
{
    [Tooltip("現在のゲームステート")] [SerializeField]
    private GameState nowGameState = GameState.None;

    [Tooltip("InGameから遷移するシーンの名前を設定")] [SerializeField]
    private string inGameToResult = "Result";

    [Tooltip("TitleBGMを入れる")] [SerializeField]
    private AudioClip titleBgmAudioClip;

    public void Initialize()
    {
        nowGameState = GameState.Title;
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
                AudioManager.Instance.BgmPlay(titleBgmAudioClip);
                nowGameState = GameState.None;
                break;
            case GameState.Start:
                break;
            case GameState.Result:
                SceneChange(inGameToResult);
                nowGameState = GameState.None;
                break;
            default:
                break;
        }
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