using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protocol;
using Protocol.DTO.Fight;
using Protocol.DTO.Fight.Instance;

namespace GameData.Constans
{
    public class BuildingData
    {
        private static Dictionary<int, KeyValuePair<AbsFightModel, BuildingModel>> buildingModels = null;
        private static List<BuildingInstance> buildingInstances = null;

        public static List<BuildingInstance> BuildingInstances {
            get {
                if (buildingInstances == null) {
                    if (buildingModels == null)
                        buildingModels = ExcelAccessor.ReadBuildingModel(new StringBuilder(System.IO.Directory.GetCurrentDirectory()).Append("/Data/buinding_data.xlsx").ToString(),1);//相对路径

                    buildingInstances = ExcelAccessor.ReadBuildingInstance(new StringBuilder(System.IO.Directory.GetCurrentDirectory()).Append("/Data/buinding_data_instances.xlsx").ToString(), 1, buildingModels);
                }

                Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
                for (int i = 0; i < buildingInstances.Count; i++) {
                    buildingInstances[i].instanceId = (-i - 1);
                }

                return buildingInstances;
            }
        }
    }
}
