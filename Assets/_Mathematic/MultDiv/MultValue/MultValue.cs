using System;
using TMPro;
using UnityEngine;

public class MultValue : MonoBehaviour
{
    public float MainValue;
    public float Multiplyer;
    public TextMeshPro Result;

    [Header("Position")] 
    public Transform MainValueTransform;
    public Transform MultilyValueTransform;
    public Transform ResultValueTransform;
    
    [Header("Scale")]
    public Transform MainScaleTransform;
    public Transform MultilyScaleTransform;
    public Transform ResultScaleTransform;
    [Header("Length")]
    public Transform MainLengthTransform;
    public Transform MultilyLengthTransform;
    public Transform ResultLengthTransform;

    private void Update()
    {
        var resultStr = Multiplyer > 0 ? $"{MainValue} * {Multiplyer} = {MainValue * Multiplyer}" 
            : $"{MainValue} * ({Multiplyer}) = {MainValue * Multiplyer}";
        Result.text = resultStr;

        UpdatePositions();
        UpdateScale();
        UpdateLength();
    }

    private void UpdatePositions()
    {
        var mainValuePos = MainValueTransform.position;
        mainValuePos.y = MainValue;
        MainValueTransform.position = mainValuePos;

        var multValuePos = MultilyValueTransform.position;
        multValuePos.y = Multiplyer;
        MultilyValueTransform.position = multValuePos;

        var resValuePos = ResultValueTransform.position;
        resValuePos.y = MainValue * Multiplyer;
        ResultValueTransform.position = resValuePos;
    }

    private void UpdateScale()
    {
        MainScaleTransform.localScale = Vector3.one * MainValue;
        MultilyScaleTransform.localScale = Vector3.one * Multiplyer;
        ResultScaleTransform.localScale = Vector3.one * (MainValue * Multiplyer);
    }

    private void UpdateLength()
    {
        var addValue = new Vector3(0, 1f, 1f);
        MainLengthTransform.localScale = Vector3.right * MainValue + addValue;
        MultilyLengthTransform.localScale = Vector3.right * Multiplyer + addValue;
        ResultLengthTransform.localScale = Vector3.right * (MainValue * Multiplyer) + addValue;
    }
}