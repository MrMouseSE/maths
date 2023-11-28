using UnityEngine;

public class OrbitalCorrect : MonoBehaviour
{
    public float Mass;
    public float StartSpeed;
    public float RootMass;

    public Transform OrbitalBody;
    public Transform RootBody;

    private Vector3 _bodySpeed;
    
    private const float _gravityConstant = 6.674f;

    private void Start()
    {
        _bodySpeed = OrbitalBody.forward * StartSpeed;
    }

    void Update()
    {
        var gravityDirection = RootBody.position - OrbitalBody.position;
        var gravityPower = _gravityConstant * (Mass * RootMass) /
                           (gravityDirection.magnitude * gravityDirection.magnitude);
        var acceleration = gravityPower / Mass;
        _bodySpeed += gravityDirection * acceleration * Time.deltaTime;
        OrbitalBody.position += _bodySpeed * Time.deltaTime;
    }
}
