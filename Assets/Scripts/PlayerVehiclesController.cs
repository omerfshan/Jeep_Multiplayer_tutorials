using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerVehiclesController : MonoBehaviour
{
    private static readonly WheelType[] _wheels = new WheelType[]{
        WheelType.FrontLeft,
        WheelType.FrontRight,
        WheelType.BackLeft,
        WheelType.BackRight
    };
    public class SpringData
    {
        public float _currentLength;
        public float _currentVelocity;
    }
    [Header("Reference")]
    [SerializeField] private Rigidbody _vehicleRb;
    [SerializeField] private BoxCollider _vehicleBoxCol;

    private Dictionary<WheelType, SpringData> _springDatas;
    private float _accelerateSpeed;
    private float _steerSpeed;
    [SerializeField] private WheelSetting wheelSetting;
    void Awake()
    {
        _springDatas = new Dictionary<WheelType, SpringData>();
        foreach (WheelType wheel in _wheels)
        {
            _springDatas.Add(wheel, new SpringData());
        }

    }
    void Update()
    {
        //steer
        SetSteerSpeed(Input.GetAxis("Horizontal"));
        //accelerate
        SetAccelerateSpeed(Input.GetAxis("Vertical"));

    }
    private void FixedUpdate() {
        Suspension();
    }
    private void Suspension()
    {
        foreach (WheelType id in _springDatas.Keys)
        {
            castSpring(id);
            float currentLength = _springDatas[id]._currentLength;
            float currentVelocity = _springDatas[id]._currentVelocity;
            float force = Hookes.CalculateDampedSpringForce
            (
                currentLength,
                currentVelocity,
                wheelSetting.SpringRestLength,
                wheelSetting.springStrength,
                wheelSetting.springDamp
            );
            _vehicleRb.AddForceAtPosition(force * transform.up, GetSpringPosition(id));
        }
    }
    private void SetAccelerateSpeed(float acceleratespeed)
    {
        _accelerateSpeed = math.clamp(acceleratespeed, -1f, 1f);

    }
    private void SetSteerSpeed(float steerSpeed)
    {
        _steerSpeed = math.clamp(steerSpeed, -1f, 1f);
    }
    private void castSpring(WheelType wheeltype)
    {
        Vector3 position = GetSpringPosition(wheeltype);
        float prevuislyLength = _springDatas[wheeltype]._currentLength;
        float currentLength;

        if (Physics.Raycast(position, -Vector3.up, out var hit, wheelSetting.SpringRestLength))
        /*transform.position– Işının başlayacağı yer.
          Vector3.up– Işının yönü.
          out var hit– Işın bir yere çarparsa, çarpılan yerin bilgilerini "hit" adlı değişkende tut.
          wheelSetting.SpringRestLengh– Işının ne kadar uzağa kadar gideceği.
        */
        {
            currentLength = hit.distance;
        }
        else
        {
            currentLength = wheelSetting.SpringRestLength;
        }
        _springDatas[wheeltype]._currentVelocity = (currentLength - prevuislyLength) / Time.deltaTime;
        _springDatas[wheeltype]._currentLength = currentLength;
    }
    private Vector3 GetSpringPosition(WheelType wheelType)
    {
        return transform.localToWorldMatrix.MultiplyPoint3x4(GetSpringRelativePosition(wheelType));
        //"Bir tekerleğin araç içindeki yerini (yerel konumunu), dünya üzerindeki gerçek konuma çevirir."
    }

    private Vector3 GetSpringRelativePosition(WheelType wheelType)
    {
        Vector3 Boxsize = _vehicleBoxCol.size;
        float BottomSize = Boxsize.y * -0.5f;

        float paddingX = wheelSetting.WheelpaddingX;
        float paddingZ = wheelSetting.WheelpaddingZ;
        return wheelType switch
        {
            //tekerleklerin yeri
            WheelType.FrontLeft => new Vector3(Boxsize.x * (paddingX - 0.5f), BottomSize, Boxsize.z * (paddingZ - 0.5f)),
            WheelType.FrontRight => new Vector3(Boxsize.x * (0.5f - paddingX), BottomSize, Boxsize.z * (paddingZ - 0.5f)),
            WheelType.BackLeft => new Vector3(Boxsize.x * (paddingX - 0.5f), BottomSize, Boxsize.z * (0.5f - paddingZ)),
            WheelType.BackRight => new Vector3(Boxsize.x * (0.5f - paddingX), BottomSize, Boxsize.z * (0.5f - paddingZ)),


            _ => default
        };
    }
}
public static class Hookes
{
    public static float CalculateDampedSpringForce(
    float currentLength,     // Yayın şu anki uzunluğu
    float lengthVelocity,    // Yayın ne kadar hızlı uzayıp kısaldığı (hız)
    float restLength,        // Yayın normal (denge) uzunluğu
    float strength,          // Yayın sertliği (ne kadar zor esnediği)
    float damper             // Sönümleme miktarı (hıza karşı direnç)
)
{
    float lengthOffset = restLength - currentLength; // Ne kadar uzamış veya kısalmış
    return (lengthOffset * strength) - (lengthVelocity * damper); // Toplam kuvveti hesapla
}

}
