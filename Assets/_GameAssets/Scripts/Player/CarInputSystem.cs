using UnityEngine;
using UnityEngine.InputSystem;



    public class VehicleInput : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;

        public Vector2 Drive { get; private set; }
        public Vector2 Look { get; private set; }
        public bool Brake { get; private set; }
        public bool Handbrake { get; private set; }

        private InputActionMap _vehicleMap;
        private InputAction _driveAction;
        // private InputAction _lookAction;
        // private InputAction _brakeAction;
        // private InputAction _handbrakeAction;

        void Awake()
        {
            _vehicleMap = playerInput.currentActionMap;

            _driveAction = _vehicleMap.FindAction("Move");
            // _lookAction = _vehicleMap.FindAction("Look");
            // _brakeAction = _vehicleMap.FindAction("Brake");
            // _handbrakeAction = _vehicleMap.FindAction("Handbrake");

            _driveAction.performed += OnDrive;
            _driveAction.canceled += OnDrive;

            // _lookAction.performed += OnLook;
            // _lookAction.canceled += OnLook;

            // _brakeAction.performed += OnBrake;
            // _brakeAction.canceled += OnBrake;

            // _handbrakeAction.performed += OnHandbrake;
            // _handbrakeAction.canceled += OnHandbrake;
        }

        private void OnDrive(InputAction.CallbackContext context)
        {
            Drive = context.ReadValue<Vector2>();
        }

        // private void OnLook(InputAction.CallbackContext context)
        // {
        //     Look = context.ReadValue<Vector2>();
        // }

        // private void OnBrake(InputAction.CallbackContext context)
        // {
        //     Brake = context.ReadValueAsButton();
        // }

        // private void OnHandbrake(InputAction.CallbackContext context)
        // {
        //     Handbrake = context.ReadValueAsButton();
        // }

        private void OnEnable() => _vehicleMap.Enable();
        private void OnDisable() => _vehicleMap.Disable();
    }

