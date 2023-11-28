using UnityEngine;

namespace _Mathematic.AddSubtract.AddSubtractExample
{
    public class Orbital : MonoBehaviour
    {
        public float AddValue_z;
        public float AddValue_x;
        public Transform OrbitalBody;
        private float _speed;
    
        void Update()
        {
            var pos = OrbitalBody.position;
            AddValue_z -= pos.z;
            pos.z += AddValue_z * Time.deltaTime;

            AddValue_x -= pos.x;
            pos.x += AddValue_x * Time.deltaTime;
            
            OrbitalBody.position = pos;
        }
    }
}
