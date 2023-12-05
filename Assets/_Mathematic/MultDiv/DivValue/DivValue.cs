using TMPro;
using UnityEngine;

public class DivValue : MonoBehaviour
{
    public float MainValue;
    public float Divider;
    public TextMeshPro Result;

    [Header("Position")] 
    public Transform MainValueTransform;
    public Transform DivideValueTransform;
    public Transform ResultValueTransform;
    [Header("Scale")]
    public Transform MainScaleTransform;
    public Transform DivideScaleTransform;
    public Transform ResultScaleTransform;
    [Header("Length")]
    public Transform MainLengthTransform;
    public Transform DivideLengthTransform;
    public Transform ResultLengthTransform;

    private void Update()
    {
        var resultStr = Divider > 0 ? $"{MainValue} / {Divider} = {MainValue / Divider}" 
            : $"{MainValue} / ({Divider}) = {MainValue / Divider}";
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

        var multValuePos = DivideValueTransform.position;
        multValuePos.y = Divider;
        DivideValueTransform.position = multValuePos;

        var resValuePos = ResultValueTransform.position;
        resValuePos.y = MainValue / Divider;
        ResultValueTransform.position = resValuePos;
    }

    private void UpdateScale()
    {
        MainScaleTransform.localScale = Vector3.one * MainValue;
        DivideScaleTransform.localScale = Vector3.one * Divider;
        ResultScaleTransform.localScale = Vector3.one * (MainValue / Divider);
    }

    private void UpdateLength()
    {
        var addValue = new Vector3(0, 1f, 1f);
        MainLengthTransform.localScale = Vector3.right * MainValue + addValue;
        DivideLengthTransform.localScale = Vector3.right * Divider + addValue;
        ResultLengthTransform.localScale = Vector3.right * (MainValue / Divider) + addValue;
    }
}
