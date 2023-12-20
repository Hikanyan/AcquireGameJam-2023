using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    Animator _playerAnimator = default;
    Collider2D _playerCollider = default;
    ContactFilter2D _contactFilter2D = new ContactFilter2D();  //�d�Ȃ�𔻒肵�����R���C�_�[��ݒ肷��R���^�N�g�t�B���^�[
    List<Collider2D> overLapColliders = new();  //�d�Ȃ��Ă���R���C�_�[��Ԃ��z��


    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerCollider = GetComponent<Collider2D>();
        _contactFilter2D.useLayerMask = true;
        //_contactFilter2D.SetLayerMask(LayerMask.GetMask("Real"));     //�e�X�g
       //_contactFilter2D.useTriggers = true;
    }


    private void Update()
    {
        //���ƌ����̂Ƃ��ŏd�Ȃ�𔻒肷�郌�C���[��؂�ւ���
        _contactFilter2D.layerMask = (StageManager.Instance.GetStageState == StageState.real) ? LayerMask.NameToLayer("Real") : LayerMask.NameToLayer("Dream");
        int count = _playerCollider.OverlapCollider(_contactFilter2D, overLapColliders);
        if (count > 0)  //�d�Ȃ��Ă���R���C�_�[������ꍇ
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

    /// <summary> Player�����S���ɃA�j���[�V�����C�x���g����Q�Ƃ��� </summary>
    public void ReLoadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}

