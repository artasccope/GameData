using System.Collections.Generic;
using Protocol.DTO.Fight.Instance;
using Protocol.DTO.Fight;

namespace GameData.Skill
{
    public class SkillAttack : ISkill
    {
        public void Damage(int level, ref AbsFightInstance atk, ref AbsFightInstance target, ref List<int[]> damages, SkillLevelData skillLevelData = null)
        {
            int value = atk.atk - target.def;
            value = value > 0 ? value : 1;
            target.hp = target.hp - value <= 0 ? 0 : target.hp - value;
            //一组伤害数据： 目标id、伤害值、是否活着(0为死亡、1为活着)
            damages.Add(new int[] { target.instanceId, value, target.hp == 0 ? 0 : 1 });
        }
    }
}
