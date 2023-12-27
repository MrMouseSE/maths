using UnityEngine;

namespace _Mathematic.Vectors.VecValue
{
    public class MultVecScal : MonoBehaviour
    {
        public float Scalar;
        public Transform VecValue;
        public Color VecColor;

        private void OnDrawGizmos()
        {
            Gizmos.color = VecColor;
            Gizmos.DrawLine(Vector3.zero, VecValue.position * Scalar);
            Gizmos.DrawWireSphere(VecValue.position,0.1f);
        }
    }
}
