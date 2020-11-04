using UnityEngine;
using System.Collections;

public class GrounsCheck : MonoBehaviour
{
    [SerializeField] new Collider2D collider;
    [SerializeField] LayerMask Layer;
    public bool isGrounded => IsGrounded();

    public bool IsGrounded()
    {
        float extraHeightTest = .1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(collider.bounds.center, Vector2.down, collider.bounds.extents.y + extraHeightTest, Layer);
        return raycastHit.collider != null;
    }
}