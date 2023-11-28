using UnityEngine;

namespace _Mathematic.AddSubstract.AddSubstractPresent
{
    [ExecuteInEditMode]
    public class AddSubtractPresent : MonoBehaviour
    {
        public Material MyMaterial;
        public Transform SlicePlane;
        [Range(-4, 4)] public float Height;
    
        private void Update()
        {
            SlicePlane.position = new Vector3(0,Height,0);
            MyMaterial.SetFloat("_Height", Height-0.01f);
        }
    }
}