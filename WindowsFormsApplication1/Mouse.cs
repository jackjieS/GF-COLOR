using System;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;
using WindowsFormsApplication1;
//using AELib;
using System.Collections.Generic;
using System.Linq;
using WindowsFormsApplication1.BaseData;

namespace testdm
{

    class Mouse
    {
        private InstanceManager im;

        public Mouse(InstanceManager im)
        {
            this.im = im;
        }

        public void delayTime(double secend,int k = 0)
        {
            if (k == 0)
            {
                double temp;
                if (WindowsFormsApplication1.BaseData.SystemInfo.RanControlinterval == true)
                {
                    Random ran = new Random();
                    int temp0 = ran.Next(0, 13);
                    decimal result = (decimal)temp0 / 10;
                     temp = secend * 1000 *Convert.ToDouble(result);
                }
                else
                {
                    temp = secend * 1000 * Settings.Default.WaitTime;
                }


                Thread.Sleep(Convert.ToInt32(temp));
            }
            else
            {
                double temp = secend * 1000;
                Thread.Sleep((int)temp);
            }
        }

        public void LeftClick(DmAe dmae, int x1, int y1, int x2, int y2)
        {
            Random ran = new Random();
            int tempx = ran.Next(x1, x2);
            int tempy = ran.Next(y1, y2);
            dmae.MoveTo(tempx, tempy);
            delayTime(0.2);
            dmae.LeftDown();
            delayTime(0.2);
            dmae.LeftUp();
            delayTime(1);
            //variables.AppState = "点击坐标x = " + tempx.ToString() + " y = " + tempy.ToString();
            ran = null;
        }

        public void BindWindowS(DmAe dmae, int B)
        {
            //windowsStat = 0 解锁 = 1 锁定
            if (B == 0)//解锁
            {
                int dmae0 = dmae.BindWindowUnLock();
                if (dmae0 == 1)
                    SystemInfo.WindowsState = 0;
            }
            if (B == 1)//锁死鼠标
            {

                int dmae0 = dmae.BindWindowLock();
                if (dmae0 == 1)
                    SystemInfo.WindowsState = 1;
            }

        }

        public void ScreenUp(DmAe dmae, int x1, int y1, int x2, int y2,int amount, int ColorX4,int ColorY4,int ColorX5, int ColorY5,int ColorX6,int ColorY6, string Color4 = "ffffff",string Color5 = "ffffff",string Color6 = "ffffff")//x1,y1,x2,y2起始范围,amount启动的像素点 ,x4 y4 为检测点,x5y5x6y6,col5col6col4为颜色
        {
            Random ran = new Random();
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "屏幕往上移动";
            int dm_ret0 = dmae.CmpColor(ColorX4, ColorY4, Color4, 1);//找不到颜色返回1
            int dm_ret1 = dmae.CmpColor(ColorX5, ColorY5, Color5, 1);//找不到颜色返回1
            int dm_ret2 = dmae.CmpColor(ColorX6, ColorY6, Color6, 1);//找不到颜色返回1
            while ((dm_ret0 == 1) && (dm_ret1 == 1) && (dm_ret2 == 1)) 
            {
                int tempx = ran.Next(x1, x2);
                int tempy = ran.Next(y1, y2);
                dmae.MoveTo(tempx, tempy);
                dmae.LeftDown();
                while (tempy < (amount + y2))
                {
                    tempy++;
                    dmae.MoveTo(tempx, tempy); delayTime(0.005);

                }
                dmae.LeftUp();
                delayTime(0.5);
                dm_ret0 = dmae.CmpColor(ColorX4, ColorY4, Color4, 1);//找不到颜色返回1
                dm_ret1 = dmae.CmpColor(ColorX5, ColorY5, Color5, 1);//找不到颜色返回1
                dm_ret2 = dmae.CmpColor(ColorX6, ColorY6, Color6, 1);//找不到颜色返回1
            }
            //Random ran = new Random();
            //variables.AppState = "屏幕往上移动";
            //int dm_ret = dmae.CmpColor(x4, y4, col + "|" + Settings.Default.AirPort, 0.6);//找不到颜色返回1
            //int dm_ret1 = dmae.CmpColor(x5, y5, col1 + "|" + Settings.Default.AirPort, 0.6);//找不到颜色返回1
            //int dm_Ret0 = 1, count = 0;
            //string temp0 = dmae.GetColor(700, 65);
            //while (true)
            //{
            //    count = 0;
            //    int tempx = ran.Next(x1, x2);
            //    int tempy = ran.Next(y1, y2);
            //    dmae.MoveTo(tempx, tempy);
            //    dmae.LeftDown();
            //    while (tempy < (x3 + y2))
            //    {
            //        temp0 = dmae.GetColor(700, 65);

            //        tempy += 3;
            //        dmae.MoveTo(tempx, tempy); delayTime(0.1);


            //        dm_Ret0 = dmae.CmpColor(700, 65, temp0, 1);

            //        if (dm_Ret0 == 0)
            //        {
            //            count += 1;
            //            if (count == 5)
            //            {
            //                dmae.LeftUp();
            //                return;
            //            }
            //        }

            //    }
            //    dmae.LeftUp();
            //    delayTime(0.5);
            //    dm_ret = dmae.CmpColor(x4, y4, col + "|" + Settings.Default.AirPort, 0.6);
            //    dm_ret1 = dmae.CmpColor(x5, y5, col1 + "|" + Settings.Default.AirPort, 0.6);
            //}
        }

        public void ScreenDown(DmAe dmae, int x1, int y1, int x2, int y2, int amount, int ColorX4, int ColorY4, int ColorX5, int ColorY5, int ColorX6, int ColorY6, string Color4 = "ffffff", string Color5 = "ffffff", string Color6 = "ffffff")//x1,y1,x2,y2起始范围,x3启动的像素点 ,x4 y4 为检测点，string col为颜色
        {
            Random ran = new Random();
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "屏幕往下移动";
            int dm_ret0 = dmae.CmpColor(ColorX4, ColorY4, Color4, 1);//找不到颜色返回1
            int dm_ret1 = dmae.CmpColor(ColorX5, ColorY5, Color5, 1);//找不到颜色返回1
            int dm_ret2 = dmae.CmpColor(ColorX6, ColorY6, Color6, 1);//找不到颜色返回1
            while ((dm_ret0 == 1) && (dm_ret1 == 1) && (dm_ret2 == 1)) 
            {

                int tempx = ran.Next(x1, x2);
                int tempy = ran.Next(y1, y2);
                dmae.MoveTo(tempx, tempy);
                dmae.LeftDown();
                while (tempy > (y1 - amount))
                {
                    tempy--;
                    dmae.MoveTo(tempx, tempy); delayTime(0.005);

                }
                dmae.LeftUp();
                delayTime(0.5);
                dm_ret0 = dmae.CmpColor(ColorX4, ColorY4, Color4, 1);//找不到颜色返回1
                dm_ret1 = dmae.CmpColor(ColorX5, ColorY5, Color5, 1);//找不到颜色返回1
                dm_ret2 = dmae.CmpColor(ColorX6, ColorY6, Color6, 1);//找不到颜色返回1
            }

            //Random ran = new Random();
            //variables.AppState = "屏幕往下移动";
            //int dm_ret = dmae.CmpColor(x4, y4, col + "|" + Settings.Default.AirPort, 1);//找不到颜色返回1
            //int dm_ret1 = dmae.CmpColor(x5, y5, col1 + "|" + Settings.Default.AirPort, 1);//找不到颜色返回1
            //int dm_Ret0 = 1, count = 0;
            //string temp0 = dmae.GetColor(700, 65);
            //while (true)
            //{
            //    count = 0;
            //    int tempx = ran.Next(x1, x2);
            //    int tempy = ran.Next(y1, y2);
            //    dmae.MoveTo(tempx, tempy);
            //    dmae.LeftDown();
            //    while (tempy > (y1 - x3))
            //    {
            //        temp0 = dmae.GetColor(700, 65);

            //        tempy -= 3;
            //        dmae.MoveTo(tempx, tempy); delayTime(0.1);


            //        dm_Ret0 = dmae.CmpColor(700, 65, temp0, 1);

            //        if (dm_Ret0 == 0)
            //        {
            //            count += 5;
            //            if (count == 5)
            //            {
            //                dmae.LeftUp();
            //                return;
            //            }
            //        }

            //    }
            //    dmae.LeftUp();
            //    delayTime(0.5);
            //}

        }

        public void MapSet(DmAe dmae, int x1, int y1, int x2, int y2,int x3,int y3,int x4,int y4)//x1,y1,x2,y2,x3,y3是地图缩放到最小的监测点x4y4鼠标移动位置
        {

            //等待
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "缩放地图";
            int dm_ret0 = dmae.CmpColor(246, 11, "ffffff", 1);
            while(dm_ret0 == 1)
            {
                delayTime(1);
                dm_ret0 = dmae.CmpColor(246, 11, "ffffff", 1);
            }

            //等待结束
            //开始缩放
            dmae.MoveTo(x3,y3);
            int dm_ret1 = dmae.CmpColor(x1, y1, "ffffff", 1);
            int dm_ret2 = dmae.CmpColor(x2, y2, "ffffff", 1);
            int dm_ret5 = dmae.CmpColor(x3, y3, "ffffff", 1);
            switch (WindowsFormsApplication1.Properties.Settings.Default.SetMapType)

            {
                case 0://右键平移
                    {

                                while(dmae.CmpColor(x1, y1, "ffffff", 1) == 1 || dmae.CmpColor(x2, y2, "ffffff", 1) == 1 || dmae.CmpColor(x3, y3, "ffffff", 1) == 1)
                                {

                                    dmae.MoveTo(x4, y4);
                                    delayTime(0.5);
                                    dmae.RightDown();
                                    delayTime(0.5);
                                    for(int tempx4= x4; tempx4 < x4+300;)
                                    {
                                        dmae.MoveTo(tempx4, y4);
                                        delayTime(0.05, 1);
                                        tempx4=tempx4+10;
                                    }
                                    dmae.RightUp();
                                    delayTime(0.5);
                                }
                        break;


                    }
                case 1://右键加滚动滑轮
                    {
                        int tempx3 = x4, tempy3 = y4;
                        int count = 0;
                        while (true)
                        {
                            dm_ret1 = dmae.CmpColor(x1, y1, "ffffff", 0.9);
                            dm_ret2 = dmae.CmpColor(x2, y2, "ffffff", 0.9);
                            dm_ret5 = dmae.CmpColor(x3, y3, "ffffff", 1);
                            if (dm_ret1 == 0 && dm_ret2 == 0 && dm_ret5 == 0) 
                            {

                                return;
                            }
                            else
                            {
                                //if (count != 0)
                                //{
                                //    dmae.MoveTo(640, 360);
                                //    tempx3 = 640;
                                //}
                                //else
                                //{
                                //    tempx3 = x4;
                                //    dmae.MoveTo(tempx3, tempy3);
                                //}
                                dmae.MoveTo(640, 360);
                                tempx3 = 640;


                                //检测突发情况（部署小队）
                                int dm_ret3 = dmae.CmpColor(558, 489, "ffffff", 0.9);
                                int dm_ret4 = dmae.CmpColor(721, 489, "ffffff", 0.9);
                                if (dm_ret3 == 0 && dm_ret4 == 0)
                                {

                                    while (dm_ret3 == 0 && dm_ret4 == 0)
                                    {
                                        LeftClick(dmae, 564, 496, 708, 545);
                                        delayTime(1);
                                        dm_ret3 = dmae.CmpColor(558, 489, "ffffff", 0.9);
                                        dm_ret4 = dmae.CmpColor(721, 489, "ffffff", 0.9);
                                    }

                                }

                                //检测突发情况（部署小队）

                                while (tempx3 < 1000)
                                {
                                    delayTime(0.05, 1);
                                    dmae.WheelDown();

                                    tempx3 += 5;
                                    if (tempx3 > 1000)
                                    {
                                        count++;
                                        break;

                                    }
                                    dm_ret1 = dmae.CmpColor(x1, y1, "ffffff", 1);
                                    dm_ret2 = dmae.CmpColor(x2, y2, "ffffff", 1);
                                    dm_ret5 = dmae.CmpColor(x3, y3, "ffffff", 1);
                                    if (dm_ret1 == 0 && dm_ret2 == 0 && dm_ret5 == 0)
                                    {
                                        delayTime(2);

                                        return;
                                    }
                                }



                            }

                        }
                    }

                default:
                    {

                        dmae.KeyUp(17);
                        dmae.KeyDown(17);
                        while (dm_ret1 == 1 || dm_ret2 == 1 || dm_ret5 == 1) 
                        {

                            dmae.WheelDown();
                            delayTime(0.1, 1);
                            dm_ret1 = dmae.CmpColor(x1, y1, "ffffff", 0.9);
                            dm_ret2 = dmae.CmpColor(x2, y2, "ffffff", 0.9);
                            dm_ret5 = dmae.CmpColor(x3, y3, "ffffff", 1);

                            //检测突发情况
                            int dm_ret3 = dmae.CmpColor(558, 489, "ffffff", 0.9);
                            int dm_ret4 = dmae.CmpColor(721, 489, "ffffff", 0.9);
                            if (dm_ret3 == 0 && dm_ret4 == 0)
                            {

                                dmae.KeyUp(17);
                                while (dm_ret3 == 0 && dm_ret4 == 0)
                                {
                                    LeftClick(dmae, 564, 496, 708, 545);
                                    delayTime(1);
                                    dm_ret3 = dmae.CmpColor(558, 489, "ffffff", 0.9);
                                    dm_ret4 = dmae.CmpColor(721, 489, "ffffff", 0.9);
                                }
                                dmae.KeyDown(17);

                                if ((x3 - 10) > 0)
                                {
                                    x3 -= 10;
                                    dmae.MoveTo(x3, y3);
                                }

                            }


                        }
                        dmae.KeyUp(17);
                        break;

                    }

            }


            //--最后收尾


            int dm_ret9 = dmae.CmpColor(558, 489, "ffffff", 0.9);
            int dm_ret10 = dmae.CmpColor(721, 489, "ffffff", 0.9);
            if (dm_ret9 == 0 && dm_ret10 == 0)
            {
                dmae.RightUp();
                while (dm_ret9 == 0 && dm_ret10 == 0)
                {
                    LeftClick(dmae, 564, 496, 708, 545);
                    delayTime(1);
                    dm_ret9 = dmae.CmpColor(558, 489, "ffffff", 0.9);
                    dm_ret10 = dmae.CmpColor(721, 489, "ffffff", 0.9);
                }
            }

        }

        public void ReceiveLogistics(DmAe dmae)
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "接受后勤任务";
            Random ran = new Random();
            double s;
            double sm = 0;
            while (sm < 11)
            {
                s = ran.Next(0, 1);
                sm = sm + s+1.4;
                LeftClick(dmae, 217, 98, 767, 521);
                delayTime(s);
            }
        }//接受后勤任务

        public void ClickHomeBattle(DmAe dmae)      //双击主页战场
        {
            int count = 0;
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "点击主页战斗按钮";
            WriteLog.WriteError("准备点击主页战斗按钮");
            int temp = 0;
            //int dm_ret0 = dmae.CmpColor(40, 85, "3ac2f7"+ "|" + Settings.Default.HomePage0, 0.9);
            //int dm_ret1 = dmae.CmpColor(900, 35, "ffffff"+ "|" + Settings.Default.HomePage1, 0.9);
            //int dm_ret2 = dmae.CmpColor(710, 690, "ffffff", 0.9);
            int dm_ret0 = CheckHomePage(dmae);
            while(dm_ret0 == 1)
            {
                delayTime(0.5,1);
                WriteLog.WriteError("不在主页");
                dm_ret0 = CheckHomePage(dmae);
                temp++;
                if (temp == 5)
                {
                    //战斗页面
                    int dm_ret9 = CheckBattlePage(dmae);
                    if (dm_ret9 == 0)
                    {
                        WriteLog.WriteError("temp = 5 点击主页战斗成功");
                        return;
                    }
                }
                if (temp == 6)
                {
                    int dm_ret11 = CheckMissionSettingPage(dmae);
                    if (dm_ret11 == 0 )
                    {
                        while (dm_ret11 == 0)
                        {
                            LeftClick(dmae, 276, 64, 283, 71);
                            delayTime(1, 1);
                            dm_ret11 = CheckMissionSettingPage(dmae);
                        }
                        return;
                    }

                    WriteLog.WriteError("temp = 6 不在主页");
                    LeftClick(dmae, 196, 90, 779, 531);
                    temp = 0;
                }
            }




            while (dm_ret0 == 0)
            {
                BindWindowS(dmae, 1);

                int dm_ret9 = CheckBattlePage(dmae);
                if (dm_ret9 == 0)
                {
                    WriteLog.WriteError("temp = 5 点击主页战斗成功");
                    return;
                }


                int dm_ret11 = CheckMissionSettingPage(dmae);

                if(dm_ret11 == 0)
                {
                    while (dm_ret11 == 0)
                    {
                        LeftClick(dmae, 276, 64, 283, 71);
                        delayTime(1,1);
                        dm_ret11 = CheckMissionSettingPage(dmae);
                    }
                    return;
                }


                WriteLog.WriteError("点击主页战斗按钮");
                LeftClick(dmae, 836, 456, 1010, 549);
                delayTime(2);
                dm_ret0 = CheckHomePage(dmae);
            }


            int dm_ret3 = CheckBattlePage(dmae);
            while (dm_ret3 == 1)
            {
                //防止呆在主页
                delayTime(1);
                dm_ret3 = CheckBattlePage(dmae);
                count += 1;
                if(count == 5) { ClickHomeBattle(dmae); }
            }

            WriteLog.WriteError("点击主页战场按钮成功");



        }

        public void ClickTeam(DmAe dmae)
        {
            int count = 0;
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "点击主页编成";
            //int dm_ret0 = dmae.CmpColor(40, 85, "3ac2f7" + "|" + Settings.Default.HomePage0, 0.9);
            //int dm_ret1 = dmae.CmpColor(900, 35, "ffffff" + "|" + Settings.Default.HomePage1, 0.9);
            //int dm_ret2 = dmae.CmpColor(710, 690, "ffffff", 0.9);
            int dm_ret0 = CheckHomePage(dmae);
            while (dm_ret0 == 1 )
            {
                int dm_ret6 = CheckBattlePage(dmae);
                //int dm_ret7 = dmae.CmpColor(138, 94, "ffffff", 0.9);

                if(dm_ret6 == 0 ) { return; }

                LeftClick(dmae, 196, 90, 779, 531);//点击人物
                delayTime(1);
                dm_ret0 = CheckHomePage(dmae);
                //dm_ret1 = dmae.CmpColor(900, 35, "ffffff" + "|" + Settings.Default.HomePage1, 0.9);
                //dm_ret2 = dmae.CmpColor(710, 690, "ffffff", 0.9);
            }
            while (dm_ret0 == 0 )
            {
                BindWindowS(dmae, 1);
                LeftClick(dmae, 1068, 429, 1245, 539);//点击编成
                dm_ret0 = CheckHomePage(dmae);
                //dm_ret0 = dmae.CmpColor(40, 85, "3ac2f7" + "|" + Settings.Default.HomePage0, 0.9);
                //dm_ret1 = dmae.CmpColor(900, 35, "ffffff" + "|" + Settings.Default.HomePage1, 0.9);
                //dm_ret2 = dmae.CmpColor(710, 690, "ffffff", 0.9);
            }

            //等待页面载入完毕

            int dm_ret3 = CheckBattlePage(dmae);
            //int dm_ret4 = dmae.CmpColor(138, 94, "ffffff", 0.9);
            while (dm_ret3 == 1)
            {
                int dm_ret6 = CheckBattlePage(dmae);
                //int dm_ret6 = dmae.CmpColor(138, 1, "ffffff", 0.9);
                //int dm_ret7 = dmae.CmpColor(138, 94, "ffffff", 0.9);

                if (dm_ret6 == 0) { return; }

                delayTime(1);

                dm_ret3 = CheckBattlePage(dmae);
                //dm_ret3 = dmae.CmpColor(38, 1, "ffffff", 0.9);
                //dm_ret4 = dmae.CmpColor(138, 94, "ffffff", 0.9);
                count += 1;
                if (count == 5) { ClickTeam(dmae); }
            }

        }

