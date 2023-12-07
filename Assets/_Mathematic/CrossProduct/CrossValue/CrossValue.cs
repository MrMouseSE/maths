using UnityEngine;

[ExecuteInEditMode]
public class CrossValue : MonoBehaviour
{
    public Transform BlueAxis;
    public Transform RedAxis;
    public Transform GreenAxis;

    public bool ShowPlane;
    public Transform PlaneMesh;

    private void Update()
    {
        var crossValue = Vector3.Cross(BlueAxis.forward,RedAxis.forward);
        GreenAxis.forward = crossValue;

        PlaneMesh.gameObject.SetActive(ShowPlane);
        PlaneMesh.forward = crossValue;
    }
}