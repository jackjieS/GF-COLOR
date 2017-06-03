using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.BaseData
{
    class TaskList
    {
        private InstanceManager im;
        public TaskList(InstanceManager im)
        {
            this.im = im;
        }

        public struct TaskListstruct
        {
            private string taskname;
            public string TaskName
            {
                get { return taskname; }
                set { taskname = value; }
            }

            private int tasknumber;
            public int TaskNumber
            {
                get { return tasknumber; }
                set { tasknumber = value; }
            }


            //有参数构造函数
            public TaskListstruct(string _name, int _age)
            {
                //如果要在结构中使用构造函数则必须给所有的变量赋值（在构造函数中赋值）
                this.taskname = _name;
                this.tasknumber = _age;

            }
        }

        public static TaskListstruct taskfree = new TaskListstruct("空闲", 0);
        public static TaskListstruct ReadLogisticsTaskTime = new TaskListstruct("读取后勤时间", 1);
        public static TaskListstruct StartLogistics = new TaskListstruct("执行后勤任务", 2);
        public static TaskListstruct StartLogisticsTask1 = new TaskListstruct("执行后勤任务", 3);
        public static TaskListstruct StartLogisticsTask2 = new TaskListstruct("执行后勤任务", 4);
        public static TaskListstruct StartLogisticsTask3 = new TaskListstruct("执行后勤任务", 5);
        public static TaskListstruct StartLogisticsTask4 = new TaskListstruct("执行后勤任务", 6);
        public static TaskListstruct ReceiveLogistics = new TaskListstruct("接收后勤任务", 7);
        public static TaskListstruct Battle2_1E = new TaskListstruct("2-1E练级", 8);
        public static TaskListstruct Battle3_3E = new TaskListstruct("3-3E练级", 9);
        public static TaskListstruct Battle4_4E = new TaskListstruct("4-4E练级", 10);
        public static TaskListstruct Battle1_6 = new TaskListstruct("1_6练级", 11);
        public static TaskListstruct Battle1 = new TaskListstruct("练级任务1", 12);
        public static TaskListstruct Battle2 = new TaskListstruct("练级任务2", 13);
        public static TaskListstruct Battle3 = new TaskListstruct("练级任务3", 14);
        public static TaskListstruct Battle4 = new TaskListstruct("练级任务4", 15);
        public static TaskListstruct AutoBattle = new TaskListstruct("自律作战", 16);
        public static TaskListstruct BuildEquipment = new TaskListstruct("装备建造", 17);
        public static TaskListstruct BuildGun = new TaskListstruct("人形建造", 18);
        public static TaskListstruct VoteOthersDormitory = new TaskListstruct("宿舍点赞", 19);

        public static TaskListstruct EquipmentUpdate = new TaskListstruct("装备强化", 20);
        public static TaskListstruct Update = new TaskListstruct("人形强化", 21);

        public static TaskListstruct ReadAndSaveFriendsDormitoryList = new TaskListstruct("读取宿舍", 22);
        public static TaskListstruct GetFriendDormitoryBattery = new TaskListstruct("领取电池", 23);
        public static TaskListstruct WaitForLogistics = new TaskListstruct("等待后勤任务结束", 98);
        public static TaskListstruct WaitAuttoBattleFinish = new TaskListstruct("自律作战结束", 99);
        public static TaskListstruct Fix = new TaskListstruct("修复", 97);
        public static TaskListstruct Dismantlement = new TaskListstruct("拆除", 96);
        public static TaskListstruct ChangeGun = new TaskListstruct("更换", 95);
        public static TaskListstruct BackToGame = new TaskListstruct("回到游戏", 94);


        public void taskadd(TaskListstruct a)//入列
        {
            //int temp = im.gametasklist.FindIndex(s => s.TaskNumber == 0);
            WriteLog.WriteError("添加任务 " + a.TaskName);
            CommonHelp.gametasklist.Add(a);
        }

        public void taskremove()//出列
        {
            CommonHelp.gametasklist.RemoveAt(0);
            WriteLog.WriteError("任务移除 ");
        }

        public void taskInsertafterOperation(TaskListstruct a)
        {
            int count = 0;
            foreach(var item in im.gameData.User_operationInfo)
            {
                if (item.Value.NeedToRecieve == true) count++;
            }


            CommonHelp.gametasklist.Insert(count, a);
        }

        public void OperationStartAdd(ref bool SetNeedToReceive, TaskListstruct a)
        {

            //true 有货，空为 false。
            //加入开始后勤任务
            //如果当前队列任务是空闲则加入接收和开始后勤任务
            //如果当前队列任务非空闲则加入开始后勤任务到最后(因为当前任务结束退到主页会检测，添加接收后期任务，故当前不需要添加接收后勤任务)
            if (CommonHelp.gametasklist.Any())
            {
                CommonHelp.gametasklist.Add(a);
            }
            else
            {
                CommonHelp.gametasklist.Add(BaseData.TaskList.ReceiveLogistics);
                CommonHelp.gametasklist.Add(a);
                SetNeedToReceive = true;
            }



        }

    }
}
