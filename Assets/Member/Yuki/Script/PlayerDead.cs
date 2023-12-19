using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    Animator _playerAnimator = default;
    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    public void Dead()
    {
        _playerAnimator.SetTrigger("isDead");
    }

    /// <summary> Player�����S���ɃA�j���[�V�����C�x���g����Q�Ƃ��� </summary>
    void ReLoadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}

