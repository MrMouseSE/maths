using UnityEngine;

public class DistanceController : MonoBehaviour
{
    public Renderer SwordRenderer;
    public float GlowDistance;
    public Transform Sword;
    public Transform Orc;

    private float _distance;
    
    void Update()
    {
        _distance = (Orc.position - Sword.position).magnitude;
        SwordRenderer.material.SetFloat("_GlowValue", GlowDistance - _distance);
    }
}
