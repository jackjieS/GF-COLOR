using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.BaseData
{
    class BuildingGunInfo
    {

        public bool BuildGunUsing = false;
        public int BuildGunLastTime = -1;
        public bool NeedToRecieve = false;




        public void OperationLastTimeCD(int c)
        {
            //c是所需要减的时间

            BuildGunLastTime = BuildGunLastTime - c;

            if (BuildGunLastTime < 60)
            {
            }
            else
            {
                BuildGunUsing = true;
            }



            if (BuildGunLastTime < 0)
            {
                BuildGunLastTime = -1;
            }

            if (BuildGunLastTime == 0)
            {
                NeedToRecieve = true;
            }


        }
    }
}
