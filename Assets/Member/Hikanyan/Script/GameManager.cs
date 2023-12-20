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
                break;
            case GameState.Start:
                break;
            case GameState.Result:
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