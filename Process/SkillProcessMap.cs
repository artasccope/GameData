using GameData.Skill;
using System.Collections.Generic;

namespace GameData.Process
{
    public class SkillProcessMap
    {
        private static Dictionary<int, ISkill> skills = new Dictionary<int, ISkill>();
        static SkillProcessMap()
        {
            Put(-1, new SkillAttack());
        }

        static void Put(int code, ISkill skill)
        {
            skills.Add(code, skill);
        }

        public static bool Has(int code)
        {
            return skills.ContainsKey(code);
        }

        public static ISkill Get(int code)
        {
            return skills[code];
        }
    }
}
