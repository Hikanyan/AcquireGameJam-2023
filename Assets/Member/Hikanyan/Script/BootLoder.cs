using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootLoder : MonoBehaviour
{
    [SerializeField] SequenceManager sequenceManagerPrefab;

    void Awake()
    {
        Instantiate(sequenceManagerPrefab);
        SequenceManager.Instance.Initialize();
    }
}
