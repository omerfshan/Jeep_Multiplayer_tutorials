using Unity.Netcode;
using UnityEngine;

public class PlayerInteractionController : NetworkBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(!IsOwner) return;
        if (other.TryGetComponent(out ICollect collectible))
        {
            collectible.Collect();
        }
    }
}
