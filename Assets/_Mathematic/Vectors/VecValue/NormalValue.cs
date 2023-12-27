using UnityEngine;

namespace _Mathematic.Vectors.VecValue
{
    [ExecuteInEditMode]
    public class NormalValue : MonoBehaviour
    {
        public Transform VecValue;
        public Color VecColor;

        public Transform PlaneTransform;
        
        void Update()
        {
            PlaneTransform.up = VecValue.position.normalized;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = VecColor;
            Gizmos.DrawLine(Vector3.zero, VecValue.position);
            Gizmos.DrawWireSphere(VecValue.position,0.1f);
        }
    }
}
