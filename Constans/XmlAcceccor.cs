using System;
using System.Collections.Generic;
using OfficeOpenXml;
using System.IO;
using Protocol;
using Protocol.DTO.Fight;
using Protocol.DTO.Fight.Instance;

namespace GameData.Constans
{
    public class ExcelAccessor
    {

        internal static Dictionary<int, KeyValuePair<AbsFightModel, BuildingModel>> ReadBuildingModel(string dir, int sheetIndex)
        {
            FileInfo file = new FileInfo(dir);
            ExcelPackage package = new ExcelPackage(file);
            Dictionary<int, KeyValuePair<AbsFightModel, BuildingModel>> buildingModelList = null;
            if (package.Workbook.Worksheets.Count > 0) {
                buildingModelList = new Dictionary<int, KeyValuePair<AbsFightModel, BuildingModel>>();
                ExcelWorksheet excelWorksheet = package.Workbook.Worksheets[sheetIndex];
                for (int m = excelWorksheet.Dimension.Start.Row + 1, n = excelWorksheet.Dimension.End.Row; m <= n; m++)
                {

                    BuildingModel buildingModel = new BuildingModel();
                    AbsFightModel fightModel = new AbsFightModel();
                    fightModel.category = excelWorksheet.GetValue<byte>(m, 1);
                    fightModel.specieId = excelWorksheet.GetValue<int>(m, 3);
                    fightModel.name = excelWorksheet.GetValue<string>(m, 4);
                    fightModel.maxHp = excelWorksheet.GetValue<int>(m, 7);
                    fightModel.atk = excelWorksheet.GetValue<int>(m, 8);
                    fightModel.def = excelWorksheet.GetValue<int>(m, 9);
                    fightModel.atkSpeed = excelWorksheet.GetValue<int>(m, 10);
                    fightModel.atkRange = excelWorksheet.GetValue<int>(m, 11);
                    fightModel.eyeRange = excelWorksheet.GetValue<int>(m, 12);
                    buildingModel.couldAttack = excelWorksheet.GetValue<bool>(m, 13);
                    buildingModel.isAntiStealth = excelWorksheet.GetValue<bool>(m, 14);
                    buildingModel.isReborn = excelWorksheet.GetValue<bool>(m, 15);
                    buildingModel.rebornTime = excelWorksheet.GetValue<int>(m, 16);

                    buildingModelList.Add(fightModel.category.GetHashCode() + fightModel.specieId.GetHashCode(), new KeyValuePair<AbsFightModel, BuildingModel>(fightModel, buildingModel));
                }
            }

            package.Dispose();
            return buildingModelList;
        }

        internal static Dictionary<int, SkillDataModel> ReadSkillModel(string dir, int sheetIndex)
        {
            FileInfo file = new FileInfo(dir);
            ExcelPackage package = new ExcelPackage(file);
            Dictionary<int, SkillDataModel> skillModelList = null;
            if (package.Workbook.Worksheets.Count > 0)
            {
                skillModelList = new Dictionary<int, SkillDataModel>();
                ExcelWorksheet excelWorksheet = package.Workbook.Worksheets[sheetIndex];
                for (int m = excelWorksheet.Dimension.Start.Row + 1, n = excelWorksheet.Dimension.End.Row; m <= n; m++)
                {
                    SkillDataModel skillModel = new SkillDataModel();
                    skillModel.code = excelWorksheet.GetValue<int>(m, 1);
                    skillModel.name = excelWorksheet.GetValue<string>(m, 2);
                    skillModel.info = excelWorksheet.GetValue<string>(m, 17);
                    skillModel.type = (SkillType)excelWorksheet.GetValue<int>(m, 3);
                    skillModel.targetType = (SkillTargetType)excelWorksheet.GetValue<int>(m, 4);
                    skillModel.costType = (SkillCostType)excelWorksheet.GetValue<int>(m, 5);
                    string[] costs = excelWorksheet.GetValue<string>(m, 6).Split('/');
                    int levelCount = costs.Length;
                    string[] preloadTimes = excelWorksheet.GetValue<string>(m, 7).Split('/');
                    string[] bootTimes = excelWorksheet.GetValue<string>(m, 8).Split('/');
                    string[] cdTimes = excelWorksheet.GetValue<string>(m, 9).Split('/');
                    string[] ranges = excelWorksheet.GetValue<string>(m, 10).Split('/');
                    string[] damages = excelWorksheet.GetValue<string>(m, 11).Split('/');
                    string[] heals = excelWorksheet.GetValue<string>(m, 12).Split('/');
                    string[] atkSpeedUps = excelWorksheet.GetValue<string>(m, 13).Split('/');
                    string[] moveSpeedUps = excelWorksheet.GetValue<string>(m, 14).Split('/');
                    string[] lastingTimes = excelWorksheet.GetValue<string>(m, 15).Split('/');
                    string[] requiredLevels = excelWorksheet.GetValue<string>(m, 16).Split('/');

                    List<SkillLevelData> levelData = new List<SkillLevelData>(5);
                    for (int i = 0; i < levelCount; i++) {
                        SkillLevelData skillLevelData = new SkillLevelData();
                        
                        skillLevelData.nextLevel = int.Parse(GetData(requiredLevels, i));
                        skillLevelData.cost = int.Parse(GetData(costs, i));
                        skillLevelData.preloadTime = int.Parse(GetData(preloadTimes, i));
                        skillLevelData.bootTime = int.Parse(GetData(bootTimes, i));
                        skillLevelData.cdTime = int.Parse(GetData(cdTimes, i));
                        skillLevelData.lastingTime = float.Parse(GetData(lastingTimes, i));
                        skillLevelData.damage = int.Parse(GetData(damages, i));
                        skillLevelData.heal = int.Parse(GetData(heals, i));
                        skillLevelData.range = float.Parse(GetData(ranges, i));

                        levelData.Add(skillLevelData);
                    }

                    if (!skillModelList.ContainsKey(skillModel.code))
                        skillModelList.Add(skillModel.code, skillModel);
                }
            }

            package.Dispose();
            return skillModelList;
        }

