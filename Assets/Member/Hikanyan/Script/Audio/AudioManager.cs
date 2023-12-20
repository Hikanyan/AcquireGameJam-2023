using UnityEngine;

public class AudioManager : AbstractSingleton<AudioManager>
{
    private AudioSource _bgmSource; // BGM用のAudioSource
    private AudioSource _seSource; // 効果音用のAudioSource

    protected override void OnAwake()
    {
        // オーディオソースを2Dに設定
        _bgmSource = gameObject.AddComponent<AudioSource>();
        _bgmSource.spatialBlend = 0.0f;
        _seSource = gameObject.AddComponent<AudioSource>();
        _seSource.spatialBlend = 0.0f;

        // BGMはループを有効にする
        _bgmSource.loop = true;

        // ボリューム
        _bgmSource.volume = 1.0f;
        _seSource.volume = 1.0f;
    }

    // BGMを再生する
    public void BgmPlay(AudioClip clip)
    {
        // 前のBGMが再生されていたら停止
        if (_bgmSource.isPlaying) _bgmSource.Stop();

        _bgmSource.clip = clip;
        _bgmSource.Play();
    }

    // BGMを停止する
    public void BgmStop()
    {
        _bgmSource.Stop();
    }

    // 効果音を再生する
    public void SePlay(AudioClip clip)
    {
        _seSource.PlayOneShot(clip);
    }
}