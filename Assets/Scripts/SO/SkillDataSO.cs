using UnityEngine;

[CreateAssetMenu(fileName = "Skill Data", menuName = "Scriptable Objects/Skill Data")]
public class SkillDataSO : ScriptableObject  
{
    [SerializeField] private Transform _skillPrefabs;
    public Transform SkillPrefabs => _skillPrefabs;
}
