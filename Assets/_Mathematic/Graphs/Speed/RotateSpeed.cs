using UnityEngine;

namespace _Mathematic.Graphs.Speed
{
    public class RotateSpeed : MonoBehaviour
    {
        public float Speed;

        void Update()
        {
            transform.RotateAround(transform.position,Vector3.up, Speed * Time.deltaTime);
        }
    }
}
