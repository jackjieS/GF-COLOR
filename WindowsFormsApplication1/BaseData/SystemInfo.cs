using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.BaseData
{
    class SystemInfo
    {
        //private InstanceManager im;

        //public SystemInfo(InstanceManager im)
        //{
        //    this.im = im;
        //}
        public static int ThreadTCase = 0;
        public object operationInfoLocker = null;//添加一个对象作为锁
        public static bool StayAtRecieveOperationPage = false;
        public object homeInfoLocker = null;//添加一个对象作为锁
        public static bool StayAtHomePage = false;
        public static string PageCheck = "";
        public object TasklistLock;
        public static bool PprogramErrorBackToHome = false;//闪退
        public static int ErrorCount = 0;
        public static bool RanControlinterval = false;
        public static int GameWindowsHwnd = 0;
        public static int OutWindowsHwnd = 0;
        public static int WindowsState = 0;
        public static string MacCode = "";

        public static int OsType;
        public static string AppState = "";
        public static int hwnd = -1;

        public static bool EquipmentPicRecord = true;
        public static bool LFinish = false;

        //以下是UI设置
        public static double UIcfg = 0.1;
        public static string BattleMap = "5_4E";
        public static string MainTeam = "第一梯队";
        public static string SupportTeam = "第二梯队";
        public static bool Fix = true;
        public static int Fixmaxtime = 0;
        public static int Fixmintime = 0;
        public static string ResolutionRatio = "1280*720";
        public static bool DebugMode = true;
        public static double WaitTime = 1;
        public static bool Supply=true;
        public static string AutoTeam1 = "第一梯队";
        public static string AutoTeam2 = "第二梯队";
        public static string AutoTeam3 = "第三梯队";
        public static string AutoTeam4 = "第四梯队";
        public static string AutoMap = "1_4E";
        public static int RoundInterval = 5;
        public static bool BattleLoopUnLockWindows = true;
        public static bool ChangeGun = false;
        public static bool SetMap = true;
        public static int FixMinPercentage = 20;
        public static int FixMaxPercentage = 20;
        public static int FixType = 2;
        public static int Team_SerrorTime = 60;
        public static string EquipmentUpdateType = "外骨骼";
        public static string EquipmentUpdatePostion = "1";



        //后勤
        public static string LogisticsTask1 = "代号01";
        public static string LogisticsTask2 = "代号02";
        public static string LogisticsTask3 = "代号03";
        public static string LogisticsTask4 = "代号04";
        public static int LogisticFinishWaittingTime = 0;


        public static int Simulator=0;//0为夜神模拟器 1为猩猩模拟器
        public static int BindWindowsType = 1;
        public static bool LockWindows = true;
        public static double FindTeamSlectStrSim = 90;
        public static int FindTeamSlectStrColorOffset = 10;
        public static int SetMapType = 0;
        //# 监控时间 过大会CPU占用增大
        public static int SimulatorCheckTime = 5;




        public static bool Time12AddGetFriendBattery = true;
        public static bool Time3AddGetFriendBattery = true;
        public static bool GetFriendBatterySecondLoop = true;
        public static bool GetFriendBatteryCapt = true;
        public static int GetFriendBattleryDelayM = 0;
        public static int GetFriendBattleryDelayH = 0;
    }
    }
