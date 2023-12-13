using System;
using UnityEngine;

namespace _Mathematic.Graphs.Lerp
{
    [ExecuteInEditMode]
    public class LerpMove : MonoBehaviour
    {
        public Transform Body;

        [Space]
        public Transform StartPosition;
        public Transform EndPosition;
        [Range(0,1)]
        public float LerpValue;

        [Space]
        public bool Unranged;
        [Range(-10, 10)]
        public float LerpUnrangedValue;

        [Space]
        public bool ShowTrajectory;
        
        void Update()
        {
            if (!Unranged)
            {
                Body.position = Vector3.Lerp(StartPosition.position, EndPosition.position, LerpValue);
            }
            else
            {
                Body.position = Vector3.LerpUnclamped(StartPosition.position, EndPosition.position, LerpUnrangedValue);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(StartPosition.position,0.5f);
            Gizmos.DrawWireSphere(EndPosition.position,0.5f);

            Gizmos.color = Color.yellow;
            if(!ShowTrajectory) return;
            Vector3 vec = StartPosition.position - EndPosition.position;
            var start = EndPosition.position + vec * 10f;
            var end = StartPosition.position - vec * 10f;
            Gizmos.DrawLine(start, end);
        }
    }
}
