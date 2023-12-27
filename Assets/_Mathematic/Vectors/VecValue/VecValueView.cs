
using UnityEngine;

public class VecValueView : MonoBehaviour
{
    public Color VecColor;
    private void OnDrawGizmos()
    {
        Gizmos.color = VecColor;
        Gizmos.DrawLine(Vector3.zero, transform.position);
        Gizmos.DrawWireSphere(transform.position,0.1f);
    }
}
