using UnityEngine;

[ExecuteInEditMode]
public class DistanceExam : MonoBehaviour
{
    public Transform Target;
    public Renderer SwordRend;

    public float Distance;
    public float Mult;
    
    private void Update()
    {
        SwordRend.material.SetVector("_TargetPosition", Target.position);
        SwordRend.material.SetFloat("_Distance", Distance);
        SwordRend.material.SetFloat("_DistMult", Mult);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0,1,0,0.5f);
        Gizmos.DrawWireSphere(Target.position, Distance);
        Gizmos.color = new Color(1,1,0,0.2f);
        Gizmos.DrawWireSphere(Target.position, Distance + (1/Mult));
    }
}
