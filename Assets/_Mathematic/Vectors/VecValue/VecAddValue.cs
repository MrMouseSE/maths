using UnityEngine;

namespace _Mathematic.Vectors.VecValue
{
    [ExecuteInEditMode]
    public class VecAddValue : MonoBehaviour
    {
        public Color VecColor;
        public Transform VecOneTransform;
        public Transform VecTwoTransform;

        public Material MeshMaterial;

        
        public bool ParaleleTranslation;
        public Color ParalleleColor;
    
        private void OnDrawGizmos()
        {
            Gizmos.color = VecColor;
            Vector3 vecEnd = VecOneTransform.position + VecTwoTransform.position;
            Gizmos.DrawLine(Vector3.zero, vecEnd);
            Gizmos.DrawWireSphere(vecEnd,0.1f);

            if (ParaleleTranslation)
            {
                Gizmos.color = ParalleleColor;
                Gizmos.DrawLine(VecOneTransform.position, vecEnd);
                Gizmos.DrawWireSphere(vecEnd,0.1f);
            }
        }

        private void Update()
        {
            Vector3 vecEnd = VecOneTransform.position + VecTwoTransform.position;
            Mesh addMehs = new Mesh();
        
            Vector3[] newVertices = {Vector3.zero, VecOneTransform.position, vecEnd, VecTwoTransform.position};
            int[] newTriangles = {0,2,1,0,3,2};
            Vector3[] newnormals = { Vector3.up,Vector3.up,Vector3.up,Vector3.up };
            var col = new Color(0.3f, 0.3f, 0.3f, 0.3f);
            Color[] colors = { col,col,col,col};

            addMehs.vertices = newVertices;
            addMehs.triangles = newTriangles;
            addMehs.normals = newnormals;
            addMehs.colors = colors;

            Matrix4x4[] matrxs = {transform.localToWorldMatrix};
        
            Graphics.DrawMeshInstanced(addMehs, 0, MeshMaterial,matrxs);
        }
    }
}
