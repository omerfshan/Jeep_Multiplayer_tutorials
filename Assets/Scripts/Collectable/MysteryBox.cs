using Unity.Netcode;
using UnityEngine;

public class MysteryBoxCollectible : NetworkBehaviour, ICollect
{
    [Header("References")]
    [SerializeField] private Animator _boxAnimator;
    [SerializeField] private Collider _collider;
    [SerializeField] private MysteryBoxSkillsSO[] mysteryBoxSkills;
    [Header("Settings")]
    [SerializeField] private float _respawnTimer;

    public void Collect(PlayerSkillController playerSkillController)
    {
        if(playerSkillController.HasSkillAlready()) return;
        MysteryBoxSkillsSO skills=getRandomMystery();
        SkillsUI.instance.SetSkill(skills.name,skills.SkillIcon);
        playerSkillController.SetupSkill(skills);
        Debug.Log("Box Working!!");
        CollectRpc();
        
    }
    [Rpc(SendTo.ClientsAndHost)]
    public void CollectRpc()
    {
        AnimateCollection();
        Invoke(nameof(Respawn), _respawnTimer);     
    }

        private void AnimateCollection()
    {
        _collider.enabled = false;
        _boxAnimator.SetTrigger(Consts.BoxAnimations.IS_COLLECTED);
    }

    private void Respawn()
    {
        _boxAnimator.SetTrigger(Consts.BoxAnimations.IS_RESPAWNED);
        _collider.enabled = true;
    }
    private MysteryBoxSkillsSO getRandomMystery()
    {
        int random=Random.Range(0,mysteryBoxSkills.Length);
        return mysteryBoxSkills[random];
    }
}
