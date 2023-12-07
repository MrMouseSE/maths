using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class DotValue : MonoBehaviour
{
    public TextMeshPro Text;
    public Material ColorQuad;
    public Transform ReferenceTransform;
    public Transform MyTransform;

    private void Update()
    {
        var dotValue = Vector3.Dot(MyTransform.forward, ReferenceTransform.forward);
        if (dotValue > 0.99f) dotValue = 1;
        if (dotValue < -0.99f) dotValue = -1;
        dotValue = Mathf.Round(dotValue*1000)/1000;
        Text.text = dotValue.ToString();

        ColorQuad.color = Color.Lerp(Color.red, Color.green, (dotValue+1)*0.5f);
    }
}
