using UnityEngine;

namespace _Mathematic.AddSubtract.AddSubtractExample.Move
{
    public class SimpleMoveExample : MonoBehaviour
    {
        public Vector3 Speed;
        public Transform MovebleBody;

        void Update()
        {
            MovebleBody.Translate(Speed);
        }
    }
}
