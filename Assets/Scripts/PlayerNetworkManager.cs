using Unity.Cinemachine;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetworkManager : NetworkBehaviour
{
    [SerializeField] private CinemachineCamera _camera;
    public override void OnNetworkSpawn()
    {
        _camera.gameObject.SetActive(IsOwner);
    }
   
}
