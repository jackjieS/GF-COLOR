using System;
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
        private InstanceManager im;
        public Action LAction;
        public BackgroundThread(InstanceManager im)
        {

            this.im = im;
        }


        public void CountDown()//倒计时
        {
            DateTime Now = DateTime.Now;
            int c;
            Thread.Sleep(200);
            int BattleStartCount;

            while (true)
            {
                c = Convert.ToInt32((DateTime.Now - Now).TotalSeconds);
                Now = DateTime.Now;

                im.gameData.User_operationInfo[0].OperationLastTimeCD(c);
                im.gameData.User_operationInfo[1].OperationLastTimeCD(c);
                im.gameData.User_operationInfo[2].OperationLastTimeCD(c);
                im.gameData.User_operationInfo[3].OperationLastTimeCD(c);

                im.gameData.User_BuildingEquipmentInfo[0].BuildingLastTimeCD(c);
                im.gameData.User_BuildingEquipmentInfo[1].BuildingLastTimeCD(c);
                im.gameData.User_BuildingEquipmentInfo[2].BuildingLastTimeCD(c);
                for (int i = 0; i < 4; i++)
                {
                    if (im.gameData.User_operationInfo[i].OperationLastTime == 0)
                    {
                        //true 有货，空为 false。
                        //加入开始后勤任务
                        //如果当前队列任务非空闲则加入开始后勤任务到最后(因为当前任务结束退到主页会检测，添加接收后期任务，故当前不需要添加接收后勤任务)
                        //如果当前队列任务是空闲则加入接收和开始后勤任务

                        if (im.gametasklist.Any() && (im.gametasklist[0].TaskNumber != 98))
                        {
                            im.gameData.User_operationInfo[i].ReceiveRightNow = true;
                        }
                        else
                        {
                            //需要把当前i传过去 靠队列
                            im.User_OperationNumberNow.Add(i);
                            im.gameData.User_operationInfo[i].Lfinish = true;
                            im.gametasklist.Add(BaseData.TaskList.WaitForLogistics);
                            //返回时间
                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                            im.gameData.User_operationInfo[i].Added = true;
                        }

                    }
                }
                for(int i = 0; i < 3; i++)
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
            dmae.BindWindow();
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

                if (im.gametasklist.Any())
                {
                    switch (im.gametasklist.ElementAt(0).TaskNumber.ToString())
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
                                            im.User_OperationNumberNow.Add(i);
                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            im.gametasklist.Add(BaseData.TaskList.WaitForLogistics);
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
                                            im.User_OperationNumberNow.Add(i);
                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            im.gametasklist.Add(BaseData.TaskList.WaitForLogistics);
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
                                            im.User_OperationNumberNow.Add(i);
                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            im.gametasklist.Add(BaseData.TaskList.WaitForLogistics);
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
                                            im.User_OperationNumberNow.Add(i);
                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            im.gametasklist.Add(BaseData.TaskList.WaitForLogistics);
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





                                //while (BaseData.SystemInfo.StayAtRecieveOperationPage)
                                //{
                                //    BaseData.SystemInfo.AppState = "等待后勤任务";
                                //    //有一个不符合也要等，当全部相同时才退出循环
                                //    im.mouse.delayTime(1, 1);
                                //    count++;
                                //    if (count == 10) goto a;
                                //}
                                //while (BaseData.SystemInfo.StayAtRecieveOperationPage)
                                //{
                                //    //全部相同才确定
                                //    BaseData.SystemInfo.AppState = "接收后勤任务";
                                //    im.mouse.delayTime(1, 1);
                                //    im.mouse.LeftClick(dmae, 484, 258, 681, 459);
                                //}
                                //a: while (BaseData.SystemInfo.StayAtHomePage)
                                //{
                                //    im.mouse.delayTime(1, 1);
                                //}
                                //BaseData.SystemInfo.AppState = "回到主页";

                                //im.taskList.taskremove();
                                //break;
                            }
                        case "12"://0
                            {
                                if (im.gameData.GetOperationTime_60s() )
                                {
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (im.gameData.User_operationInfo[i].OperationNeedTowait&& (im.gameData.User_operationInfo[i].Added==false))
                                        {
                                            im.User_OperationNumberNow.Add(i);
                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            im.gametasklist.Add(BaseData.TaskList.WaitForLogistics);
                                            //返回时间
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }
                                    }
                                }
                                else
                                {
                                    //im.taskList.taskremove();
                                    im.gameData.User_battleInfo[0].BattleStart = false;
                                    im.gameData.User_battleInfo[0].Team_Serror = false;
                                    UserBattleInfo tempUserBattleInfo = new UserBattleInfo();
                                    tempUserBattleInfo = im.gameData.User_battleInfo[0];
                                    im.time.ChoseThebattle(dmae, im.mouse, ref tempUserBattleInfo);
                                    im.gameData.User_battleInfo[0] = tempUserBattleInfo;
                                    im.taskList.taskremove();


                                    if (im.gameData.User_battleInfo[0].Team_Serror)
                                    {
                                        im.gameData.User_battleInfo[0].BattleFixTime = im.gameData.User_battleInfo[0].Team_SerrorTime;
                                        goto temp;
                                    }

                                    if (im.gameData.User_battleInfo[0].NeedToFix)
                                    {
                                        im.userData.BattleFixNumber = 1;
                                        im.gametasklist.Insert(0, BaseData.TaskList.Fix);
                                    }
                                    else //-----循环间隔
                                    {
                                        Random ran = new Random();
                                        int temp0 = ran.Next(0, im.gameData.User_battleInfo[0].RoundInterval);
                                        im.gameData.User_battleInfo[0].BattleFixTime = temp0 + 1;
                                        ran = null;
                                    }

                                    temp:
                                    im.gameData.User_battleInfo[0].BattleLoopTime++;
                                }


                                if (im.gameData.User_battleInfo[0].Used == false) { im.mouse.BindWindowS(dmae, 0); }
                                if (im.gameData.User_battleInfo[0].BattleLoopUnLockWindows == false) { im.mouse.BindWindowS(dmae, 0); }
                                break;
                            }

                        case "13":
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
                                            im.User_OperationNumberNow.Add(i);
                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            im.gametasklist.Add(BaseData.TaskList.WaitForLogistics);
                                            //返回时间
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }

                                    }

                                }
                                else
                                {

                                    im.gameData.User_battleInfo[1].BattleStart = false;
                                    im.gameData.User_battleInfo[1].Team_Serror = false;
                                    UserBattleInfo tempUserBattleInfo = new UserBattleInfo();
                                    tempUserBattleInfo = im.gameData.User_battleInfo[1];
                                    im.time.ChoseThebattle(dmae, im.mouse, ref tempUserBattleInfo);
                                    im.gameData.User_battleInfo[1] = tempUserBattleInfo;
                                    im.taskList.taskremove();

                                    if (im.gameData.User_battleInfo[1].Team_Serror)
                                    {
                                        im.gameData.User_battleInfo[1].BattleFixTime = im.gameData.User_battleInfo[1].Team_SerrorTime;
                                        goto temp;
                                    }

                                    if (im.gameData.User_battleInfo[1].NeedToFix == true)
                                    {
                                        im.userData.BattleFixNumber = 2;
                                        im.gametasklist.Insert(0, BaseData.TaskList.Fix);
                                    }
                                    else//-----循环间隔
                                    {
                                        Random ran = new Random();
                                        int temp0 = ran.Next(0, im.gameData.User_battleInfo[1].RoundInterval);
                                        im.gameData.User_battleInfo[1].BattleFixTime = temp0 + 1;
                                        ran = null;
                                    }

                                    //战斗结束 判断是否需要加接收后勤任务到最前
                                    temp:



                                    im.gameData.User_battleInfo[1].BattleLoopTime++;


                                }
                                if (im.gameData.User_battleInfo[1].Used == false) { im.mouse.BindWindowS(dmae, 0); }
                                if (im.gameData.User_battleInfo[1].BattleLoopUnLockWindows == false) { im.mouse.BindWindowS(dmae, 0); }
                                break;
                            }
                        case "14":
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
                                            im.User_OperationNumberNow.Add(i);
                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            im.gametasklist.Add(BaseData.TaskList.WaitForLogistics);
                                            //返回时间
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }

                                    }
                                }
                                else
                                {

                                    im.gameData.User_battleInfo[2].BattleStart = false;
                                    im.gameData.User_battleInfo[2].Team_Serror = false;
                                    UserBattleInfo tempUserBattleInfo = new UserBattleInfo();
                                    tempUserBattleInfo = im.gameData.User_battleInfo[2];
                                    im.time.ChoseThebattle(dmae, im.mouse, ref tempUserBattleInfo);
                                    im.gameData.User_battleInfo[2] = tempUserBattleInfo;
                                    im.gameData.User_battleInfo[2].BattleLoopTime++;
                                    im.taskList.taskremove();


                                    if (im.gameData.User_battleInfo[2].Team_Serror)
                                    {
                                        im.gameData.User_battleInfo[2].BattleFixTime = im.gameData.User_battleInfo[2].Team_SerrorTime;
                                        goto temp;
                                    }
                                    if (im.gameData.User_battleInfo[2].NeedToFix == true)
                                    {
                                        im.userData.BattleFixNumber = 3;
                                        im.gametasklist.Insert(0, BaseData.TaskList.Fix);
                                        //taskadd(Fix);
                                    }
                                    else//-----循环间隔
                                    {
                                        Random ran = new Random();
                                        int temp0 = ran.Next(0, im.gameData.User_battleInfo[2].RoundInterval);
                                        im.gameData.User_battleInfo[2].BattleFixTime = temp0 + 1;
                                        ran = null;
                                    }
                                    temp:
                                    im.gameData.User_battleInfo[2].BattleLoopTime++;
                                }
                                if (im.gameData.User_battleInfo[2].Used == false) { im.mouse.BindWindowS(dmae, 0); }
                                if (im.gameData.User_battleInfo[2].BattleLoopUnLockWindows == false) { im.mouse.BindWindowS(dmae, 0); }
                                break;
                            }
                        case "15":
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
                                            im.User_OperationNumberNow.Add(i);
                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            im.gametasklist.Add(BaseData.TaskList.WaitForLogistics);
                                            //返回时间
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }

                                    }
                                }
                                else
                                {
                                    im.gameData.User_battleInfo[3].BattleStart = false;
                                    im.gameData.User_battleInfo[3].Team_Serror = false;
                                    UserBattleInfo tempUserBattleInfo = new UserBattleInfo();
                                    tempUserBattleInfo = im.gameData.User_battleInfo[3];
                                    im.time.ChoseThebattle(dmae, im.mouse, ref tempUserBattleInfo);
                                    im.gameData.User_battleInfo[3] = tempUserBattleInfo;
                                    im.gameData.User_battleInfo[3].BattleLoopTime++;
                                    im.taskList.taskremove();


                                    if (im.gameData.User_battleInfo[3].Team_Serror)
                                    {
                                        im.gameData.User_battleInfo[3].BattleFixTime = im.gameData.User_battleInfo[3].Team_SerrorTime;
                                        goto temp;
                                    }

                                    if (im.gameData.User_battleInfo[3].NeedToFix == true)
                                    {
                                        im.userData.BattleFixNumber = 4;
                                        im.gametasklist.Insert(0, BaseData.TaskList.Fix);
                                        //taskadd(Fix);
                                    }
                                    else if (im.gameData.User_battleInfo[3].Team_Serror || im.gameData.User_battleInfo[3].NeedToFix == false)//-----循环间隔
                                    {
                                        Random ran = new Random();
                                        int temp0 = ran.Next(0, im.gameData.User_battleInfo[3].RoundInterval);
                                        im.gameData.User_battleInfo[3].BattleFixTime = temp0 + 1;
                                        ran = null;
                                    }
                                    //战斗结束 判断是否需要加接收后勤任务到最前
                                    temp:
                                    im.gameData.User_battleInfo[3].BattleLoopTime++;

                                }
                                if (im.gameData.User_battleInfo[3].Used == false) { im.mouse.BindWindowS(dmae, 0); }
                                if (im.gameData.User_battleInfo[3].BattleLoopUnLockWindows == false) { im.mouse.BindWindowS(dmae, 0); }
                                break;
                            }

                        case "16":
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
                                            im.User_OperationNumberNow.Add(i);
                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            im.gametasklist.Add(BaseData.TaskList.WaitForLogistics);
                                            //返回时间
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }

                                    }
                                }
                                else
                                {


                                    im.gameData.User_AutobattleInfo[0].AutoBattleUse = false;
                                    //im.gameData.User_AutobattleInfo[0].AutoBattleLastTime = im.time.AutoBattle(dmae, im.mouse, Settings.Default.AutoMap, Settings.Default.AutoTeam1, Settings.Default.AutoTeam2, Settings.Default.AutoTeam3, Settings.Default.AutoTeam4,ref im.gameData.User_battleInfo[]);
                                    im.gameData.User_AutobattleInfo[0].AutoBattleLoopTime++;
                                    im.taskList.taskremove();
                                    ////战斗结束 判断是否需要加接收后勤任务到最前
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


                        case "17":
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
                                            im.User_OperationNumberNow.Add(i);
                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            im.gametasklist.Add(BaseData.TaskList.WaitForLogistics);
                                            //返回时间
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }

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
                                if (im.gameData.GetOperationTime_60s())
                                {
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (im.gameData.User_operationInfo[i].OperationNeedTowait && (im.gameData.User_operationInfo[i].Added == false))
                                        {
                                            //im.gametasklist.Insert(0, BaseData.TaskList.WaitForLogistics);//等加接收一起完成
                                            //im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            //im.gameData.User_operationInfo[i].Added = true;
                                            im.User_OperationNumberNow.Add(i);
                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            im.gametasklist.Add(BaseData.TaskList.WaitForLogistics);
                                            //返回时间
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }

                                    }
                                }
                                else
                                {

                                    //拆枪代码
                                    im.time.DismantlementGun(dmae, im.mouse, im.userData.DismantlementGunCount);
                                    im.taskList.taskremove();

                                }

                                //战斗结束 判断是否需要加接收后勤任务到最前
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


                                im.mouse.BindWindowS(dmae, 0);



                                break;
                            }

                        case "97":
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
                                            im.User_OperationNumberNow.Add(i);
                                            im.gameData.User_operationInfo[i].Lfinish = true;
                                            im.gametasklist.Insert(0, BaseData.TaskList.WaitForLogistics);//等加接收一起完成
                                            //返回时间
                                            im.gameData.User_operationInfo[i].OperationLastTime = im.time.StartLogisticsTask(im.mouse, im.gameData.User_operationInfo[i].OperationTeamName, im.gameData.User_operationInfo[i].OperationName, 1);
                                            im.gameData.User_operationInfo[i].Added = true;
                                        }

                                    }
                                }
                                else
                                {
                                    switch (im.userData.BattleFixNumber)
                                    {
                                        case 1: { im.gameData.User_battleInfo[0].BattleFixTime = im.time.Fix(dmae, im.mouse, ref im.ShowerTime, im.gameData.User_battleInfo[0]); break; }
                                        case 2: { im.gameData.User_battleInfo[1].BattleFixTime = im.time.Fix(dmae, im.mouse, ref im.ShowerTime, im.gameData.User_battleInfo[0]); break; }
                                        case 3: { im.gameData.User_battleInfo[2].BattleFixTime = im.time.Fix(dmae, im.mouse, ref im.ShowerTime, im.gameData.User_battleInfo[0]); break; }
                                        case 4: { im.gameData.User_battleInfo[3].BattleFixTime = im.time.Fix(dmae, im.mouse, ref im.ShowerTime, im.gameData.User_battleInfo[0]); break; }

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
                                while (true)
                                {
                                    if (SystemInfo.StayAtRecieveOperationPage)
                                    {
                                        SystemInfo.AppState = "接收后勤任务";
                                        im.mouse.delayTime(1, 1);
                                        im.mouse.LeftClick(dmae, 484, 258, 681, 459);
                                    }
                                    while (im.mouse.CheckLsystemAgain(dmae))
                                    {
                                        im.mouse.LeftClick(dmae, 677, 475, 808, 514);
                                        im.mouse.delayTime(1, 1);
                                        while (im.mouse.CheckLsystemAgain(dmae) == false)
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
                                    im.gameData.User_operationInfo[im.User_OperationNumberNow[0]].Lfinish = false;
                                    im.User_OperationNumberNow.RemoveAt(0);//出列
                                }
                                catch (Exception)
                                {
                                }

                                break;
                            }
                            //}
                            //break;







                    }
                }


            }
        }

        public void ThreadT()//处理线程;
        {
            DmAe dmae = new DmAe();
            dmae.BindWindow();
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
                            im.userData.BattleFixNumber = 0;
                            im.gameData.User_battleInfo[0].Used = false;
                            im.gameData.User_battleInfo[1].Used = false;
                            im.gameData.User_battleInfo[2].Used = false;
                            im.gameData.User_battleInfo[3].Used = false;

                            im.CompleteMisson.Abort();
                            im.gametasklist.Clear();

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
            int dm_ret = dmae.BindWindow();

            string directPath = Application.StartupPath + "\\Debug";    //获得文件夹路径
            dmae.SetPath(directPath);
            dmae.LoadPic("A.bmp");

            while (true)
            {
                //sw.Start();
                if (dmae.FindPic(Settings.Default.SimulatorHomeCheckX1, Settings.Default.SimulatorHomeCheckY1, Settings.Default.SimulatorHomeCheckX2, Settings.Default.SimulatorHomeCheckY2, "A.bmp", "000000", 1, 0, out intX, out intY) == 0)//用户自定义检测范围
                {
                    //BaseData.SystemInfo.AppState = "检测到闪退";
                    ////开始处理线程1
                    //thread1.Abort();
                    //im.taskList.taskremove();
                    //im.taskList.taskremove();
                    //im.taskList.taskremove();
                    //im.taskList.taskremove();
                    //im.taskList.taskremove();
                    //im.taskList.taskremove();
                    //im.taskList.taskremove();
                    //im.taskList.taskremove();
                    //im.taskList.taskremove();
                    //im.taskList.taskremove();
                    //BaseData.SystemInfo.AppState = "返回游戏";
                    //im.mouse.BindWindowS(dmae, 0);
                    //im.time.BackToGame(dmae, im.mouse);
                    //im.mouse.BindWindowS(dmae, 0);
                    //thread1 = new Thread(CompleteMisson);
                    //thread1.IsBackground = true;
                    //thread1.Start();
                    //im.mouse.BindWindowS(dmae, 0);//0不锁死鼠标

                }

                //监控页面

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
                if (im.mouse.CheckHomePage(dmae) == 0)
                {

                    BaseData.SystemInfo.StayAtHomePage = true;
                    BaseData.SystemInfo.PageCheck = "主页";
                }
                else
                {
                    BaseData.SystemInfo.StayAtHomePage = false;
                }

                if (im.mouse.CheckBattleResult(dmae))
                {
                    SystemInfo.PageCheck = "战斗结算";
                    continue;
                }
                if (im.mouse.CheckNewGunEquipmentPage(dmae))
                {
                    SystemInfo.PageCheck = "获取新人形";
                    continue;
                }



                Thread.Sleep(Settings.Default.SimulatorHomeCheckTime * 10);

            }


        }























    }
}
