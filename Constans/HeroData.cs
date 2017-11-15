using Protocol.DTO.Fight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameData.Constans
{
    public class HeroData
    {
        private static Dictionary<int, HeroModel> heroModels = null;

        public static Dictionary<int, HeroModel> HeroModels
        {
            get
            {
                if (heroModels == null)
                    heroModels = ExcelAccessor.ReadHeroModel(new StringBuilder(System.IO.Directory.GetCurrentDirectory()).Append("/Data/hero_data.xlsx").ToString(), 1);//相对路径
                return heroModels;
            }
        }
    }
}
