using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GameData.Constans
{
    public class MapData
    {
        public static Vector3 heroBornPointTeamOne = new Vector3(27, 0, 27);
        public static Vector3 heroBornPointTeamTwo = new Vector3(222, 0, 222);
        public static Vector3[] soilderBornPointTeamOne = new Vector3[3] { new Vector3(14, 0, 75), new Vector3(65, 0, 65), new Vector3(75, 0, 14)};
        public static Vector3[] soilderBornPointTeamTwo = new Vector3[3] { new Vector3(175, 0, 236), new Vector3(185,0,185), new Vector3(236, 0,175)};
    }
}
