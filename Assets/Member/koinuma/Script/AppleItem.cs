using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class AppleItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StageManager.Instance.AddDreamCount();
            Destroy(gameObject);
        }
    }
}