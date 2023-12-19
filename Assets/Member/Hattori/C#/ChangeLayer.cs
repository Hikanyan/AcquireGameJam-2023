using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Cysharp.Threading.Tasks;

public class ChangeLayer : MonoBehaviour
{
    [SerializeField] Camera m_camera;
    private NowState _nowState = NowState.Real;

    private void Start()
    {
        GameObject realObject = GameObject.FindGameObjectWithTag("Real");
        GameObject dreamObject = GameObject.FindGameObjectWithTag("Dream");
        
        var realLayer = LayerMask.NameToLayer("Real");
        var dreamLayer = LayerMask.NameToLayer("Dream");

        //realLayer��\��
        ChangeCameraLayer(dreamLayer);
        realObject.SetActive(true);
        dreamObject.SetActive(false);

        this.UpdateAsObservable()
        .Subscribe(_ =>
        {
            if (Input.GetKeyDown(KeyCode.X)) //�{�^���������ꂽ�Ƃ�(������͂Ȃ��B)
            {
                if(_nowState == NowState.Real)
                {
                    _nowState = NowState.Dream;
                    ChangeCameraLayer(realLayer); //Real���C���[�ȊO��\��
                    realObject.SetActive(false);
                    dreamObject.SetActive(true);
                }
                else
                {
                    _nowState = NowState.Real;
                    ChangeCameraLayer(dreamLayer);//dream���C���[�ȊO��\��
                    realObject.SetActive(false);
                    dreamObject.SetActive(true);
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