        private static string GetData(string[] datas, int n) {
            return datas.Length > 1 ? datas[n] : datas[0];
        }

        internal static Dictionary<int, HeroModel> ReadHeroModel(string dir, int sheetIndex)
        {
            FileInfo file = new FileInfo(dir);
            ExcelPackage package = new ExcelPackage(file);
            Dictionary<int, HeroModel> heroModelList = null;
            if (package.Workbook.Worksheets.Count > 0)
            {
                heroModelList = new Dictionary<int, HeroModel>();
                ExcelWorksheet excelWorksheet = package.Workbook.Worksheets[sheetIndex];
                for (int m = excelWorksheet.Dimension.Start.Row + 1, n = excelWorksheet.Dimension.End.Row; m <= n; m++)
                {
                    HeroModel heroModel = new HeroModel();
                    heroModel.category = (byte)ModelType.Hero;
                    heroModel.specieId = excelWorksheet.GetValue<int>(m, 1);
                    heroModel.id = heroModel.specieId;
                    heroModel.name = excelWorksheet.GetValue<string>(m, 2);
                    heroModel.atk = excelWorksheet.GetValue<int>(m, 3);
                    heroModel.def = excelWorksheet.GetValue<int>(m, 4);
                    heroModel.maxHp = excelWorksheet.GetValue<int>(m, 5);
                    heroModel.mp = excelWorksheet.GetValue<int>(m, 6);
                    heroModel.atkArr = excelWorksheet.GetValue<int>(m, 7);
                    heroModel.defArr = excelWorksheet.GetValue<int>(m, 8);
                    heroModel.hpArr = excelWorksheet.GetValue<int>(m, 9);
                    heroModel.mpArr = excelWorksheet.GetValue<int>(m, 10);
                    heroModel.speed = excelWorksheet.GetValue<float>(m, 11);
                    heroModel.atkSpeed = excelWorksheet.GetValue<float>(m, 12);
                    heroModel.atkRange = excelWorksheet.GetValue<int>(m, 13);
                    heroModel.eyeRange = excelWorksheet.GetValue<int>(m, 14);
                    heroModel.skillCodes = GetSkills(excelWorksheet.GetValue<string>(m, 15));

                    if(!heroModelList.ContainsKey(heroModel.specieId))
                        heroModelList.Add(heroModel.specieId, heroModel);
                }
            }

            package.Dispose();
            return heroModelList;
        }

        private static int[] GetSkills(string str) {
            string[] strs = str.Split(' ');
            int[] skills = new int[strs.Length];
            for (int i = 0; i < strs.Length; i++) {
                skills[i] = int.Parse(strs[i]);
            }

            return skills;
        }

        internal static List<BuildingInstance> ReadBuildingInstance(string dir, int sheetIndex, Dictionary<int, KeyValuePair<AbsFightModel, BuildingModel>> buildingModels)
        {
            FileInfo file = new FileInfo(dir);
            ExcelPackage package = new ExcelPackage(file);
            List<BuildingInstance> buildingInstanceList = null;
            if (package.Workbook.Worksheets.Count > 0)
            {
                ExcelWorksheet excelWorksheet = package.Workbook.Worksheets[sheetIndex];
                buildingInstanceList = new List<BuildingInstance>();
                for (int m = excelWorksheet.Dimension.Start.Row, n = excelWorksheet.Dimension.End.Row; m <= n; m++)
                {
                    int categoryId = excelWorksheet.GetValue<byte>(m, 1);
                    int specieId = excelWorksheet.GetValue<byte>(m, 5);
                    KeyValuePair<AbsFightModel, BuildingModel> pair = buildingModels[categoryId.GetHashCode() + specieId.GetHashCode()];

                    BuildingInstance buildingInstance = new BuildingInstance(pair.Key, pair.Value);
                    buildingInstance.posX = excelWorksheet.GetValue<float>(m, 2);
                    buildingInstance.posY = excelWorksheet.GetValue<float>(m, 3);
                    buildingInstance.posZ = excelWorksheet.GetValue<float>(m, 4);
                    buildingInstance.eAngleX = excelWorksheet.GetValue<float>(m, 18);
                    buildingInstance.eAngleY = excelWorksheet.GetValue<float>(m, 19);
                    buildingInstance.eAngleZ = excelWorksheet.GetValue<float>(m, 20);
                    buildingInstance.scaleX = excelWorksheet.GetValue<float>(m, 21);
                    buildingInstance.scaleY = excelWorksheet.GetValue<float>(m, 22);
                    buildingInstance.scaleZ = excelWorksheet.GetValue<float>(m, 23);
                    buildingInstance.teamId = excelWorksheet.GetValue<byte>(m, 24);

                    buildingInstanceList.Add(buildingInstance);
                }
            }

            package.Dispose();
            return buildingInstanceList;
        }

    }
}
