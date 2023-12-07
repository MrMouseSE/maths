using System;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class CrossPresent : MonoBehaviour
{
    public Material MyMat;
    public TextMeshPro MyText;

    private void Update()
    {
        var crossValue = Vector3.Cross(transform.forward, transform.right);
        MyMat.SetColor("_Color", new Color(crossValue.x,crossValue.y,crossValue.z,1));

        MyText.text = "Vec3( " + Math.Round(crossValue.x,2) + ", " +  Math.Round(crossValue.y,2) + ", " +  Math.Round(crossValue.z,2) + ")";
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Vector3.up * 10);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward * 10);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right * 10);
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, transform.up * 3);
    }
}