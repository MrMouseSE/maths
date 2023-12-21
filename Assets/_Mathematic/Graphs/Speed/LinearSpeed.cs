using UnityEngine;

namespace _Mathematic.Graphs.Speed
{
    public class LinearSpeed : MonoBehaviour
    {
        public Transform Body;
        public bool Transition;
        public bool Position;
        public float Speed;
        public float Acceleration;

        public bool ManualTime;
        public float MyTime;

        private Vector3 _startPosition;

        private void Start()
        {
            _startPosition = Body.position;
        }

        void Update()
        {
            if (Transition && !Position)
            {
                Body.position += Vector3.right * (Speed * Time.deltaTime);
            }

            if (Position && !ManualTime)
            {
                Body.position = _startPosition + Vector3.right * ((Speed * Time.time) + (Acceleration * Time.time * Time.time / 2f));
            }

            if (Position && ManualTime)
            {
                Body.position = _startPosition + Vector3.right * ((Speed * MyTime) + (Acceleration * MyTime * MyTime / 2f));
            }
        }
    }
}
