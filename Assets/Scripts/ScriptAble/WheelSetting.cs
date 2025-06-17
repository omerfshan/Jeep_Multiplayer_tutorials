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
    public float WheelpaddingX => _wheelpaddingX;
    public float WheelpaddingZ => _wheelpaddingZ;
    public float SpringRestLength => _springRestLength;
    public float springDamp => _springDamp;
    public float springStrength => _springStrength;
}
