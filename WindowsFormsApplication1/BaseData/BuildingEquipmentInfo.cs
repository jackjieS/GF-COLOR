using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.BaseData
{
    class BuildingEquipmentInfo
    {

        public bool BuildEquipmentUsing = false;
        public int BuildEquipmentLastTime = -1;
        public bool NeedToRecieve = false;
        public bool tempNeedToRecieve = false;
        public int BuildingTime = 0;
        public int BuildingFavoriteNumber = 0;
        public void BuildingLastTimeCD(int c)
        {
            //c是所需要减的时间

            BuildEquipmentLastTime = BuildEquipmentLastTime - c;

            if (BuildEquipmentLastTime < 60)
            {
            }
            else
            {
                BuildEquipmentUsing = true;
            }



            if (BuildEquipmentLastTime < 0)
            {
                BuildEquipmentLastTime = -1;
            }

            if (BuildEquipmentLastTime == 0)
            {
                NeedToRecieve = true;
            }


        }
    }
}
