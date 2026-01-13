using Unity.Netcode;
using UnityEngine;

public class PlayerInteractionController : NetworkBehaviour
{
    private PlayerSkillController playerSkill;
        public override void OnNetworkSpawn()
        {
            if(!IsOwner) return;
            playerSkill=GetComponent<PlayerSkillController>();
        }
    private void OnTriggerEnter(Collider other)
    {
        if(!IsOwner) return;
        if (other.TryGetComponent(out ICollect collectible))
        {
            collectible.Collect(playerSkill);
        }
    }
}
