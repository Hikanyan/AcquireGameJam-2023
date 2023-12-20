using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    float timer = 10;
    bool change = false;
    bool Scene = false;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (change == true)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            SceneManager.LoadScene("Start", LoadSceneMode.Single);

        }
    }

    public void BackScene()
    {
        change = true;
    }
    public void BackScene2()
    {
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }
}
