﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.BaseData;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
    class BackgroundThread
    {
        public InstanceManager im;
        public Action LAction;
        public BackgroundThread(InstanceManager im)
        {

            this.im = im;
        }


        public void CountDown()//倒计时
        {
            DateTime Now = DateTime.Now;
            DateTime BeijingTimeNow = CommonHelp.PSTConvertToGMT(Now);
            int c;
            Thread.Sleep(200);
            int BattleStartCount;

            while (true)
            {
                c = Convert.ToInt32((DateTime.Now - Now).TotalSeconds);
                Now = DateTime.Now;

                BeijingTimeNow = CommonHelp.PSTConvertToGMT(Now);
                //如果12点过了则添加Settings.Default.GetFriendBattleryDelayM

                //3点
                if(BeijingTimeNow.Hour*60+BeijingTimeNow.Minute == (60 * 3 + (SystemInfo.GetFriendBattleryDelayM))&& SystemInfo.Time3AddGetFriendBattery == true)
                {
                    im.taskList.taskadd(BaseData.TaskList.GetFriendDormitoryBattery);
                    SystemInfo.Time3AddGetFriendBattery = false;
                }
                else
                {
                    if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute != 60 * 3 + SystemInfo.GetFriendBattleryDelayM)
                        SystemInfo.Time3AddGetFriendBattery = im.Form1.checkBox4.Checked;
                }

                //15点
                if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute == (60 * 15 + (SystemInfo.GetFriendBattleryDelayM)) && SystemInfo.Time15AddGetFriendBattery == true)
                {
                    im.taskList.taskadd(BaseData.TaskList.GetFriendDormitoryBattery);

                    SystemInfo.Time15AddGetFriendBattery = false;
                }
                else
                {
                    if (BeijingTimeNow.Hour * 60 + BeijingTimeNow.Minute != 60 * 15 + SystemInfo.GetFriendBattleryDelayM)
                        SystemInfo.Time15AddGetFriendBattery = im.Form1.checkBox1.Checked;
                }

                im.gameData.User_operationInfo[0].OperationLastTimeCD(c);
                im.gameData.User_operationInfo[1].OperationLastTimeCD(c);
                im.gameData.User_operationInfo[2].OperationLastTimeCD(c);
                im.gameData.User_operationInfo[3].OperationLastTimeCD(c);

                im.gameData.User_BuildingEquipmentInfo[0].BuildingLastTimeCD(c);
                im.gameData.User_BuildingEquipmentInfo[1].BuildingLastTimeCD(c);
                im.gameData.User_BuildingEquipmentInfo[2].BuildingLastTimeCD(c);
                for (int i = 0; i < 4; i++)
                {
                    if (im.gameData.User_operationInfo[i].OperationLastTime == 0 )
                    {
                        //true 有货，空为 false。
                        //加入开始后勤任务
                        //如果当前队列任务非空闲则加入开始后勤任务到最后(因为当前任务结束退到主页会检测，添加接收后期任务，故当前不需要添加接收后勤任务)
                        //如果当前队列任务是空闲则加入接收和开始后勤任务

                        if (CommonHelp.gametasklist.Any() && (CommonHelp.gametasklist[0].TaskNumber != 98))
                        {
                            im.gameData.User_operationInfo[i].ReceiveRightNow = true;
                        }
                        else
                        {
                            //需要把当前i传过去 靠队列
                            LogistandAutolist temp = new LogistandAutolist();
                            temp.key = i;
                            temp.type = 0;
                            CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                            im.gameData.User_operationInfo[i].Lfinish = true;
                            CommonHelp.gametasklist.Add(BaseData.TaskList.WaitForLogistics);
                            //返回时间
                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                            im.gameData.User_operationInfo[i].Added = true;
                        }
                    }
                }

                if(im.gameData.User_AutobattleInfo[0].AutoBattleUse==true && im.gameData.User_AutobattleInfo[0].AutoBattleLastTime == 0)
                {
                    if (CommonHelp.gametasklist.Any() && (CommonHelp.gametasklist[0].TaskNumber != 98))
                    {
                        CommonHelp.gametasklist.Add(BaseData.TaskList.WaitForLogistics);
                    }
                    else
                    {
                        //需要把当前i传过去 靠队列
                        LogistandAutolist temp = new LogistandAutolist();
                        temp.key = -1;
                        temp.type = 1;
                        CommonHelp.User_LogistandAutoNumberNow.Add(temp);

                        CommonHelp.gametasklist.Add(BaseData.TaskList.WaitForLogistics);
                        //返回时间
                        CommonHelp.gametasklist.Add(BaseData.TaskList.AutoBattle);
                        im.gameData.User_AutobattleInfo[0].AutoBattleUse = true;
                    }


                }


                for (int i = 0; i < 3; i++)
                {
                    if (im.gameData.User_BuildingEquipmentInfo[i].NeedToRecieve == true)
                    {
                        im.taskList.taskadd(BaseData.TaskList.BuildEquipment);
                        im.gameData.User_BuildingEquipmentInfo[i].NeedToRecieve = false;
                    }
                }


                im.gameData.User_battleInfo[0].BattleFixLastTimeCD(c);
                im.gameData.User_battleInfo[1].BattleFixLastTimeCD(c);
                im.gameData.User_battleInfo[2].BattleFixLastTimeCD(c);
                im.gameData.User_battleInfo[3].BattleFixLastTimeCD(c);
                BattleStartCount = 0;

                foreach (var item in im.gameData.User_battleInfo)
                {
                    if (item.Value.Used)
                    {
                        if (item.Value.BattleFixTime == 0)
                        {
                            switch (BattleStartCount)
                            {
                                case 0: { im.taskList.taskadd(BaseData.TaskList.Battle1); im.gameData.User_battleInfo[0].BattleStart = false; break; }
                                case 1: { im.taskList.taskadd(BaseData.TaskList.Battle2); im.gameData.User_battleInfo[1].BattleStart = false; break; }
                                case 2: { im.taskList.taskadd(BaseData.TaskList.Battle3); im.gameData.User_battleInfo[2].BattleStart = false; break; }
                                case 3: { im.taskList.taskadd(BaseData.TaskList.Battle4); im.gameData.User_battleInfo[3].BattleStart = false; break; }
                                default: break;
                            }
                        }
                    }
                    BattleStartCount++;
                }



                im.gameData.User_AutobattleInfo[0].AutoBattleLastTimeCD(c);

                if (im.ShowerTime[0] > -1)
                {
                    im.ShowerTime[0] -= c;
                }
                if (im.ShowerTime[1] > -1)
                {
                    im.ShowerTime[1] -= c;
                }
                if (im.ShowerTime[2] > -1)
                {
                    im.ShowerTime[2] -= c;
                }
                if (im.ShowerTime[3] > -1)
                {
                    im.ShowerTime[3] -= c;
                }
                if (im.ShowerTime[4] > -1)
                {
                    im.ShowerTime[4] -= c;
                }
                if (im.ShowerTime[5] > -1)
                {
                    im.ShowerTime[5] -= c;
                }

                if (im.ShowerTime[6] > -1)
                {
                    im.ShowerTime[6] -= c;
                }
                if (im.ShowerTime[7] > -1)
                {
                    im.ShowerTime[7] -= c;
                }

                im.uiupdate.UIupdateOperation();
                Thread.Sleep(1000);
            }
        }

        public void CompleteMisson()
        {
            DmAe dmae = new DmAe();
            

            if (dmae.BindWindow() == 0)
            {
                MessageBox.Show("绑定窗口错误");
            }
            dmae.SetDict();//设置系统路径和字典
            if (BaseData.SystemInfo.PprogramErrorBackToHome == true)
            {
                //点游戏图标重进游戏
                im.taskList.taskadd(BaseData.TaskList.BackToGame);
                BaseData.SystemInfo.PprogramErrorBackToHome = false;
            }
            DateTime Now = DateTime.Now;

            Thread.Sleep(1000);


            while (true)
            {
                Thread.Sleep(500);

                //Stopwatch sw = new Stopwatch();
                Now = DateTime.Now;

                if (CommonHelp.gametasklist.Any())
                {
                    switch (CommonHelp.gametasklist.ElementAt(0).TaskNumber.ToString())
                    {
                        case "1":
                            {

                                im.time.ReadLogisticsTaskTime(dmae, im.mouse);
                                im.taskList.taskremove();



                                im.mouse.BindWindowS(dmae, 0);
                                break;
                            }

                        case "2":
                            {

                                    im.time.StartLogistics(dmae, im.mouse, ref im.gameData.User_operationInfo);
                                    im.taskList.taskremove();


                                //战斗结束 判断是否需要加接收后勤任务到最前
                                //foreach (var item in im.gameData.User_operationInfo)
                                //{
                                //    if (item.Value.NeedToRecieve)
                                //    {
                                //        im.gametasklist.Insert(0, BaseData.TaskList.ReceiveLogistics);
                                //        item.Value.NeedToRecieve = false;
                                //    }
                                //}


                                im.mouse.BindWindowS(dmae, 0);
                                break;


                            }


                        case "3":
                            {
                                if (im.gameData.GetOperationTime_60s())
                                {
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                                        {
                                            //im.gametasklist.Insert(0, BaseData.TaskList.WaitForLogistics);//等加接收一起完成
                                            ////等待完成

                                            //im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            //im.gameData.User_operationInfo[i].Added = true;
                                            ////SystemInfo.LFinish = false;

                                            LogistandAutolist temp = new LogistandAutolist();
                                            temp.key = i;
                                            temp.type = 0;
                                            CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            CommonHelp.gametasklist.Add(BaseData.TaskList.WaitForLogistics);
                                            //返回时间
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }

                                    }
                                }
                                else
                                {

                                    im.time.StartLogisticsTask1(dmae, im.mouse);
                                    im.taskList.taskremove();
                                }

                                //战斗结束 判断是否需要加接收后勤任务到最前
                                //foreach (var item in im.gameData.User_operationInfo)
                                //{
                                //    if (item.Value.NeedToRecieve)
                                //    {
                                //        im.gametasklist.Insert(0, BaseData.TaskList.ReceiveLogistics);
                                //        item.Value.NeedToRecieve = false;
                                //    }
                                //}


                                im.mouse.BindWindowS(dmae, 0);
                                break;
                            }

                        case "4":
                            {
                                if (im.gameData.GetOperationTime_60s())
                                {
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                                        {
                                            //im.gametasklist.Insert(0, BaseData.TaskList.WaitForLogistics);//等加接收一起完成
                                            //im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            //im.gameData.User_operationInfo[i].Added = true;

                                            LogistandAutolist temp = new LogistandAutolist();
                                            temp.key = i;
                                            temp.type = 0;
                                            CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            CommonHelp.gametasklist.Add(BaseData.TaskList.WaitForLogistics);
                                            //返回时间
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }

                                    }
                                }

                                else
                                {
                                    im.time.StartLogisticsTask2(dmae, im.mouse);
                                    im.taskList.taskremove();
                                }
                                //战斗结束 判断是否需要加接收后勤任务到最前
                                //foreach (var item in im.gameData.User_operationInfo)
                                //{
                                //    if (item.Value.NeedToRecieve)
                                //    {
                                //        im.gametasklist.Insert(0, BaseData.TaskList.ReceiveLogistics);
                                //        item.Value.NeedToRecieve = false;
                                //    }
                                //}
                                im.mouse.BindWindowS(dmae, 0);

                                break;
                            }

                        case "5":
                            {
                                if (im.gameData.GetOperationTime_60s())
                                {
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                                        {
                                            //im.gametasklist.Insert(0, BaseData.TaskList.WaitForLogistics);//等加接收一起完成
                                            //im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            //im.gameData.User_operationInfo[i].Added = true;
                                            LogistandAutolist temp = new LogistandAutolist();
                                            temp.key = i;
                                            temp.type = 0;

                                            CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            CommonHelp.gametasklist.Add(BaseData.TaskList.WaitForLogistics);
                                            //返回时间
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }

                                    }
                                }
                                else
                                {
                                    im.time.StartLogisticsTask3(dmae, im.mouse);
                                    im.taskList.taskremove();
                                }
                                //战斗结束 判断是否需要加接收后勤任务到最前
                                //foreach (var item in im.gameData.User_operationInfo)
                                //{
                                //    if (item.Value.NeedToRecieve)
                                //    {
                                //        im.gametasklist.Insert(0, BaseData.TaskList.ReceiveLogistics);
                                //        item.Value.NeedToRecieve = false;
                                //    }
                                //}
                                im.mouse.BindWindowS(dmae, 0);

                                break;
                            }



                        case "6":
                            {

                                if (im.gameData.GetOperationTime_60s())
                                {
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                                        {
                                            //im.gametasklist.Insert(0, BaseData.TaskList.WaitForLogistics);//等加接收一起完成
                                            //im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            //im.gameData.User_operationInfo[i].Added = true;

                                            LogistandAutolist temp = new LogistandAutolist();
                                            temp.key = i;
                                            temp.type = 0;

                                            CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            CommonHelp.gametasklist.Add(BaseData.TaskList.WaitForLogistics);
                                            //返回时间
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }

                                    }
                                }
                                else
                                {
                                    im.time.StartLogisticsTask4(dmae, im.mouse);
                                    im.taskList.taskremove();
                                }
                                //战斗结束 判断是否需要加接收后勤任务到最前
                                //foreach (var item in im.gameData.User_operationInfo)
                                //{
                                //    if (item.Value.NeedToRecieve)
                                //    {
                                //        im.gametasklist.Insert(0, BaseData.TaskList.ReceiveLogistics);
                                //        item.Value.NeedToRecieve = false;
                                //    }
                                //}
                                im.mouse.BindWindowS(dmae, 0);
                                break;
                            }
                        case "7":
                            {
                                int temp = 0;

                                while (true)
                                {
                                    while (BaseData.SystemInfo.StayAtRecieveOperationPage)
                                    {
                                        //全部相同才确定
                                        BaseData.SystemInfo.AppState = "接收后勤任务";
                                        im.mouse.delayTime(1, 1);
                                        im.mouse.LeftClick(dmae, 484, 258, 681, 459);
                                        temp = 1;
                                    }
                                    if (temp == 1 && BaseData.SystemInfo.StayAtHomePage)
                                    {
                                        BaseData.SystemInfo.AppState = "回到主页";
                                        im.taskList.taskremove();
                                        break;
                                    }
                                    im.mouse.delayTime(1, 1);
                                }
                                break;




                            }
                        case "12"://0
                            {
                                if (im.gameData.GetOperationTime_60s()|| im.gameData.GetAutoBattleTime_60s())
                                {
                                    //后勤
                                    Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                                        {
                                            LogistandAutolist temp = new LogistandAutolist();
                                            temp.key = i;
                                            temp.type = 0;
                                            temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                                            TimeDic.Add(i, temp);

                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            CommonHelp.gametasklist.Insert(0, BaseData.TaskList.WaitForLogistics);//等加接收一起完成
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }
                                    }
                                    //自律

                                    if (im.gameData.GetAutoBattleTime_60s())
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.type = 1;
                                        temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                                        TimeDic.Add(TimeDic.Count, temp);
                                    }
                                    
                                    var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                                    foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.key = kvp.Key;
                                        temp.type = 0;
                                        CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                                    }

                                }
                                else
                                {
                                    im.gameData.User_battleInfo[0].reSetBattleInfo();
                                    UserBattleInfo tempUserBattleInfo = new UserBattleInfo();
                                    tempUserBattleInfo = im.gameData.User_battleInfo[0];

                                    im.time.ChoseThebattle(dmae, im.mouse, ref tempUserBattleInfo);

                                    im.gameData.User_battleInfo[0] = tempUserBattleInfo;

                                    im.taskList.taskremove();

                                    im.gameData.User_battleInfo[0].EndAtBattle(dmae);
                                }



                                break;
                            }

                        case "13":
                            {

                                if (im.gameData.GetOperationTime_60s() || im.gameData.GetAutoBattleTime_60s())
                                {
                                    //后勤
                                    Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                                        {
                                            LogistandAutolist temp = new LogistandAutolist();
                                            temp.key = i;
                                            temp.type = 0;
                                            temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                                            TimeDic.Add(i, temp);

                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            CommonHelp.gametasklist.Insert(0, BaseData.TaskList.WaitForLogistics);//等加接收一起完成
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }
                                    }
                                    //自律

                                    if (im.gameData.GetAutoBattleTime_60s())
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.type = 1;
                                        temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                                        TimeDic.Add(TimeDic.Count, temp);
                                    }

                                    var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                                    foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.key = kvp.Key;
                                        temp.type = 0;
                                        CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                                    }

                                }
                                else
                                {

                                    im.gameData.User_battleInfo[1].reSetBattleInfo();
                                    UserBattleInfo tempUserBattleInfo = new UserBattleInfo();
                                    tempUserBattleInfo = im.gameData.User_battleInfo[1];

                                    im.time.ChoseThebattle(dmae, im.mouse, ref tempUserBattleInfo);
                                    im.gameData.User_battleInfo[1] = tempUserBattleInfo;

                                    im.taskList.taskremove();



                                    im.gameData.User_battleInfo[1].EndAtBattle(dmae);

                                }

                                //判断最大循环最大次数，若相等则停止
                                break;
                            }
                        case "14":
                            {
                                if (im.gameData.GetOperationTime_60s() || im.gameData.GetAutoBattleTime_60s())
                                {
                                    //后勤
                                    Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                                        {
                                            LogistandAutolist temp = new LogistandAutolist();
                                            temp.key = i;
                                            temp.type = 0;
                                            temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                                            TimeDic.Add(i, temp);

                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            CommonHelp.gametasklist.Insert(0, BaseData.TaskList.WaitForLogistics);//等加接收一起完成
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }
                                    }
                                    //自律

                                    if (im.gameData.GetAutoBattleTime_60s())
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.type = 1;
                                        temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                                        TimeDic.Add(TimeDic.Count, temp);
                                    }

                                    var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                                    foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.key = kvp.Key;
                                        temp.type = 0;
                                        CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                                    }

                                }
                                else
                                {

                                    im.gameData.User_battleInfo[2].reSetBattleInfo();
                                    UserBattleInfo tempUserBattleInfo = new UserBattleInfo();
                                    tempUserBattleInfo = im.gameData.User_battleInfo[2];

                                    im.time.ChoseThebattle(dmae, im.mouse, ref tempUserBattleInfo);
                                    im.gameData.User_battleInfo[2] = tempUserBattleInfo;

                                    im.taskList.taskremove();

                                    im.gameData.User_battleInfo[2].EndAtBattle(dmae);

                                }
                                break;
                            }
                        case "15":
                            {
                                if (im.gameData.GetOperationTime_60s() || im.gameData.GetAutoBattleTime_60s())
                                {
                                    //后勤
                                    Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                                        {
                                            LogistandAutolist temp = new LogistandAutolist();
                                            temp.key = i;
                                            temp.type = 0;
                                            temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                                            TimeDic.Add(i, temp);

                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            CommonHelp.gametasklist.Insert(0, BaseData.TaskList.WaitForLogistics);//等加接收一起完成
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }
                                    }
                                    //自律

                                    if (im.gameData.GetAutoBattleTime_60s())
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.type = 1;
                                        temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                                        TimeDic.Add(TimeDic.Count, temp);
                                    }

                                    var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                                    foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.key = kvp.Key;
                                        temp.type = 0;
                                        CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                                    }

                                }
                                else
                                {
                                    im.gameData.User_battleInfo[3].reSetBattleInfo();
                                    UserBattleInfo tempUserBattleInfo = new UserBattleInfo();
                                    tempUserBattleInfo = im.gameData.User_battleInfo[3];

                                    im.time.ChoseThebattle(dmae, im.mouse, ref tempUserBattleInfo);
                                    im.gameData.User_battleInfo[3] = tempUserBattleInfo;
                                    im.taskList.taskremove();


                                    im.gameData.User_battleInfo[3].EndAtBattle(dmae);

                                }

                                break;
                            }

                        case "16":
                            {
                                if (im.gameData.GetOperationTime_60s()/* || im.gameData.GetAutoBattleTime_60s()*/)
                                {
                                    //后勤
                                    Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                                        {
                                            LogistandAutolist temp = new LogistandAutolist();
                                            temp.key = i;
                                            temp.type = 0;
                                            temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                                            TimeDic.Add(i, temp);

                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            CommonHelp.gametasklist.Insert(0, BaseData.TaskList.WaitForLogistics);//等加接收一起完成
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }
                                    }
                                    //自律

                                    if (im.gameData.GetAutoBattleTime_60s())
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.type = 1;
                                        temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                                        TimeDic.Add(TimeDic.Count, temp);
                                    }

                                    var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                                    foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.key = kvp.Key;
                                        temp.type = 0;
                                        CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                                    }

                                }
                                else
                                {
                                    UserAutoBattleInfo temp = new UserAutoBattleInfo();

                                    im.gameData.User_AutobattleInfo[0].AutoBattleUse = true;
                                    temp = im.gameData.User_AutobattleInfo[0];
                                    im.gameData.User_AutobattleInfo[0].AutoBattleLastTime = im.time.AutoBattle(dmae, im.mouse, ref temp);
                                    im.gameData.User_AutobattleInfo[0].AutoBattleLoopTime++;
                                    im.taskList.taskremove();


                                }
                                im.mouse.BindWindowS(dmae, 0);
                                break;
                            }


                        case "17":
                            {
                                if (im.gameData.GetOperationTime_60s() || im.gameData.GetAutoBattleTime_60s())
                                {
                                    //后勤
                                    Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                                        {
                                            LogistandAutolist temp = new LogistandAutolist();
                                            temp.key = i;
                                            temp.type = 0;
                                            temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                                            TimeDic.Add(i, temp);

                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            CommonHelp.gametasklist.Insert(0, BaseData.TaskList.WaitForLogistics);//等加接收一起完成
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }
                                    }
                                    //自律

                                    if (im.gameData.GetAutoBattleTime_60s())
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.type = 1;
                                        temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                                        TimeDic.Add(TimeDic.Count, temp);
                                    }

                                    var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                                    foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.key = kvp.Key;
                                        temp.type = 0;
                                        CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                                    }

                                }
                                else
                                {
                                    im.time.BuildEquipment(dmae, im.mouse);
                                    im.taskList.taskremove();

                                }
                                im.mouse.BindWindowS(dmae, 0);
                                break;

                            }
                        case "19":
                            {
                                im.mouse.BindWindowS(dmae, 1);
                                im.dormitory.VoteDormitoryLoop(dmae);
                                im.taskList.taskremove();
                                im.mouse.BindWindowS(dmae, 0);
                                break;
                            }

                        case "20"://装备强化
                            {
                                if (im.gameData.GetOperationTime_60s() || im.gameData.GetAutoBattleTime_60s())
                                {
                                    //后勤
                                    Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                                        {
                                            LogistandAutolist temp = new LogistandAutolist();
                                            temp.key = i;
                                            temp.type = 0;
                                            temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                                            TimeDic.Add(i, temp);

                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            CommonHelp.gametasklist.Insert(0, BaseData.TaskList.WaitForLogistics);//等加接收一起完成
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }
                                    }
                                    //自律

                                    if (im.gameData.GetAutoBattleTime_60s())
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.type = 1;
                                        temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                                        TimeDic.Add(TimeDic.Count, temp);
                                    }

                                    var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                                    foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.key = kvp.Key;
                                        temp.type = 0;
                                        CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                                    }

                                }
                                else
                                {
                                    //代码
                                    im.equipment.EquipmentUpdate(dmae,im.gameData.User_battleInfo[CommonHelp.BattleEquipmentOrGunNumber-1].EquipmentType, im.gameData.User_battleInfo[CommonHelp.BattleEquipmentOrGunNumber-1].EquipmentUpdatePostion, im.gameData.User_battleInfo[CommonHelp.BattleEquipmentOrGunNumber-1].EquipmentUpdateCount);
                                    im.taskList.taskremove();

                                }


                                im.mouse.BindWindowS(dmae, 0);



                                break;
                            }


                        case "22"://读取和保存好友宿舍的名单
                            {
                                im.mouse.BindWindowS(dmae, 1);
                                im.dormitory.ReadAndSaveFriendsDormitoryList(dmae);
                                im.taskList.taskremove();



                                im.mouse.BindWindowS(dmae, 0);
                                break;
                            }
                        case "23"://读取和保存好友宿舍的名单
                            {
                                im.mouse.BindWindowS(dmae, 1);

                                im.dormitory.GetFriendBattery(dmae,im.Form1.checkBox2.Checked,im.Form1.checkBox3.Checked);
                                im.taskList.taskremove();

                                im.mouse.BindWindowS(dmae, 0);
                                break;
                            }


                        case "24"://更换编队1
                            {
                                if (im.gameData.GetOperationTime_60s() || im.gameData.GetAutoBattleTime_60s())
                                {
                                    //后勤
                                    Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                                        {
                                            LogistandAutolist temp = new LogistandAutolist();
                                            temp.key = i;
                                            temp.type = 0;
                                            temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                                            TimeDic.Add(i, temp);

                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            CommonHelp.gametasklist.Insert(0, BaseData.TaskList.WaitForLogistics);//等加接收一起完成
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }
                                    }
                                    //自律

                                    if (im.gameData.GetAutoBattleTime_60s())
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.type = 1;
                                        temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                                        TimeDic.Add(TimeDic.Count, temp);
                                    }

                                    var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                                    foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.key = kvp.Key;
                                        temp.type = 0;
                                        CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                                    }

                                }
                                else
                                {
                                    //根据当前battle的KEY传过去

                                    UserBattleInfo tempUserBattleInfo = new UserBattleInfo();
                                    tempUserBattleInfo = im.gameData.User_battleInfo[CommonHelp.BattleFixNumber-1];
                                    switch (CommonHelp.BattleFixNumber)
                                    {
                                        case 1: { im.formation.TeamFormationChange1(dmae,im.mouse,ref tempUserBattleInfo); break; }
                                        case 2: { im.formation.TeamFormationChange1(dmae, im.mouse, ref tempUserBattleInfo); break; }
                                        case 3: { im.formation.TeamFormationChange1(dmae, im.mouse, ref tempUserBattleInfo); break; }
                                        case 4: { im.formation.TeamFormationChange1(dmae, im.mouse, ref tempUserBattleInfo); break; }

                                        default:
                                            break;
                                    }




                                    im.taskList.taskremove();


                                }



                                break;
                            }

                        case "25"://单独补给
                            {
                                if (im.gameData.GetOperationTime_60s() || im.gameData.GetAutoBattleTime_60s())
                                {
                                    //后勤
                                    Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                                        {
                                            LogistandAutolist temp = new LogistandAutolist();
                                            temp.key = i;
                                            temp.type = 0;
                                            temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                                            TimeDic.Add(i, temp);

                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            CommonHelp.gametasklist.Insert(0, BaseData.TaskList.WaitForLogistics);//等加接收一起完成
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }
                                    }
                                    //自律

                                    if (im.gameData.GetAutoBattleTime_60s())
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.type = 1;
                                        temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                                        TimeDic.Add(TimeDic.Count, temp);
                                    }

                                    var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                                    foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.key = kvp.Key;
                                        temp.type = 0;
                                        CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                                    }

                                }
                                else
                                {
                                    //根据当前battle的KEY传过去
                                    im.gameData.User_battleInfo[CommonHelp.BattleFixNumber - 1].NeetToDismantleGunOrEquipment = false;
                                    UserBattleInfo tempUserBattleInfo = new UserBattleInfo();
                                    tempUserBattleInfo = im.gameData.User_battleInfo[CommonHelp.BattleFixNumber - 1];
                                    switch (CommonHelp.BattleFixNumber)
                                    {
                                        case 1: { im.formation.TeamFormationFighterSupport(dmae, im.mouse, ref tempUserBattleInfo); break; }
                                        case 2: { im.formation.TeamFormationFighterSupport(dmae, im.mouse, ref tempUserBattleInfo); break; }
                                        case 3: { im.formation.TeamFormationFighterSupport(dmae, im.mouse, ref tempUserBattleInfo); break; }
                                        case 4: { im.formation.TeamFormationFighterSupport(dmae, im.mouse, ref tempUserBattleInfo); break; }

                                        default:
                                            break;
                                    }
                                    im.gameData.User_battleInfo[CommonHelp.BattleFixNumber - 1] = tempUserBattleInfo;



                                    im.taskList.taskremove();

                                    if(im.gameData.User_battleInfo[CommonHelp.BattleFixNumber - 1].NeetToDismantleGunOrEquipment)
                                    {
                                        CommonHelp.gametasklist.Insert(1, BaseData.TaskList.BattleSupport_plus);
                                    }


                                }



                                break;
                            }


                        case "26"://更换编队2
                            {
                                if (im.gameData.GetOperationTime_60s() || im.gameData.GetAutoBattleTime_60s())
                                {
                                    //后勤
                                    Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                                        {
                                            LogistandAutolist temp = new LogistandAutolist();
                                            temp.key = i;
                                            temp.type = 0;
                                            temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                                            TimeDic.Add(i, temp);

                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            CommonHelp.gametasklist.Insert(0, BaseData.TaskList.WaitForLogistics);//等加接收一起完成
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }
                                    }
                                    //自律

                                    if (im.gameData.GetAutoBattleTime_60s())
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.type = 1;
                                        temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                                        TimeDic.Add(TimeDic.Count, temp);
                                    }

                                    var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                                    foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.key = kvp.Key;
                                        temp.type = 0;
                                        CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                                    }

                                }
                                else
                                {
                                    //根据当前battle的KEY传过去

                                    UserBattleInfo tempUserBattleInfo = new UserBattleInfo();
                                    tempUserBattleInfo = im.gameData.User_battleInfo[CommonHelp.BattleFixNumber - 1];
                                    switch (CommonHelp.BattleFixNumber)
                                    {
                                        case 1: { im.formation.TeamFormationChange2(dmae, im.mouse, ref tempUserBattleInfo); break; }
                                        case 2: { im.formation.TeamFormationChange2(dmae, im.mouse, ref tempUserBattleInfo); break; }
                                        case 3: { im.formation.TeamFormationChange2(dmae, im.mouse, ref tempUserBattleInfo); break; }
                                        case 4: { im.formation.TeamFormationChange2(dmae, im.mouse, ref tempUserBattleInfo); break; }

                                        default:
                                            break;
                                    }




                                    im.taskList.taskremove();


                                }



                                break;
                            }



                        case "94"://回到游戏
                            {
                                break;
                            }
                        //case "95"://1-2换枪
                        //    {

                        //        //if ((variables.RT1 > 0 && variables.RT1 < 10) || (variables.RT2 > 0 && variables.RT2 < 10) || (variables.RT3 > 0 && variables.RT3 < 10) || (variables.RT4 > 0 && variables.RT4 < 10))
                        //        //{
                        //        //    taskadd(WaitForLogistics);
                        //        //    im.taskList.taskremove();
                        //        //    taskadd(ChangeGun);//1-2换枪
                        //        //}
                        //        //else
                        //        //{

                        //        //    //1-2换枪代码
                        //        //    switch (variables.ChangeGunBattleTask)
                        //        //    {
                        //        //        case 1: { im.time.ChangeGun(dmae, im.mouse, Battletask1.TaskMianTeam, 1, 2, 3, 4, 5); break; }
                        //        //        case 2: { im.time.ChangeGun(dmae, im.mouse, Battletask2.TaskMianTeam, 1, 2, 3, 4, 5); break; }
                        //        //        case 3: { im.time.ChangeGun(dmae, im.mouse, Battletask3.TaskMianTeam, 1, 2, 3, 4, 5); break; }
                        //        //        case 4: { im.time.ChangeGun(dmae, im.mouse, Battletask4.TaskMianTeam, 1, 2, 3, 4, 5); break; }

                        //        //        default:
                        //        //            break;
                        //        //    }

                        //        //    im.taskList.taskremove();

                        //        //}
                        //        //im.mouse.BindWindowS(dmae, 0);
                        //        //break;
                        //    }

                        case "96"://拆除
                            {
                                if (im.gameData.GetOperationTime_60s() || im.gameData.GetAutoBattleTime_60s())
                                {
                                    //后勤
                                    Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                                        {
                                            LogistandAutolist temp = new LogistandAutolist();
                                            temp.key = i;
                                            temp.type = 0;
                                            temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                                            TimeDic.Add(i, temp);

                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            CommonHelp.gametasklist.Insert(0, BaseData.TaskList.WaitForLogistics);//等加接收一起完成
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }
                                    }
                                    //自律

                                    if (im.gameData.GetAutoBattleTime_60s())
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.type = 1;
                                        temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                                        TimeDic.Add(TimeDic.Count, temp);
                                    }

                                    var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                                    foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.key = kvp.Key;
                                        temp.type = 0;
                                        CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                                    }

                                }
                                else
                                {

                                    //拆枪代码
                                    switch (CommonHelp.BattleEquipmentOrGunNumber)
                                    {
                                        case 1: { im.time.DismantlementGun(dmae, im.mouse, im.gameData.User_battleInfo[0].DismantlementGunCount);  break; }
                                        case 2: { im.time.DismantlementGun(dmae, im.mouse, im.gameData.User_battleInfo[1].DismantlementGunCount); break; }
                                        case 3: { im.time.DismantlementGun(dmae, im.mouse, im.gameData.User_battleInfo[2].DismantlementGunCount); break; }
                                        case 4: { im.time.DismantlementGun(dmae, im.mouse, im.gameData.User_battleInfo[3].DismantlementGunCount); break; }

                                        default:
                                            break;
                                    }
                                    im.taskList.taskremove();

                                }


                                im.mouse.BindWindowS(dmae, 0);



                                break;
                            }

                        case "97":
                            {
                                if (im.gameData.GetOperationTime_60s() || im.gameData.GetAutoBattleTime_60s())
                                {
                                    //后勤
                                    Dictionary<int, LogistandAutolist> TimeDic = new Dictionary<int, LogistandAutolist>();
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (im.gameData.User_operationInfo[i].OperationLastTime <= 60 && im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                                        {
                                            LogistandAutolist temp = new LogistandAutolist();
                                            temp.key = i;
                                            temp.type = 0;
                                            temp.Time = im.gameData.User_operationInfo[i].OperationLastTime;
                                            TimeDic.Add(i, temp);

                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            CommonHelp.gametasklist.Insert(0, BaseData.TaskList.WaitForLogistics);//等加接收一起完成
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }
                                    }
                                    //自律

                                    if (im.gameData.GetAutoBattleTime_60s())
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.type = 1;
                                        temp.Time = im.gameData.User_AutobattleInfo[0].AutoBattleLastTime;
                                        TimeDic.Add(TimeDic.Count, temp);
                                    }

                                    var dicSort = from objDic in TimeDic orderby objDic.Value.key descending select objDic;
                                    foreach (KeyValuePair<int, LogistandAutolist> kvp in dicSort)
                                    {
                                        LogistandAutolist temp = new LogistandAutolist();
                                        temp.key = kvp.Key;
                                        temp.type = 0;
                                        CommonHelp.User_LogistandAutoNumberNow.Add(temp);
                                    }

                                }
                                else
                                {
                                    switch (CommonHelp.BattleFixNumber)
                                    {
                                        case 1: { im.gameData.User_battleInfo[0].BattleFixTime = im.time.Fix(dmae, im.mouse, ref im.ShowerTime, im.gameData.User_battleInfo[0]); break; }
                                        case 2: { im.gameData.User_battleInfo[1].BattleFixTime = im.time.Fix(dmae, im.mouse, ref im.ShowerTime, im.gameData.User_battleInfo[1]); break; }
                                        case 3: { im.gameData.User_battleInfo[2].BattleFixTime = im.time.Fix(dmae, im.mouse, ref im.ShowerTime, im.gameData.User_battleInfo[2]); break; }
                                        case 4: { im.gameData.User_battleInfo[3].BattleFixTime = im.time.Fix(dmae, im.mouse, ref im.ShowerTime, im.gameData.User_battleInfo[3]); break; }

                                        default:
                                            break;
                                    }


                                    im.taskList.taskremove();

                                    //修复结束 判断是否需要加接收后勤任务到最前
                                    //foreach (var item in im.gameData.User_operationInfo)
                                    //{
                                    //    if (item.Value.ReceiveRightNow)
                                    //    {
                                    //        im.gametasklist.Insert(0, BaseData.TaskList.ReceiveLogistics);
                                    //        item.Value.ReceiveRightNow = false;
                                    //        item.Value.NeedToRecieve = false;
                                    //        item.Value.OperationNeedTowait = false;
                                    //    }
                                    //}
                                }
                                im.mouse.BindWindowS(dmae, 0);
                                break;
                            }


                        case "98":
                            {
                                switch (CommonHelp.User_LogistandAutoNumberNow[0].type)
                                {
                                    case 0:
                                        {
                                            while (true)
                                            {
                                                if (SystemInfo.StayAtRecieveOperationPage)
                                                {
                                                    SystemInfo.AppState = "接收后勤任务";
                                                    im.mouse.delayTime(1, 1);
                                                    Random ran = new Random();

                                                    if (WindowsFormsApplication1.BaseData.SystemInfo.LogisticFinishWaittingTime != 0)
                                                    {
                                                        im.mouse.delayTime(Convert.ToDouble(ran.Next(1, WindowsFormsApplication1.BaseData.SystemInfo.LogisticFinishWaittingTime * 10)) / 10 * 60, 1);//等待时间
                                                    }

                                                    im.mouse.LeftClick(dmae, 484, 258, 681, 459);
                                                }
                                                while (im.pagecheck.CheckLsystemAgain(dmae.dm))
                                                {

                                                    im.mouse.LeftClick(dmae, 677, 475, 808, 514);
                                                    im.mouse.delayTime(1, 1);
                                                    while (im.pagecheck.CheckLsystemAgain(dmae.dm) == false)
                                                    {
                                                        goto end;
                                                    }
                                                }
                                                if (SystemInfo.StayAtHomePage)
                                                {
                                                    SystemInfo.AppState = "主页";
                                                }
                                                im.mouse.delayTime(1, 1);
                                            }
                                            end: im.taskList.taskremove();
                                            try
                                            {
                                                im.gameData.User_operationInfo[CommonHelp.User_LogistandAutoNumberNow[0].key].Lfinish = false;
                                                CommonHelp.User_LogistandAutoNumberNow.RemoveAt(0);//出列
                                            }
                                            catch (Exception)
                                            {
                                            }
                                            break;
                                        }
                                    case 1:
                                        {
                                            while (true)
                                            {
                                                if (SystemInfo.AutoBattleFinishPage)
                                                {
                                                    SystemInfo.AppState = "自律任务完成";
                                                    im.mouse.delayTime(1, 1);
                                                    Random ran = new Random();

                                                    if (WindowsFormsApplication1.BaseData.SystemInfo.LogisticFinishWaittingTime != 0)
                                                    {
                                                        im.mouse.delayTime(Convert.ToDouble(ran.Next(1, WindowsFormsApplication1.BaseData.SystemInfo.LogisticFinishWaittingTime * 10)) / 10 * 60, 1);//等待时间
                                                    }

                                                    im.mouse.LeftClick(dmae, 484, 258, 681, 459);
                                                }
                                                while (true)
                                                {

                                                    while (im.pagecheck.CheckWhiteM(dmae.dm))
                                                    {
                                                        im.mouse.delayTime(1, 1);
                                                        continue;
                                                    }
                                                    if (im.pagecheck.CheckNewGunEquipmentPage(dmae.dm))
                                                    {
                                                        SystemInfo.AppState = "获取新人形";
                                                        im.mouse.LeftClick(dmae, 1107, 633, 1242, 691);
                                                    }
                                                    im.mouse.delayTime(1, 1);

                                                    if (SystemInfo.AutoBattleFinishPage)
                                                    {
                                                        while (SystemInfo.StayAtHomePage == false)
                                                        {
                                                            im.mouse.LeftClick(dmae, 1107, 633, 1242, 691);
                                                        }
                                                        goto end;
                                                    }


                                                }
                                            }
                                            end: im.taskList.taskremove();
                                            try
                                            {
                                                im.gameData.User_operationInfo[CommonHelp.User_LogistandAutoNumberNow[0].key].Lfinish = false;
                                                CommonHelp.User_LogistandAutoNumberNow.RemoveAt(0);//出列
                                            }
                                            catch (Exception)
                                            {
                                            }

                                            break;

                                        }
                                    default:
                                        break;
                                }
                                

                                break;
                            }
                        case "99"://接收自律
                            {
                                break;
                            }



                    }
                }


            }
        }

        public void ThreadT()//处理线程;
        {
            DmAe dmae = new DmAe();
            if (dmae.BindWindow() == 0)
            {
                MessageBox.Show("绑定窗口错误");
            }
            dmae.SetDict();//设置系统路径和字典
            while (true)
            {
                Thread.Sleep(1000);
                switch (BaseData.SystemInfo.ThreadTCase)
                {
                    case 0: { break; }
                    //重启处理任务的线程;
                    case 1:
                        {

                            im.gameData.User_battleInfo[0].Used = false;
                            im.gameData.User_battleInfo[1].Used = false;
                            im.gameData.User_battleInfo[2].Used = false;
                            im.gameData.User_battleInfo[3].Used = false;

                            im.CompleteMisson.Abort();
                            CommonHelp.gametasklist.Clear();

                            im.CompleteMisson = new Thread(CompleteMisson);
                            im.CompleteMisson.IsBackground = true;
                            im.CompleteMisson.Start();

                            BaseData.SystemInfo.ThreadTCase = 0;
                            im.mouse.BindWindowS(dmae, 0);//0不锁死鼠标
                            break;
                        }
                    case 2:
                        {
                            im.CompleteMisson.Abort();
                            //im.taskList.taskremove();
                            im.CompleteMisson = new Thread(CompleteMisson);
                            im.CompleteMisson.IsBackground = true;
                            im.CompleteMisson.Start();
                            BaseData.SystemInfo.ThreadTCase = 0;
                            im.mouse.BindWindowS(dmae, 0);//0不锁死鼠标
                            break;
                        }

                    default:
                        break;
                }
            }



        }

        public void MonitorPic()
        {
            Object intX, intY;
            intX = intY = -1;

            DmAe dmae = new DmAe();
            if (dmae.BindWindow() == 0)
            {
                MessageBox.Show("绑定窗口错误");
            }

            string directPath = Application.StartupPath + "\\Debug";    //获得文件夹路径
            dmae.SetPath(directPath);
            dmae.LoadPic("A.bmp");

            while (true)
            {

                Thread.Sleep(WindowsFormsApplication1.BaseData.SystemInfo.SimulatorCheckTime * 10);


                //sw.Start();
                //if (dmae.FindPic(Settings.Default.SimulatorHomeCheckX1, Settings.Default.SimulatorHomeCheckY1, Settings.Default.SimulatorHomeCheckX2, Settings.Default.SimulatorHomeCheckY2, "A.bmp", "000000", 1, 0, out intX, out intY) == 0)//用户自定义检测范围
                //{
                //    //BaseData.SystemInfo.AppState = "检测到闪退";
                //    ////开始处理线程1
                //    //thread1.Abort();
                //    //im.taskList.taskremove();
                //    //im.taskList.taskremove();
                //    //im.taskList.taskremove();
                //    //im.taskList.taskremove();
                //    //im.taskList.taskremove();
                //    //im.taskList.taskremove();
                //    //im.taskList.taskremove();
                //    //im.taskList.taskremove();
                //    //im.taskList.taskremove();
                //    //im.taskList.taskremove();
                //    //BaseData.SystemInfo.AppState = "返回游戏";
                //    //im.mouse.BindWindowS(dmae, 0);
                //    //im.time.BackToGame(dmae, im.mouse);
                //    //im.mouse.BindWindowS(dmae, 0);
                //    //thread1 = new Thread(CompleteMisson);
                //    //thread1.IsBackground = true;
                //    //thread1.Start();
                //    //im.mouse.BindWindowS(dmae, 0);//0不锁死鼠标

                //}

                //监控页面
                if (im.pagecheck.CheckInternetTransfer(dmae.dm))
                {
                    BaseData.SystemInfo.PageCheck = "网络传输";
                    continue;
                }


                if (dmae.CmpColor(74, 333, "ffffff", 1) == 0 && dmae.CmpColor(117, 376, "ffffff", 1) == 0 && dmae.CmpColor(255, 334, "ffffff", 1) == 0 && dmae.CmpColor(295, 374, "ffffff", 1) == 0 && dmae.CmpColor(257, 392, "ffffff", 1) == 0 && dmae.CmpColor(92, 408, "ffffff", 1) == 0)
                {
                    BaseData.SystemInfo.StayAtRecieveOperationPage = true;
                    BaseData.SystemInfo.PageCheck = "后勤结束";
                    continue;
                }
                else
                {
                    BaseData.SystemInfo.StayAtRecieveOperationPage = false;
                }
                //监控后勤任务

                //监控主页

                if (im.pagecheck.CheckAutoBattleFinishPage(dmae.dm))
                {
                    BaseData.SystemInfo.AutoBattleFinishPage = true;
                    BaseData.SystemInfo.PageCheck = "自律结束";
                    continue;
                }
                else
                {
                    BaseData.SystemInfo.AutoBattleFinishPage = false;
                    BaseData.SystemInfo.PageCheck = "";
                }
                if (im.pagecheck.CheckHomePage(dmae.dm) == 0)
                {

                    BaseData.SystemInfo.StayAtHomePage = true;
                    BaseData.SystemInfo.PageCheck = "主页";
                    continue;
                }
                else
                {
                    BaseData.SystemInfo.StayAtHomePage = false;
                    BaseData.SystemInfo.PageCheck = "";
                }

                if (im.pagecheck.CheckBattleResult(dmae.dm))
                {
                    SystemInfo.PageCheck = "战斗结算";
                    continue;
                }
                if (im.pagecheck.CheckNewGunEquipmentPage(dmae.dm))
                {
                    SystemInfo.PageCheck = "获取新人形";
                    continue;
                }



            }


        }























    }
}
