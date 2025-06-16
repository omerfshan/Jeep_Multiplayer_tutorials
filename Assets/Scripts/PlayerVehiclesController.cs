using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.Rendering;

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
        float _currentLength;
        float _currentVelocity;
    }
    [Header("Reference")]
    [SerializeField] private Rigidbody _vehicleRb;
    [SerializeField] private BoxCollider _vehicleBoxCol;

    private Dictionary<WheelType, SpringData> _springDatas;
    private float _accelerateSpeed;
    private float _steerSpeed;

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

    private void SetAccelerateSpeed(float acceleratespeed)
    {
        _accelerateSpeed = math.clamp(acceleratespeed, -1f, 1f);

    }
    private void SetSteerSpeed(float steerSpeed)
    {
        _steerSpeed = math.clamp(steerSpeed, -1f, 1f);
    }

}
