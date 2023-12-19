using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    float timer1 = 10;
    float timer2 = 10;
    float timer3 = 10;
    bool change1 = false;
    bool change2 = false;
    bool change3 = false;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Debug.Log(timer1);
        Debug.Log(timer2);
        Debug.Log(timer3);
        if (change1 == true)
        {
            timer1 -= Time.deltaTime;
        }
        if (timer1 <= 0)
        {
            SceneManager.LoadScene("Stage1", LoadSceneMode.Single);

        }
        if (change2 == true) 
        {
            timer2 -= Time.deltaTime;
        }
        if (timer2 <= 0)
        {
            SceneManager.LoadScene("Stage2", LoadSceneMode.Single);

        }
        if (change3 == true) 
        {
            timer3 -= Time.deltaTime;
        }
        if (timer3 <= 0)
        {
            SceneManager.LoadScene("Stage3", LoadSceneMode.Single);

        }
    }
    public void ChangeScene1()
    {
        change1 = true;
    }
    public void ChangeScene2()
    {
        change2 = true;
    }
    public void ChangeScene3()
    {
        change3 = true;
    }
}
