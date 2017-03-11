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
        public static int Simulator;//0为夜神模拟器 1为猩猩模拟器
        public static int OsType;
        public static string AppState = "";
        public static int hwnd = -1;


    }
}