        public void ClickFactory(DmAe dmae)
        {
            delayTime(2, 1);
            int count = 0;
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "点击主页工厂";

            while (CheckHomePage(dmae) == 1)
            {
                int dm_ret6 = dmae.CmpColor(138, 1, "ffffff", 0.9);
                int dm_ret7 = dmae.CmpColor(138, 94, "ffffff", 0.9);

                if (dm_ret6 == 0 || dm_ret7 == 0) { return; }

                LeftClick(dmae, 196, 90, 779, 531);//点击人物
                delayTime(0.5,1);

            }
            while (CheckHomePage(dmae) == 0)
            {
                BindWindowS(dmae, 1);
                LeftClick(dmae, 1073, 311, 1224, 376);//点击工厂
            }

            //等待页面载入完毕

            int dm_ret3 = dmae.CmpColor(138, 1, "ffffff", 0.9);
            int dm_ret4 = dmae.CmpColor(138, 94, "ffffff", 0.9);
            while (dm_ret3 == 1 || dm_ret4 == 1)
            {
                int dm_ret6 = dmae.CmpColor(138, 1, "ffffff", 0.9);
                int dm_ret7 = dmae.CmpColor(138, 94, "ffffff", 0.9);

                if (dm_ret6 == 0 || dm_ret7 == 0) { return; }

                delayTime(1);
                dm_ret3 = dmae.CmpColor(38, 1, "ffffff", 0.9);
                dm_ret4 = dmae.CmpColor(138, 94, "ffffff", 0.9);
                count += 1;
                if (count == 5) { ClickFactory(dmae); }
            }

        }

        public void ClickDismantlementGun(DmAe dmae)
        {

            int dm_ret0 = dmae.CmpColor(173, 400, "ffffff", 0.9);
            while(dm_ret0 == 1)
            {
                delayTime(1);
                dm_ret0 = dmae.CmpColor(173, 400, "ffffff", 0.9);
            }

            while(dm_ret0 == 0)
            {
                LeftClick(dmae, 22, 416, 156, 463);
                delayTime(1);
                dm_ret0 = dmae.CmpColor(173, 400, "ffffff", 0.9);
            }


        }

        public void ClickChoiceGun(DmAe dmae,int status)
        {
            switch (status)
            {
                case 0:
                    {
                        int dm_ret2 = dmae.CmpColor(130, 10, "ffffff", 0.9);
                        while (dm_ret2 == 1)
                        {
                            LeftClick(dmae, 279, 153, 420, 229);
                            delayTime(1);
                            dm_ret2 = dmae.CmpColor(130, 10, "ffffff", 0.9);
                        }
                        break;
                    }
                case 1:
                    {
                        int dm_ret2 = dmae.CmpColor(130, 10, "ffffff", 0.9);
                        while (dm_ret2 == 1)
                        {
                            LeftClick(dmae, 278, 412, 416, 483);
                            delayTime(1);
                            dm_ret2 = dmae.CmpColor(130, 10, "ffffff", 0.9);
                        }
                        break;
                    }
                case 2:
                    {
                        int dm_ret2 = dmae.CmpColor(130, 10, "ffffff", 0.9);
                        while (dm_ret2 == 1)
                        {
                            LeftClick(dmae, 477, 414, 622, 486);
                            delayTime(1);
                            dm_ret2 = dmae.CmpColor(130, 10, "ffffff", 0.9);
                        }
                        break;
                    }
                case 3:
                    {
                        int dm_ret2 = dmae.CmpColor(130, 10, "ffffff", 0.9);
                        while (dm_ret2 == 1)
                        {
                            LeftClick(dmae, 672, 413, 809, 480);
                            delayTime(1,1);
                            dm_ret2 = dmae.CmpColor(130, 10, "ffffff", 0.9);
                        }
                        break;
                    }
                case 4:
                    {
                        int dm_ret2 = dmae.CmpColor(130, 10, "ffffff", 0.9);
                        while (dm_ret2 == 1)
                        {
                            LeftClick(dmae, 880, 411, 1004, 477);
                            delayTime(1,1);
                            dm_ret2 = dmae.CmpColor(130, 10, "ffffff", 0.9);
                        }
                        break;
                    }
                case 5:
                    {
                        int dm_ret2 = dmae.CmpColor(130, 10, "ffffff", 0.9);
                        while (dm_ret2 == 1)
                        {
                            LeftClick(dmae, 1081, 415, 1211, 486);
                            delayTime(1,1);
                            dm_ret2 = dmae.CmpColor(130, 10, "ffffff", 0.9);
                        }
                        break;
                    }
                default:
                    break;
            }


            }



        public void ClickChoice(DmAe dmae,int count)
        {
            bool firsttime = true;
            int _count = count;
            int temp0 = 0;//用来确定选择按钮的位置
            int n;
            //等待页面加载完毕
            int dm_ret0 = dmae.CmpColor(1072, 590, "ffffff", 0.9);
            int dm_ret1 = dmae.CmpColor(910, 590, "ffffff", 0.9);
            while (dm_ret0 == 1 || dm_ret1 == 1)
            {
                delayTime(1);
                dm_ret0 = dmae.CmpColor(1072, 590, "ffffff", 0.9);
                dm_ret1 = dmae.CmpColor(910, 590, "ffffff", 0.9);
            }


            //----------点击选择按钮选择拆解枪支

            while (_count > 0)
            {
                //点击

                n = 1;

                //----------点击选择按钮
                if (firsttime == true)
                {
                    ClickChoiceGun(dmae, 0);
                    firsttime = false;
                }
                else
                {
                    ClickChoiceGun(dmae, temp0%5+1);
                }



                //-------选择十二支枪
                if(_count >= 12)
                {
                    while (n < 13)
                    {
                        ClickDismantleGun(dmae, n);
                        n += 1;
                        temp0 += 1;
                        _count -= 1;
                    }
                }
                else
                {
                    while (n <= _count)
                    {
                        ClickDismantleGun(dmae, n);
                        n += 1;
                        temp0 += 1;
                    }
                    //---------点击确定
                    int dm_ret10 = dmae.CmpColor(131, 8, "ffffff", 0.9);
                    int dm_ret11 = dmae.CmpColor(131, 88, "ffffff", 0.9);
                    while (dm_ret10 == 0 && dm_ret11 == 0)
                    {
                        LeftClick(dmae, 1111, 610, 1247, 675);
                        dm_ret10 = dmae.CmpColor(131, 8, "ffffff", 0.9);
                        dm_ret11 = dmae.CmpColor(131, 88, "ffffff", 0.9);
                    }
                    break;
                }

                //---------点击确定
                int dm_ret4 = dmae.CmpColor(131, 8, "ffffff", 0.9);
                int dm_ret5 = dmae.CmpColor(131, 88, "ffffff", 0.9);
                while (dm_ret4 == 0 && dm_ret5 == 0)
                {
                    LeftClick(dmae, 1111, 610, 1247, 675);
                    dm_ret4 = dmae.CmpColor(131, 8, "ffffff", 0.9);
                    dm_ret5 = dmae.CmpColor(131, 88, "ffffff", 0.9);
                }
            }//循环结束



            //等待窗口加载完毕
            int dm_ret8 = dmae.CmpColor(138, 1, "ffffff", 0.9);
            int dm_ret9 = dmae.CmpColor(138, 94, "ffffff", 0.9);
            while (dm_ret8 == 1 || dm_ret9 == 1)
            {
                delayTime(1);
                dm_ret8 = dmae.CmpColor(138, 1, "ffffff", 0.9);
                dm_ret9 = dmae.CmpColor(138, 94, "ffffff", 0.9);

            }

            //---------点击确定
            int dm_ret12 = dmae.CmpColor(138, 1, "ffffff", 0.9);
            int dm_ret13 = dmae.CmpColor(138, 94, "ffffff", 0.9);

            int dm_ret6 = dmae.CmpColor(610, 464, "ffffff", 0.9);
            int dm_ret7 = dmae.CmpColor(447, 464, "ffffff", 0.9);


            while (dm_ret8 == 0 || dm_ret9 == 0)
            {
                LeftClick(dmae, 1110, 608, 1217, 630);
                delayTime(1);
                dm_ret12 = dmae.CmpColor(138, 1, "ffffff", 0.9);
                dm_ret13 = dmae.CmpColor(138, 94, "ffffff", 0.9);

                dm_ret6 = dmae.CmpColor(610, 464, "ffffff", 0.9);
                dm_ret7 = dmae.CmpColor(447, 464, "ffffff", 0.9);
                if (dm_ret6 == 0 && dm_ret7 == 0) { break; }

                int dm_ret14 = dmae.CmpColor(315, 169, "ffffff", 0.9);
                int dm_ret15 = dmae.CmpColor(315, 221, "ffffff", 0.9);
                int dm_ret16 = dmae.CmpColor(289, 195, "ffffff", 0.9);
                if (dm_ret14 == 0 && dm_ret15 == 0 && dm_ret16 == 0)
                {
                    return;
                }

            }




            //----检查高编制高等级高星级窗口

            while(dm_ret6 == 0 || dm_ret7 == 0)
            {
                LeftClick(dmae, 669, 473, 804, 520);
                dm_ret6 = dmae.CmpColor(610, 464, "ffffff", 0.9);
                dm_ret7 = dmae.CmpColor(447, 464, "ffffff", 0.9);

                dm_ret8 = dmae.CmpColor(138, 1, "ffffff", 0.9);
                dm_ret9 = dmae.CmpColor(138, 94, "ffffff", 0.9);

                if(dm_ret8 == 0&& dm_ret9 == 0) { break; }

            }
        }

        public void ClickDismantleGun(DmAe dmae,int N)
        {
            switch (N)
            {
                case 1:
                    {
                        string tempcolor =  dmae.GetColor(170, 392);
                        while (true)
                        {
                            LeftClick(dmae, 26, 172, 149, 310);
                            //delayTime(1);
                            if (dmae.CmpColor(170, 392, tempcolor, 1) == 1) { return; }
                        }
                    }

                case 2:
                    {
                        string tempcolor = dmae.GetColor(350,375);
                        while (true)
                        {
                            LeftClick(dmae, 197, 137, 331, 320);
                            //delayTime(1);
                            if (dmae.CmpColor(350,375, tempcolor, 1) == 1) { return; }
                        }
                    }
                case 3:
                    {
                        string tempcolor = dmae.GetColor(530,380);
                        while (true)
                        {
                            LeftClick(dmae, 386, 165, 513, 320);
                            //delayTime(1);
                            if (dmae.CmpColor(530,380, tempcolor, 1) == 1) { return; }
                        }
                    }
                case 4:
                    {
                        string tempcolor = dmae.GetColor(708,390);
                        while (true)
                        {
                            LeftClick(dmae, 567, 176, 689, 316);
                            //delayTime(1);
                            if (dmae.CmpColor(708,390, tempcolor, 1) == 1) { return; }
                        }
                    }
                case 5:
                    {
                        string tempcolor = dmae.GetColor(720,380);
                        while (true)
                        {
                            LeftClick(dmae, 740, 163, 865, 318);
                            //delayTime(1);
                            if (dmae.CmpColor(720,380, tempcolor, 1) == 1) { return; }
                        }
                    }
                case 6:
                    {
                        string tempcolor = dmae.GetColor(1065,390);
                        while (true)
                        {
                            LeftClick(dmae, 915, 164, 1046, 309);
                            //delayTime(1);
                            if (dmae.CmpColor(1065,390, tempcolor, 1) == 1) { return; }
                        }
                    }
                case 7:
                    {
                        string tempcolor = dmae.GetColor(170, 700);
                        while (true)
                        {
                            LeftClick(dmae, 20, 431, 147, 615);
                            //delayTime(1);
                            if (dmae.CmpColor(170, 700, tempcolor, 1) == 1) { return; }
                        }
                    }
                case 8:
                    {
                        string tempcolor = dmae.GetColor(350, 700);
                        while (true)
                        {
                            LeftClick(dmae, 205, 481, 324, 595);
                            //delayTime(1);
                            if (dmae.CmpColor(350, 700, tempcolor, 1) == 1) { return; }
                        }
                    }
                case 9:
                    {
                        string tempcolor = dmae.GetColor(528, 700);
                        while (true)
                        {
                            LeftClick(dmae, 398, 471, 496, 590);
                            //delayTime(1);
                            if (dmae.CmpColor(528, 700, tempcolor, 1) == 1) { return; }
                        }
                    }
                case 10:
                    {
                        string tempcolor = dmae.GetColor(710, 700);
                        while (true)
                        {
                            LeftClick(dmae, 569, 455, 680, 592);
                            //delayTime(1);
                            if (dmae.CmpColor(710, 700, tempcolor, 1) == 1) { return; }
                        }
                    }
                case 11:
                    {
                        string tempcolor = dmae.GetColor(888, 700);
                        while (true)
                        {
                            LeftClick(dmae, 734, 429, 876, 621);
                            //delayTime(1);
                            if (dmae.CmpColor(888, 700, tempcolor, 1) == 1) { return; }
                        }
                    }
                case 12:
                    {
                        string tempcolor = dmae.GetColor(1065, 700);
                        while (true)
                        {
                            LeftClick(dmae, 921, 460, 1042, 614);
                            //delayTime(1);
                            if (dmae.CmpColor(1065, 700, tempcolor, 1) == 1) { return; }
                        }
                    }


                default:
                    break;
            }



        }

        public void ChangeGun(DmAe dmae)
        {
            //----------------新方法
            bool No3Status = false, No4Status = false, No5Status = false;
            bool ChangeNext = false;
            bool ret0;
            bool temp0 = false;
            int N = 3;
            int temp1 = 1;



            while (temp1 <= 3)
            {
                //if (No3Status = true && No4Status == true && No5Status == true)
                //{
                //    break;
                //}

                //检测3个是否OK

                

                ClickBox(dmae, N);

                if(temp0 == false)
                {

                    ShowNewGun(dmae);//排序方式 获得顺序
                    temp0 = true;
                }



                ret0 = ClickGunChange(dmae, ChangeNext);

                if(ret0 == true)
                {
                    temp1 += 1;

                    if (N == 3)
                    {
                        No3Status = true;
                        N += 1;
                    }
                    else if(N == 4)
                    {
                        No4Status = true;
                        N += 1;
                        if (N == 5) { ChangeNext = true; } else { ChangeNext = false; }
                    }
                    else if(N == 5)
                    {
                        if(No3Status == false)
                        {
                            N = 3;
                        }
                        if(No4Status == false)
                        {
                            N = 4;
                        }
                        No5Status = true;

                        ChangeNext = true;
                    }
                }
                else
                {
                    N += 1;

                    if (N == 5) { ChangeNext = true; } else { ChangeNext = false; }
                    if(No5Status == true) { ChangeNext = true; }
                }



            }





            //// ---------------old3号位
            //int dm_ret3 = dmae.CmpColor(138, 1, "ffffff", 0.9);
            //int dm_ret4 = dmae.CmpColor(138, 94, "ffffff", 0.9);
            //while (dm_ret3 == 0 && dm_ret4 == 0)// 3号位
            //{
            //    LeftClick(dmae, 527, 220, 673, 420);
            //    dm_ret3 = dmae.CmpColor(138, 1, "ffffff", 0.9);
            //    dm_ret4 = dmae.CmpColor(138, 94, "ffffff", 0.9);
            //}

            //ShowNewGun(dmae);//排序方式 获得顺序
            //ClickGunChange(dmae);

            //// 4号位
            //dm_ret3 = dmae.CmpColor(138, 1, "ffffff", 0.9);
            //dm_ret4 = dmae.CmpColor(138, 94, "ffffff", 0.9);
            //while (dm_ret3 == 0 && dm_ret4 == 0)// 4号位
            //{
            //    LeftClick(dmae, 727, 179, 843, 431);
            //    dm_ret3 = dmae.CmpColor(138, 1, "ffffff", 0.9);
            //    dm_ret4 = dmae.CmpColor(138, 94, "ffffff", 0.9);
            //}

            ////ShowNewGun(dmae);//排序方式 获得顺序
            //ClickGunChange(dmae);

            //// 5号位
            //dm_ret3 = dmae.CmpColor(138, 1, "ffffff", 0.9);
            //dm_ret4 = dmae.CmpColor(138, 94, "ffffff", 0.9);
            //while (dm_ret3 == 0 && dm_ret4 == 0)// 5号位
            //{
            //    LeftClick(dmae, 921, 200, 1024, 428);
            //    dm_ret3 = dmae.CmpColor(138, 1, "ffffff", 0.9);
            //    dm_ret4 = dmae.CmpColor(138, 94, "ffffff", 0.9);
            //}

            ////ShowNewGun(dmae);//排序方式 获得顺序
            //ClickGunChange(dmae);





        }





        public void ShowNewGun(DmAe dmae)//排序方式 获得顺序
        {

            //等待页面展示完毕
            int dm_ret12 = dmae.CmpColor(343, 375, "ffffff", 0.9);
            while(dm_ret12 == 1) { delayTime(2); }


            int dm_ret0 = dmae.CmpColor(1251, 171, "ffffff", 0.9);
            //等待页面展示完毕
            while (dm_ret0 == 1)
            {
                int dm_ret7 = dmae.CmpColor(721, 489, "ffffff", 1);
                int dm_ret8 = dmae.CmpColor(558, 489, "ffffff", 1);
                if (dm_ret7 == 0 && dm_ret8 == 0)
                {
                    while (dm_ret7 == 0 && dm_ret8 == 0)
                    {
                        LeftClick(dmae, 597, 500, 675, 533);
                        delayTime(1);
                        dm_ret7 = dmae.CmpColor(721, 489, "ffffff", 1);
                        dm_ret8 = dmae.CmpColor(558, 489, "ffffff", 1);
                    }
                }


                delayTime(2, 1);
                dm_ret0 = dmae.CmpColor(1251, 171, "ffffff", 0.9);
            }


            int dm_ret5 = dmae.CmpColor(1080, 180, "ffffff", 0.9);  //点击排序方式
            while (dm_ret5 == 1)
            {

                //检测误操作

                int dm_ret7 = dmae.CmpColor(721, 489, "ffffff", 0.9);
                int dm_ret8 = dmae.CmpColor(558, 489, "ffffff", 0.9);
                if(dm_ret7 == 0 && dm_ret8 == 0)
                {
                    while (dm_ret7 == 0 && dm_ret8 == 0)
                    {
                        LeftClick(dmae, 597, 500, 675, 533);
                        delayTime(1);
                        dm_ret7 = dmae.CmpColor(721, 489, "ffffff", 0.9);
                        dm_ret8 = dmae.CmpColor(558, 489, "ffffff", 0.9);
                    }
                }



                LeftClick(dmae, 1121, 159, 1261, 212);
                dm_ret5 = dmae.CmpColor(1080, 180, "ffffff", 0.9);
            }

            int dm_ret6 = dmae.CmpColor(1080, 180, "ffffff", 0.9);  //点击获得顺序
            while (dm_ret6 == 0)
            {
                LeftClick(dmae, 1077, 303, 1080, 370);
                dm_ret6 = dmae.CmpColor(1080, 180, "ffffff", 0.9);
            }

        }

        public bool ClickGunChange(DmAe dmae,bool ChangeNext)//开始更换枪支
        {
            int dm_ret0 = dmae.CmpColor(1251, 171, "ffffff", 0.9);
            while (dm_ret0 == 1) { delayTime(2, 1); dm_ret0 = dmae.CmpColor(1251, 171, "ffffff", 0.9); }//等待页面展示完毕
            int count = 1;

            while (true)
            {
                ClickGun(dmae, count);
                delayTime(2, 1);
                int dm_ret1 = dmae.CmpColor(721, 489, "ffffff", 0.9);
                int dm_ret2 = dmae.CmpColor(558, 489, "ffffff", 0.9);
                if (dm_ret1 == 0 && dm_ret2 == 0)//判断是否2支相同的
                {

                    while (dm_ret1 == 0 && dm_ret2 == 0)//检测到两只相同
                    {
                        LeftClick(dmae, 561, 494, 707, 545);
                        dm_ret1 = dmae.CmpColor(721, 489, "ffffff", 0.9);
                        dm_ret2 = dmae.CmpColor(558, 489, "ffffff", 0.9);
                    }

                    if(ChangeNext == false)
                    {
                        //点击返回并且return false

                        ClickBackToGunList(dmae);
                        return false;
                    }


                    count += 1;
                }

                else
                {
                    //count += 1;
                    return true;
                }

            }





        }

