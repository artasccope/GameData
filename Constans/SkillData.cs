using Protocol.DTO.Fight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameData.Constans
{
    public class SkillData
    {
        private static Dictionary<int, SkillDataModel> skillModels = null;
        public static Dictionary<int, SkillDataModel> SkillModels
        {
            get
            {
                if (skillModels == null)
                    skillModels = ExcelAccessor.ReadSkillModel(new StringBuilder(System.IO.Directory.GetCurrentDirectory()).Append("/Data/skill_data.xlsx").ToString(), 1);//相对路径
                return skillModels;
            }
        }
    }
}
