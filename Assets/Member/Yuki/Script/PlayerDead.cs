using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    Animator _playerAnimator = default;
    Collider2D _playerCollider = default;
    ContactFilter2D _contactFilter2D = new ContactFilter2D();  //重なりを判定したいコライダーを設定するコンタクトフィルター
    List<Collider2D> overLapColliders = new();  //重なっているコライダーを返す配列


    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerCollider = GetComponent<Collider2D>();
        _contactFilter2D.useLayerMask = true;
        //_contactFilter2D.SetLayerMask(LayerMask.GetMask("Real"));     //テスト
       //_contactFilter2D.useTriggers = true;
    }


    private void Update()
    {
        //夢と現実のときで重なりを判定するレイヤーを切り替える
        _contactFilter2D.layerMask = (StageManager.Instance.GetStageState == StageState.real) ? LayerMask.NameToLayer("Real") : LayerMask.NameToLayer("Dream");
        int count = _playerCollider.OverlapCollider(_contactFilter2D, overLapColliders);
        if (count > 0)  //重なっているコライダーがある場合
        {
            foreach (var col in overLapColliders)
            {
                if (!col.isTrigger)
                {
                    Dead();
                    break;
                }
            }
        }
    }

    public void Dead()
    {
        _playerAnimator.SetTrigger("isDead");
    }

    /// <summary> Playerが死亡時にアニメーションイベントから参照する </summary>
    public void ReLoadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}

