using UnityEngine;

namespace _Mathematic.Vectors.VecValue
{
    [ExecuteInEditMode]
    public class SubtractVecs : MonoBehaviour
    {
        public Color VecColor;
        public Transform VecOneTransform;
        public Color VecTwoColor;
        public Transform VecTwoTransform;

        public Color ResultColor;

        public Material MeshMaterial;
        
        public bool ParaleleTranslation;
        public Color ParalleleColor;
    
        private void OnDrawGizmos()
        {
            Gizmos.color = VecColor;
            Gizmos.DrawLine(Vector3.zero, VecOneTransform.position);
            Gizmos.DrawWireSphere(VecOneTransform.position,0.1f);

            Gizmos.color = VecTwoColor;
            Gizmos.DrawLine(Vector3.zero, VecTwoTransform.position);
            Gizmos.DrawWireSphere(VecTwoTransform.position,0.1f);


            Gizmos.color = ResultColor;
            Gizmos.DrawLine(VecOneTransform.position, VecTwoTransform.position);
            Gizmos.DrawWireSphere(VecTwoTransform.position,0.15f);
            
            if (ParaleleTranslation)
            {
                var vecEnd = VecTwoTransform.position - VecOneTransform.position;
                Gizmos.color = ParalleleColor;
                Gizmos.DrawLine(Vector3.zero, vecEnd);
                Gizmos.DrawWireSphere(vecEnd,0.1f);
            }
        }

        private void Update()
        {
            Mesh addMehs = new Mesh();
        
            Vector3[] newVertices = {Vector3.zero, VecOneTransform.position, VecTwoTransform.position};
            int[] newTriangles = {0,2,1};
            Vector3[] newnormals = { Vector3.up,Vector3.up,Vector3.up};
            var col = new Color(0.3f, 0.3f, 0.3f, 0.3f);
            Color[] colors = { col,col,col};

            addMehs.vertices = newVertices;
            addMehs.triangles = newTriangles;
            addMehs.normals = newnormals;
            addMehs.colors = colors;

            Matrix4x4[] matrxs = {transform.localToWorldMatrix};
        
            Graphics.DrawMeshInstanced(addMehs, 0, MeshMaterial,matrxs);
        }
    }
}
