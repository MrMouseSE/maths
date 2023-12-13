using UnityEngine;

namespace _Mathematic.Graphs.Abs
{
    [ExecuteInEditMode]
    public class Abs : MonoBehaviour
    {
        public Transform[] Objects;
        public float AddVal;
        public float SecondAddVal;
    
        void Update()
        {
            foreach (var o in Objects)
            {
                var pos = o.position;
                pos.y = Mathf.Abs(Mathf.Abs(pos.x + AddVal)+SecondAddVal);
                o.position = pos;
            }
        }
    }
}
