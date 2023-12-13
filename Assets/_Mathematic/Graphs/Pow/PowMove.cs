using UnityEngine;

public class PowMove : MonoBehaviour
{
    public Transform Linear;
    public Transform Pow;
    public Transform Smoothstep;
    public Transform Practice;

    public float Distance; 
    
    void Update()
    {
        float time = Time.time * 0.5f;
        time -= Mathf.Floor(time);
        time -= 0.5f;
        time = 1 - Mathf.Abs(time)*2;
        MoveObj(Linear, time);
        MoveObj(Pow, Mathf.Pow(time,2));
        var smoothTime = time * time * (3.0f - 2.0f * time);
        MoveObj(Smoothstep, smoothTime);
        var practiceTime = time * time * (3.0f - 2.0f * time) - (time - 0.25f) * Mathf.Floor(time - 0.25f) + (0.75f - time) * Mathf.Floor(0.75f - time);
        MoveObj(Practice, practiceTime);
    }

    private void MoveObj(Transform obj, float value)
    {
        Vector3 pos = obj.position;
        pos.x = Mathf.LerpUnclamped(0, Distance, value);
        obj.position = pos;
    }
}
