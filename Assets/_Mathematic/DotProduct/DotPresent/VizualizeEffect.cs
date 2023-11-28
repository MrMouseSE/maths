using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class VizualizeEffect : MonoBehaviour
{
    public Material Mat;

    private void Update()
    {
        Mat.SetFloat("_Radius", transform.localScale.x);
        Mat.SetVector("_Offset", transform.position);
    }
}
