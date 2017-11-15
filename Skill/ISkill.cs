
using Protocol.DTO.Fight;
using Protocol.DTO.Fight.Instance;
using System.Collections.Generic;

namespace GameData.Skill
{
    public interface ISkill
    {
        void Damage(int level, ref AbsFightInstance atk, ref AbsFightInstance target, ref List<int[]> damages, SkillLevelData skillLevelData = null);
    }
}
