using UnityEngine;

namespace _Mathematic.Graphs.Lerp
{
    [ExecuteInEditMode]
    public class LerpRotation : MonoBehaviour
    {
        public Transform Body;

        [Space]
        public Transform FirstTarget;
        public Transform SecondTarget;

        public bool IsQuatLerp;
        public bool IsSlerp;

        [Range(0,1)]
        public float Value;
        
        void Update()
        {
            var targetOne = (FirstTarget.position - Body.position).normalized;
            var targetTwo = (SecondTarget.position - Body.position).normalized;
            if (!IsQuatLerp)
            {
                Body.forward = Vector3.Lerp(targetOne, targetTwo, Value);
            }
            else if (!IsSlerp)
            {
                Body.rotation = Quaternion.Lerp(Quaternion.LookRotation(targetOne), Quaternion.LookRotation(targetTwo), Value);
            }
            else
            {
                Body.rotation = Quaternion.Slerp(Quaternion.LookRotation(targetOne), Quaternion.LookRotation(targetTwo), Value);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(FirstTarget.position,0.5f);
            Gizmos.DrawWireSphere(SecondTarget.position,0.5f);
        }
    }
}