        public void ClickBox(DmAe dmae,int N)
        {
            int dm_ret5, dm_ret6, dm_ret7, dm_ret8;
            switch (N)
            {

                case 3:
                    {
                        int dm_ret3 = dmae.CmpColor(138, 1, "ffffff", 0.9);
                        int dm_ret4 = dmae.CmpColor(138, 94, "ffffff", 0.9);
                        while (dm_ret3 == 0 && dm_ret4 == 0)// 3号位
                        {
                            dm_ret5 = dmae.CmpColor(343, 394, "ffffff", 0.9);
                            dm_ret6 = dmae.CmpColor(1058, 697, "ffffff", 0.9);
                            if (dm_ret5 == 0 && dm_ret6 == 0) { return; }



                            LeftClick(dmae, 527, 220, 673, 420);
                            delayTime(1, 1);
                            dm_ret3 = dmae.CmpColor(138, 1, "ffffff", 0.9);
                            dm_ret4 = dmae.CmpColor(138, 94, "ffffff", 0.9);
                        }
                        break;
                    }
                case 4:
                    {
                        int dm_ret3 = dmae.CmpColor(138, 1, "ffffff", 0.9);
                        int dm_ret4 = dmae.CmpColor(138, 94, "ffffff", 0.9);
                        while (dm_ret3 == 0 && dm_ret4 == 0)// 4号位
                        {
                            dm_ret5 = dmae.CmpColor(343, 394, "ffffff", 0.9);
                            dm_ret6 = dmae.CmpColor(1058, 697, "ffffff", 0.9);
                            if (dm_ret5 == 0 && dm_ret6 == 0) { return; }

                            LeftClick(dmae, 727, 179, 843, 431);
                            delayTime(1, 1);
                            dm_ret3 = dmae.CmpColor(138, 1, "ffffff", 0.9);
                            dm_ret4 = dmae.CmpColor(138, 94, "ffffff", 0.9);
                        }
                        break;
                    }
                case 5:
                    {
                        int dm_ret3 = dmae.CmpColor(138, 1, "ffffff", 0.9);
                        int dm_ret4 = dmae.CmpColor(138, 94, "ffffff", 0.9);
                        while (dm_ret3 == 0 && dm_ret4 == 0)// 5号位
                        {
                            dm_ret5 = dmae.CmpColor(343, 394, "ffffff", 0.9);
                            dm_ret6 = dmae.CmpColor(1058, 697, "ffffff", 0.9);
                            if (dm_ret5 == 0 && dm_ret6 == 0) { return; }


                            LeftClick(dmae, 921, 200, 1024, 428);
                            delayTime(1, 1);
                            dm_ret3 = dmae.CmpColor(138, 1, "ffffff", 0.9);
                            dm_ret4 = dmae.CmpColor(138, 94, "ffffff", 0.9);
                        }
                        break;
                    }

                default:
                    break;
            }


        }

        public void ClickGun(DmAe dmae,int N)
        {
            switch (N)
            {
                case 1:
                    {
                        int dm_ret0 = dmae.CmpColor(215, 360, "ffffff", 0.9);
                        if(dm_ret0 == 1)
                        {
                            LeftClick(dmae, 196, 138, 337, 317);
                        }
                        else
                        {
                            ClickGun(dmae, N + 1);
                        }
                        break;
                    }
                case 2:
                    {
                        int dm_ret0 = dmae.CmpColor(400, 360, "ffffff", 0.9);
                        if (dm_ret0 == 1)
                        {
                            LeftClick(dmae, 398, 168, 510, 308);
                        }
                        else
                        {
                            ClickGun(dmae, N + 1);
                        }
                        break;
                    }
                case 3:
                    {
                        int dm_ret0 = dmae.CmpColor(579, 360, "ffffff", 0.9);
                        if (dm_ret0 == 1)
                        {
                            LeftClick(dmae, 558, 166, 693, 308);
                        }
                        else
                        {
                            ClickGun(dmae, N + 1);
                        }

                        break;
                    }
                case 4:
                    {
                        int dm_ret0 = dmae.CmpColor(753, 360, "ffffff", 0.9);
                        if (dm_ret0 == 1)
                        {
                            LeftClick(dmae, 751, 158, 867, 298);
                        }
                        else
                        {
                            ClickGun(dmae, N + 1);
                        }

                        break;
                    }
                case 5:
                    {
                        int dm_ret0 = dmae.CmpColor(935, 360, "ffffff", 0.9);
                        if (dm_ret0 == 1)
                        {
                            LeftClick(dmae, 916, 171, 1044, 311);
                        }
                        else
                        {
                            ClickGun(dmae, N + 1);
                        }


                        break;
                    }
                case 6:
                    {
                        int dm_ret0 = dmae.CmpColor(40, 662, "ffffff", 0.9);
                        if (dm_ret0 == 1)
                        {
                            LeftClick(dmae, 27, 475, 165, 612);
                        }
                        else
                        {
                            ClickGun(dmae, N + 1);
                        }


                        break;
                    }
                case 7:
                    {
                        int dm_ret0 = dmae.CmpColor(220, 663, "ffffff", 0.9);
                        if (dm_ret0 == 1)
                        {
                            LeftClick(dmae, 207, 466, 314, 595);
                        }
                        else
                        {
                            ClickGun(dmae, N + 1);
                        }

                        break;
                    }
                case 8:
                    {
                        int dm_ret0 = dmae.CmpColor(396, 663, "ffffff", 0.9);
                        if (dm_ret0 == 1)
                        {
                            LeftClick(dmae, 392, 473, 507, 607);
                        }
                        else
                        {
                            ClickGun(dmae, N + 1);
                        }

                        break;
                    }
                case 9:
                    {
                        int dm_ret0 = dmae.CmpColor(577, 663, "ffffff", 0.9);
                        if (dm_ret0 == 1)
                        {
                            LeftClick(dmae, 562, 466, 671, 614);
                        }
                        else
                        {
                            ClickGun(dmae, N + 1);
                        }

                        break;
                    }
                case 10:
                    {
                        int dm_ret0 = dmae.CmpColor(752, 662, "ffffff", 0.9);
                        if (dm_ret0 == 1)
                        {
                            LeftClick(dmae, 758, 460, 859, 637);
                        }
                        else
                        {
                            ClickGun(dmae, N + 1);
                        }

                        break;
                    }
                case 11:
                    {
                        int dm_ret0 = dmae.CmpColor(933, 662, "ffffff", 0.9);
                        if (dm_ret0 == 1)
                        {
                            LeftClick(dmae, 916, 466, 1046, 616);
                        }
                        else
                        {
                            ClickGun(dmae, N + 1);
                        }

                        break;
                    }
                default:
                    {
                        int dm_ret0 = dmae.CmpColor(131, 8, "ffffff", 0.9);
                        int dm_ret1 = dmae.CmpColor(130, 88, "ffffff", 0.9);
                        while (dm_ret0 == 0 && dm_ret1 == 0)
                        {
                            LeftClick(dmae, 118, 149, 214, 204);
                            delayTime(3,1);
                            dm_ret0 = dmae.CmpColor(131, 8, "ffffff", 0.9);
                            dm_ret1 = dmae.CmpColor(130, 88, "ffffff", 0.9);
                        }

                        //MessageBox.Show(N.ToString() + "错误");
                        break;
                    }
            }


        }

        public void ClickBackToGunList(DmAe dmae)//点击返回到编成列表
        {
            int dm_ret3 = dmae.CmpColor(130, 8, "ffffff", 0.9);
            int dm_ret4 = dmae.CmpColor(130, 88, "ffffff", 0.9);
            while (dm_ret3 == 0 && dm_ret4 == 0)// 5号位
            {
                LeftClick(dmae, 27, 26, 112, 72);
                dm_ret3 = dmae.CmpColor(130, 8, "ffffff", 0.9);
                dm_ret4 = dmae.CmpColor(130, 88, "ffffff", 0.9);
            }
        }

        public void ClickHomeShower(DmAe dmae)      //双击澡堂
        {
            int count = 0;
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "点击修复按钮";
            int dm_ret0 = CheckHomePage(dmae);
            while (dm_ret0 == 1 )
            {
                //若检测主页不在             
                LeftClick(dmae, 479, 175, 661, 587);//点击人物
                delayTime(1);
                dm_ret0 = CheckHomePage(dmae);
            }
            while (dm_ret0 == 0)
            {
                BindWindowS(dmae, 1);
                LeftClick(dmae, 856, 206, 999, 265);//点击修复
                dm_ret0 = CheckHomePage(dmae);
            }

            //等待页面载入完毕

            int dm_ret3 = dmae.CmpColor(220, 40, "ffffff", 0.9);
            int dm_ret4 = dmae.CmpColor(1130, 40, "ffffff", 0.9);
            while (dm_ret3 == 1 || dm_ret4 == 1)
            {
                delayTime(1);
                dm_ret3 = dmae.CmpColor(220, 40, "ffffff", 0.9);
                dm_ret4 = dmae.CmpColor(1130, 40, "ffffff", 0.9);
                count += 1;
                if (count == 5) { ClickHomeShower(dmae); }
            }


        }


        public void LeftClickHomeToBattle(DmAe dmae, int battle,int difficult,int mission,int activity = 0)//battle ==11 2016夏活
        {
            ClickHomeBattle(dmae);


            ChooseBattle(dmae, battle);//点击战役battle ==11 2016夏活
            ChooseDifficult(dmae, difficult);//0不选择跳过
            ChooseMission(dmae, mission);//点击地图
            delayTime(1);
        }

        public void BackToHomeFromBattlePageREADY(DmAe dmae)
        {
            //while (CheckBattleMapReady == 1)
            //{
            //    LeftClick(dmae)
            //}
            ClickBackToBattle(dmae);
            LeftClickBackHome(dmae);
            WaitToHome(dmae);
        }


