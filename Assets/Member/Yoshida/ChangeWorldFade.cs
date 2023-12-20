using UnityEngine;
using DG.Tweening;

public class ChangeWorldFade : MonoBehaviour
{
    [SerializeField] private GameObject _fade;
    [SerializeField] private float _fadeTime = 3;
    public void FadeIn()
    {
        _fade.gameObject.SetActive(true);
        _fade.transform.DOScale(new Vector2(45, 45), _fadeTime)
            .SetEase(Ease.InOutQuad)
            .SetLoops(2, LoopType.Yoyo)
            .OnComplete(() => _fade.gameObject.SetActive(false));
    }
}
