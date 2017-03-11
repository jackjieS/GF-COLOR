using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.BaseData
{
    public class UserOperationInfo//模板
    {
        //public static string LogisticsTask1 = Properties.Settings.Default.LogisticsTask1;//后勤任务1名称
        //public static string LogisticsTask2 = Properties.Settings.Default.LogisticsTask2;//后勤任务
        //public static string LogisticsTask3 = Properties.Settings.Default.LogisticsTask3;//后勤任务
        //public static string LogisticsTask4 = Properties.Settings.Default.LogisticsTask4;//后勤任务
        //public static double RT1 = 0, RT2 = 0, RT3 = 0, RT4 = 0;//后勤任务时间
        //public static bool RT1_Start = false, RT2_Start = false, RT3_Start = false, RT4_Start = false;
        //public static bool RT1_NeedToWait = false, RT2_NeedToWait = false, RT3_NeedToWait = false, RT4_NeedToWait = false;
        //public static string LogisticsTeam1 = "第五梯队";//后勤任务小队
        //public static string LogisticsTeam2 = "第六梯队";//后勤任务
        //public static string LogisticsTeam3 = "第七梯队";//后勤任务
        //public static string LogisticsTeam4 = "第八梯队";//后勤任务

        public string OperationName ;
        public string OperationTeamName;
        public double OperationTotalTime;
        public int OperationLastTime = -1;
        public bool OperationState;//是否在运行
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
