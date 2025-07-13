using UnityEngine;

[CreateAssetMenu(fileName = "WheelSetting", menuName = "ScriptAble/WheelSetting", order = 0)]
public class WheelSetting : ScriptableObject
{
    [Header("Padding")]
    [SerializeField] private float _wheelpaddingX;
    [SerializeField] private float _wheelpaddingZ;
    [Header("Suspansiyon")]
    [SerializeField] private float _springRestLength;
    [SerializeField] private float _springStrength;
    [SerializeField] private float _springDamp;
    [Header("Handling")]
    [SerializeField] private float _steerAngle;
    [SerializeField] private float _frontWheelsGripFactor;
        [SerializeField] private float _RearWheelsGripFactor;


    public float FrontWheelsGripFactor => _frontWheelsGripFactor;
     public float RearWheelsGripFactor => RearWheelsGripFactor;
    
    public float WheelpaddingX => _wheelpaddingX;
    public float WheelpaddingZ => _wheelpaddingZ;
    public float SpringRestLength => _springRestLength;
    public float springDamp => _springDamp;
    public float springStrength => _springStrength;
    public float SteerAngle => _steerAngle;

}
