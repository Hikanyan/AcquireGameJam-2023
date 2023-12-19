using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSettingActiveClass : MonoBehaviour
{
    void Awake()
    {
        if(gameObject.activeInHierarchy == false)
        {
            gameObject.SetActive(true);
            Debug.Log(transform);
        }
    }
}
