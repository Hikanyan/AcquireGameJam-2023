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

        //realLayer��\��
        ChangeCameraLayer(dreamLayer);
        
        this.UpdateAsObservable()
        .Subscribe(_ =>
        {
            if (Input.GetKeyDown(KeyCode.X)) //�{�^���������ꂽ�Ƃ�(������͂Ȃ��B)
            {
                if(_nowState == NowState.Real)
                {
                    _nowState = NowState.Dream;
                    ChangeCameraLayer(realLayer); //Real���C���[�ȊO��\��
                }
                else
                {
                    _nowState = NowState.Real;
                    ChangeCameraLayer(dreamLayer);//dream���C���[�ȊO��\��
                }
            }
        });
    }
    /// <summary>
    /// �n���ꂽ���C���[�ȊO��\������B
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