        public void Activity(DmAe dmae)      //夏活
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "点击魔方行动";
            int dm_ret0 = CheckActivityChoicePage(dmae);
            while (dm_ret0 == 1)//1为不相等
            {
                LeftClick(dmae, 25, 400, 172, 460);
                delayTime(1);
                dm_ret0 = CheckActivityChoicePage(dmae);
            }
        }

        public void ClickLogistics(DmAe dmae)      //双击后勤
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "点击后勤任务";
            int dm_ret = dmae.CmpColor(90, 215, "ffffff", 1);
            while (dm_ret == 0)//1为不相等
            {
                LeftClick(dmae, 15, 219, 166, 282);
                delayTime(1);
                dm_ret = dmae.CmpColor(90, 215, "ffffff", 1);
            }
        }



        public void ChooseBattle(DmAe dmae, int battle)      //选择战役 11为夏活E1,12夏活E2 13夏活E3 14 夏活E4
        {

            bool dm_ret6 = ((dmae.CmpColor(240, 240, "ffffff", 0.9) == 0) || (dmae.CmpColor(240, 240, "f7ae00", 0.7) == 0) || (dmae.CmpColor(240, 240, Settings.Default.BattleSelectColor, 0.7) == 0));//任务1斜杠//确保打开了任务选择页面
            while (dm_ret6 == false)
            {
                delayTime(1);
                dm_ret6 = ((dmae.CmpColor(240, 240, "ffffff", 0.9) == 0) || (dmae.CmpColor(240, 240, "f7ae00", 0.7) == 0) || (dmae.CmpColor(240, 240, Settings.Default.BattleSelectColor, 0.7) == 0));
            }


            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "选择战役";
            if (battle == 0)//点击第零战役
            {

                LeftClick(dmae, 203, 114, 294, 179);
                delayTime(1);
                int dm_ret0 = dmae.CmpColor(250, 188, Settings.Default.BattleSelectColor, 0.7);
                while (dm_ret0 == 1) { LeftClick(dmae, 203, 114, 294, 179); delayTime(1); dm_ret0 = dmae.CmpColor(250, 188, Settings.Default.BattleSelectColor, 0.7); }

            }

            if (battle == 1)//点击第一战役
            {
                LeftClick(dmae, 202, 213, 297, 285); delayTime(1);
                int dm_ret1 = dmae.CmpColor(240, 240, Settings.Default.BattleSelectColor, 0.7);
                while (dm_ret1 == 1) { LeftClick(dmae, 202, 213, 297, 285); delayTime(1); dm_ret1 = dmae.CmpColor(240, 240, Settings.Default.BattleSelectColor, 0.7); }
            }

            if (battle == 2)//点击第二战役
            {

                LeftClick(dmae, 201, 315, 302, 387); delayTime(1);
                int dm_ret2 = dmae.CmpColor(250, 350, Settings.Default.BattleSelectColor, 0.7);
                while(dm_ret2 == 1) { LeftClick(dmae, 201, 315, 302, 387); delayTime(1); dm_ret2 = dmae.CmpColor(250, 350, Settings.Default.BattleSelectColor, 0.7); }

            }
            if (battle == 3)//点击第三战役
            {


                LeftClick(dmae, 197, 411, 298, 494); delayTime(1);
                int dm_ret3 = dmae.CmpColor(250, 455, Settings.Default.BattleSelectColor, 0.7);
                while(dm_ret3 == 1 ) { LeftClick(dmae, 197, 411, 298, 494); delayTime(1); dm_ret3 = dmae.CmpColor(250, 455, Settings.Default.BattleSelectColor, 0.7); }

            }
            if (battle == 4)//点击第四战役
            {

                LeftClick(dmae, 200, 522, 296, 594); delayTime(1);
                int dm_ret4 = dmae.CmpColor(240, 560, Settings.Default.BattleSelectColor, 0.7);
                while(dm_ret4 == 1) { LeftClick(dmae, 200, 522, 296, 594); delayTime(1); dm_ret4 = dmae.CmpColor(240, 560, Settings.Default.BattleSelectColor, 0.7); }

            }
            if (battle == 5)//点击第五战役
            {
                LeftClick(dmae, 197, 622, 297, 688); delayTime(1);
                int dm_ret5 = dmae.CmpColor(250, 613, Settings.Default.BattleSelectColor, 0.7);
                while(dm_ret5 == 1) { LeftClick(dmae, 197, 622, 297, 688); delayTime(1); dm_ret5 = dmae.CmpColor(250, 613, Settings.Default.BattleSelectColor, 0.7); }
            }

            if (battle == 11)//点击夏活
            {
                WindowsFormsApplication1.BaseData.SystemInfo.AppState = "点击魔方行动";
                int dm_ret0 = CheckActivityChoicePage(dmae);
                while (dm_ret0 == 1)//1为不相等
                {
                    LeftClick(dmae, 25, 400, 172, 460);
                    delayTime(1);
                    dm_ret0 = CheckActivityChoicePage(dmae);
                }
            }
        }

        public void ChooseDifficult(DmAe dmae, int difficult) //选择普通还是紧急0为普通 1为紧急
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "选择难度";

            WriteLog.WriteError("准备选择难度");
            if (difficult == 0)
            {
                //普通 什么都不做 添加一个判定
                delayTime(1);
            }
            else if(difficult ==1)//为紧急
            {
                // 确定->点击->确定->退出循环
                int dm_ret2 = dmae.CmpColor(1030, 110, Settings.Default.UrgentTask, 0.8);
                while(dm_ret2 == 1)
                {




                    LeftClick(dmae, 428, 122, 1242, 203);
                    delayTime(1);
                    dm_ret2 = dmae.CmpColor(1030, 110, Settings.Default.UrgentTask, 0.8);
                }

            }
            WriteLog.WriteError("选择难度完成");
        }
        
        public void ChoiceActivityBattle(DmAe dmae,int mission)//魔方行动E-E4
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "点击任务";
            int dm_Ret0 = CcheckActivityPageReady(dmae);
            while(dm_Ret0 == 1)
            {
                delayTime(1);
                dm_Ret0 = CcheckActivityPageReady(dmae);
            }

            switch (mission)
            {
                case 11:
                    {
                        break;
                    }
                case 12:
                    {
                        break;
                    }
                case 13:
                    {
                        break;
                    }
                case 14:
                    {

                        int dm_Ret1 = CheckMissionSettingPage(dmae);//530 80 是作战设置
                        while (dm_Ret1 == 1)
                        {
                            LeftClick(dmae, 900, 515, 1112, 587);
                            delayTime(1);
                            dm_Ret1 = CheckMissionSettingPage(dmae);
                        }
                        WriteLog.WriteError("点击完成");


                        break;
                    }
                default:
                    break;
            }

        }


        public void ChooseMission(DmAe dmae, int mission)//只支持1-5号任务   11为夏活E1,12为夏活E2,13为夏活E3,14为夏活E4
        {
            if(mission > 10)
            {
                ChoiceActivityBattle(dmae, mission);
                return;
            }


            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "点击任务";
            delayTime(1);
            int dm_ret1 = dmae.CmpColor(515, 275, "ffffff", 0.9);
            int dm_ret2 = dmae.CmpColor(505, 415, "ffffff", 0.9);
            int dm_ret3 = dmae.CmpColor(510, 525, "ffffff", 0.9);
            int dm_ret4 = dmae.CmpColor(505, 650, "ffffff", 0.9);

            int count0 = 0;
            while (true)
            {
                count0 += 1;
                if(count0 == 30) { MessageBox.Show("发生未知错误"); }
                if (dm_ret1 == 0 && dm_ret2 == 0 && dm_ret3 == 0 && dm_ret4 == 0) { break; }
                delayTime(1);
                dm_ret1 = dmae.CmpColor(515, 275, "ffffff", 0.9);//任务1斜杠
                dm_ret2 = dmae.CmpColor(505, 415, "ffffff", 0.9);//任务2斜杠
                dm_ret3 = dmae.CmpColor(510, 525, "ffffff", 0.9);//任务3斜杠
                dm_ret4 = dmae.CmpColor(505, 650, "ffffff", 0.9);//任务4斜杠
            }




            if (mission == 1)//点击第一个任务
            {
                WriteLog.WriteError("准备点击第一任务");
                int dm_Ret1 = dmae.CmpColor(530, 80, "ffffff", 0.9);
                while(dm_Ret1 == 1)
                {
                    LeftClick(dmae, 492, 243, 980, 311);
                    delayTime(1);
                    dm_Ret1 = dmae.CmpColor(210, 90, "ffffff", 0.9);
                }
                WriteLog.WriteError("点击完成");
            }
            if (mission == 2)//点击第二个任务
            {
                WriteLog.WriteError("准备点击第二任务");
                int dm_ret0 = dmae.CmpColor(315, 190, "ffffff", 0.9);
                int dm_ret5 = dmae.CmpColor(815, 175, "ffffff", 0.9);


                while (dm_ret0 == 1 || dm_ret5 == 1)
                {
                    LeftClick(dmae, 839, 360, 1060, 438);
                    delayTime(1);
                    dm_ret0 = dmae.CmpColor(315, 190, "ffffff", 0.9);
                    dm_ret5 = dmae.CmpColor(815, 175, "ffffff", 0.9);

                }
                WriteLog.WriteError("点击完成");
            }
            if (mission == 3)//点击第三个任务
            {
                WriteLog.WriteError("准备点击第三任务");
                int dm_Ret1 = dmae.CmpColor(530, 80, "ffffff", 0.9);
                while (dm_Ret1 == 1)
                {
                    LeftClick(dmae, 848, 480, 1244, 551);
                    delayTime(1);
                    dm_Ret1 = dmae.CmpColor(210, 90, "ffffff", 0.9);
                }
                WriteLog.WriteError("点击完成");
            }
            if (mission == 4)//点击第四个任务
            {
                WriteLog.WriteError("准备点击第四任务");
                int dm_Ret1 = dmae.CmpColor(530, 80, "ffffff", 0.9);//530 80 是作战设置
                int dm_Ret2;
                while (dm_Ret1 == 1)
                {
                    dm_Ret2 = dmae.CmpColor(1020, 590, "ffffff", 0.9);
                    LeftClick(dmae, 843, 597, 1255, 671);
                    delayTime(1);
                    dm_Ret1 = dmae.CmpColor(210, 90, "ffffff", 0.9);
                }
                WriteLog.WriteError("点击完成");
            }
            if (mission == 5)//点击第五个任务
            {
                WriteLog.WriteError("准备点击第五任务");
                LeftClick(dmae, 544, 706, 1030, 718);
                delayTime(1);
                //判断是否点击成功
                int dm_ret = dmae.CmpColor(237, 83, "ffffff", 0.9);
                while (dm_ret == 1)
                {
                    LeftClick(dmae, 428, 707, 1257, 715);
                    delayTime(1);
                    dm_ret = dmae.CmpColor(237, 83, "ffffff", 0.9);
                }
                WriteLog.WriteError("点击完成");
            }
        }

        public void ChooseLogisticsTask(DmAe dmae, int task)//点击1-4后勤任务 
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "选择后勤任务";

            //等待页面加在完毕
            int dm_ret2 = ChooseLogisticsPageReady(dmae);
            while(dm_ret2 == 1)
            {
                delayTime(1);
                dm_ret2 = ChooseLogisticsPageReady(dmae);
            }




            if (task == 1)
            {
                int dm_ret0 = dmae.CmpColor(560, 635, "ffffff", 0.9);
                if (dm_ret0  == 1)
                {
                    MessageBox.Show("后勤任务进行中", "少女前线");
                    return;
                }
                //int dm_ret1 = dmae.CmpColor(390, 100, "ffffff", 0.9);
                int dm_ret1 = CheckTeamSlectPage(dmae);
                while (dm_ret1 == 1)
                {
                    LeftClick(dmae, 423, 178, 569, 401);
                    delayTime(1);
                    dm_ret1 = CheckTeamSlectPage(dmae);
                }
            }

            if (task == 2)
            {
                int dm_ret0 = dmae.CmpColor(660, 630, "ffffff", 0.9);
                //int dm_ret0 = CheckTeamSlectPage(dmae);
                if (dm_ret0 == 1)
                {
                    MessageBox.Show("后勤任务进行中", "少女前线");
                    return;
                }
                int dm_ret1 = CheckTeamSlectPage(dmae);
                while (dm_ret1 == 1)
                {
                    LeftClick(dmae, 626, 163, 794, 402);
                    delayTime(1);
                    dm_ret1 = CheckTeamSlectPage(dmae);
                }
            }

            if (task == 3)
            {
                int dm_ret0 = dmae.CmpColor(930, 640, "ffffff", 0.9);
                if (dm_ret0 == 1)
                {
                    MessageBox.Show("后勤任务进行中", "少女前线");
                    return;
                }
                int dm_ret1 = CheckTeamSlectPage(dmae);
                while (dm_ret1 == 1)
                {
                    LeftClick(dmae, 860, 166, 1010, 404);
                    delayTime(1);
                    dm_ret1 = CheckTeamSlectPage(dmae);
                }
            }

            if (task == 4)
            {
                int dm_ret0 = dmae.CmpColor(1145, 635, "ffffff", 0.9);
                if (dm_ret0 == 1)
                {
                    MessageBox.Show("后勤任务进行中", "少女前线");
                    return;
                }
                int dm_ret1 = CheckTeamSlectPage(dmae);
                while (dm_ret1 == 1)
                {
                    LeftClick(dmae, 1073, 162, 1242, 405);
                    delayTime(1);
                    dm_ret1 = CheckTeamSlectPage(dmae);
                }
            }


        }

        public void DoubleClickLogisticsConfirm(DmAe dmae)//双击后勤任务确定
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "确认";
            int dm_ret0 = CheckTeamSlectPage(dmae);
            while (dm_ret0 == 0)
            {
                LeftClick(dmae, 1104, 622, 1235, 655);
                delayTime(1);
                dm_ret0 = CheckTeamSlectPage(dmae); ;
            }
        }

        public void ClickFightType(DmAe dmae, string s1)//双击作战任务
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "选择作战方式";
            WriteLog.WriteError("准备选择作战方式");
            object intX, intY;
            int dm_ret;
            if (s1 == "self-discipline")
            {
                while (dmae.CmpColor(525, 90, "ffffff", 0.9) == 0 && dmae.CmpColor(210, 90, "ffffff", 0.9) == 0)
                {
                    //dm_ret = dmae.FindColor(428, 527, 885, 664, "8cca10"+ "|"+Settings.Default.selfdiscipline, 0.9, 0, out intX, out intY);
                    //if(dm_ret == 0) { break; }

                    LeftClick(dmae, 604,542,759,616);
                    delayTime(1);
                    Girl_Full(dmae);//检测床位是否已满
                }
            }

            if (s1 == "normal")
            {
                //找到颜色位置
                //单击颜色位置
                //判断单击是否成功
                //x坐标范围 800-825 542-616

                while (dmae.CmpColor(525, 90, "ffffff", 0.9) == 0 && dmae.CmpColor(210, 90, "ffffff", 0.9) == 0 && dmae.CmpColor(310, 200, "ffffff", 0.9) == 0)
                {
                    //dm_ret = dmae.FindColor(428, 527, 885, 664, "ffba00" + "|" + Settings.Default.normal, 0.9, 0, out intX, out intY);

                    LeftClick(dmae, 800,542,825,616);

                    delayTime(1,1);

                    Girl_Full(dmae);//检测床位是否已满
                }
            }
            WriteLog.WriteError("选择作战方式完成");

        }

        public bool Girl_Full(DmAe dmae)//检测床位是否已满
        {
            int dm_ret0 = dmae.CmpColor(560, 500, "ffffff", 0.9);
            int dm_ret1 = dmae.CmpColor(720, 500, "ffffff", 0.9);

            if (dm_ret0 == 1 || dm_ret1 == 1) { return false; }

            while (dm_ret0 == 0 && dm_ret1 == 0)
            {
                LeftClick(dmae, 563, 494, 713, 545);
                delayTime(1);
                dm_ret0 = dmae.CmpColor(560, 500, "ffffff", 0.9);
                dm_ret1 = dmae.CmpColor(720, 500, "ffffff", 0.9);

                int dm_ret4 = dmae.CmpColor(230, 20, "ffffff", 0.9);
                if(dm_ret4 == 0) { return false; }

            }

            int dm_ret2 = dmae.CmpColor(240, 80, "ffffff", 0.9);
            int dm_ret3 = dmae.CmpColor(500, 100, "ffffff", 0.9);

            while(dm_ret2 == 0&& dm_ret3 == 0)
            {
                LeftClick(dmae, 190, 73, 276, 115);
                delayTime(1);
                dm_ret2 = dmae.CmpColor(240, 80, "ffffff", 0.9);
                dm_ret3 = dmae.CmpColor(500, 100, "ffffff", 0.9);

                int dm_ret4 = dmae.CmpColor(230, 20, "ffffff", 0.9);
                if (dm_ret4 == 0) { return false; }
            }

            LeftClickBackHome(dmae);

            if(Settings.Default.dismantlegun == true)
            {
                //Task.Insert(0, Dismantlement);
                im.gametasklist.Insert(0, WindowsFormsApplication1.BaseData.TaskList.Dismantlement);
            }
            else
            {
                MessageBox.Show("床位已满，请整顿", "少女前线");
            }
            WindowsFormsApplication1.BaseData.SystemInfo.ThreadTCase = 2;
            return true;
        }

        public void BattleStart(DmAe dmae)//双击开始战斗
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "开始战斗";
            //int dm_ret0 = dmae.CmpColor(297, 40, "ffffff", 0.9);
            //while (dm_ret0 == 1)
            //{
            //    LeftClick(dmae, 1028, 624, 1246, 693);
            //    delayTime(3);
            //    dm_ret0 = dmae.CmpColor(297, 40, "ffffff", 0.9);
            //}
            //确定->点击->确定
            int dm_ret0 = dmae.CmpColor(151, 12, "ffffff", 0.9);
            while(dm_ret0 ==1) { delayTime(1); dm_ret0 = dmae.CmpColor(151, 12, "ffffff", 0.9); }

            int dm_ret1 = dmae.CmpColor(297, 40, "ffffff", 0.9);
            while (dm_ret1 == 1) { LeftClick(dmae, 1028, 624, 1246, 693); delayTime(3); dm_ret1 = dmae.CmpColor(297, 40, "ffffff", 0.9); ; }


        }

        public void ClosMissionHelp (DmAe dmae)
        {
            int dm_Ret0 = CheckMissionHelp(dmae);

            while (dm_Ret0 == 1)
            {
                delayTime(1, 1);
                dm_Ret0 = CheckMissionHelp(dmae);
            }


            while (dm_Ret0 ==0)
            {
                LeftClick(dmae, 170, 115, 260, 155);
                delayTime(1,1);
                dm_Ret0 = CheckMissionHelp(dmae);
            }
        }

        public void Support(DmAe dmae,int x1,int y1,int x2 ,int y2)//双击补给
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "补给梯队";
            int count = 0;
            int dm_ret0 = CheckBattleMapReady(dmae);//检查是否在战斗页面
            //int dm_ret0 = dmae.CmpColor(210, 20, "ffffff", 0.9);
            while (dm_ret0 == 0)
            {
                LeftClick(dmae, x1, y1, x2, y2);
                delayTime(1);
                dm_ret0 = dm_ret0 = CheckBattleMapReady(dmae);
            }

            delayTime(1);

            int dm_ret2 = CheckTeamSlectPage(dmae);


            while (dm_ret2 == 1 )
            {
                LeftClick(dmae, x1, y1, x2, y2);
                delayTime(1);
                dm_ret2 = CheckTeamSlectPage(dmae);

            }


            delayTime(1);
            int dm_ret1 = CheckTeamSlectPage(dmae);


            while (dm_ret1 == 0)
            {
                if (count == 5)
                {
                    MessageBox.Show("补给失败", "少女前线");
                }
                count += 1;
                WriteLog.WriteError("点击补给" + count.ToString());

                LeftClick(dmae, 1095, 525, 1267, 571);
                delayTime(1,1);

                int dm_ret4 = CheckErrorWindows(dmae);
                WriteLog.WriteError("检查错误窗口 dm_ret4 = " + dm_ret4.ToString());
                if (dm_ret4 == 0 )
                {
                    WindowsFormsApplication1.BaseData.SystemInfo.AppState = "不需要补给";
                    while(dm_ret4 == 0)
                    {
                        LeftClick(dmae, 562, 493, 713, 547);
                        delayTime(1);
                        dm_ret4 = CheckErrorWindows(dmae);
                        //dm_ret5 = dmae.CmpColor(721, 489, "ffffff", 0.9);
                    }
                    return;
                }

                dm_ret1 = CheckTeamSlectPage(dmae);
                WriteLog.WriteError("检测补给 dm_Ret1 = " + dm_ret1.ToString());
            }

        }

        public void RoundEnd(DmAe dmae,ref UserBattleInfo userBattleInfo)//回合结束
        {
            SystemInfo.AppState = "回合结束";

            //开始检测血量
            WriteLog.WriteError("开始检测血量");
            if (userBattleInfo.FixMaxPercentage == 0)
            {
                userBattleInfo.NeedToFix = true;
            }
            else if (userBattleInfo.ChoiceToFix == true)
            {
                //打开梯队列表检查HP
                WriteLog.WriteError("打开梯队列表检查HP");
                while (CheckTeamSlectPage(dmae) == 1)
                {
                    LeftClick(dmae, 1019, 515, 1068, 555);
                    delayTime(1);
                }
                //开始检测HP
                int dm_ret5;
                for (int i = 1; i <= 5; i++)
                {
                    dm_ret5 = CheckToFix(dmae, i);
                    if (dm_ret5 < userBattleInfo.FixMaxPercentage)//小于某一个数
                    {
                        WriteLog.WriteError("需要修复");
                        userBattleInfo.NeedToFix = true;
                    }
                }
            }
            //关闭梯队页面

            while (CheckTeamSlectPage(dmae) == 0)
            {
                WriteLog.WriteError("关闭梯队页面");
                LeftClick(dmae, 909, 614, 1045, 663);
                delayTime(1);
            }

            while (CheckBattleMapReady(dmae) == 0)
            {
                WriteLog.WriteError("点击回合结束");
                LeftClick(dmae, 1107, 633, 1242, 691);
                delayTime(5);
            }

            //战斗结果结算页面
            while (true)
            {
                if (CheckHomePage(dmae)==0)
                {
                    break;
                }
                if (CheckBattleResult(dmae))
                {
                    SystemInfo.AppState = "战斗结算";
                    LeftClick(dmae, 1107, 633, 1242, 691);
                    delayTime(1);
                }

                if(CheckNewGunPage(dmae))
                {
                    SystemInfo.AppState = "获取新人形";
                    LeftClick(dmae, 1107, 633, 1242, 691);
                    delayTime(1);
                }
                delayTime(1);

            }



        }

        public void RoundEnd2(DmAe dmae)//回合结束
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "回合结束";

            //等待加载完毕
            int dm_ret1 = 1, count = 0;
            while (dm_ret1 == 0)
            {
                delayTime(1);
                dm_ret1 = CheckActionCount(dmae);
            }



            dm_ret1 = 1; count = 0;
            while (true)
            {
                delayTime(0.1, 1);
                dm_ret1 = CheckBattleEnd(dmae);

                if(dm_ret1 == 0) { WindowsFormsApplication1.BaseData.SystemInfo.AppState = "敌方回合"; break; }
                count += 1;
                if (count % 10 == 1)
                {
                    Random ran = new Random();
                    int tempx = ran.Next(1107, 1242);
                    int tempy = ran.Next(633, 691);
                    dmae.MoveTo(tempx, tempy);
                    dmae.LeftDown();
                    delayTime(0.2, 1);
                    dmae.LeftUp();
                    ran = null;
                }


            }


            count = 0;
            dm_ret1 = 1;
            while (true)
            {

                delayTime(0.1, 1);

                dm_ret1 = CheckBattleStart(dmae);
                if(dm_ret1 == 0) { WindowsFormsApplication1.BaseData.SystemInfo.AppState = "回合开始"; break; }

                //鼠标点击防止卡住战斗结算页面
                count += 1;
                if (count % 10 == 1)
                {
                    Random ran = new Random();
                    int tempx = ran.Next(638, 1156);
                    int tempy = ran.Next(132, 519);
                    dmae.MoveTo(tempx, tempy);
                    dmae.LeftDown();
                    delayTime(0.2,1);
                    dmae.LeftUp();
                    ran = null;
                }
            }



            //int dm_ret0 = dmae.CmpColor(800, 25, "ffffff", 0.9);
            //while (dm_ret0 == 1)
            //{
            //    LeftClick(dmae, 1107, 633, 1242, 691);
            //    delayTime(2);
            //    dm_ret0 = dmae.CmpColor(800, 25, "ffffff", 0.9);
            //}
            delayTime(2, 1);
        }

        public void ImposedLeave (DmAe dmae)
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "强制撤离";
            int dm_ret0 = dmae.CmpColor(565, 490, "ffffff", 0.9);
            int dm_ret1 = dmae.CmpColor(710, 515, "ffffff", 0.9);

            while (dm_ret0 == 1 || dm_ret1 == 1)
            {
                delayTime(0.5);
                dm_ret0 = dmae.CmpColor(565, 490, "ffffff", 0.9);
                dm_ret1 = dmae.CmpColor(710, 515, "ffffff", 0.9);
            }


            while (dm_ret0 == 0 && dm_ret1 == 0)
            {
                LeftClick(dmae, 564, 493, 711, 546);
                delayTime(1);
                dm_ret0 = dmae.CmpColor(565, 490, "ffffff", 0.9);
                dm_ret1 = dmae.CmpColor(710, 515, "ffffff", 0.9);
            }

        }

        public void CheckMapSize(DmAe dmae,int pointx1,int pointy1,int pointx2, int pointy2)
        {
            int dm_ret0 = dmae.CmpColor(pointx1, pointy1, Settings.Default.AirPort, 0.9);
            int dm_ret1 = dmae.CmpColor(pointx2, pointy2, Settings.Default.AirPort, 0.9);
            if(dm_ret0 == 1 || dm_ret1 == 1) { MessageBox.Show("地图检测失败，是否确认地图已缩放到最大？", "少女前线"); }

        }

        public int Teamdispose(DmAe dmae, int x1, int y1, int x2, int y2, string TeamNumber,int x = 0)//部署梯队 特殊情况 x=1 可能会遇到的情况 机场为红色无法部署
        {
            //return -1表示部署
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "部署梯队";
            int count = 0;
            int count0 = 0;

            //等待界面加在完毕
            int dm_ret6 = CheckBattleMapReady(dmae);
            while(dm_ret6 ==1)
            {
                delayTime(1);
                dm_ret6 = CheckBattleMapReady(dmae);

                //检查突发情况
                int dm_ret7 = CheckErrorWindows(dmae);
                while (dm_ret7 == 0)
                {
                    delayTime(1);
                    LeftClick(dmae, 567, 495, 708, 542);
                    dm_ret7 = CheckErrorWindows(dmae);
                }
            }
            //等待界面加载完毕

            //点击机场或指挥部
            while (dm_ret6 == 0)
            {
                if (x == 1)
                {
                    count0 += 1;
                    if (count0 == 15) { return -1; }
                }

                LeftClick(dmae, x1, y1, x2, y2);
                delayTime(1);
                dm_ret6 = CheckBattleMapReady(dmae);



            }
            delayTime(1);


            int dm_ret2 = CheckTeamSlectPage(dmae);
            while (dm_ret2 == 1)
            {
                //检查突发情况(我方总部需。。。)
                int dm_ret7 = CheckErrorWindows(dmae);
                while (dm_ret7 == 0)
                {
                    delayTime(1);
                    LeftClick(dmae, 567, 495, 708, 542);
                    dm_ret7 = CheckErrorWindows(dmae);
                }
                
                LeftClick(dmae, x1, y1, x2, y2);
                delayTime(1);
                dm_ret2 = CheckTeamSlectPage(dmae);

            }

            if(im.time.Team_S(dmae, this, TeamNumber)==false)//选择梯队
            {
                //如果选择失败则返回
                while (CheckTeamSlectPage(dmae) == 0)
                {
                    Team_SeclectClickCancel(dmae);
                    delayTime(1);
                }
                return -1;
            }
            delayTime(1);


            int dm_ret1 = CheckTeamSlectPage(dmae);
            count = 0;
            while (dm_ret1 == 0)
            {
                if (count == 20)
                {
                    MessageBox.Show("部署梯队失败", "少女前线");
                }
                count += 1;
                LeftClick(dmae, 1087, 612, 1244, 659);
                delayTime(1);
                dm_ret1 = CheckTeamSlectPage(dmae);
            }
            return 0;
        }

        public int FindTeamSelectLine(DmAe dmae, int x1, int y1, int x2, int y2, int findtype, int cmpcolornumber = 50, double sim = 1)//findtpe=0是横着找，=1是竖着找
        {
            //找到返回0 找不到返回1
            switch (findtype)
            {
                case 0:
                    {
                        string tempcolor0 = "", tempcolor1 = "";
                        int tempx1 = x1, tempy1 = y1;
                        int tempx2 = x2, tempy2 = y2;
                        for (; y1 < y2; y1++)
                        {
                            tempy1 = y1;
                            tempx2 = x2;
                            tempcolor0 = dmae.GetColor(tempx1, tempy1);
                            tempcolor1 = dmae.GetColor(tempx2, tempy1);
                            if (tempcolor0 == tempcolor1)
                            {
                                //tempcolor2 = dmae.GetColor(tempx2 - 1, tempy1);
                                while (tempcolor0 == tempcolor1)
                                {
                                    tempx2 = tempx2 - 1;
                                    tempcolor1 = dmae.GetColor(tempx2, tempy1);
                                    if (tempx2 == tempx1)
                                    {
                                        return 0;
                                    }
                                }
                            }
                        }
                        return 1;
                    }
                case 1:
                    {
                        {
                            string tempcolor0 = "", tempcolor1 = "";
                            int tempx1 = x1, tempy1 = y1;
                            int tempx2 = x2, tempy2 = y2;
                            for (; x1 < x2; x1++)
                            {
                                tempx1 = x1;
                                tempy2 = y2;
                                tempcolor0 = dmae.GetColor(tempx1, tempy1);
                                tempcolor1 = dmae.GetColor(tempx1, tempy2);
                                if (tempcolor0 == tempcolor1)
                                {
                                    //tempcolor2 = dmae.GetColor(tempx1, tempy2 - 1);
                                    while (tempcolor0 == tempcolor1)
                                    {
                                        tempy2 = tempy2 - 1;
                                        tempcolor1 = dmae.GetColor(tempx1, tempy2);
                                        if (tempy2 == tempy1)
                                        {
                                            return 0;
                                        }
                                    }
                                }
                            }
                            return 1;
                        }
                    }
                default:
                    return 1;
            }

            //for (tempy1 = y1; tempy1 < y2; tempy1++)
            //{
            //    for (tempx1 = x1; tempx1 < x2; tempx1++)
            //    {

            //        tempcolor0 = dmae.GetColor(tempx1, tempy1);
            //        if(findtype == 0)
            //        {
            //            tempcolor1 = dmae.GetColor(tempx1 + cmpcolornumber, tempy1);
            //            if (tempcolor0 == tempcolor1)
            //            {
            //                string tempcolor3 = dmae.GetColor(tempx1 + cmpcolornumber / 2, tempy1);
            //                if (tempcolor3 != tempcolor1)
            //                {
            //                    tempx1 = tempx1 + cmpcolornumber / 2;
            //                    break;
            //                }
            //                for (x0 = 1; x0 <= cmpcolornumber; x0++)
            //                {
            //                    //tempcolor0 = dmae.GetColor(tempx1 + x0, tempy1);
            //                    tempcolor1 = dmae.GetColor(tempx1 + cmpcolornumber - x0, tempy1);
            //                    if (tempcolor1 != tempcolor0)
            //                    {
            //                        //tempx1+=2;
            //                        break;
            //                    }
            //                    if (x0 == cmpcolornumber)
            //                    {
            //                        return 0;
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                if (tempx1 > x1 + cmpcolornumber / 2)
            //                {
            //                    //tempx1 += 2;
            //                    break;
            //                }
            //            }
            //        }

            //        if (findtype == 1)
            //        {
            //            tempcolor1 = dmae.GetColor(tempx1, tempy1 + cmpcolornumber);
            //            if (tempcolor0 == tempcolor1)
            //            {
            //                string tempcolor3 = dmae.GetColor(tempx1, tempy1 + cmpcolornumber / 2);
            //                if (tempcolor3 != tempcolor1) { tempy1 = tempy1 + cmpcolornumber / 2; break; }
            //                for (x0 = 1; x0 <= cmpcolornumber; x0++)
            //                {
            //                    //tempcolor0 = dmae.GetColor(tempx1 + x0, tempy1);
            //                    tempcolor1 = dmae.GetColor(tempx1 , tempy1 + cmpcolornumber - x0);
            //                    if (tempcolor1 != tempcolor0)
            //                    {
            //                        //tempx1+=2;
            //                        break;
            //                    }
            //                    if (x0 == cmpcolornumber)
            //                    {
            //                        return 0;
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                if (tempy1 > y1 + cmpcolornumber / 2)
            //                {
            //                    //tempx1 += 2;
            //                    break;
            //                }
            //            }
            //        }





            //    }//x坐标循环
            //    //数次比较后如果还是一样就返回0,结束函数

            //}//y坐标循环
        }
        public int MoveAndMove(DmAe dmae, int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int x5, int y5, int x6, int y6, int x99, int x98, int x97 = 0)//移动与战斗 //0不需要检查机遇点 x98 0是横 1是束  X97随机点遇敌0撤退1不撤退
        {
            int count = 0;//用于计算错误，累计则回合开始
            int count1 = 0;
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "开始移动";
            object intX, intY;

            int dm_ret1 = FindTeamSelectLine(dmae, x5, y5, x6, y6, x98);
            while (dm_ret1 == 1)
            {
                LeftClick(dmae, x1, y1, x2, y2);
                delayTime(1);
                int dm_ret2 = dmae.CmpColor(714, 609, "ffffff", 0.9);
                int dm_ret3 = dmae.CmpColor(1061, 609, "ffffff", 0.9);
                int dm_ret4 = dmae.CmpColor(930, 638, "ffffff", 0.9);
                if (dm_ret2 == 0 && dm_ret3 == 0 && dm_ret4 == 0)
                {
                    LeftClick(dmae, 902, 612, 1053, 664);
                    delayTime(2);
                    dm_ret2 = dmae.CmpColor(714, 609, "ffffff", 0.9);
                    dm_ret3 = dmae.CmpColor(1061, 609, "ffffff", 0.9);
                    dm_ret4 = dmae.CmpColor(930, 638, "ffffff", 0.9);
                    count += 1;
                    if (count == 10) { BattleStart(dmae); }
                }
                dm_ret1 = FindTeamSelectLine(dmae, x5, y5, x6, y6, x98);
            }

            while (dm_ret1 == 0)
            {
                LeftClick(dmae, x3, y3, x4, y4);
                delayTime(1);
                dm_ret1 = FindTeamSelectLine(dmae, x5, y5, x6, y6, x98);

                int dm_ret2 = dmae.CmpColor(714, 609, "ffffff", 0.9);
                int dm_ret3 = dmae.CmpColor(1061, 609, "ffffff", 0.9);
                int dm_ret4 = dmae.CmpColor(930, 638, "ffffff", 0.9);
                if (dm_ret2 == 0 && dm_ret3 == 0 && dm_ret4 == 0)
                {
                    LeftClick(dmae, 902, 612, 1053, 664);
                    delayTime(2);
                    dm_ret2 = dmae.CmpColor(714, 609, "ffffff", 0.9);
                    dm_ret3 = dmae.CmpColor(1061, 609, "ffffff", 0.9);
                    dm_ret4 = dmae.CmpColor(930, 638, "ffffff", 0.9);
                }
                dm_ret1 = FindTeamSelectLine(dmae, x5, y5, x6, y6, x98);
            }

            delayTime(1,1);






            //检测机遇点
            if (x99 == 1)
            {
                int case1 = 0;
                int count0 = 0;
                //等待机遇窗口
                int dm_ret2 = dmae.CmpColor(439, 165, "ffffff", 0.9);
                int dm_ret3 = dmae.CmpColor(523, 182, "ffffff", 0.9);
                int dm_ret4 = dmae.CmpColor(523, 165, "ffffff", 0.9);
                while( dm_ret2 == 1 || dm_ret3 == 1 || dm_ret4 == 1)
                {
                    delayTime(1,1);
                    dm_ret2 = dmae.CmpColor(439, 165, "ffffff", 0.9);
                    dm_ret3 = dmae.CmpColor(523, 182, "ffffff", 0.9);
                    dm_ret4 = dmae.CmpColor(523, 165, "ffffff", 0.9);
                    count1 += 1;
                    if(count1 == 3)
                    {
                        return -1;//没有检测到随即窗口

                    }
                }


                if (Settings.Default.RandomNotes == true)
                {
                    int dm_retsave = dmae.Capture(425, 150, 963, 599, "\\随机点记录\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".bmp");
                }

                if (Settings.Default.DebugMode == true)
                {
                    int dm_retsave = dmae.Capture(0, 0, 2000, 2000, "\\Debug\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".bmp");
                }


                int dm_ret10 = dmae.CmpColor(599, 497, "ffffff", 0.9);
                int dm_ret11 = dmae.CmpColor(785, 515, "ffffff", 0.9);
                if(dm_ret10 ==0 && dm_ret11 ==0){ WriteLog.WriteError("随机事件 case = 1"); case1 = 1; }

                int dm_ret12 = dmae.CmpColor(479, 499, "ffffff", 0.9);
                int dm_ret13 = dmae.CmpColor(909, 510, "ffffff", 0.9);
                if(dm_ret12 == 0 && dm_ret13 == 0) { WriteLog.WriteError("随机事件 case = 2");  case1 = 2; }

                Random ran = new Random();
                int tempx, tempy;

                switch (case1)
                {
                    case 1://遭遇伏击
                        {
                            WriteLog.WriteError("遭遇伏击");
                            while (dm_ret2 == 0 && dm_ret3 == 0 && dm_ret4 == 0)
                            {
                                WriteLog.WriteError("点击随机页面");
                                LeftClick(dmae, 413, 134, 982, 606); delayTime(1);
                                dm_ret2 = dmae.CmpColor(439, 165, "ffffff", 0.9);
                                dm_ret3 = dmae.CmpColor(523, 182, "ffffff", 0.9);
                                dm_ret4 = dmae.CmpColor(523, 165, "ffffff", 0.9);
                            }


                            if(x97 == 1) //X97随机点遇敌0撤退1不撤退
                            {
                                int dm_ret14 = CheckRandomPointWindows(dmae);
                                while(dm_ret14 == 0)
                                {
                                    LeftClick(dmae, 491, 202, 920, 546);
                                    dm_ret14 = CheckRandomPointWindows(dmae);
                                    return 0;
                                }
                            }


                            int dm_ret29 = dmae.CmpColor(642, 706, "ffffff",1);
                            int dm_ret30 = dmae.CmpColor(637, 706, "ffffff", 1);
                            WriteLog.WriteError("开始检测暂停键");
                            while (true)//确保等到战斗开始
                            {
                                delayTime(0.1,1);
                                dm_ret29 = dmae.CmpColor(642, 706, "ffffff", 0.9);
                                dm_ret30 = dmae.CmpColor(637, 706, "ffffff", 0.9);

                                if(dm_ret29 == 0 && dm_ret30 == 0) { break; }

                            }
                            WriteLog.WriteError("检测暂停键成功");


                            while (true)
                            {
                                //检测暂停键
                                //点击暂停键
                                //检测全体撤退按键
                                //点击全体撤退按键

                                while (true)//检测到暂停键则点击
                                {
                                    WriteLog.WriteError("点击暂停键");
                                    dm_ret29 = dmae.CmpColor(634, 691, "ffffff", 0.9);
                                    dm_ret30 = dmae.CmpColor(634, 706, "ffffff", 0.9);
                                    int dm_ret34 = dmae.CmpColor(645, 698, "ffffff", 0.9);
                                    if (dm_ret29 == 0 && dm_ret30 == 0 && dm_ret34 == 0)
                                    {
                                        tempx = ran.Next(605, 674);
                                        tempy = ran.Next(693, 711);
                                        dmae.MoveTo(tempx, tempy);
                                        dmae.LeftDown();
                                        delayTime(0.3, 1);
                                        dmae.LeftUp();
                                        delayTime(1);

                                        int dm_ret31 = dmae.CmpColor(814, 683, "ffffff", 0.9);
                                        int dm_ret32 = dmae.CmpColor(789, 683, "ffffff", 0.9);
                                        int dm_ret33 = dmae.CmpColor(800, 695, "ffffff", 0.9);
                                        while (dm_ret31 == 0 && dm_ret32 == 0 && dm_ret33 == 0)
                                        {
                                            WriteLog.WriteError("点击全体撤退");
                                            LeftClick(dmae, 342, 665, 539, 708);
                                            delayTime(1);
                                            dm_ret31 = dmae.CmpColor(814, 683, "ffffff", 0.9);
                                            dm_ret32 = dmae.CmpColor(789, 683, "ffffff", 0.9);
                                            dm_ret33 = dmae.CmpColor(800, 695, "ffffff", 0.9);
                                            if(dm_ret31 == 1 || dm_ret32 == 1 || dm_ret33 == 1)
                                            {
                                                WriteLog.WriteError("点击全体撤退完成");
                                                ran = null;
                                                return 1;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                    dm_ret29 = dmae.CmpColor(634, 691, "ffffff", 0.9);
                                    dm_ret30 = dmae.CmpColor(634, 706, "ffffff", 0.9);
                                    dm_ret34 = dmae.CmpColor(645, 698, "ffffff", 0.9);
                                }












                            }
                        }
                    case 2://强制撤离
                        {
                            while (dm_ret2 == 0 && dm_ret3 == 0 && dm_ret4 == 0) { LeftClick(dmae,413, 134, 982, 606); delayTime(1); dm_ret2 = dmae.CmpColor(439, 165, "ffffff", 0.9); dm_ret3 = dmae.CmpColor(523, 182, "ffffff", 0.9); dm_ret4 = dmae.CmpColor(523, 165, "ffffff", 0.9); }

                            return 2;
                        }
                    default:
                        {
                            WriteLog.WriteError("随机事件 = default");
                            dm_ret2 = dmae.CmpColor(439, 165, "ffffff", 0.9);
                            dm_ret3 = dmae.CmpColor(523, 182, "ffffff", 0.9);
                            dm_ret4 = dmae.CmpColor(523, 165, "ffffff", 0.9);
                            while (dm_ret2 == 1 || dm_ret3 == 1 || dm_ret4 == 1)
                            {
                                LeftClick(dmae, 491, 202, 920, 546);
                                delayTime(1);
                                dm_ret2 = dmae.CmpColor(439, 165, "ffffff", 0.9);
                                dm_ret3 = dmae.CmpColor(523, 182, "ffffff", 0.9);
                                dm_ret4 = dmae.CmpColor(523, 165, "ffffff", 0.9);
                            }
                            LeftClick(dmae, 491, 202, 920, 546);
                            return 0;
                        }

                }






            }

            else
            {

                return 0;
            }


        }

        public void MoveToAirport(DmAe dmae, int x1, int y1, int x2, int y2, /*第一个点*/int x3, int y3, int x4, int y4, /*第二个点*/int x5, int y5,int x99,int y99,/*黄条检测范围*/int x6,int y6,/*检测范围*/int x8 ,int y8,int x9,int y9,/*点击移动坐标*/int x98 = 0)
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "开始移动";
            object intX1, intY1;
            int dm_ret3;

            int dm_ret1 = dm_ret1 = FindTeamSelectLine(dmae, x5, y5, x99, y99, x98);
            while (dm_ret1 == 1)
            {
                LeftClick(dmae, x1, y1, x2, y2);
                delayTime(1);
                //dm_ret0 = dmae.FindColor(x5, y5, x99, y99, "ffba00" + "|" + Settings.Default.TeamSelect, 0.9, 0, out intX1, out intY1);
                //检测误操作是否点如梯队列表
                dm_ret3 = CheckTeamSlectPage(dmae);
                while(dm_ret3 == 0)
                {
                    LeftClick(dmae, 921, 625, 1029, 659);
                    dm_ret3 = CheckTeamSlectPage(dmae);
                }

                dm_ret1 = dm_ret1 = FindTeamSelectLine(dmae, x5, y5, x99, y99, x98);
                //if (x98 == 0)
                //{
                //    dm_ret1 = dmae.CmpColor(Int32.Parse(intX1.ToString()) + 5, Int32.Parse(intY1.ToString()), "ffba00" + "|" + Settings.Default.TeamSelect, 0.9);
                //    WriteLog.WriteError("检测梯队是否选中 = " + dm_ret1.ToString());
                //}
                //else
                //{
                //    dm_ret1 = dmae.CmpColor(Int32.Parse(intX1.ToString()), Int32.Parse(intY1.ToString()) + 5, "ffba00" + "|" + Settings.Default.TeamSelect, 0.9);
                //    WriteLog.WriteError("检测梯队是否选中 = " + dm_ret1.ToString());
                //}

                //dm_ret1 = dmae.CmpColor(Int32.Parse(intX1.ToString()) + 5, Int32.Parse(intY1.ToString()), "ffba00" + "|" + Settings.Default.TeamSelect, 0.9);
            }

            string color = dmae.GetColor(x6, y6);
            int dm_ret2 = 0;
            while (dm_ret2 ==0) { LeftClick(dmae, x3, y3, x4, y4); delayTime(3); dm_ret2 = dmae.CmpColor(x6, y6, color, 0.9); }//点击机场


            color = dmae.GetColor(x6, y6);
            dm_ret2 = 0;
            while (dm_ret2 == 0) { LeftClick(dmae, x8, y8, x9, y9); delayTime(3); dm_ret2 = dmae.CmpColor(x6, y6, color, 0.9); }
        }

        public void CheckTeamSlect(DmAe dame, int x1 = 714, int y1 = 609, int x2 = 876, int y2 = 609, int x3 = 907, int y3 = 614, int x4 = 1048, int y4 = 663)
        {
            int dm_ret2 = dame.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_ret3 = dame.CmpColor(x2, y2, "ffffff", 0.9);
            while (dm_ret2 == 0 && dm_ret3 == 0)
            {
                LeftClick(dame, 907, 614, 1048, 663);
                delayTime(1);
                dm_ret3 = dame.CmpColor(x1, y1, "ffffff", 0.9);
                dm_ret2 = dame.CmpColor(x2, y2, "ffffff", 0.9); }

        }

        public void Evacuate(DmAe dmae, int x1, int y1, int x2,int y2, ref UserBattleInfo userBattleInfo)//撤离 小于FixMinTime 不进行修复
        {
            SystemInfo.AppState = "开始撤离";
            int count = 0;
            int dm_ret0 = dmae.CmpColor(297, 40, "ffffff", 0.9);
            while (dm_ret0 == 0)
            {
                LeftClick(dmae, x1, y1, x2, y2);
                delayTime(1);
                dm_ret0 = dmae.CmpColor(297, 40, "ffffff", 0.9);
                count += 1;
                if (count == 20)
                {
                    int dm_ret4 = CheckTeamSlectPage(dmae);
                    if (dm_ret4 == 0)
                    {
                        break;
                    }
                    else
                    {
                        WriteLog.WriteError("无法点击到撤离界面");
                        count = 0;
                    }
                }
            }
            //开始检测血量
            if(userBattleInfo.FixMaxPercentage== 0)
            {
                userBattleInfo.NeedToFix = true;
            }
            else if (userBattleInfo.ChoiceToFix == true)
            {
                int dm_ret5;
                for (int i = 1; i <= 5; i++)
                {
                    dm_ret5 = CheckToFix(dmae, i);

                    if(dm_ret5 < userBattleInfo.FixMaxPercentage)//小于某一个数
                    {
                        userBattleInfo.NeedToFix = true;
                    }

                }
            }



            int dm_ret3 = CheckTeamSlectPage(dmae);
            while (dm_ret3 == 0)
            {
                LeftClick(dmae, 726, 614, 865, 666);
                delayTime(1);
                dm_ret3 = CheckTeamSlectPage(dmae);
            }

            int dm_ret1 = dmae.CmpColor(450, 470, "ffffff", 0.9);
            int dm_ret2 = dmae.CmpColor(610, 465, "ffffff", 0.9);
            while(dm_ret1 == 0&& dm_ret2 == 0)
            {
                LeftClick(dmae, 674, 469, 814, 522);
                delayTime(1,1);
                dm_ret1 = dmae.CmpColor(450, 470, "ffffff", 0.9);
                dm_ret2 = dmae.CmpColor(610, 465, "ffffff", 0.9);
            }


        }


        public int MoveAndFight(DmAe dmae, int x1, int y1, int x2, int y2, /*1*/int x3, int y3, int x4, int y4,/*2*/ int x5, int y5,int x6,int y6,int x99, int x98)//移动与战斗 //0不需要检查机遇点X99随机点 x98 0是横 1是束 
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "开始移动";

            //找到返回0 找不到返回1
            WriteLog.WriteError("开始判断梯队选取状态");
            a: while (FindTeamSelectLine(dmae, x5, y5, x6, y6, x98) == 1)
            {
                WriteLog.WriteError("没有找到");
                if (dmae.CmpColor(634, 14, "ffffff", 1) == 0 && dmae.CmpColor(643, 14, "ffffff", 1) == 0)
                {
                    WriteLog.WriteError("检测到正在战斗");
                    break;
                }
                WriteLog.WriteError("点击X1点");
                LeftClick(dmae, x1, y1, x2, y2);
                delayTime(1,1);
                
                int dm_ret5 = dmae.CmpColor(714, 609, "ffffff", 0.9);
                int dm_ret3 = dmae.CmpColor(1061, 609, "ffffff", 0.9);
                int dm_ret4 = dmae.CmpColor(930, 638, "ffffff", 0.9);
                if (dm_ret5 == 0 && dm_ret3 == 0 && dm_ret4 == 0)//判断是否点击到梯队列表
                {
                    LeftClick(dmae, 902, 612, 1053, 664);
                    delayTime(2);
                    dm_ret5 = dmae.CmpColor(714, 609, "ffffff", 0.9);
                    dm_ret3 = dmae.CmpColor(1061, 609, "ffffff", 0.9);
                    dm_ret4 = dmae.CmpColor(930, 638, "ffffff", 0.9);
                }
            }

            b: while (FindTeamSelectLine(dmae, x5, y5, x6, y6, x98) == 0)
            {
                WriteLog.WriteError("检测到梯队已选取");
                if (dmae.CmpColor(634, 14, "ffffff", 1) == 0 && dmae.CmpColor(643, 14, "ffffff", 1) == 0)
                {
                    WriteLog.WriteError("检测到正在战斗");
                    break;
                }
                WriteLog.WriteError("将点击X3点");
                LeftClick(dmae, x3, y3, x4, y4);
                delayTime(1);
                int dm_ret5 = dmae.CmpColor(714, 609, "ffffff", 0.9);
                int dm_ret3 = dmae.CmpColor(1061, 609, "ffffff", 0.9);
                int dm_ret4 = dmae.CmpColor(930, 638, "ffffff", 0.9);
                if (dm_ret5 == 0 && dm_ret3 == 0 && dm_ret4 == 0)
                {
                    LeftClick(dmae, 902, 612, 1053, 664);
                    delayTime(2);
                    dm_ret5 = dmae.CmpColor(714, 609, "ffffff", 0.9);
                    dm_ret3 = dmae.CmpColor(1061, 609, "ffffff", 0.9);
                    dm_ret4 = dmae.CmpColor(930, 638, "ffffff", 0.9);
                }
            }

            WriteLog.WriteError("完成移动命令");
            //检测机遇点

            if (x99 == 1)
            {
                int case1 = 0;

                //等待机遇窗口

                while(dmae.CmpColor(439, 165, "ffffff", 1) == 1 || dmae.CmpColor(523, 182, "ffffff", 1) ==1 || dmae.CmpColor(523, 165, "ffffff", 1) == 1)
                {
                    delayTime(1, 1);
                }

                if (Settings.Default.RandomNotes == true)
                {
                    int dm_retsave = dmae.Capture(425, 150, 963, 599, "\\随机点记录\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".bmp");
                }

                if (Settings.Default.DebugMode == true)
                {
                    int dm_retsave = dmae.Capture(0, 0, 2000, 2000, "\\Debug\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".bmp");
                }
                int dm_ret10 = dmae.CmpColor(599, 497, "ffffff", 0.9);
                int dm_ret11 = dmae.CmpColor(785, 515, "ffffff", 0.9);
                if (dm_ret10 == 0 && dm_ret11 == 0) { case1 = 1; }

                int dm_ret12 = dmae.CmpColor(479, 499, "ffffff", 0.9);
                int dm_ret13 = dmae.CmpColor(909, 510, "ffffff", 0.9);
                if (dm_ret12 == 0 && dm_ret13 == 0) { case1 = 2; }

                Random ran = new Random();
                int tempx = ran.Next(387, 1243);
                int tempy = ran.Next(55, 643);

                switch (case1)
                {
                    case 1://遭遇伏击
                        {

                            while (dmae.CmpColor(439, 165, "ffffff", 1) == 0 && dmae.CmpColor(523, 182, "ffffff", 1) == 0&&  dmae.CmpColor(523, 165, "ffffff", 1) == 0)
                            {
                                LeftClick(dmae, 413, 134, 982, 606);
                                delayTime(1);
                            }


                            int dm_ret29 = dmae.CmpColor(635, 695, "ffffff", 0.9);
                            int dm_ret30 = dmae.CmpColor(645, 705, "ffffff", 0.9);
                            while (dm_ret29 == 1 || dm_ret30 == 1)//确保等到战斗开始
                            {
                                delayTime(0.1, 1);
                                dm_ret29 = dmae.CmpColor(635, 695, "ffffff", 0.9);
                                dm_ret30 = dmae.CmpColor(645, 705, "ffffff", 0.9);
                            }

                            while (dm_ret29 == 0 && dm_ret30 == 0)//检测到暂停键则点击
                            {
                                tempx = ran.Next(605, 674);
                                tempy = ran.Next(693, 711);
                                dmae.MoveTo(tempx, tempy);
                                dmae.LeftDown();
                                delayTime(0.3, 1);
                                dmae.LeftUp();
                                delayTime(1);
                                dm_ret29 = dmae.CmpColor(635, 695, "ffffff", 0.9);
                                dm_ret30 = dmae.CmpColor(645, 705, "ffffff", 0.9);
                            }

                            int dm_ret31 = dmae.CmpColor(814, 683, "ffffff", 0.9);
                            int dm_ret32 = dmae.CmpColor(789, 683, "ffffff", 0.9);
                            int dm_ret33 = dmae.CmpColor(800, 695, "ffffff", 0.9);
                            while (dm_ret31 == 0 && dm_ret32 == 0 && dm_ret33 == 0)
                            {
                                LeftClick(dmae, 342, 665, 539, 708);
                                delayTime(1);
                                dm_ret31 = dmae.CmpColor(814, 683, "ffffff", 0.9);
                                dm_ret32 = dmae.CmpColor(789, 683, "ffffff", 0.9);
                                dm_ret33 = dmae.CmpColor(800, 695, "ffffff", 0.9);
                            }

                            //}

                            ran = null;
                                break;
                        }
                    case 2://强制撤离
                        {
                            while (dmae.CmpColor(439, 165, "ffffff", 1) == 0&& dmae.CmpColor(523, 182, "ffffff", 1) == 0 && dmae.CmpColor(523, 165, "ffffff", 1) == 1)
                            {
                                LeftClick(dmae, 413, 134, 982, 606);
                                delayTime(1);
                            }

                            return 2;
                        }
                    default: break;

                }






            }

            //2017.1.27新代码重写战斗部分
            while (dmae.CmpColor(634, 14, "ffffff", 1) == 1 && dmae.CmpColor(643, 14, "ffffff", 1) == 1)
            {
                WindowsFormsApplication1.BaseData.SystemInfo.AppState = "移动中";
                delayTime(0.5);

                if(dmae.CmpColor(634, 14, "ffffff", 1) == 0 && dmae.CmpColor(643, 14, "ffffff", 1) == 0)
                {
                    break;
                }

                if(FindTeamSelectLine(dmae, x5, y5, x6, y6, x98) == 1)
                {
                    goto a;
                }

                if(FindTeamSelectLine(dmae, x5, y5, x6, y6, x98) == 0)
                {
                    goto b;
                }
            }

            while (dmae.CmpColor(634, 14, "ffffff", 1) == 0 && dmae.CmpColor(643, 14, "ffffff", 1) == 0)
            {
                WindowsFormsApplication1.BaseData.SystemInfo.AppState = "战斗中";

                if(CheckBattleMapReady(dmae) == 0)
                {
                    break;
                }

                while (CheckBattleMapReady(dmae) == 1)
                {
                    if (dmae.CmpColor(640, 15, "ffffff", 1) == 0)                //暂停判断
                    {
                        LeftClick(dmae, 615, 10, 665, 25);
                        delayTime(1);
                    }
                    //暂停判断结束
                    //任意点击
                    LeftClick(dmae, 315, 111, 1076, 531);
                    delayTime(1, 1);
                }
            }

            while (CheckBattleMapReady(dmae) == 1)
            {
                WindowsFormsApplication1.BaseData.SystemInfo.AppState = "等待";
                LeftClick(dmae, 315, 111, 1076, 531);
                delayTime(0.5);
            }


            //while (CheckBattleMapReady(dmae)==1)
            //{
            //    variables.AppState = "移动中";
            //    delayTime(0.5);
            //    if (dmae.CmpColor(634, 14, "ffffff", 1) == 0 && dmae.CmpColor(643, 14, "ffffff", 1) == 0)
            //    {
            //        variables.AppState = "战斗中";
            //        while(CheckBattleMapReady(dmae) == 0)
            //        {
            //            if (dmae.CmpColor(640, 15, "ffffff", 1) == 0)                //暂停判断
            //            {
            //                LeftClick(dmae,615, 10, 665, 25);
            //                delayTime(1);
            //            }
            //            //暂停判断结束
            //            //任意点击
            //            LeftClick(dmae, 315, 111, 1076, 531);
            //            delayTime(1, 1);
            //        }
            //        break;
            //    }

            //}



            ////dm_ret2 =1 不匹配表示已经进入战斗界面
            ////开始检测是否按到暂停键

            //int dm_ret6 = dmae.CmpColor(640, 15, "ffffff", 1);
            ////开始循环是否战斗结束到大地图界面，其中鼠标点击
            //while(CheckBattleMapReady(dmae) == 1)
            //{
            //    //暂停判断
            //    dm_ret6 = dmae.CmpColor(640, 15, "ffffff", 1);
            //    if(dm_ret6 == 0)
            //    {
            //        LeftClick(dmae, 615, 10, 665, 25);
            //        delayTime(1);
            //        dm_ret6 = dmae.CmpColor(640, 15, "ffffff", 1);
            //    }
            //    //暂停判断结束
            //    //任意点击
            //    LeftClick(dmae, 315, 111, 1076, 531);
            //    delayTime(1,1);
            //}






            //int dm_ret2 = dmae.CmpColor(285, 40, "ff5500" + "|" + Settings.Default.Battle0, 0.9);

            //while (dm_ret2 == 0)
            //{
            //    LeftClick(dmae, 437, 162, 953, 588);
            //    delayTime(2);
            //    dm_ret2 = dmae.CmpColor(285, 40, "ff5500" + "|" + Settings.Default.Battle0, 0.9);
            //}

            //while (dm_ret2 == 1)
            //{
            //    LeftClick(dmae, 315, 111, 1076, 531);
            //    delayTime(1);
            //    dm_ret2 = dmae.CmpColor(285, 40, "ff5500" + "|" + Settings.Default.Battle0, 0.9);//用户自定义颜色
            //    int dm_ret3 = dmae.CmpColor(640, 15, "ffffff", 1);
            //    while (dm_ret3 == 0)//暂停判断
            //    {
            //        LeftClick(dmae, 615, 10, 665, 25);
            //        delayTime(1);
            //        dm_ret3 = dmae.CmpColor(640, 15, "ffffff", 1);
            //    }
            //}
            //delayTime(1);
            return 99;
        }

        public void StopBattle(DmAe dmae)//作战中止
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "中止作战";
            
            int dm_ret0 = dmae.CmpColor(925, 160, "ffffff", 1);
            int dm_ret1 = dmae.CmpColor(957, 160, "ffffff", 1);
            int dm_ret2 = dmae.CmpColor(403, 266, "ffffff", 1);
            int dm_ret3 = dmae.CmpColor(705, 272, "ffffff", 1);

            while (dm_ret0 == 1 || dm_ret1 == 1 || dm_ret2 == 1 || dm_ret3 == 1)
            {
                LeftClick(dmae, 271, 14, 360, 76);
                delayTime(1);
                dm_ret0 = dmae.CmpColor(925, 160, "ffffff", 1);
                dm_ret1 = dmae.CmpColor(957, 160, "ffffff", 1);
                dm_ret2 = dmae.CmpColor(403, 266, "ffffff", 1);
                dm_ret3 = dmae.CmpColor(705, 272, "ffffff", 1);
            }

            while(dm_ret0 == 0 && dm_ret1 == 0 && dm_ret2 == 0 && dm_ret3 == 0)
            {
                if (SystemInfo.StayAtHomePage) { break; }


                LeftClick(dmae, 716, 465, 860, 508);//直接返回主页
                delayTime(1,1);
                dm_ret0 = dmae.CmpColor(925, 160, "ffffff", 1);
                dm_ret1 = dmae.CmpColor(957, 160, "ffffff", 1);
                dm_ret2 = dmae.CmpColor(403, 266, "ffffff", 1);
                dm_ret3 = dmae.CmpColor(705, 272, "ffffff", 1);
            }

            if (SystemInfo.StayAtHomePage == false)
            {
                delayTime(0.1, 1);
            }


        }

        public void ClickBackToBattle(DmAe dmae)//从地图返回到作战地图选择页面
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "返回";
            int dm_ret0 = dmae.CmpColor(130, 15, "ffffff", 0.9);
            int dm_ret1 = dmae.CmpColor(245, 10, "ffffff", 0.9);

            while (dm_ret0 == 0 && dm_ret1 == 0)
            {
                LeftClick(dmae, 14, 15, 123, 75);
                delayTime(1);
                dm_ret0 = dmae.CmpColor(130, 15, "ffffff", 0.9);
                dm_ret1 = dmae.CmpColor(245, 10, "ffffff", 0.9);
            }
        }

        public void LeftClickBackHome(DmAe dmae)//回首页
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "返回主页";
            //2017.1.29重构
            while(dmae.CmpColor(138, 2, "ffffff", 0.9) ==1 && dmae.CmpColor(1140, 20, "ffffff", 0.9) == 1)
            {
                delayTime(1);
            }

            //等待拆解完成

            //检查是否在主页

            while(CheckHomePage(dmae) == 1)
            {
                if(dmae.CmpColor(138, 2, "ffffff", 0.9) == 0 && dmae.CmpColor(1140, 20, "ffffff", 0.9) == 0)
                {
                    LeftClick(dmae, 54, 6, 133, 19);
                }
                else
                {
                    delayTime(1);
                }
            }







        }

        public bool WaitToHome(DmAe dmae)
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "等待回到主页";

            while (CheckHomePage(dmae) == 1 )
            {
                delayTime(1);
                return false;
            }
            return true;
        }

        public int OpenFixBox(DmAe dmae, int N)
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "打开修复槽";
            int dm_ret;
            switch (N)
            {
                case 1:
                    {
                        dm_ret = dmae.CmpColor(132, 7, "ffffff", 1);
                        while (dm_ret == 1)
                        {
                            LeftClick(dmae, 71, 172, 210, 656);
                            delayTime(1, 1);
                            dm_ret = dmae.CmpColor(132, 7, "ffffff", 1);
                            dmae.WheelDown();
                            delayTime(1, 1);
                            //检测是否有“没有要修复窗体”
                            if (dm_ret == 1)
                            {
                                while (dmae.CmpColor(558, 489, "ffffff", 1) == 0 && dmae.CmpColor(721, 489, "ffffff", 1) == 0 && dmae.CmpColor(616, 517, "ffffff", 1) == 0)  
                                {
                                    LeftClick(dmae, 580, 499, 696, 541);
                                    delayTime(1,1);
                                }
                                return 1;//失败
                            }

                        }
                        break;
                    }

                case 2:
                    {
                        dm_ret = dmae.CmpColor(132, 7, "ffffff", 1);
                        while (dm_ret == 1)
                        {
                            LeftClick(dmae, 244, 163, 392, 620);
                            delayTime(1, 1);
                            dm_ret = dmae.CmpColor(132, 7, "ffffff", 1);
                            dmae.WheelDown();
                            delayTime(1, 1);


                            //检测是否有“没有要修复窗体”
                            if (dm_ret == 1)
                            {
                                while (dmae.CmpColor(558, 489, "ffffff", 1) == 0 && dmae.CmpColor(721, 489, "ffffff", 1) == 0 && dmae.CmpColor(616, 517, "ffffff", 1) == 0)
                                {
                                    LeftClick(dmae, 580, 499, 696, 541);
                                    delayTime(1, 1);
                                }
                                return 1;//失败
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        dm_ret = dmae.CmpColor(132, 7, "ffffff", 1);
                        while (dm_ret == 1)
                        {
                            LeftClick(dmae, 429, 172, 577, 652);
                            delayTime(1,1);
                            dm_ret = dmae.CmpColor(132, 7, "ffffff", 1);
                            dmae.WheelDown();
                            delayTime(1, 1);
                            //检测是否有“没有要修复窗体”
                            if (dm_ret == 1)
                            {
                                while (dmae.CmpColor(558, 489, "ffffff", 1) == 0 && dmae.CmpColor(721, 489, "ffffff", 1) == 0 && dmae.CmpColor(616, 517, "ffffff", 1) == 0)
                                {
                                    LeftClick(dmae, 580, 499, 696, 541);
                                    delayTime(1, 1);
                                }
                                return 1;//失败
                            }
                        }
                        break;
                    }
                case 4:
                    {
                        dm_ret = dmae.CmpColor(132, 7, "ffffff", 1);
                        while (dm_ret == 1)
                        {
                            LeftClick(dmae, 616, 168, 769, 622);
                            delayTime(1, 1);
                            dm_ret = dmae.CmpColor(132, 7, "ffffff", 1);
                            dmae.WheelDown();
                            delayTime(1, 1);
                            //检测是否有“没有要修复窗体”
                            if (dm_ret == 1)
                            {
                                while (dmae.CmpColor(558, 489, "ffffff", 1) == 0 && dmae.CmpColor(721, 489, "ffffff", 1) == 0 && dmae.CmpColor(616, 517, "ffffff", 1) == 0)
                                {
                                    LeftClick(dmae, 580, 499, 696, 541);
                                    delayTime(1, 1);
                                }
                                return 1;//失败
                            }
                        }
                        break;
                    }
                case 5:
                    {
                        dm_ret = dmae.CmpColor(132, 7, "ffffff", 1);
                        while (dm_ret == 1)
                        {
                            LeftClick(dmae, 801, 170, 942, 631);
                            delayTime(1, 1);
                            dm_ret = dmae.CmpColor(132, 7, "ffffff", 1);
                            dmae.WheelDown();
                            delayTime(1, 1);
                            //检测是否有“没有要修复窗体”
                            if (dm_ret == 1)
                            {
                                while (dmae.CmpColor(558, 489, "ffffff", 1) == 0 && dmae.CmpColor(721, 489, "ffffff", 1) == 0 && dmae.CmpColor(616, 517, "ffffff", 1) == 0)
                                {
                                    LeftClick(dmae, 580, 499, 696, 541);
                                    delayTime(1, 1);
                                }
                                return 1;//失败
                            }
                        }
                        break;
                    }
                case 6:
                    {
                        dm_ret = dmae.CmpColor(132, 7, "ffffff", 1);
                        while (dm_ret == 1)
                        {
                            LeftClick(dmae, 980, 161, 1128, 643);
                            delayTime(1, 1);
                            dm_ret = dmae.CmpColor(132, 7, "ffffff", 1);
                            dmae.WheelDown();
                            delayTime(1, 1);
                            //检测是否有“没有要修复窗体”
                            if (dm_ret == 1)
                            {
                                while (dmae.CmpColor(558, 489, "ffffff", 1) == 0 && dmae.CmpColor(721, 489, "ffffff", 1) == 0 && dmae.CmpColor(616, 517, "ffffff", 1) == 0)
                                {
                                    LeftClick(dmae, 580, 499, 696, 541);
                                    delayTime(1, 1);
                                }
                                return 1;//失败
                            }
                        }
                        break;
                    }
                case 7:
                    {
                        dm_ret = dmae.CmpColor(132, 7, "ffffff", 1);
                        while (dm_ret == 1)
                        {
                            LeftClick(dmae, 1163, 174, 1273, 658);
                            delayTime(1, 1);
                            dm_ret = dmae.CmpColor(132, 7, "ffffff", 1);
                            dmae.WheelDown();
                            delayTime(1, 1);
                            //检测是否有“没有要修复窗体”
                            if (dm_ret == 1)
                            {
                                while (dmae.CmpColor(558, 489, "ffffff", 1) == 0 && dmae.CmpColor(721, 489, "ffffff", 1) == 0 && dmae.CmpColor(616, 517, "ffffff", 1) == 0)
                                {
                                    LeftClick(dmae, 580, 499, 696, 541);
                                    delayTime(1, 1);
                                }
                                return 1;//失败
                            }
                        }
                        break;
                    }
                default:
                    break;
            }
            return 0;




        }

        public bool CheckGirlFix(DmAe dmae)//检查是否在后勤训练而无法修复
        {
            int dm_ret0 = dmae.CmpColor(132, 7, "ffffff", 0.9);
            int dm_ret1 = dmae.CmpColor(131, 89, "ffffff", 0.9);
            while (dm_ret0 == 1 || dm_ret1 == 1)
            {
                LeftClick(dmae, 567, 499, 703, 540);
                dm_ret0 = dmae.CmpColor(132, 7, "ffffff", 0.9);
                dm_ret1 = dmae.CmpColor(131, 89, "ffffff", 0.9);
                if (dm_ret0 == 0 && dm_ret1 == 0) { return true; }
            }
            return false;
        }

        public int ClickGirl(DmAe dmae,FixGirlsInfo userFixGirlsInfo)//返回0表示选取成功返回1则表示后勤中等
        {
            //2017.1.27重写
            //检测是否在选取待修复少女页面上

            delayTime(1);
            while(CheckSelectFixGirlPage(dmae) == 1)
            {
                delayTime(0.5);
            }

            switch (userFixGirlsInfo.Location)
            {
                case 1:
                    {
                        //判断是否点击成功
                        while(dmae.CmpColor(9, 111, userFixGirlsInfo.Color,1) == 0)//返回0表示颜色匹配需要再点击
                        {
                            LeftClick(dmae, 17, 158, 159, 329);
                            delayTime(1);
                        }
                        //点击第一位
                        break;
                    }
                case 2:
                    {
                        //判断是否点击成功
                        while (dmae.CmpColor(188, 111, userFixGirlsInfo.Color, 1) == 0)//返回0表示颜色匹配需要再点击
                        {
                            LeftClick(dmae, 198, 161, 338, 367);
                            delayTime(1);
                        }
                        //点击第一位
                        break;
                    }
                case 3:
                    {
                        //判断是否点击成功
                        while (dmae.CmpColor(366, 111, userFixGirlsInfo.Color, 1) == 0)//返回0表示颜色匹配需要再点击
                        {
                            LeftClick(dmae, 372, 143, 518, 380);
                            delayTime(1);
                        }
                        //点击第一位
                        break;
                    }
                case 4:
                    {
                        //判断是否点击成功
                        while (dmae.CmpColor(545, 397, userFixGirlsInfo.Color, 1) == 0)//返回0表示颜色匹配需要再点击
                        {
                            LeftClick(dmae, 556, 140, 703, 363);
                            delayTime(1);
                        }
                        //点击第一位
                        break;
                    }
                case 5:
                    {
                        //判断是否点击成功
                        while (dmae.CmpColor(724, 397, userFixGirlsInfo.Color, 1) == 0)//返回0表示颜色匹配需要再点击
                        {
                            LeftClick(dmae, 733, 131, 876, 372);
                            delayTime(1);
                        }
                        //点击第一位
                        break;
                    }
                case 6:
                    {
                        //判断是否点击成功
                        while (dmae.CmpColor(902, 397, userFixGirlsInfo.Color, 1) == 0)//返回0表示颜色匹配需要再点击
                        {
                            LeftClick(dmae, 914, 164, 1052, 315);
                            delayTime(1);
                        }
                        //点击第一位
                        break;
                    }
                case 7:
                    {
                        //判断是否点击成功
                        while (dmae.CmpColor(9, 415, userFixGirlsInfo.Color, 1) == 0)//返回0表示颜色匹配需要再点击
                        {
                            LeftClick(dmae, 41, 468, 154, 606);
                            delayTime(1);
                        }
                        //点击第一位
                        break;
                    }
                case 8:
                    {
                        //判断是否点击成功
                        while (dmae.CmpColor(188, 415, userFixGirlsInfo.Color, 1) == 0)//返回0表示颜色匹配需要再点击
                        {
                            LeftClick(dmae, 199, 434, 336, 625);
                            delayTime(1);
                        }
                        //点击第一位
                        break;
                    }
                case 9:
                    {
                        //判断是否点击成功
                        while (dmae.CmpColor(366, 415, userFixGirlsInfo.Color, 1) == 0)//返回0表示颜色匹配需要再点击
                        {
                            LeftClick(dmae, 384, 438, 522, 629);
                            delayTime(1);
                        }
                        //点击第一位
                        break;
                    }
                case 10:
                    {
                        //判断是否点击成功
                        while (dmae.CmpColor(545, 415, userFixGirlsInfo.Color, 1) == 0)//返回0表示颜色匹配需要再点击
                        {
                            LeftClick(dmae, 558, 444, 684, 631);
                            delayTime(1);
                        }
                        //点击第一位
                        break;
                    }
                case 11:
                    {
                        //判断是否点击成功
                        while (dmae.CmpColor(724, 415, userFixGirlsInfo.Color, 1) == 0)//返回0表示颜色匹配需要再点击
                        {
                            LeftClick(dmae, 740, 433, 876, 622);
                            delayTime(1);
                        }
                        //点击第一位
                        break;
                    }
                case 12:
                    {
                        //判断是否点击成功
                        while (dmae.CmpColor(902, 415, userFixGirlsInfo.Color, 1) == 0)//返回0表示颜色匹配需要再点击
                        {
                            LeftClick(dmae, 909, 435, 1057, 594);
                            delayTime(1);
                        }
                        //点击第一位
                        break;
                    }
                default:
                    break;
            }





            //int dm_ret, dm_ret1;
            //switch (N)
            //{
            //    case 1:
            //        {
            //            dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);//返回1代表不相同点击未成功 时钟
            //            dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //            while (dm_ret == 1 || dm_ret1 == 1)
            //            {
            //                LeftClick(dmae, 17, 158, 159, 329);
            //                delayTime(1);
            //                dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);
            //                dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //                if (dm_ret == 1)
            //                {
            //                    if (CheckGirlFix(dmae) == true) { return 1; }

            //                }
            //            }
            //            break;
            //        }

            //    case 2:
            //        {
            //            dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);//返回1代表不相同点击未成功
            //            dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //            while (dm_ret == 1 || dm_ret1 == 1)
            //            {
            //                LeftClick(dmae, 198, 161, 338, 367);
            //                delayTime(1);
            //                dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);
            //                dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //                if (dm_ret == 1)
            //                {
            //                    if (CheckGirlFix(dmae) == true) { return 1; }

            //                }
            //            }
            //            break;
            //        }

            //    case 3:
            //        {
            //            dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);//返回1代表不相同点击未成功
            //            dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //            while (dm_ret == 1 || dm_ret1 == 1)
            //            {
            //                LeftClick(dmae, 372, 143, 518, 380);
            //                delayTime(1);
            //                dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);
            //                dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //                if (dm_ret == 1)
            //                {
            //                    if (CheckGirlFix(dmae) == true) { return 1; }

            //                }
            //            }
            //            break;
            //        }
            //    case 4:
            //        {
            //            dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);//返回1代表不相同点击未成功
            //            dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //            while (dm_ret == 1 || dm_ret1 == 1)
            //            {
            //                LeftClick(dmae, 556, 140, 703, 363);
            //                delayTime(1);
            //                dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);
            //                dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //                if (dm_ret == 1)
            //                {
            //                    if (CheckGirlFix(dmae) == true) { return 1; }

            //                }
            //            }
            //            break;
            //        }
            //    case 5:
            //        {
            //            dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);//返回1代表不相同点击未成功
            //            dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //            while (dm_ret == 1 || dm_ret1 == 1)
            //            {
            //                LeftClick(dmae, 733, 131, 876, 372);
            //                delayTime(1);
            //                dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);
            //                dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //                if (dm_ret == 1)
            //                {
            //                    if (CheckGirlFix(dmae) == true) { return 1; }

            //                }
            //            }
            //            break;
            //        }
            //    case 6:
            //        {
            //            dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);//返回1代表不相同点击未成功
            //            dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //            while (dm_ret == 1 || dm_ret1 == 1)
            //            {
            //                LeftClick(dmae, 914, 154, 1056, 386);
            //                delayTime(1);
            //                dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);
            //                dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //                if (dm_ret == 1)
            //                {
            //                    if (CheckGirlFix(dmae) == true) { return 1; }

            //                }
            //            }
            //            break;
            //        }
            //    case 7:
            //        {
            //            dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);//返回1代表不相同点击未成功
            //            dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //            while (dm_ret == 1 || dm_ret1 == 1)
            //            {
            //                LeftClick(dmae, 20, 445, 157, 680);
            //                delayTime(1);
            //                dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);
            //                dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //                if (dm_ret == 1)
            //                {
            //                    if (CheckGirlFix(dmae) == true) { return 1; }

            //                }
            //            }
            //            break;
            //        }
            //    case 8:
            //        {
            //            dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);//返回1代表不相同点击未成功
            //            dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //            while (dm_ret == 1 || dm_ret1 == 1)
            //            {
            //                LeftClick(dmae, 197, 431, 332, 660);
            //                delayTime(1);
            //                dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);
            //                dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //                if (dm_ret == 1)
            //                {
            //                    if (CheckGirlFix(dmae) == true) { return 1; }

            //                }
            //            }
            //            break;
            //        }
            //    case 9:
            //        {
            //            dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);//返回1代表不相同点击未成功
            //            dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //            while (dm_ret == 1 || dm_ret1 == 1)
            //            {
            //                LeftClick(dmae, 377, 435, 517, 665);
            //                delayTime(1);
            //                dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);
            //                dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //                if (dm_ret == 1)
            //                {
            //                    if (CheckGirlFix(dmae) == true) { return 1; }

            //                }
            //            }
            //            break;
            //        }
            //    case 10:
            //        {
            //            dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);//返回1代表不相同点击未成功
            //            dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //            while (dm_ret == 1 || dm_ret1 == 1)
            //            {
            //                LeftClick(dmae, 558, 430, 688, 676);
            //                delayTime(1);
            //                dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);
            //                dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //                if (dm_ret == 1)
            //                {
            //                    if (CheckGirlFix(dmae) == true) { return 1; }

            //                }
            //            }
            //            break;
            //        }
            //    case 11:
            //        {
            //            dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);//返回1代表不相同点击未成功
            //            dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //            while (dm_ret == 1 || dm_ret1 == 1)
            //            {
            //                LeftClick(dmae, 737, 429, 870, 673);
            //                delayTime(1);
            //                dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);
            //                dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //                if (dm_ret == 1)
            //                {
            //                    if (CheckGirlFix(dmae) == true) { return 1; }

            //                }
            //            }
            //            break;
            //        }
            //    case 12:
            //        {
            //            dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);//返回1代表不相同点击未成功
            //            dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //            while (dm_ret == 1 || dm_ret1 == 1)
            //            {
            //                LeftClick(dmae, 920, 430, 1054, 682);
            //                delayTime(1);
            //                dm_ret = dmae.CmpColor(896, 272, "ffffff", 1);
            //                dm_ret1 = dmae.CmpColor(910, 330, "ffffff", 0.9);
            //                if (dm_ret == 1)
            //                {
            //                    if (CheckGirlFix(dmae) == true) { return 1; }

            //                }
            //            }
            //            break;
            //        }
            //    default:
            //        break;
            //}
            if (CheckGirlFix(dmae) == true) { return 1; }
            return 0;
        }

        public void ClickQuickFix(DmAe dmae)//使用快修
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "使用快速修复";
            //检查页面状态并按确定
            while(CheckSelectFixGirlPage(dmae) == 0)
            {
                LeftClick(dmae, 1109, 600, 1254, 682);
                delayTime(1);
            }

            while ((dmae.CmpColor(284, 477, "ffffff", 1) == 0) && (dmae.CmpColor(347, 477, "ffffff", 1) == 0) && (dmae.CmpColor(284, 537, "ffffff", 1) == 0) && (dmae.CmpColor(347, 537, "ffffff", 1) == 0))
            {
                LeftClick(dmae, 289, 481, 340, 531);
                delayTime(1);
            }
            ClickFixSure(dmae,true);
        }

        public void ClickNormalFix(DmAe dmae)//使用快修
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "普通修复";
            //检查页面状态并按确定
            while (CheckSelectFixGirlPage(dmae) == 0)
            {
                delayTime(1);
                LeftClick(dmae, 1109, 600, 1254, 682);
            }



        }

        public void ClickFixSure(DmAe dmae,bool QuickFix)
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "确认";
            while ((dmae.CmpColor(642, 476, "ffffff", 1) == 0) && (dmae.CmpColor(805, 476, "ffffff", 1) == 0) && (dmae.CmpColor(643, 536, "ffffff", 1) == 0) && (dmae.CmpColor(791, 530, "ffffff", 1) == 0))
            {
                LeftClick(dmae, 854, 488, 984, 525);

            }

            switch (QuickFix)
            {
                case true:
                    {
                        while ((dmae.CmpColor(721, 489, "ffffff", 1) == 1) || (dmae.CmpColor(721, 515, "ffffff", 1) == 1) || (dmae.CmpColor(558, 489, "ffffff", 1) == 1))
                        {
                            delayTime(1);
                        }
                        while ((dmae.CmpColor(721, 489, "ffffff", 1) == 0) && (dmae.CmpColor(721, 515, "ffffff", 1) == 0) && (dmae.CmpColor(558, 489, "ffffff", 1) == 0))
                        {
                            LeftClick(dmae, 558, 489, 721, 515);
                            delayTime(1);
                        }

                        while (CheckFixPage(dmae) == 1)
                        {
                            delayTime(1);
                        }
                        break;
                    }
                case false:
                    {
                        while (CheckFixPage(dmae) == 1)
                        {
                            delayTime(1);
                        }
                        break;
                    }
                default:
                    break;
            }


        }

        public void ClickCancelFix(DmAe dmae)
        {
            WindowsFormsApplication1.BaseData.SystemInfo.AppState = "取消修复";
            int dm_ret1 = dmae.CmpColor(800, 480, "ffffff", 1);

            while (dm_ret1 == 0)
            {
                LeftClick(dmae, 649, 481, 790, 533);
                delayTime(1);
                dm_ret1 = dmae.CmpColor(800, 480, "ffffff", 1);
            }

        }

        public void Team_SeclectClickCancel(DmAe dmae)
        {
            LeftClick(dmae, 905, 612, 1044, 664);
        }

        public int LoadFixGirlInfo(DmAe dmae,ref List<FixGirlsInfo> GirlsInfo,UserBattleInfo userBattleInfo)
        {
            int n=0;
            GirlsInfo.Clear();
            string dm_RetN1 = dmae.GetColor(9, 112);

            for (int i = 9, x = 1; i <= 167; i++, x++)
            {

                string temp = dmae.GetColor(9 + x, 112);
                if (temp == dm_RetN1)
                {
                    //判断是否相等
                    //判断是否循环到最后
                    if (i == 59)//167
                    {
                        FixGirlsInfo tempFixGirlsInfo1 = new FixGirlsInfo();
                        n += 1;
                        tempFixGirlsInfo1.Color = dmae.GetColor(9, 111);

                        tempFixGirlsInfo1.Location = 1;
                        tempFixGirlsInfo1.Hp= FixPageCheckTheHP(dmae, n);
                        tempFixGirlsInfo1.CheckNeedQfix(userBattleInfo);
                        GirlsInfo.Add(tempFixGirlsInfo1);
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            dm_RetN1 = dmae.GetColor(188, 112);
            for (int i = 188, x = 1; i <= 346; i++, x++)
            {

                string temp = dmae.GetColor(188 + x, 112);
                if (temp == dm_RetN1)
                {
                    //判断是否相等
                    //判断是否循环到最后
                    if (i == 238)//346
                    {
                        FixGirlsInfo tempFixGirlsInfo2 = new FixGirlsInfo();
                        n += 1;
                        tempFixGirlsInfo2.Color = dmae.GetColor(188, 111);
                        tempFixGirlsInfo2.Location = 2;
                        tempFixGirlsInfo2.Hp = FixPageCheckTheHP(dmae, n);
                        tempFixGirlsInfo2.CheckNeedQfix(userBattleInfo);
                        GirlsInfo.Add(tempFixGirlsInfo2);
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            dm_RetN1 = dmae.GetColor(366, 112);
            for (int i = 366, x = 1; i <= 525; i++, x++)
            {

                string temp = dmae.GetColor(366 + x, 112);
                if (temp == dm_RetN1)
                {
                    //判断是否相等
                    //判断是否循环到最后
                    if (i == 416)//
                    {
                        FixGirlsInfo tempFixGirlsInfo3 = new FixGirlsInfo();
                        n += 1;
                        tempFixGirlsInfo3.Color = dmae.GetColor(366, 111);
                        tempFixGirlsInfo3.Location = 3;
                        tempFixGirlsInfo3.Hp = FixPageCheckTheHP(dmae, n);
                        tempFixGirlsInfo3.CheckNeedQfix(userBattleInfo);
                        GirlsInfo.Add(tempFixGirlsInfo3);
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            //4
            dm_RetN1 = dmae.GetColor(545, 398);
            for (int i = 545, x = 1; i <= 704; i++, x++)
            {

                string temp = dmae.GetColor(545 + x, 398);
                if (temp == dm_RetN1)
                {
                    //判断是否相等
                    //判断是否循环到最后
                    if (i == 595)//704
                    {
                        FixGirlsInfo tempFixGirlsInfo4 = new FixGirlsInfo();
                        n += 1;
                        tempFixGirlsInfo4.Color = dmae.GetColor(545, 397);
                        tempFixGirlsInfo4.Location = 4;
                        tempFixGirlsInfo4.Hp = FixPageCheckTheHP(dmae, n);
                        tempFixGirlsInfo4.CheckNeedQfix(userBattleInfo);
                        GirlsInfo.Add(tempFixGirlsInfo4);
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            dm_RetN1 = dmae.GetColor(724, 398);
            for (int i = 724, x = 1; i <= 883; i++, x++)
            {

                string temp = dmae.GetColor(724 + x, 398);
                if (temp == dm_RetN1)
                {
                    //判断是否相等
                    //判断是否循环到最后
                    if (i == 774)//883
                    {
                        FixGirlsInfo tempFixGirlsInfo5 = new FixGirlsInfo();
                        n += 1;
                        tempFixGirlsInfo5.Color = dmae.GetColor(724, 397); 
                        tempFixGirlsInfo5.Location = 5;
                        tempFixGirlsInfo5.Hp = FixPageCheckTheHP(dmae, n);
                        tempFixGirlsInfo5.CheckNeedQfix(userBattleInfo);
                        GirlsInfo.Add(tempFixGirlsInfo5);
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            dm_RetN1 = dmae.GetColor(902, 398);
            for (int i = 902, x = 1; i <= 1061; i++, x++)
            {

                string temp = dmae.GetColor(902 + x, 398);
                if (temp == dm_RetN1)
                {
                    //判断是否相等
                    //判断是否循环到最后
                    if (i == 952)//1061
                    {
                        FixGirlsInfo tempFixGirlsInfo6 = new FixGirlsInfo();
                        n += 1;
                        tempFixGirlsInfo6.Location = 6;
                        tempFixGirlsInfo6.Color = dmae.GetColor(902, 397);
                        tempFixGirlsInfo6.Hp = FixPageCheckTheHP(dmae, n);
                        tempFixGirlsInfo6.CheckNeedQfix(userBattleInfo);
                        GirlsInfo.Add(tempFixGirlsInfo6);
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            dm_RetN1 = dmae.GetColor(9, 416);
            for (int i = 9, x = 1; i <= 168; i++, x++)
            {

                string temp = dmae.GetColor(9 + x, 416);
                if (temp == dm_RetN1)
                {
                    //判断是否相等
                    //判断是否循环到最后
                    if (i == 59)//168
                    {
                        FixGirlsInfo tempFixGirlsInfo7 = new FixGirlsInfo();
                        n += 1;
                        tempFixGirlsInfo7.Location = 7;
                        tempFixGirlsInfo7.Color = dmae.GetColor(9, 415);
                        tempFixGirlsInfo7.Hp = FixPageCheckTheHP(dmae, n);
                        tempFixGirlsInfo7.CheckNeedQfix(userBattleInfo);
                        GirlsInfo.Add(tempFixGirlsInfo7);
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            //8
            dm_RetN1 = dmae.GetColor(188, 416);
            for (int i = 188, x = 1; i <= 346; i++, x++)
            {

                string temp = dmae.GetColor(188 + x, 416);
                if (temp == dm_RetN1)

                    //判断是否相等
                    //判断是否循环到最后
                    if (i == 238)//346
                    {

                        FixGirlsInfo tempFixGirlsInfo8 = new FixGirlsInfo();
                        n += 1;
                        tempFixGirlsInfo8.Location = 8;
                        tempFixGirlsInfo8.Color = dmae.GetColor(188, 415);
                        tempFixGirlsInfo8.Hp = FixPageCheckTheHP(dmae, n);
                        tempFixGirlsInfo8.CheckNeedQfix(userBattleInfo);
                        GirlsInfo.Add(tempFixGirlsInfo8);
                        break;

                    }
                    else
                {
                    break;
                }
            }

            dm_RetN1 = dmae.GetColor(366, 416);
            for (int i = 366, x = 1; i <= 525; i++, x++)
            {

                string temp = dmae.GetColor(366 + x, 416);
                if (temp == dm_RetN1)
                {
                    //判断是否相等
                    //判断是否循环到最后
                    if (i == 416)//
                    {
                        FixGirlsInfo tempFixGirlsInfo9 = new FixGirlsInfo();
                        n += 1;
                        tempFixGirlsInfo9.Location = 9;
                        tempFixGirlsInfo9.Color = dmae.GetColor(366, 415);
                        tempFixGirlsInfo9.Hp = FixPageCheckTheHP(dmae, n);
                        tempFixGirlsInfo9.CheckNeedQfix(userBattleInfo);
                        GirlsInfo.Add(tempFixGirlsInfo9);
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            //10
            dm_RetN1 = dmae.GetColor(545, 416);
            for (int i = 545, x = 1; i <= 704; i++, x++)
            {

                string temp = dmae.GetColor(545 + x, 416);
                if (temp == dm_RetN1)
                {
                    //判断是否相等
                    //判断是否循环到最后
                    if (i == 595)//
                    {
                        FixGirlsInfo tempFixGirlsInfo10 = new FixGirlsInfo();
                        n += 1;
                        tempFixGirlsInfo10.Location = 10;
                        tempFixGirlsInfo10.Color = dmae.GetColor(545, 415);
                        tempFixGirlsInfo10.Hp = FixPageCheckTheHP(dmae, n);
                        tempFixGirlsInfo10.CheckNeedQfix(userBattleInfo);
                        GirlsInfo.Add(tempFixGirlsInfo10);
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            dm_RetN1 = dmae.GetColor(724, 416);
            for (int i = 724, x = 1; i <= 883; i++, x++)
            {

                string temp = dmae.GetColor(724 + x, 416);
                if (temp == dm_RetN1)
                {
                    //判断是否相等
                    //判断是否循环到最后
                    if (i == 774)//
                    {
                        FixGirlsInfo tempFixGirlsInfo11 = new FixGirlsInfo();
                        n += 1;
                        tempFixGirlsInfo11.Location = 11;
                        tempFixGirlsInfo11.Color = dmae.GetColor(724, 415);
                        tempFixGirlsInfo11.Hp = FixPageCheckTheHP(dmae, n);
                        tempFixGirlsInfo11.CheckNeedQfix(userBattleInfo);
                        GirlsInfo.Add(tempFixGirlsInfo11);
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            dm_RetN1 = dmae.GetColor(902, 416);
            for (int i = 902, x = 1; i <= 1061; i++, x++)
            {

                string temp = dmae.GetColor(902 + x, 416);
                if (temp == dm_RetN1)
                {
                    //判断是否相等
                    //判断是否循环到最后
                    if (i == 652)//1061
                    {
                        FixGirlsInfo tempFixGirlsInfo12 = new FixGirlsInfo();
                        n += 1;
                        tempFixGirlsInfo12.Location = 12;
                        tempFixGirlsInfo12.Color = dmae.GetColor(902, 415);
                        tempFixGirlsInfo12.Hp = FixPageCheckTheHP(dmae, n);
                        tempFixGirlsInfo12.CheckNeedQfix(userBattleInfo);
                        GirlsInfo.Add(tempFixGirlsInfo12);
                        break;
                    }
                }
                else
                {
                    break;
                }
            }




            return n;
        }



        









        //------------------多点比较颜色函数

        public int CheckToFix(DmAe dmae, int N)//梯队列表检查是否需要维修
        {
            int x1, y1, x2, y2, x3, y3, i;
            string dm_ret0, dm_ret1, dm_ret2;

            switch (N)
            {
                case 1:
                    {
                        x1 = 204; y1 = 503; x2 = 308; y2 = 503; x3 = 207; y3 = 512;
                        break;
                    }
                case 2:
                    {
                        x1 = 391; y1 = 503; x2 = 494; y2 = 503; x3 = 393; y3 = 512;
                        break;
                    }
                case 3:
                    {
                        x1 = 577; y1 = 503; x2 = 681; y2 = 503; x3 = 579; y3 = 512;
                        break;
                    }

                case 4:
                    {
                        x1 = 763; y1 = 503; x2 = 867; y2 = 503; x3 = 766; y3 = 512;
                        break;
                    }

                case 5:
                    {
                        x1 = 949; y1 = 503; x2 = 1053; y2 = 503; x3 = 952; y3 = 512;
                        break;
                    }
                default:
                    return -1;
            }

            dm_ret0 = dmae.GetColor(x1, y1);
            dm_ret1 = dmae.GetColor(x2, y2);
            if (dm_ret0 == dm_ret1)//判断是否满血或者没血
            {
                dm_ret2 = dmae.GetColor(x3, y3);
                if (dm_ret2 == dm_ret1)
                {
                    Console.WriteLine("0血");
                    return 0;
                    //0血状态
                }
                Console.WriteLine("满血");
                return 100;
                //满血状态
            }
            else
            {
                for (i = 0; i < (x2 - x1); i++)
                {
                    string dm_ret3 = dmae.GetColor(x1 + i, y1);
                    if (dm_ret3 != dm_ret0)
                    {
                        Console.WriteLine("x = " + (x1 + i).ToString());
                        break;
                    }
                }
                //检查
                Console.WriteLine("遍历完成 i = " + i.ToString());
                Console.WriteLine("百分比为" + Convert.ToInt32(((float)i / (x2 - x1) * 100) + 0.5).ToString());
                return Convert.ToInt32(((float)i / (x2 - x1) * 100) + 0.5);
            }


        }

        public int FixPageCheckTheHP(DmAe dmae, int N)//修复页面列表读取血量
        {
            int x1, y1, x2, y2, x3, y3, i;
            string dm_ret0, dm_ret1, dm_ret2;

            switch (N)
            {
                case 1:
                    {
                        x1 = 9; y1 = 335; x2 = 167;  y2 = 335;
                        break;
                    }
                case 2:
                    {
                        x1 = 187; y1 = 335; x2 = 346; y2 = 335;
                        break;
                    }
                case 3:
                    {
                        x1 = 366; y1 = 335; x2 = 525;  y2 = 335;
                        break;
                    }

                case 4:
                    {
                        x1 = 545; y1 = 335; x2 = 704; y2 = 335;
                        break;
                    }

                case 5:
                    {
                        x1 = 724;  y1 = 335; x2 = 882;  y2 = 335;
                        break;
                    }
                case 6:
                    {
                        x1 = 902;y1 = 335;x2= 1061;y2 = 335;
                        break;
                    }
                case 7:
                    {
                        x1 = 9; y1 = 638;x2 = 167; y2 = 638;
                        break;
                    }
                case 8:
                    {
                        x1= 167; y1 = 638;x2 = 346; y2 = 638;
                        break;
                    }
                case 9:
                    {
                        x1 =367; y1 = 638;x2= 525; y2 = 638;
                        break;
                    }
                case 10:
                    {
                        x1 = 546; y1 = 638;x2= 704; y2 = 638;
                        break;
                    }
                case 11:
                    {
                        x1= 725; y1 = 638;x2 = 882; y2 = 638;
                        break;
                    }
                case 12:
                    {
                        x1= 903; y1 = 638;x2= 1061; y2 = 638;
                        break;
                    }
                default:
                    return -1;
            }

            dm_ret0 = dmae.GetColor(x1, y1);
            dm_ret1 = dmae.GetColor(x2, y2);

            for (i = 0; i < (x2 - x1); i++)
            {
                string dm_ret3 = dmae.GetColor(x1 + i, y1);
                if (dm_ret3 != dm_ret0)
                {
                    //Console.WriteLine("x = " + (x1 + i).ToString());
                    break;
                }
            }
            //检查
            //Console.WriteLine("遍历完成 i = " + i.ToString());
            //Console.WriteLine("百分比为" + Convert.ToInt32(((float)i / (x2 - x1) * 100) + 0.5).ToString());
            int k = Convert.ToInt32(((float)i / (x2 - x1) * 100));
            return k;


        }

        public bool CheckIsBroken(DmAe dmae,int N)//检测是否大破
        {
            int x1, y1, x2, y2, x3, y3, x4, y4, x5, y5;
            string dm_ret1;
            string dm_main_ret0;
            int tempx;
            switch (N)//识别第N个是否大破
            {
                case 1:
                    {
                        x1 = 10; y1 = 155; x2 = 27; y2 = 155; x3 = 39; y3 = 155; x4 = 74; y4 = 155; x5 = 132; y5 = 155;
                        break;
                    }
                case 2:
                    {
                        x1 = 189; y1 = 155; x2 = 205; y2 = 155; x3 = 229; y3 = 155; x4 = 253; y4 = 155; x5 = 310; y5 = 155;
                        break;
                    }
                case 3:
                    {
                        x1 = 368; y1 = 155; x2 = 384; y2 = 155; x3 = 408; y3 = 155; x4 = 600; y4 = 155; x5 = 668; y5 = 155;
                        break;
                    }
                case 4:
                    {
                        x1 = 547; y1 = 155; x2 = 563; y2 = 155; x3 = 575; y3 = 155; x4 = 611; y4 = 155; x5 = 668; y5 = 155;
                        break;
                    }
                case 5:
                    {
                        x1 = 726; y1 = 155; x2 = 741; y2 = 155; x3 = 753; y3 = 155; x4 = 777; y4 = 155; x5 = 845; y5 = 155;
                        break;
                    }
                case 6:
                    {
                        x1 = 904; y1 = 155; x2 = 920; y2 = 155; x3 = 932; y3 = 155; x4 = 956; y4 = 155; x5 = 1025; y5 = 155;
                        break;
                    }
                case 7:
                    {
                        x1 = 10; y1 = 458; x2 = 28; y2 = 458; x3 = 39; y3 = 458; x4 = 51; y4 = 458; x5 = 130; y5 = 458;
                        break;
                    }
                case 8:
                    {
                        x1 = 189; y1 = 458; x2 = 207; y2 = 458; x3 = 219; y3 = 458; x4 = 231; y4 = 458; x5 = 310; y5 = 458;
                        break;
                    }

                case 9:
                    {
                        x1 = 368; y1 = 458; x2 = 385; y2 = 458; x3 = 576; y3 = 458; x4 = 600; y4 = 458; x5 = 668; y5 = 458;
                        break;
                    }
                case 10:
                    {
                        x1 = 547; y1 = 458; x2 = 565; y2 = 458; x3 = 588; y3 = 458; x4 = 600; y4 = 458; x5 = 667; y5 = 458;
                        break;
                    }
                case 11:
                    {
                        x1 = 725; y1 = 458; x2 = 743; y2 = 458; x3 = 755; y3 = 458; x4 = 790; y4 = 458; x5 = 845; y5 = 458;
                        break;
                    }
                case 12:
                    {
                        x1 = 904; y1 = 458; x2 = 921; y2 = 458; x3 = 945; y3 = 458; x4 = 958; y4 = 458; x5 = 1025; y5 = 458;
                        break;
                    }
                default:
                    return false;
            }

            for (int i = 1; i <= 5; i++)
            {
                switch (i)
                {
                    case 1:
                        {
                            dm_main_ret0 = dmae.GetColor(x1, y1);
                            tempx = x1;
                            break;
                        }
                    case 2:
                        {
                            dm_main_ret0 = dmae.GetColor(x2, y2);
                            tempx = x2;
                            break;
                        }
                    case 3:
                        {
                            dm_main_ret0 = dmae.GetColor(x3, y3);
                            tempx = x3;
                            break;
                        }
                    case 4:
                        {
                            dm_main_ret0 = dmae.GetColor(x4, y4);
                            tempx = x4;
                            break;
                        }
                    case 5:
                        {
                            dm_main_ret0 = dmae.GetColor(x5, y5);
                            tempx = x5;
                            break;
                        }
                    default:
                        {
                            dm_main_ret0 = dmae.GetColor(x1, y1);
                            tempx = x1;
                            break;
                        }
                }
                for (int y = 1; y <= 3; y++)
                {
                    dm_ret1 = dmae.GetColor(tempx + y, y1);
                    if (dm_main_ret0 != dm_ret1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public int CheckTeamSlectPage(DmAe dmae)//梯队详细列表
        {
            int dm_Ret0 = dmae.CmpColor(192, 90, "ffffff", 1);
            int dm_Ret1 = dmae.CmpColor(1000, 615, "ffffff", 1);
            int dm_Ret2 = dmae.CmpColor(388, 94, "ffffff", 1);
            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0)
            {
                return 0;//真0假1
            }

            else
            {
                return 1;
            }
        }

        public int CheckErrorWindows(DmAe dmae, int x1 = 558, int y1 = 489, int x2 = 721, int y2 = 489)
        {
            int dm_ret0 = dmae.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_ret1 = dmae.CmpColor(x2, y2, "ffffff", 0.9);

            if(dm_ret0 ==0 && dm_ret1 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }


        public int CheckMissionHelp(DmAe dmae, int x1 = 164, int y1 = 106, int x2 = 270, int y2 = 106, int x3 = 259, int y3 = 162)
        {
            int dm_Ret0 = dmae.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_Ret1 = dmae.CmpColor(x2, y2, "ffffff", 0.9);
            int dm_Ret2 = dmae.CmpColor(x3, y3, "ffffff", 0.9);

            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }

        public int ChooseLogisticsPageReady(DmAe dmae,int x1 = 435,int y1=395,int x2= 658,int y2 = 392,int x3 = 880,int y3=394,int x4= 1102,int y4 = 394)
        {
            int dm_Ret0 = dmae.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_Ret1 = dmae.CmpColor(x2, y2, "ffffff", 0.9);
            int dm_Ret2 = dmae.CmpColor(x3, y3, "ffffff", 0.9);
            int dm_Ret3 = dmae.CmpColor(x4, y4, "ffffff", 0.9);
            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0 && dm_Ret3 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }


        }

        public void CheckFixBox(DmAe dmae, ref List<int> list)
        {

            for (int x1 = 120, y1 = 291; x1 < 141; x1++, y1++)
            {
                if (dmae.GetColor(x1, 309) != "ffffff")
                {
                    break;
                }
                if (dmae.GetColor(140, y1) != "ffffff")
                {
                    break;
                }
                if (x1 == 140)
                {
                    list.Add(1);//第一个槽为空
                }
            }

            for (int x1 = 305, y1 = 291; x1 < 326; x1++, y1++)
            {
                if (dmae.GetColor(x1, 309) != "ffffff")
                {
                    break;
                }
                if (dmae.GetColor(324, y1) != "ffffff")
                {
                    break;
                }
                if (x1 == 325)
                {

                    list.Add(2);//第二个槽为空
                }
            }

            for (int x1 = 488, y1 = 291; x1 < 509; x1++, y1++)
            {
                if (dmae.GetColor(x1, 309) != "ffffff")
                {
                    break;
                }
                if (dmae.GetColor(509, y1) != "ffffff")
                {
                    break;
                }
                if (x1 == 508)
                {
                    list.Add(3);//第三个槽为空
                }
            }

            for (int x1 = 672, y1 = 291; x1 < 693; x1++, y1++)
            {
                if (dmae.GetColor(x1, 308) != "ffffff")
                {
                    break;
                }
                if (dmae.GetColor(691, y1) != "ffffff")
                {
                    break;
                }
                if (x1 == 692)
                {
                    list.Add(4);//第四个槽为空
                }
            }
            for (int x1 = 856, y1 = 291; x1 < 877; x1++, y1++)
            {
                if (dmae.GetColor(x1, 308) != "ffffff")
                {
                    break;
                }
                if (dmae.GetColor(876, y1) != "ffffff")
                {
                    break;
                }
                if (x1 == 856)
                {
                    list.Add(5);//第五个槽为空
                }
            }
            for (int x1 = 1039, y1 = 291; x1 < 1060; x1++, y1++)
            {
                if (dmae.GetColor(x1, 309) != "ffffff")
                {
                    break;
                }
                if (dmae.GetColor(1058, y1) != "ffffff")
                {
                    break;
                }
                if (x1 == 1059)
                {
                    list.Add(6);//第六个槽为空
                }
            }

            for (int x1 = 1223, y1 = 291; x1 < 1244; x1++, y1++)
            {
                if (dmae.GetColor(x1, 309) != "ffffff")
                {
                    break;
                }
                if (dmae.GetColor(1242, y1) != "ffffff")
                {
                    break;
                }
                if (x1 == 1243)
                {
                    list.Add(7);//第七个槽为空
                }
            }

        }
        public int CheckSelectFixGirlPage(DmAe dmae)//检测是否在选取待修复少女的页面
        {
            //符合返回0不符合1
            int dm_ret0 = dmae.CmpColor(10, 8, "ffffff", 1);
            int dm_ret1 = dmae.CmpColor(131, 8, "ffffff", 1);
            int dm_ret2 = dmae.CmpColor(10, 88, "ffffff", 1);
            int dm_ret3 = dmae.CmpColor(130, 88, "ffffff", 1);
            if(dm_ret0 == 0 && dm_ret1 == 0 && dm_ret2 == 0 && dm_ret3 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }

        public int CheckBattleMapReady(DmAe dmae, int x1 = 11,int y1 = 12, int x2 = 246, int y2 = 11, int x3 = 235, int y3 = 78)//检查战斗页面没有按战斗开始
        {
            int dm_Ret0 = dmae.CmpColor(x1, y1, "ffffff", 1);
            int dm_Ret1 = dmae.CmpColor(x2, y2, "ffffff", 1);
            int dm_Ret2 = dmae.CmpColor(x3, y3, "ffffff", 1);

            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }


        }

        public bool CheckBattleResult(DmAe dmae)
        {
            int dm_ret0 = dmae.CmpColor(74, 278, "ffffff", 1);
            int dm_ret1 = dmae.CmpColor(74, 333, "ffffff", 1);
            int dm_ret2 = dmae.CmpColor(74, 387, "ffffff", 1);
            int dm_ret3 = dmae.CmpColor(74, 431, "ffffff", 1);
            int dm_ret4 = dmae.CmpColor(296, 431, "ffffff", 1);
            if (dm_ret0 == 0 && dm_ret1 == 0 && dm_ret2 == 0 && dm_ret3 == 0 & dm_ret4 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool CheckNewGunPage(DmAe dmae)
        {
            for(int x=1088,y=675;x< 1102; x++)
            {
                if (dmae.CmpColor(x, y, "ffffff", 1) == 1 )
                {
                    return false;
                }
                else if(dmae.CmpColor(126, 25, "ffffff", 1) == 0)
                {
                    return false;
                }
                     
            }
            return true;
        }

        public int CheckRandomPointWindows(DmAe dmae, int x1 = 439, int y1 = 165, int x2 = 523, int y2 = 182, int x3 = 523, int y3 = 165)//检查随机点窗口
        {
            int dm_Ret0 = dmae.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_Ret1 = dmae.CmpColor(x2, y2, "ffffff", 0.9);
            int dm_Ret2 = dmae.CmpColor(x3, y3, "ffffff", 0.9);
            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int CheckActionCount(DmAe dmae, int x1 = 1012, int y1 = 639, int x2 = 1080, int y2 = 639)
        {
            int dm_Ret0 = dmae.CmpColor(x1, y1, "ffffff", 1);
            int dm_Ret1 = dmae.CmpColor(x2, y2, "ffffff", 1);
            if (dm_Ret0 == 0 && dm_Ret1 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int CheckBattleEnd(DmAe dmae, int x1 = 1049, int y1 = 637, int x2 = 1037, int y2 = 145, int x3 = 932, int y3 = 569)//检查回合开始
        {
            int dm_Ret0 = dmae.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_Ret1 = dmae.CmpColor(x2, y2, "ffffff", 0.9);
            int dm_Ret2 = dmae.CmpColor(x3, y3, "ffffff", 0.9);
            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int CheckBattleStart(DmAe dmae, int x1 = 849, int y1 = 184, int x2 = 1148, int y2 = 184, int x3 = 849, int y3 = 454, int x4 = 119, int y4 = 246, int x5 = 722, int y5 = 327, int x6 = 314, int y6 = 24, int x7 = 50, int y7 = 655)//检查回合开始
        {
            int dm_Ret0 = dmae.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_Ret1 = dmae.CmpColor(x2, y2, "ffffff", 0.9);
            int dm_Ret2 = dmae.CmpColor(x3, y3, "ffffff", 0.9);
            int dm_Ret3 = dmae.CmpColor(x4, y4, "ffffff", 0.9);
            int dm_Ret4 = dmae.CmpColor(x5, y5, "ffffff", 0.9);
            int dm_Ret5 = dmae.CmpColor(x6, y6, "ffffff", 0.9);
            int dm_Ret6 = dmae.CmpColor(x7, y7, "ffffff", 0.9);
            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0 && dm_Ret3 == 0 && dm_Ret4 == 0 && dm_Ret5 == 1 && dm_Ret6 == 1)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int CheckHomePage(DmAe dmae , int x1 = 1100, int y1 = 690, int x2 = 975, int y2 = 680, int x3 = 695, int y3 = 25)
        {
            int dm_Ret0 = dmae.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_Ret1 = dmae.CmpColor(x2, y2, "ffffff", 0.9);
            int dm_Ret2 = dmae.CmpColor(x3, y3, "ffffff", 0.9);
            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0)
            {
                if (dmae.CmpColor(126, 25, "ffffff", 1) == 0)
                {
                    return 1;
                }
                return 0;//相同返回0
            }
            else
            {
                return 1;
            }
        }

        public int CheckBattlePage(DmAe dmae, int x1 = 986, int y1 = 30, int x2 = 5, int y2 = 94, int x3 = 138, int y3 = 94, int x4 = 138, int y4 = 1)
        {
            int dm_Ret0 = dmae.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_Ret1 = dmae.CmpColor(x2, y2, "ffffff", 0.9);
            int dm_Ret2 = dmae.CmpColor(x3, y3, "ffffff", 0.9);
            int dm_Ret3 = dmae.CmpColor(x3, y3, "ffffff", 0.9);

            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0 && dm_Ret3 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int CheckFixPage(DmAe dmae, int x1 = 204, int y1 = 63, int x2 = 138, int y2 = 1, int x3 = 5, int y3 = 94)//检测修复页面
        {
            int dm_Ret0 = dmae.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_Ret1 = dmae.CmpColor(x2, y2, "ffffff", 0.9);
            int dm_Ret2 = dmae.CmpColor(x3, y3, "ffffff", 0.9);

            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int CheckActivityBattlePage(DmAe dmae, int x1 = 135, int y1 = 94, int x2 = 135, int y2 = 1)
        {
            int dm_Ret0 = dmae.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_Ret1 = dmae.CmpColor(x2, y2, "ffffff", 0.9);

            if (dm_Ret0 == 0 && dm_Ret1 == 0 )
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int CheckMissionSettingPage(DmAe dmae, int x1 = 180, int y1 = 64, int x2 = 542, int y2 = 79, int x3 = 195, int y3 = 134)
        {
            int dm_Ret0 = dmae.CmpColor(x1, y1, "ffffff", 1);
            int dm_Ret1 = dmae.CmpColor(x2, y2, "ffffff", 1);
            int dm_Ret2 = dmae.CmpColor(x3, y3, "ffffff", 1);


            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int CheckActivityChoicePage(DmAe dmae, int x1 = 63, int y1 = 445, int x2 = 134, int y2 = 482, int x3 = 191, int y3 = 481)//魔方行动
        {
            int dm_Ret0 = dmae.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_Ret1 = dmae.CmpColor(x2, y2, "ffffff", 0.9);
            int dm_Ret2 = dmae.CmpColor(x3, y3, "ffffff", 0.9);


            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }


        }
        public int CcheckActivityPageReady(DmAe dmae, int x1 = 951, int y1 = 419, int x2 = 964, int y2 = 672, int x3 = 639, int y3 = 637)//检查魔方行动4个战役加载完毕
        {
            int dm_Ret0 = dmae.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_Ret1 = dmae.CmpColor(x2, y2, "ffffff", 0.9);
            int dm_Ret2 = dmae.CmpColor(x3, y3, "ffffff", 0.9);


            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }


        }


    }


}
