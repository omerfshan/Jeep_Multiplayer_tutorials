using Unity.Netcode;
using UnityEngine;

public class PlayerSkillController : NetworkBehaviour
{
        [SerializeField] private bool _hasSkillAllready;
        [SerializeField] private MysteryBoxSkillsSO _mysteryBoxSkill;
   
        private bool _isSkillUsed;

        private void Update()
        {
                if (!IsOwner) { return; }

                if (Input.GetKeyDown(KeyCode.Space) && !_isSkillUsed)
                {
                ActivateSkill();
                _isSkillUsed = true;
                }
        

        }
        public void ActivateSkill()
        {
                if (!_hasSkillAllready) { return; }

                SkillsUI.instance.SetSkillToNone();
                _hasSkillAllready = false;

                Debug.Log("Skill Used: " + _mysteryBoxSkill.SkillType);
        }
        public void SetupSkill(MysteryBoxSkillsSO skill)
        {
                _mysteryBoxSkill = skill;

                _hasSkillAllready = true;
                _isSkillUsed = false;
        }
        public bool HasSkillAlready() => _hasSkillAllready;


}
