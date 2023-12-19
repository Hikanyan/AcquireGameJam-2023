using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ChangeLayer : MonoBehaviour
{
    [SerializeField] Camera m_camera;
    private NowState _nowState = NowState.Real;

    private void Start()
    {
        var realLayer = LayerMask.NameToLayer("Real");
        var dreamLayer = LayerMask.NameToLayer("Dream");

        //realLayerを表示
        ChangeCameraLayer(dreamLayer);
        
        this.UpdateAsObservable()
        .Subscribe(_ =>
        {
            if (Input.GetKeyDown(KeyCode.X)) //ボタンが押されたとき(今上限はない。)
            {
                if(_nowState == NowState.Real)
                {
                    _nowState = NowState.Dream;
                    ChangeCameraLayer(realLayer); //Realレイヤー以外を表示
                }
                else
                {
                    _nowState = NowState.Real;
                    ChangeCameraLayer(dreamLayer);//dreamレイヤー以外を表示
                }
            }
        });
    }
    /// <summary>
    /// 渡されたレイヤー以外を表示する。
    /// </summary>
    private void ChangeCameraLayer(int layer)
    {
        m_camera.cullingMask = ~(1 << layer); 
    }
}
public enum NowState
{
    Real,
    Dream,
}
