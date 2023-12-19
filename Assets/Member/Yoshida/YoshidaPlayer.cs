using UnityEngine;

public class YoshidaPlayer : MonoBehaviour
{
    public void JJump(Rigidbody2D rigidbody)
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y + 5);
    }
}
