using UnityEngine;

public class TranslateExample : MonoBehaviour
{
    public Transform Body;
    public float InitSpeed;
    public float AdditionalSpeed;

    public bool AccelerationOn;
    public float Acceleration;

    private float _initTime;

    [ContextMenu("Reset")]
    public void ResetSystem()
    {
        Body.position = Vector3.zero;
        enabled = false;
    }

    private void OnEnable()
    {
        _initTime = Time.time;
    }

    void Update()
    {
        var currTime = Time.time - _initTime;
        var dif = 0f;
        if (!AccelerationOn)
        {
            dif = InitSpeed * currTime + AdditionalSpeed * currTime / 2;
        }
        else
        {
            dif = InitSpeed * currTime + Acceleration * currTime * currTime / 2;
        }
        Body.position = new Vector3(dif, 0, 0);
    }
}
