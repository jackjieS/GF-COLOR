using EyLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskList;
using testdm;
using dmtext;
using PageCheck;
using static WindowsFormsApplication1.BaseData.TaskList;

namespace WindowsFormsApplication1
{
    class InstanceManager
    {
        public Form1 Form1;
        public UIupdate uiupdate;
        public WriteLog writelog;

        //public DmAe dmae;
        public dmtext.CDmSoft dm;
        public PageCheck.PageCheck pagecheck;

        public Mouse mouse;
        public Time time;
        public BaseData.ConfigManager configManager;


        public BaseData.TaskList taskList;
        public BackgroundThread backGroundThread;

        public EyLoginSoft eyLogin;
        public CommonHelp commonHelp;


        public GameeData gameData;
        public UserData userData;

        public Events.Dormitory dormitory;
        public Events.Equipment equipment;
        public Events.Formation formation;




        public InstanceManager(Form1 form1)
        {
            this.Form1 = form1;
            this.uiupdate = new UIupdate(this);
            //this.dmae = new DmAe(this);
            this.writelog = new WriteLog(this);

            this.dm = new dmtext.CDmSoft();
            pagecheck = new PageCheck.PageCheck();

            this.mouse = new Mouse(this);
            this.time = new Time(this);
            this.configManager = new BaseData.ConfigManager(this);

            this.taskList = new BaseData.TaskList(this);
            this.backGroundThread = new BackgroundThread(this);
            this.eyLogin = new EyLoginSoft();
            this.commonHelp = new CommonHelp(this);

            this.gameData = new GameeData(this);
            this.userData = new UserData(this);
            this.dormitory = new Events.Dormitory(this);
            this.equipment = new Events.Equipment(this);
            this.formation = new Events.Formation(this);


            for (int i = 0; i < 4; i++)
            {
                BaseData.UserOperationInfo user_operationinfo0 = new BaseData.UserOperationInfo();
                this.gameData.User_operationInfo.Add(i, user_operationinfo0);
            }

            for(int i = 0; i < 4; i++)
            {
                BaseData.UserBattleInfo user_battleinfo = new BaseData.UserBattleInfo();
                user_battleinfo.Key = i;
                this.gameData.User_battleInfo.Add(i, user_battleinfo);
            }

            for(int i = 0; i < 8; i++)
            {
                ShowerTime.Add(-1);
            }

            BaseData.UserAutoBattleInfo autobattleinfo = new BaseData.UserAutoBattleInfo();
            this.gameData.User_AutobattleInfo.Add(0, autobattleinfo);

            for (int i = 0; i < 3; i++)//装备建造
            {
                BaseData.BuildingEquipmentInfo user_buildingequipmentinfo0 = new BaseData.BuildingEquipmentInfo();
                this.gameData.User_BuildingEquipmentInfo.Add(i, user_buildingequipmentinfo0);
            }
            for (int i = 0; i < 3; i++)//枪建造
            {
                BaseData.BuildingGunInfo user_buildingguninfo0 = new BaseData.BuildingGunInfo();
                this.gameData.User_BuildingGunInfo.Add(i, user_buildingguninfo0);
            }


        }
        public Thread CountDown, CompleteMisson, ThreadT, MonitorPic;
        //public List<TaskListstruct> gametasklist = new List<TaskListstruct>();
        //public List<int> User_LogistandAutoNumberNow = new List<int>();
        public List<int> ShowerTime = new List<int>();
    }
}
