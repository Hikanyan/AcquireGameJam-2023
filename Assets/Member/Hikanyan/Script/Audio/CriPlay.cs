using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CriAudioManager.Instance.CriBgmPlay(0);
        Debug.Log("Play");
    }
}
