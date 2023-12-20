using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    [SerializeField] private AudioClip bgmAudioClip;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.BgmPlay(bgmAudioClip);
        Debug.Log("Play");
    }
}
