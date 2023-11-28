using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HexRoundGeneration : MonoBehaviour
{
    public GameObject HexObject;
    public int RadiusSteps;
    public float SizeFactor;

    private float _sideValue;
    private static float _sqrtOfThree = Mathf.Sqrt(3f);
    private static float _angle = Mathf.Deg2Rad*60;

    private List<GameObject> _myPreviousGeneratedHexes;

    private void OnValidate()
    {
        _sideValue = SizeFactor / 2;
    }

    [ContextMenu("Regenerate")]
    public void Regenerate()
    {
        ClearArray();

        GameObject centralHexObject = Instantiate(HexObject, Vector3.zero, Quaternion.identity);
        centralHexObject.transform.localScale = Vector3.one*SizeFactor;
        _myPreviousGeneratedHexes.Add(centralHexObject);

        for (int k = 1; k < RadiusSteps+1; k++)
        {

            for (int i = 0; i < 6*k; i++)
            {
                float recalculateAngleForStep = _angle * Mathf.Floor(i / k);
                Vector3 position = new Vector3(Mathf.Cos(recalculateAngleForStep), Mathf.Sin(recalculateAngleForStep), 0) * _sqrtOfThree * _sideValue * k;

                float devisionAngle = recalculateAngleForStep + 2 * _angle;
                position += i % k * _sqrtOfThree * _sideValue * new Vector3(Mathf.Cos(devisionAngle), Mathf.Sin(devisionAngle), 0);
                
                GameObject localHexObject = Instantiate(HexObject, position, Quaternion.identity);
                localHexObject.transform.localScale = Vector3.one*SizeFactor;
                _myPreviousGeneratedHexes.Add(localHexObject);
                
                /*for (int j = 0; j < k-1; j++)
                {
                    GameObject hexSubObject = Instantiate(HexObject, position, Quaternion.identity);
                    hexSubObject.transform.Rotate(Vector3.forward, Mathf.Rad2Deg * _angle * (i+0.5f));
                    hexSubObject.transform.Translate(new Vector3(0,_sqrtOfThree * _sideValue * (j+1),0),Space.Self);
                    hexSubObject.transform.rotation = Quaternion.identity;
                    _myPreviousGeneratedHexes.Add(hexSubObject);
                }*/
            }
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