using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HexFieldGeneration : MonoBehaviour
{
    public GameObject HexObject;
    public Vector2 HexGridDemention;
    public float SizeFactor;

    private float _sideValue;
    private float sqrtOfThree = Mathf.Sqrt(3f);

    private List<GameObject> _myPreviousGeneratedHexes;

    private void OnValidate()
    {
        _sideValue = SizeFactor / 2;
    }

    [ContextMenu("Regenerate")]
    public void Regenerate()
    {
        ClearArray();

        int multyplyer = -1;
        for (int i = 0; i < HexGridDemention.x; i++)
        {
            for (int j = 0; j < HexGridDemention.y; j++)
            {
                Vector3 hexObjectPosition = new Vector3((0.25f + multyplyer*0.25f + j) * _sideValue * sqrtOfThree,i*1.5f*_sideValue,  0);
                GameObject hexObject = Instantiate(HexObject, hexObjectPosition, Quaternion.identity);
                hexObject.transform.localScale = Vector3.one * SizeFactor;
                _myPreviousGeneratedHexes.Add(hexObject);
            }
            multyplyer *= -1;
        }
    }
    
    [ContextMenu("Clear")]
    public void ClearArray()
    {
        
        for (int i = 0; i < _myPreviousGeneratedHexes.Count; i++)
        {
            DestroyImmediate(_myPreviousGeneratedHexes[i]);
        }

        _myPreviousGeneratedHexes = new List<GameObject>();
    }
    
    [ContextMenu("ClearArrayOnly")]
    public void ClearArrayOnly()
    {
        _myPreviousGeneratedHexes = new List<GameObject>();
    }
}