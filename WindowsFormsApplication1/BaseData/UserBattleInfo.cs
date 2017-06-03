using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.BaseData
{
    public class UserBattleInfo
    {
        public int Key;//字典本事key键

        public int BattleLoopTime = 0;
        public double BattleFixTime;//修复时间也是新的一轮所等的时间
        public bool BattleStart = false;//可以开始新的一轮或者等待修复
        public bool ChangeGunBattleTask;//换枪任务

        public int DismantlementGunCount = 24;//拆枪数量
        public int EquipmentUpdateCount = 24;

        public bool DismantleGunOrEquipment;//这个变量决定枪满装备满是否拆除或者停止脚本
        public int DismantleType;//=0表示拆的是枪，1是装备升级
        public bool NeetToDismantleGunOrEquipment = false;//是否需要拆枪
        public int EquipmentType;//升级装备所选贼装备的类型
        public int EquipmentUpdatePostion;

        public bool Used;//整个挂机任务是否使用
        public string TaskName;//地图名称如5-4E
        public int TaskNumber;
        public string TaskMianTeam;
        public string TaskSupportTeam1;
        public string TaskSupportTeam2;
        public string TaskSupportTeam3;
        public string TaskSupportTeam4;
        public string TaskSupportTeam5;
        public string TaskSupportTeam6;
        public string TaskSupportTeam7;
        public string TaskSupportTeam8;
        public bool Team_Serror = false;
        public int Team_SerrorTime = 0;
        public int TaskType = 2;
        public bool ChoiceToFix;//总设定是否修复
        public bool NeedToFix;
        public bool ChoiceToSupply;
        public int FixType = 2;
        public int FixMaxTime;
        public int FixMintime;
        public int FixMaxPercentage = 0;
        public int FixMinPercentage = 0;
        public int RoundInterval;
        public int LoopMaxTime = -1;//循环最大次数达到这个数目则停止循环战斗 -1为无限次
        public bool BattleLoopUnLockWindows;

        public bool ChangeGun;
        public bool SetMap = false;

        public void BattleFixLastTimeCD(int c)
        {
            //c是所需要减的时间

            this.BattleFixTime = BattleFixTime - c;
            if (this.BattleFixTime < 0)
            {
                this.BattleFixTime = -1;
            }
        }

       

        public void reSetBattleInfo()
        {
            this.BattleStart = false;
            this.Team_Serror = false;
            this.NeetToDismantleGunOrEquipment = false;
            this.NeedToFix = false;
        }

        public void EndAtBattle(DmAe dmae)
        {
            this.BattleLoopTime++;
            if (this.Team_Serror)
            {
                this.BattleFixTime = this.Team_SerrorTime;
                return;
            }

            if (this.NeedToFix)
            {
                CommonHelp.BattleFixNumber = Key+1;
                CommonHelp.gametasklist.Insert(0, TaskList.Fix);
            }
            else //-----循环间隔
            {
                Random ran = new Random();
                int temp0 = ran.Next(0, this.RoundInterval);
                this.BattleFixTime = temp0 + 1;
            }

            if (this.BattleLoopTime == this.LoopMaxTime)
            {
                this.BattleLoopTime = 0; this.BattleFixTime = -1; this.Used = false;
            }
            if (this.Used == false) { CommonHelp.BindWindowS(dmae, 0); }
            if (this.BattleLoopUnLockWindows == false) { CommonHelp.BindWindowS(dmae, 0); }




        }

    }

    public class UserAutoBattleInfo
    {
        public bool AutoBattleUse = false;
        public bool DismantleGunOrEquipment = false;
        public bool NeetToDismantleGunOrEquipment = false;
        public int DismantleType = 0;
        public int AutoBattleStartTime;
        public int AutoBattleLastTime;
        public int AutoBattleLoopTime = 0;
        public string AutoBattleMap;
        public string AutoBattleTeamName1;
        public string AutoBattleTeamName2;
        public string AutoBattleTeamName3;
        public string AutoBattleTeamName4;
        public bool AutoBattle_State;

        public void AutoBattleLastTimeCD(int c)
        {
            //c是所需要减的时间


            if (this.AutoBattleLastTime < 0)
            {
                this.AutoBattleLastTime = -1;
                AutoBattle_State = true;
            }
            else
            {
                this.AutoBattleLastTime = AutoBattleLastTime - c;
                this.AutoBattle_State = false;
            }




        }
    }
}


