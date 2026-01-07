using NUnit.Framework;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetworkCamera : NetworkBehaviour
{   
        [SerializeField] private GameObject _camera;
        public override void OnNetworkSpawn()
        {
            _camera.SetActive(IsOwner);
        }
}
