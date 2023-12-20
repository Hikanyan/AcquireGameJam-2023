using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    [SerializeField] GameObject wood = null;
    GameObject player = null;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        player.transform.position = wood.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
