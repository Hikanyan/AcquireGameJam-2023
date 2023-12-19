using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    float timer = 0;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        timer = (10 - Time.deltaTime);
    }
    public void ChangeScene1()
    {
        animator.SetBool("Fade",true);

        if (timer == 0)
        {
            SceneManager.LoadScene("stage1", LoadSceneMode.Single);

        }
    }
    public void ChangeScene2()
    {
        animator.SetBool("Fade", true);

        if (timer == 0)
        {
            SceneManager.LoadScene("stage2", LoadSceneMode.Single);

        }
    }
    public void ChangeScene3()
    {
        animator.SetBool("Fade", true);

        if (timer == 0)
        {
            SceneManager.LoadScene("stage3", LoadSceneMode.Single);

        }
    }
}
