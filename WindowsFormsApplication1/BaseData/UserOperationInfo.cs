using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.BaseData
{
    public class UserOperationInfo//模板
    {


        public string OperationName ;
        public string OperationTeamName;
        public double OperationTotalTime;
        public int OperationLastTime = -1;
        public bool OperationUsingState=false;//是否在运行
        public bool OperationNeedTowait=false;
        public bool Added = false;
        public bool NeedToRecieve = false;
        public bool ReceiveRightNow = false;

        public void OperationLastTimeCD(int c)
        {
            //c是所需要减的时间

            OperationLastTime = OperationLastTime - c;

            if (OperationLastTime < 60 )
            {
                OperationNeedTowait = true;
            }
            else
            {
                OperationUsingState = true;
                Added = false;
                OperationNeedTowait = false;

            }



            if (OperationLastTime < 0)
            {
                OperationLastTime = -1;

            }

            if (OperationLastTime == 0)
            {
                NeedToRecieve = true;
                ReceiveRightNow = true;
            }
           
        }


    }
}
