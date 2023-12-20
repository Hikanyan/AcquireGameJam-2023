
using UnityEngine;

public class SequenceManager : AbstractSingleton<SequenceManager>
{
    [SerializeField] GameObject[] _preloadedAssets;
    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        InstantiatePreloadedAssets();
        GameManager.Instance.Initialize();
    }

    /// <summary>
    /// 登録されたPrefabを全てインスタンス化
    /// </summary>
    void InstantiatePreloadedAssets()
    {
        foreach (var asset in _preloadedAssets)
        {
            Instantiate(asset);
        }
    }
}