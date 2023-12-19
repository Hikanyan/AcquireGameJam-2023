using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;
using Cysharp.Threading.Tasks;


public class CRIAudioManager : AbstractSingleton<CRIAudioManager>
{
    [SerializeField] string _streamingAssetsPathAcf = "";
    [SerializeField] string _cueSheetBGM = "";
    [SerializeField] string _cueSheetSe = "";

    CriAtomSource _criAtomSourceBgm;
    CriAtomSource _criAtomSourceSe;

    private CriAtomExPlayback _criAtomExPlaybackBGM;
    CriAtomEx.CueInfo _cueInfo;

    protected override void OnAwake()
    {
        //acf設定
        string path = Common.streamingAssetsPath + $"/{_streamingAssetsPathAcf}.acf";

        CriAtomEx.RegisterAcf(null, path);

        // CriAtom作成
        new GameObject().AddComponent<CriAtom>();

        // BGM acb追加
        CriAtom.AddCueSheet(_cueSheetBGM, $"{_cueSheetBGM}.acb", null, null);
        // SE acb追加
        CriAtom.AddCueSheet(_cueSheetSe, $"{_cueSheetSe}.acb", null, null);


        //BGM用のCriAtomSourceを作成
        _criAtomSourceBgm = gameObject.AddComponent<CriAtomSource>();
        _criAtomSourceBgm.cueSheet = _cueSheetBGM;
        //SE用のCriAtomSourceを作成
        _criAtomSourceSe = gameObject.AddComponent<CriAtomSource>();
        _criAtomSourceSe.cueSheet = _cueSheetSe;
    }


    private int _indexStay = 0;



    public void CriBgmPlay(int index)
    {
        if (_criAtomSourceBgm.status == CriAtomSource.Status.Playing)
        {
            _criAtomSourceBgm.Stop();
        }

        _criAtomSourceBgm.loop = true;
        _criAtomExPlaybackBGM = _criAtomSourceBgm.Play(index);
        _indexStay = index;
    }

    public void CriBgmStop()
    {
        _criAtomSourceBgm.Stop();
    }

    public void CriSePlay(int index)
    {
        _criAtomSourceSe.Play(index);
    }

    public void CriSeStop()
    {
        _criAtomSourceSe.Stop();
    }
}