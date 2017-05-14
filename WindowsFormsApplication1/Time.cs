using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;
using WindowsFormsApplication1;
using WindowsFormsApplication1.BaseData;

namespace testdm
{
    class Time        //传入一个string,传出一个int
    {
        private InstanceManager im;

        public Time(InstanceManager im)
        {
            this.im = im;
        }
        public int getVolume(string time)
        {
            int T = 0;
            if (time != "")
                T = Int32.Parse(time.Substring(0, 2)) * 3600 + Int32.Parse(time.Substring(2, 2)) * 60 + Int32.Parse(time.Substring(time.Length - 2));
            return T;
        }

        public void SaveBmp(DmAe dmae, int x1,int y1,int x2,int y2,string temp)
        {   
            if (Settings.Default.DebugMode == true)
            {
                int dm_retsave = dmae.Capture(x1, y1, x2, y2, temp+DateTime.Now.ToString("yyyyMMddhhmmss") + ".bmp");
            }
        }

        public void ReadLogisticsTaskTime(DmAe dmae, Mouse mouse)
        {
            WriteLog.WriteError("开始执行读取后勤任务 ");
            int dmDict_ret = dmae.UseDict(1);
            int PageNumber = -1;
            int ZeroPage = 0;
            int time = 0;
            int count = 0;
            string Teamname;
            mouse.ClickHomeBattle(dmae);
            mouse.delayTime(1);
            object intX, intY;
            //判断当前是否在后勤页面上
            //....
            mouse.ClickLogistics(dmae);
            mouse.delayTime(1);
            ////判断开了多少页
            //if (dmae.CmpColor(240, 240, "ffffff", 0.9) == 0 || dmae.CmpColor(240, 240, "f7ae00", 0.7) == 0 || dmae.CmpColor(240, 240, Settings.Default.BattleSelectColor, 0.7) == 0)   //第一战役
            //                                                                                                                                                                           //PageNumber += 1;
            //{
            //    PageNumber += 1;
            //}
            //if (dmae.CmpColor(250, 350, "ffffff", 0.9) == 0 || dmae.CmpColor(250, 350, "f7ae00", 0.7) == 0 || dmae.CmpColor(250, 350, Settings.Default.BattleSelectColor, 0.7) == 0)//第二战役
            //{
            //    PageNumber += 1;
            //}

            //if (dmae.CmpColor(250, 455, "ffffff", 0.9) == 0 || dmae.CmpColor(250, 455, "f7ae00", 0.7) == 0 || dmae.CmpColor(250, 455, Settings.Default.BattleSelectColor, 0.7) == 0)//第三战役
            //{
            //    PageNumber += 1;
            //}
            ////PageNumber += 1;
            //if (dmae.CmpColor(240, 560, "ffffff", 0.9) == 0 || dmae.CmpColor(240, 560, "f7ae00", 0.7) == 0 || dmae.CmpColor(240, 560, Settings.Default.BattleSelectColor, 0.7) == 0)//第四战役
            //{
            //    PageNumber += 1;
            //}

            //if (dmae.CmpColor(250, 613, "ffffff", 0.9) == 0 || dmae.CmpColor(250, 613, "f7ae00", 0.7) == 0 || dmae.CmpColor(250, 613, Settings.Default.BattleSelectColor, 0.7) == 0)//第五战役
            //{

            //    PageNumber += 1;
            //}

            //if (dmae.CmpColor(250, 188, "ffffff", 0.9) == 0 || dmae.CmpColor(250, 188, "f7ae00", 0.7) == 0 || dmae.CmpColor(250, 188, Settings.Default.BattleSelectColor, 0.7) == 0)//判断0号战役如果打开了则zeropage为1;
            //{
            //    PageNumber += 1; ZeroPage = 1;
            //}



            for (int i = 0; i <= 8; i++) 
            {
                if (i == 0)
                {
                    mouse.ChooseBattle(dmae, "00",1);
                    mouse.delayTime(1, 1);
                }
                if (i == 1)
                {
                    mouse.ChooseBattle(dmae, "01", 1);
                    mouse.delayTime(1, 1);
                }
                if (i == 2)
                {
                    mouse.ChooseBattle(dmae, "02", 1);
                    mouse.delayTime(1, 1);
                }
                if (i == 3)
                {
                    mouse.ChooseBattle(dmae, "03", 1);
                    mouse.delayTime(1, 1);
                }
                if (i == 4)
                {
                    mouse.ChooseBattle(dmae, "04", 1);
                    mouse.delayTime(1, 1);
                }
                if (i == 5)
                {
                    mouse.ChooseBattle(dmae, "05", 1);
                    mouse.delayTime(1, 1);
                }
                if (i == 6)
                {
                    mouse.ChooseBattle(dmae, "06", 1);
                    mouse.delayTime(1, 1);
                }
                if (i == 7)
                {
                    mouse.ChooseBattle(dmae, "07", 1);
                    mouse.delayTime(1, 1);
                }
                if (i == 8)
                {
                    mouse.ChooseBattle(dmae, "08", 1);
                    mouse.delayTime(1, 1);
                }

                int dm_ret0 = dmae.FindColor(416, 518, 447, 551, "ffffff", 1, 0, out  intX, out  intY);//0:没找到1:找到
                if (dm_ret0 == 0)
                {
                    dm_ret0 = FindLTeam(dmae,1, 402, 517, 588, 554, 397, 550, 586, 584, out Teamname, ref time);//number1 = 第一个格子
                    GivenUIL(count, Teamname, i, 0, time.ToString());
                    count += 1;
                }

                int dm_ret1 = dmae.FindColor(631, 519, 795, 553, "ffffff", 1, 0, out  intX, out  intY);//0:没找到1:找到
                //int dm_ret1 = FindLTeam(dmae,2, 617, 519, 811, 553, 621, 551, 810, 584, out Teamname, ref time);//number2 = 第2个格子
                if (dm_ret1 == 0)
                {
                    dm_ret0 = FindLTeam(dmae, 2, 402, 517, 588, 554, 397, 550, 586, 584, out Teamname, ref time);//number2 = 第2个格子
                    GivenUIL(count, Teamname, i, 1, time.ToString());
                    count += 1;
                }

                int dm_ret2 = dmae.FindColor(853, 517, 1012, 552, "ffffff", 1, 0, out intX, out intY);//0:没找到1:找到
                //int dm_ret2 = FindLTeam(dmae,3, 837, 516, 1033, 554, 846, 552, 1026, 584, out Teamname, ref time);//number3 = 第3个格子
                if (dm_ret2 == 0)
                {
                    dm_ret0 = FindLTeam(dmae, 3, 402, 517, 588, 554, 397, 550, 586, 584, out Teamname, ref time);//number3 = 第3个格子
                    GivenUIL(count, Teamname, i, 2, time.ToString());
                    count += 1;
                }

                int dm_ret3 = dmae.FindColor(1080, 519, 1231, 553, "ffffff", 1, 0, out intX, out intY);//0:没找到1:找到
                //int dm_ret3 = FindLTeam(dmae,4, 1064, 516, 1248, 553, 1065, 551, 1254, 586, out Teamname, ref time);//number4 = 第4个格子
                if (dm_ret3 == 0)
                {
                    dm_ret0 = FindLTeam(dmae, 4, 402, 517, 588, 554, 397, 550, 586, 584, out Teamname, ref time);//number4 = 第4个格子
                    GivenUIL(count, Teamname, i, 3, time.ToString());
                    count += 1;
                }




            }
            mouse.LeftClickBackHome(dmae);
            mouse.delayTime(1);
        }

        public int WaitForLogistics(DmAe dmae,Mouse mouse)
        {
            while(dmae.CmpColor(75, 335,"ffffff",1)==1 || dmae.CmpColor(119, 376, "ffffff", 1) == 1 || dmae.CmpColor(254, 334, "ffffff", 1) == 1 || dmae.CmpColor(255, 374, "ffffff", 1) == 1 || dmae.CmpColor(296, 432, "ffffff", 1) == 1 )
            {
                mouse.delayTime(1, 1);
            }

            while(dmae.CmpColor(75, 335, "ffffff", 1) == 0 && dmae.CmpColor(119, 376, "ffffff", 1) == 0 && dmae.CmpColor(254, 334, "ffffff", 1) == 0 && dmae.CmpColor(255, 374, "ffffff", 1) == 0 && dmae.CmpColor(296, 432, "ffffff", 1) == 0)
            {
                mouse.LeftClick(dmae, 315, 175, 657, 452);
            }

            while (mouse.CheckHomePage(dmae) == 1)
            {
                mouse.delayTime(1);
            }
                return 0;
        }

        public int FindLTeam(DmAe dmae,int number, int x1,int y1,int x2, int y2,int x3,int y3,int x4,int y4,out string Teamname,ref int time)
        {
            int dmDict_ret0 = dmae.UseDict(3);
            Teamname = "";


            switch (number)
            {
                case 1:
                    {
                        string LTeamMainColor = FindLTeamMainColor(dmae, 433, 521, 457, 547);//number1 = 第一个格子
                        Teamname = dmae.Ocr(461,521,493,551, LTeamMainColor, (double)((decimal)Settings.Default.FindTeamSlectStrSim / 100));
                        dmDict_ret0 = dmae.UseDict(0);
                        time = getVolume(dmae.Ocr(419, 553, 572, 585, LTeamMainColor + "-" + Settings.Default.FindTeamSlectStrColorOffset + Settings.Default.FindTeamSlectStrColorOffset + Settings.Default.FindTeamSlectStrColorOffset, (double)((decimal)Settings.Default.FindTeamSlectStrSim / 100)));
                        return 1;
                    }
                case 2:
                    {
                        string LTeamMainColor = FindLTeamMainColor(dmae, 654, 522, 682, 548);//number2 = 第2个格子
                        Teamname = dmae.Ocr(682, 521, 714, 548, LTeamMainColor, (double)((decimal)Settings.Default.FindTeamSlectStrSim / 100));
                        dmDict_ret0 = dmae.UseDict(0);
                        time = getVolume(dmae.Ocr(634, 550, 788, 588, LTeamMainColor + "-" + Settings.Default.FindTeamSlectStrColorOffset + Settings.Default.FindTeamSlectStrColorOffset + Settings.Default.FindTeamSlectStrColorOffset, (double)((decimal)Settings.Default.FindTeamSlectStrSim / 100)));
                        return 1;
                    }
                case 3:
                    {
                        string LTeamMainColor = FindLTeamMainColor(dmae, 878, 522, 902, 547);//number3 = 第3个格子
                        Teamname = dmae.Ocr(904, 521, 936, 553, LTeamMainColor, (double)((decimal)Settings.Default.FindTeamSlectStrSim / 100));
                        dmDict_ret0 = dmae.UseDict(0);
                        time = getVolume(dmae.Ocr(867, 553, 1002, 583, LTeamMainColor + "-" + Settings.Default.FindTeamSlectStrColorOffset + Settings.Default.FindTeamSlectStrColorOffset + Settings.Default.FindTeamSlectStrColorOffset, (double)((decimal)Settings.Default.FindTeamSlectStrSim / 100)));
                        return 1;
                    }
                case 4:
                    {

                        string LTeamMainColor = FindLTeamMainColor(dmae, 1099, 522, 1125, 548);//number4 = 第4个格子
                        Teamname = dmae.Ocr(1127, 522, 1158, 548, LTeamMainColor, (double)((decimal)Settings.Default.FindTeamSlectStrSim / 100));
                        dmDict_ret0 = dmae.UseDict(0);
                        time = getVolume(dmae.Ocr(1085, 551, 1230, 583, LTeamMainColor + "-" + Settings.Default.FindTeamSlectStrColorOffset + Settings.Default.FindTeamSlectStrColorOffset + Settings.Default.FindTeamSlectStrColorOffset, (double)((decimal)Settings.Default.FindTeamSlectStrSim / 100)));
                        return 1;
                    }
                default:
                    return 0;
            }

        }

        public void GivenUIL(int count,string teamname,int i,int loc,string time)
        {
            //im.gameData.User_operationInfo.Remove(count);
            //UserOperationInfo tempUserOperationInfo = new UserOperationInfo();
            try
            {
                im.gameData.User_operationInfo[count].OperationTeamName = teamname;
                im.gameData.User_operationInfo[count].OperationName = TaskTime(i, loc.ToString());
                im.gameData.User_operationInfo[count].OperationLastTime = Int32.Parse(time) + 5;

            }
            catch (Exception)
            {

            }



        }





        
        

        public string TaskTime(int page, string loc)
        {

            if (page == 0)
            {
                switch (loc)
                {
                    case "0":
                        {
                            return "代号01";
                        }
                    case "1":
                        {
                            return "代号02";
                        }
                    case "2":
                        {
                            return "代号03";
                        }
                    case "3":
                        {
                            return "代号04";
                        }
                }
            }

            if (page == 1)
            {
                switch (loc)
                {
                    case "0":
                        {
                            return "代号05";
                        }
                    case "1":
                        {
                            return "代号06";
                        }
                    case "2":
                        {
                            return "代号07";
                        }
                    case "3":
                        {
                            return "代号08";
                        }
                }
            }
            if (page == 2)
            {
                switch (loc)
                {
                    case "0":
                        {
                            return "代号09";
                        }
                    case "1":
                        {
                            return "代号10";
                        }
                    case "2":
                        {
                            return "代号11";
                        }
                    case "3":
                        {
                            return "代号12";
                        }
                }
            }
            if (page == 3)
            {
                switch (loc)
                {
                    case "0":
                        {
                            return "代号13";
                        }
                    case "1":
                        {
                            return "代号14";
                        }
                    case "2":
                        {
                            return "代号15";
                        }
                    case "3":
                        {
                            return "代号16";
                        }
                }


            }
            if (page == 4)
            {
                switch (loc)
                {
                    case "0":
                        {
                            return "代号17";
                        }
                    case "1":
                        {
                            return "代号18";
                        }
                    case "2":
                        {
                            return "代号19";
                        }
                    case "3":
                        {
                            return "代号20";
                        }
                }


            }
            if (page == 5)
            {
                switch (loc)
                {
                    case "0":
                        {
                            return "代号21";
                        }
                    case "1":
                        {
                            return "代号22";
                        }
                    case "2":
                        {
                            return "代号23";
                        }
                    case "3":
                        {
                            return "代号24";
                        }
                }
            }
            if (page == 6)
            {
                switch (loc)
                {
                    case "0":
                        {
                            return "代号25";
                        }
                    case "1":
                        {
                            return "代号26";
                        }
                    case "2":
                        {
                            return "代号27";
                        }
                    case "3":
                        {
                            return "代号28";
                        }
                }
            }

            if (page == 7)
            {
                switch (loc)
                {
                    case "0":
                        {
                            return "代号29";
                        }
                    case "1":
                        {
                            return "代号30";
                        }
                    case "2":
                        {
                            return "代号31";
                        }
                    case "3":
                        {
                            return "代号32";
                        }
                }


            }


            if (page == 8)
            {
                switch (loc)
                {
                    case "0":
                        {
                            return "代号33";
                        }
                    case "1":
                        {
                            return "代号34";
                        }
                    case "2":
                        {
                            return "代号35";
                        }
                    case "3":
                        {
                            return "代号36";
                        }
                }


            }
            return "";



        }
        public int AutoBattleTime(string map)
        {
            switch (map)
            {
                case "1_4E": { return 6000; }
                default: { return 0; }

            }
        }

        public void AutoBattleTask(out string battle1, out int battle2, out int battle3,string map)
        {
            switch (map)
            {
                case "1_6": { battle1 = "01"; battle2 = 0; battle3 = 6; break; }
                case "1_4E": { battle1 = "01"; battle2 = 1;battle3 = 4;break; }
                default: { battle1 = "00"; battle2 = 0; battle3 = 0; break; }

            }
        }

        public void StartLogistics(DmAe dmae, Mouse mouse, ref Dictionary<int, UserOperationInfo> userOperationInfo)
        {
            //判断是否在主页
            //....


            mouse.ClickHomeBattle(dmae);
            mouse.delayTime(1);

            //判断当前是否在后勤页面上
            //....
            mouse.ClickLogistics(dmae);
            mouse.delayTime(1);
            //判断开了多少页


            userOperationInfo[0].OperationLastTime = StartLogisticsTask( mouse, userOperationInfo[0].OperationTeamName, userOperationInfo[0].OperationName,0,dmae);
            userOperationInfo[1].OperationLastTime = StartLogisticsTask( mouse, userOperationInfo[1].OperationTeamName, userOperationInfo[1].OperationName, 0, dmae);
            userOperationInfo[2].OperationLastTime = StartLogisticsTask( mouse, userOperationInfo[2].OperationTeamName, userOperationInfo[2].OperationName, 0, dmae);
            userOperationInfo[3].OperationLastTime = StartLogisticsTask( mouse, userOperationInfo[3].OperationTeamName, userOperationInfo[3].OperationName, 0, dmae);
            mouse.delayTime(1);
            mouse.LeftClickBackHome(dmae);

        }

        public int StartLogisticsTask(Mouse mouse, string TeamNumber, string TaskNumber, int type = 0, DmAe dmae=null)
        {

            switch (type)
            {
                case 0:
                    {
                        switch (TaskNumber)
                        {
                            case "代号01": { mouse.ChooseBattle(dmae, "00", 1); mouse.ChooseLogisticsTask(dmae, 1); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 3005; }
                            case "代号02": { mouse.ChooseBattle(dmae, "00", 1); mouse.ChooseLogisticsTask(dmae, 2); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 10805; }
                            case "代号03": { mouse.ChooseBattle(dmae, "00", 1); mouse.ChooseLogisticsTask(dmae, 3); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 43205; }
                            case "代号04": { mouse.ChooseBattle(dmae, "00", 1); mouse.ChooseLogisticsTask(dmae, 4); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 86405; }

                            case "代号05": { mouse.ChooseBattle(dmae, "01", 1); mouse.ChooseLogisticsTask(dmae, 1); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 905; }
                            case "代号06": { mouse.ChooseBattle(dmae, "01", 1); mouse.ChooseLogisticsTask(dmae, 2); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 1805; }
                            case "代号07": { mouse.ChooseBattle(dmae, "01", 1); mouse.ChooseLogisticsTask(dmae, 3); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 3605; }
                            case "代号08": { mouse.ChooseBattle(dmae, "01", 1); mouse.ChooseLogisticsTask(dmae, 4); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 7205; }

                            case "代号09": { mouse.ChooseBattle(dmae, "02", 1); mouse.ChooseLogisticsTask(dmae, 1); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 2405; }
                            case "代号10": { mouse.ChooseBattle(dmae, "02", 1); mouse.ChooseLogisticsTask(dmae, 2); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 5405; }
                            case "代号11": { mouse.ChooseBattle(dmae, "02", 1); mouse.ChooseLogisticsTask(dmae, 3); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 14405; }
                            case "代号12": { mouse.ChooseBattle(dmae, "02", 1); mouse.ChooseLogisticsTask(dmae, 4); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 21605; }

                            case "代号13": { mouse.ChooseBattle(dmae, "03", 1); mouse.ChooseLogisticsTask(dmae, 1); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 1205; }
                            case "代号14": { mouse.ChooseBattle(dmae, "03", 1); mouse.ChooseLogisticsTask(dmae, 2); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 2705; }
                            case "代号15": { mouse.ChooseBattle(dmae, "03", 1); mouse.ChooseLogisticsTask(dmae, 3); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 5405; }
                            case "代号16": { mouse.ChooseBattle(dmae, "03", 1); mouse.ChooseLogisticsTask(dmae, 4); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 18005; }

                            case "代号17": { mouse.ChooseBattle(dmae, "04", 1); mouse.ChooseLogisticsTask(dmae, 1); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 3605; }
                            case "代号18": { mouse.ChooseBattle(dmae, "04", 1); mouse.ChooseLogisticsTask(dmae, 2); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 7205; }
                            case "代号19": { mouse.ChooseBattle(dmae, "04", 1); mouse.ChooseLogisticsTask(dmae, 3); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 21605; }
                            case "代号20": { mouse.ChooseBattle(dmae, "04", 1); mouse.ChooseLogisticsTask(dmae, 4); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 28805; }

                            case "代号21": { mouse.ChooseBattle(dmae, "05", 1); mouse.ChooseLogisticsTask(dmae, 1); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 1805; }
                            case "代号22": { mouse.ChooseBattle(dmae, "05", 1); mouse.ChooseLogisticsTask(dmae, 2); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 9005; }
                            case "代号23": { mouse.ChooseBattle(dmae, "05", 1); mouse.ChooseLogisticsTask(dmae, 3); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 14405; }
                            case "代号24": { mouse.ChooseBattle(dmae, "05", 1); mouse.ChooseLogisticsTask(dmae, 4); Team_S(dmae, mouse, TeamNumber); mouse.DoubleClickLogisticsConfirm(dmae); return 25205; }

                            default:
                                return -1;
                        }

                    }
                case 1:
                    {
                        switch (TaskNumber)
                        {
                            case "代号01": { return 3005; }
                            case "代号02": { return 10805; }
                            case "代号03": { return 43205; }
                            case "代号04": { return 86405; }

                            case "代号05": { return 905; }
                            case "代号06": { return 1805; }
                            case "代号07": { return 3605; }
                            case "代号08": { return 7205; }

                            case "代号09": { return 2405; }
                            case "代号10": { return 5405; }
                            case "代号11": { return 14405; }
                            case "代号12": { return 21605; }

                            case "代号13": { return 1205; }
                            case "代号14": { return 2705; }
                            case "代号15": { return 5405; }
                            case "代号16": { return 18005; }

                            case "代号17": { return 3605; }
                            case "代号18": { return 7205; }
                            case "代号19": { return 21605; }
                            case "代号20": { return 28805; }

                            case "代号21": { return 1805; }
                            case "代号22": { return 9005; }
                            case "代号23": { return 14405; }
                            case "代号24": { return 25205; }

                            case "代号25": { return 7205; }
                            case "代号26": { return 10805; }
                            case "代号27": { return 18005; }
                            case "代号28": { return 43205; }

                            case "代号29": { return 9005; }
                            case "代号30": { return 14405; }
                            case "代号31": { return 19805; }
                            case "代号32": { return 28805; }

                            case "代号33": { return 3605; }
                            case "代号34": { return 10805; }
                            case "代号35": { return 21605; }
                            case "代号36": { return 32405; }

                            default:
                                return -1;
                        }
                    }
                default:
                    break;
            }

            return -1;
        }
        //可能要分开 后勤 选择梯队和 作战选择梯队

        public static string FindTeamMainColor(DmAe dmae, int y)
        {
            List<string> colorlist = new List<string>();
            List<int> countlist = new List<int>();
            string color0;
            int count = 0, tempy = y;

            for (tempy = y; tempy < y + 70; tempy++)
            {
                for (int x = 76; x < 101; x++)
                {
                    color0 = dmae.GetColor(x, tempy);
                    count = colorlist.FindIndex(s => s == color0);

                    if (count == -1)
                    {
                        colorlist.Add(color0);
                        countlist.Add(1);
                    }
                    else
                    {
                        countlist[count] += 1;
                    }
                }
            }
            count = countlist.Max();
            countlist.Remove(count);
            count = countlist.Max();
            count = countlist.FindIndex(s => s == count);
            return colorlist[count + 1];
        }

        public static string FindLTeamMainColor(DmAe dmae,int x1,int y1,int x2,int y2)
        {
            List<string> colorlist = new List<string>();
            List<int> countlist = new List<int>();
            string color0;
            int count = 0, tempy = x1;

            for (tempy = y1; tempy < y2; tempy++)
            {
                for (int x = x1; x < x2; x++)
                {
                    color0 = dmae.GetColor(x, tempy);
                    count = colorlist.FindIndex(s => s == color0);

                    if (count == -1)
                    {
                        colorlist.Add(color0);
                        countlist.Add(1);
                    }
                    else
                    {
                        countlist[count] += 1;
                    }
                }
            }
            //count = countlist.Max();
            //countlist.Remove(count);
            count = countlist.Max();
            count = countlist.FindIndex(s => s == count);
            return colorlist[count];
        }

        public string FindCombatMissionMainColor(DmAe dmae, int x1, int y1, int x2, int y2)
        {
            List<string> colorlist = new List<string>();
            List<int> countlist = new List<int>();
            string color0;
            int count = 0, tempy = x1;

            for (tempy = y1; tempy < y2; tempy++)
            {
                for (int x = x1; x < x2; x++)
                {
                    color0 = dmae.GetColor(x, tempy);
                    count = colorlist.FindIndex(s => s == color0);

                    if (count == -1)
                    {
                        colorlist.Add(color0);
                        countlist.Add(1);
                    }
                    else
                    {
                        countlist[count] += 1;
                    }
                }
            }
            //count = countlist.Max();
            //countlist.Remove(count);
            count = countlist.Max();
            count = countlist.FindIndex(s => s == count);
            return colorlist[count];
        }

        public static string FindYellowBackGroundColor(DmAe dmae)
        {
            object x, y;
            int dm_ret0 = dmae.FindColor(17, 0, 18, 720, "ffffff", 1,0, out x, out y);
            if(dm_ret0 == 0)//没有白色没找到
            {
                return dmae.GetColor(15, 335);
            }
            int tempy = Convert.ToInt32(y) - 27;
            return dmae.GetColor(Convert.ToInt32(x), tempy);
        }

        public bool Team_S(DmAe dmae, Mouse mouse, string TeamNumber,int page = 0)//选取队伍 page = 0是普通的 =1 是编成界面下 用于1-2换枪
        {
            int dm_ret99 = dmae.UseDict(1);
            int count = 0;
            string AutoFindTeamMainColor, AutoFindYellowColor;
            object x, y;

            if (page == 0)//page = 0是普通的 =1 是编成界面下 用于1-2换枪
            {
                int dm_ret0 = dmae.CmpColor(180, 100, "ffffff", 0.9);
                int dm_ret1 = dmae.CmpColor(950, 615, "ffffff", 0.9);

                while (dm_ret0 == 1 || dm_ret1 == 1)//确保在选择梯队页面
                {
                    mouse.delayTime(1);
                    dm_ret0 = dmae.CmpColor(180, 100, "ffffff", 0.9);
                    dm_ret1 = dmae.CmpColor(950, 615, "ffffff", 0.9);

                }

                mouse.delayTime(1);//确保梯队加载完毕
            }

            if(page == 1)//page = 0是普通的 =1 是编成界面下 用于1-2换枪
            {
                int dm_ret0 = dmae.CmpColor(138, 1, "ffffff", 0.9);
                int dm_ret1 = dmae.CmpColor(138, 94, "ffffff", 0.9);

                while (dm_ret0 == 1 || dm_ret1 == 1)//确保在选择梯队页面
                {
                    mouse.delayTime(1);
                    dm_ret0 = dmae.CmpColor(138, 1, "ffffff", 0.9);
                    dm_ret1 = dmae.CmpColor(138, 94, "ffffff", 0.9);

                }

                mouse.delayTime(2,1);//确保梯队加载完毕

            }

            //----------确保梯队加载完毕


            object intX, intY;
            int dm_ret2;
            int dm_ret3;
            WriteLog.WriteError("teamNumber = " + TeamNumber);


        a: if (page == 1)
            {

                //dm_ret2 = dmae.FindStr(75, 109, 105, 720, TeamNumber, "313531" + "|" + Settings.Default.TeamListSelect0, 0.9, out intX, out intY);

                //---------------------开始定位
                AutoFindYellowColor = FindYellowBackGroundColor(dmae);
                if (AutoFindYellowColor == "")//没有找到直接返回
                {
                    return false;
                }
                int dm_ret9 = dmae.FindColor(9, 0, 10, 720, AutoFindYellowColor, 0.9, 0, out x, out y);
                if (dm_ret9 == 0)
                {
                    MessageBox.Show("找不到黄色点", "少女前线");
                }

                //找到颜色后确定主颜色
                AutoFindTeamMainColor = FindTeamMainColor(dmae, Convert.ToInt32(y));
                //dm_ret2 = dmae.FindStr(75, Convert.ToInt32(y), 105, 720, TeamNumber, "313531" + "|" + Settings.Default.TeamListSelect0, 0.9, out intX, out intY);
                dm_ret2 = dmae.FindStr(75, Convert.ToInt32(y), 105, 720, TeamNumber, AutoFindTeamMainColor, 0.9, out intX, out intY);
            }
            else
            {
                //---------------------开始定位
                AutoFindYellowColor = FindYellowBackGroundColor(dmae);
                if (AutoFindYellowColor == "")//没有找到直接返回
                {
                    return false;
                }
                //int dm_ret9 = dmae.FindColor(9, 0, 10, 720, Settings.Default.TeamListSelect1 + "|" + Settings.Default.TeamListSelect2, 0.5, 0, out x, out y);
                int dm_ret9 = dmae.FindColor(9, 0, 10, 720, AutoFindYellowColor, 0.9, 0, out x, out y);
                if (dm_ret9 == 0)
                {
                    MessageBox.Show("找不到黄色点", "少女前线");
                }
                //找到颜色后确定主颜色
                AutoFindTeamMainColor = FindTeamMainColor(dmae, Convert.ToInt32(y));
                //dm_ret2 = dmae.FindStr(75, Convert.ToInt32(y), 105, 720, TeamNumber, "313531" + "|" + Settings.Default.TeamListSelect0, 0.9, out intX, out intY);
                dm_ret2 = dmae.FindStr(75, Convert.ToInt32(y), 120, 720, TeamNumber, AutoFindTeamMainColor+"-"+Settings.Default.FindTeamSlectStrColorOffset+ Settings.Default.FindTeamSlectStrColorOffset+ Settings.Default.FindTeamSlectStrColorOffset, (double)((decimal)Settings.Default.FindTeamSlectStrSim/100), out intX, out intY);

                if(dm_ret2 == -1)
                {

                    SaveBmp(dmae, 0, 0, 2000, 2000, "\\Debug\\TeamSerror"+TeamNumber.ToString());
                    SystemInfo.ErrorCount++;
                    return false;

                }




            }



            WriteLog.WriteError("findstrfast dm_ret2 = " + dm_ret2.ToString() + "intx = " + intX.ToString() + "iny = " + intY.ToString());
            //dm_ret3 = dmae.CmpColor(5, Int32.Parse(intY.ToString()), "f7b200" + "|" + Settings.Default.TeamListSelect2, 0.3);
            dm_ret3 = dmae.CmpColor(5, Int32.Parse(intY.ToString()), "ffffff", 1);
            WriteLog.WriteError("CmpColor dm_ret3 = " + dm_ret3.ToString());
            while (dm_ret3 == 0)
            {

                mouse.LeftClick(dmae, (Int32.Parse(intX.ToString()) - 5), (Int32.Parse(intY.ToString()) - 5), (Int32.Parse(intX.ToString()) + 5), (Int32.Parse(intY.ToString()) + 5));
                mouse.delayTime(1);
                //dm_ret3 = dmae.CmpColor(5, Int32.Parse(intY.ToString()), "f7b200" + "|" + Settings.Default.TeamListSelect2, 0.5);
                dm_ret3 = dmae.CmpColor(5, Int32.Parse(intY.ToString()), "ffffff", 1);
                WriteLog.WriteError("while CmpColor dm_ret3 = " + dm_ret3.ToString());
                if (TeamNumber == "第一梯队") { break; }

                //dm_ret2 = dm.FindStrFast(75, 0, 105, 720, TeamNumber, "313531" + "|" + Settings.Default.TeamListSelect0, 0.8, out intX, out intY);
                if(dm_ret3 == 0)
                {
                    count += 1;
                    if(count == 20)
                    {
                        MessageBox.Show("无法识别梯队", "少女前线");
                        return false;
                    }
                    mouse.delayTime(1);
                    goto a;
                }
            }
            return true;
            dmae.UseDict(0);
        }

        public void StartLogisticsTask1(DmAe dmae, Mouse mouse)
        {
            mouse.ClickHomeBattle(dmae);
            mouse.delayTime(1);

            //判断当前是否在后勤页面上
            //....
            mouse.ClickLogistics(dmae);
            mouse.delayTime(1);
            //判断开了多少页
            im.gameData.User_operationInfo[0].OperationLastTime = StartLogisticsTask(mouse, im.gameData.User_operationInfo[0].OperationTeamName, im.gameData.User_operationInfo[0].OperationName, 0, dmae);
            mouse.LeftClickBackHome(dmae);
        }

        public void StartLogisticsTask2(DmAe dmae, Mouse mouse)
        {
            mouse.ClickHomeBattle(dmae);
            mouse.delayTime(1);

            //判断当前是否在后勤页面上
            //....
            mouse.ClickLogistics(dmae);
            mouse.delayTime(1);
            //判断开了多少页
            im.gameData.User_operationInfo[1].OperationLastTime = StartLogisticsTask(mouse, im.gameData.User_operationInfo[1].OperationTeamName, im.gameData.User_operationInfo[1].OperationName, 0, dmae);
            mouse.LeftClickBackHome(dmae);



        }

        public void StartLogisticsTask3(DmAe dmae, Mouse mouse)
        {
            mouse.ClickHomeBattle(dmae);
            mouse.delayTime(1);

            //判断当前是否在后勤页面上
            //....
            mouse.ClickLogistics(dmae);
            mouse.delayTime(1);
            //判断开了多少页
            im.gameData.User_operationInfo[2].OperationLastTime = StartLogisticsTask( mouse, im.gameData.User_operationInfo[2].OperationTeamName, im.gameData.User_operationInfo[2].OperationName, 0, dmae);
            mouse.LeftClickBackHome(dmae);



        }

        public void StartLogisticsTask4(DmAe dmae, Mouse mouse)
        {
            mouse.ClickHomeBattle(dmae);
            mouse.delayTime(1);

            //判断当前是否在后勤页面上
            //....
            mouse.ClickLogistics(dmae);
            mouse.delayTime(1);
            //判断开了多少页
            im.gameData.User_operationInfo[3].OperationLastTime = StartLogisticsTask(mouse, im.gameData.User_operationInfo[3].OperationTeamName, im.gameData.User_operationInfo[3].OperationName, 0, dmae);
            mouse.LeftClickBackHome(dmae);



        }

        public void BackToGame(DmAe dmae, Mouse mouse)
        {
            object intX, intY;
            intX = intY = -1;
            while (dmae.FindPic(WindowsFormsApplication1.Properties.Settings.Default.SimulatorHomeCheckX1, WindowsFormsApplication1.Properties.Settings.Default.SimulatorHomeCheckY1, WindowsFormsApplication1.Properties.Settings.Default.SimulatorHomeCheckX2, WindowsFormsApplication1.Properties.Settings.Default.SimulatorHomeCheckY2, "A.bmp", "000000", 1, 0, out intX, out intY) == 0)
            {

                 SystemInfo.AppState = "打开游戏";

                mouse.LeftClick(dmae, WindowsFormsApplication1.Properties.Settings.Default.GameIconX, WindowsFormsApplication1.Properties.Settings.Default.GameIconY, WindowsFormsApplication1.Properties.Settings.Default.GameIconX+2, WindowsFormsApplication1.Properties.Settings.Default.GameIconX+2);
                mouse.delayTime(5, 1);
            }

            if (mouse.CheckHomePage(dmae) == 0)
            {
                SystemInfo.AppState = "重连成功";
                return;
            }
            while (dmae.CmpColor(145, 327,"ffffff",1)==0&& dmae.CmpColor(302, 106, "ffffff", 1) == 0 && dmae.CmpColor(167, 336, "ffffff", 1) == 0 && dmae.CmpColor(43, 180, "ffffff", 1) == 0 && dmae.CmpColor(445, 108, "ffffff", 1) == 0)
            {
                SystemInfo.AppState = "点击登陆";
                mouse.LeftClick(dmae, 29, 399, 273, 451);
                mouse.delayTime(5, 5);
            }


            while (mouse.CheckHomePage(dmae) == 1 )//直到回到主页，不停地点击登陆
            {
                if (dmae.CmpColor(367, 285, "ffffff", 1) == 0 && dmae.CmpColor(477, 282, "ffffff", 1) == 0 && dmae.CmpColor(645, 292, "ffffff", 1) == 0 && dmae.CmpColor(715, 311, "ffffff", 1) == 0 && dmae.CmpColor(759, 295, "ffffff", 1) == 0)
                {
                    while (dmae.CmpColor(367, 285, "ffffff", 1) == 0 && dmae.CmpColor(477, 282, "ffffff", 1) == 0 && dmae.CmpColor(645, 292, "ffffff", 1) == 0 && dmae.CmpColor(715, 311, "ffffff", 1) == 0 && dmae.CmpColor(759, 295, "ffffff", 1) == 0)
                    {
                        //自动登陆超时错误窗口
                        SystemInfo.AppState = "登陆超时";
                        mouse.LeftClick(dmae, 501, 371, 779, 433);
                        mouse.delayTime(5, 5);
                    }

                    //点击登陆
                    while (dmae.CmpColor(618, 350, "ffffff", 1) == 0 && dmae.CmpColor(658, 370, "ffffff", 1) == 0 && dmae.CmpColor(641, 182, "ffffff", 1) == 0 && dmae.CmpColor(640, 136, "ffffff", 1) == 0)
                    {
                        SystemInfo.AppState = "点击登陆";
                        mouse.LeftClick(dmae, 413, 326, 864, 389);
                        mouse.delayTime(5, 1);
                    }
                }
                mouse.LeftClick(dmae, 29, 399, 273, 451);
                mouse.delayTime(5, 5);
            }
            if (mouse.CheckHomePage(dmae) == 0)
            {
                SystemInfo.AppState = "重连成功";
                return;
            }
        }
        

        public int Fix(DmAe dmae, Mouse mouse,ref List<int> Showertime,UserBattleInfo userBattleInfo)
        {
            int dm_dict = dmae.UseDict(2);
            int n = 0;//待修复少女的数量
            int skip = 0, time;
            int k = 0;//k用于给showertime外部链表计数用，哪个槽为空就以这个为主
            string time1;

            mouse.ClickHomeShower(dmae);
            mouse.delayTime(2,1);

            List<int> EmptyFixBox = new List<int>();//修理槽
            List<FixGirlsInfo> GirlsInfo = new List<FixGirlsInfo>();
            List<int> temptime = new List<int>();

            //判断有多少个在修复，剩余空槽有多少;

            while (EmptyFixBox.Any()==false)
            {
                mouse.CheckFixBox(dmae, ref EmptyFixBox);
            }

            //读取修复槽完毕

                //开始读取修复数量

                mouse.OpenFixBox(dmae, EmptyFixBox[0]);
            mouse.delayTime(1);

            int dm_ret0 = dmae.CmpColor(716, 510, "ffffff", 1);//返回
            while(dm_ret0 == 0)
            {
                mouse.LeftClick(dmae, 566, 495, 709, 548);//遇到叉点击返回
                mouse.delayTime(1);
                dm_ret0 = dmae.CmpColor(716, 510, "ffffff", 1);//修改 没有需要修复的少女，则可以退出澡堂
                if (dm_ret0 == 1)
                {
                    time = 10;
                    goto temp;
                }
            }

            //读取修复少女的数量
            n = mouse.LoadFixGirlInfo(dmae,ref GirlsInfo, userBattleInfo);



            //开始分支，按时间修复或者按百分比修复

            //检测血量
            if(userBattleInfo.FixType == 1)
            {
                ////点击待修复少女
                //int dm_ret8 = mouse.ClickGirl(dmae, 1 + skip);//返回0 正常 返回1 = 后勤或训练
                //if (dm_ret8 == 0)
                //{
                //    //读取时间
                //    SaveBmp(dmae, 827, 385, 1019, 435, "\\Debug\\");
                //    time1 = dmae.Ocr(827, 385, 1019, 435, "ffffff-101010", 0.9);//
                //    if (getVolume(time1) >userBattleInfo.FixMaxTime && userBattleInfo.FixMaxTime != 0)
                //    {
                //        //使用快修
                //        mouse.ClickQuickFix(dmae);
                //        n = n - 1;
                //    }

                //    if (getVolume(time1) < userBattleInfo.FixMintime && userBattleInfo.FixMintime != 0)
                //    {
                //        //小于设定时间不维修
                //        mouse.ClickCancelFix(dmae);
                //        skip = skip + 1;
                //        n = n - 1;
                //    }
                //    if (userBattleInfo.FixMintime == 0 && userBattleInfo.FixMintime == 0)
                //    {
                //        //点击普通维修
                //        mouse.ClickFixSure(dmae,false);
                //        Showertime[k] = getVolume(time1);
                //        k++;
                //        temptime.Add(getVolume(time1));
                //            EmptyFixBox.RemoveAt(0);
                //        n = n - 1;
                //    }
                //}
                //else { skip += 1; n = n - 1; }

                ///////////////////开始循环

                //for (int temp = 0; temp < n; temp++)
                //{
                //    if (dm_ret8 == 0)
                //    {
                //        mouse.OpenFixBox(dmae, EmptyFixBox[0]);
                //    }


                //    dm_ret8 = mouse.ClickGirl(dmae, 1 + skip);
                //    if (dm_ret8 == 0)
                //    {
                //        SaveBmp(dmae, 827, 385, 1019, 435, "\\Debug\\");
                //        time1 = dmae.Ocr(827, 385, 1019, 435, "ffffff-101010", 0.9);//

                //        if (getVolume(time1) > userBattleInfo.FixMaxTime && userBattleInfo.FixMaxTime != 0)
                //        {
                //            //使用快修
                //            mouse.ClickQuickFix(dmae);
                //        }

                //        if (getVolume(time1) < userBattleInfo.FixMintime && userBattleInfo.FixMintime != 0)
                //        {
                //            //小于设定时间不维修
                //            mouse.ClickCancelFix(dmae);
                //            skip = skip + 1;
                //        }
                //        if (userBattleInfo.FixMintime == 0 && userBattleInfo.FixMintime == 0)
                //        {
                //            //点击普通维修
                //            mouse.ClickFixSure(dmae,false);

                //            //Showertime[Showertime.FindIndex(s => s == -1)] = getVolume(time1);
                //            Showertime[k] = getVolume(time1);
                //            k++;
                //            temptime.Add(getVolume(time1));
                //                EmptyFixBox.RemoveAt(0);
                //        }
                //    }
                //    else { skip += 1; }
                //}
            }







            else if (userBattleInfo.FixType == 2)
            {
                bool NeetToQFxi = false;
                bool NeetTONFxi = false;
                //第一轮先快修
                foreach (var item in GirlsInfo)
                {
                    if(item.NeedQFix)
                    {
                        mouse.ClickGirl(dmae, item);
                        NeetToQFxi = true;//存在需要快修的，需要点击确定修复
                    }
                }
                if(NeetToQFxi)
                {
                    mouse.ClickQuickFix(dmae);
                    mouse.OpenFixBox(dmae, EmptyFixBox[0]);
                    mouse.delayTime(1);
                    while (dmae.CmpColor(716, 510, "ffffff", 1) == 0)
                    {
                        mouse.LeftClick(dmae, 566, 495, 709, 548);//遇到叉点击返回
                        mouse.delayTime(1);
                        if (dmae.CmpColor(716, 510, "ffffff", 1) == 1)
                        {
                            time = 10;
                            goto temp;
                        }
                    }
                }
                //第二轮慢修
                foreach (var item in GirlsInfo)
                {
                    if (item.NeedNFix)
                    {
                        mouse.ClickGirl(dmae, item);
                        NeetTONFxi = true;
                    }
                }
                if (NeetTONFxi)
                {
                    mouse.ClickNormalFix(dmae);
                    temptime.Add(getVolume(dmae.Ocr(827, 385, 1019, 435, "ffffff-101010", 0.9)));
                    mouse.ClickFixSure(dmae, false);
                }



                //foreach (var item in GirlsInfo)
                //{
                //    if ((item.Hp <= userBattleInfo.FixMinPercentage) && userBattleInfo.FixMinPercentage != 0)
                //    {
                //        //快修
                //        dm_ret8 = mouse.ClickGirl(dmae, item.Location); continue;
                //    }
                //    if ((item.Hp >= userBattleInfo.FixMaxPercentage) && userBattleInfo.FixMaxPercentage != 0)
                //    {
                //        continue;
                //    }
                //    if (userBattleInfo.FixMinPercentage == 0 && (item.Hp < userBattleInfo.FixMaxPercentage))
                //    {
                //        //点击普通维修
                //        dm_ret8 = mouse.ClickGirl(dmae, item.Location); continue;
                //    }
                //    if (userBattleInfo.FixMinPercentage == 0 && userBattleInfo.FixMaxPercentage == 0)
                //    {
                //        //点击普通维修
                //        dm_ret8 = mouse.ClickGirl(dmae, item.Location); continue;
                //    }
                //    if (item.Hp < userBattleInfo.FixMinPercentage)
                //    {
                //        //快修
                //        dm_ret8 = mouse.ClickGirl(dmae, item.Location); continue;
                //    }
                //    if (item.Hp > userBattleInfo.FixMinPercentage && userBattleInfo.FixMaxPercentage == 0)
                //    {
                //        //点击普通维修
                //        dm_ret8 = mouse.ClickGirl(dmae, item.Location); continue;
                //    }
                //}
                //mouse.ClickNormalFix(dmae);
                //temptime.Add(getVolume(dmae.Ocr(827, 385, 1019, 435, "ffffff-101010", 0.9)));
                //mouse.ClickFixSure(dmae, false);





                //int Leave = 0;
                //bool NeedToOpenFixBox = false;
                //for (int i = 1; i <= n; i++)
                //{



                //    //检测是否在修复页面
                //    while (mouse.CheckFixPage(dmae) == 1)
                //    {
                //        mouse.delayTime(1,1);
                //    }

                //    if (NeedToOpenFixBox)
                //    {
                //        mouse.delayTime(1, 1);
                //        Leave = mouse.OpenFixBox(dmae, EmptyFixBox[0]);
                //        if(Leave == 1) { break; }
                //    }
                    
                //    if ((mouse.FixPageCheckTheHP(dmae, 1 + skip) <= userBattleInfo.FixMinPercentage) && userBattleInfo.FixMinPercentage != 0)
                //    {
                //          1
                //        //快修
                //        dm_ret8 = mouse.ClickGirl(dmae, 1 + skip);
                //        mouse.ClickQuickFix(dmae);
                //        NeedToOpenFixBox = true;
                //        goto end;


                //    }
                //    if ((mouse.FixPageCheckTheHP(dmae, i + skip) >= userBattleInfo.FixMaxPercentage) && userBattleInfo.FixMaxPercentage != 0)
                //    {
                //          2
                //        skip = skip + 1;
                //        NeedToOpenFixBox = false;
                //        if (i == n)
                //        {
                //            break;
                //        }
                //    }

                //    if (userBattleInfo.FixMinPercentage == 0 && (mouse.FixPageCheckTheHP(dmae, 1 + skip) < userBattleInfo.FixMaxPercentage))
                //    {
                //          3
                //        //点击普通维修
                //        dm_ret8 = mouse.ClickGirl(dmae, 1 + skip);
                //        mouse.ClickNormalFix(dmae);
                //        time1 = dmae.Ocr(827, 385, 1019, 435, "ffffff-101010", 0.9);

                //        mouse.ClickFixSure(dmae,false);
                //        //Showertime[Showertime.FindIndex(s => s == -1)] = getVolume(time1);
                //        Showertime[k] = getVolume(time1);
                //        k++;
                //        temptime.Add(getVolume(time1));
                //        EmptyFixBox.RemoveAt(0);
                //        NeedToOpenFixBox = true;
                //        goto end;
                //    }

                //    if (userBattleInfo.FixMinPercentage == 0 && userBattleInfo.FixMaxPercentage == 0)
                //    {
                //        //点击普通维修
                //          4
                //        dm_ret8 = mouse.ClickGirl(dmae, 1 + skip);
                //        mouse.ClickNormalFix(dmae);
                //        time1 = dmae.Ocr(827, 385, 1019, 435, "ffffff-101010", 0.9);

                //        mouse.ClickFixSure(dmae,false);
                //        //Showertime[Showertime.FindIndex(s => s == -1)] = getVolume(time1);
                //        Showertime[k] = getVolume(time1);
                //        k++;
                //        temptime.Add(getVolume(time1));
                //        EmptyFixBox.RemoveAt(0);
                //        NeedToOpenFixBox = true;
                //        goto end;
                //    }

                //    if (mouse.FixPageCheckTheHP(dmae, 1 + skip) < userBattleInfo.FixMinPercentage)
                //    {
                //        //快修
                //        dm_ret8 = mouse.ClickGirl(dmae, 1 + skip);
                //        mouse.ClickQuickFix(dmae);
                //        NeedToOpenFixBox = true;
                //        goto end;
                //    }
                //    if (mouse.FixPageCheckTheHP(dmae, 1 + skip) > userBattleInfo.FixMinPercentage && userBattleInfo.FixMaxPercentage == 0)
                //    {
                //        //点击普通维修
                //        dm_ret8 = mouse.ClickGirl(dmae, 1 + skip);
                //        mouse.ClickNormalFix(dmae);
                //        time1 = dmae.Ocr(827, 385, 1019, 435, "ffffff-101010", 0.9);

                //        mouse.ClickFixSure(dmae,false);
                //        //Showertime[Showertime.FindIndex(s => s == -1)] = getVolume(time1);
                //        Showertime[k] = getVolume(time1);
                //        k++;
                //        temptime.Add(getVolume(time1));
                //        EmptyFixBox.RemoveAt(0);
                //        NeedToOpenFixBox = true;
                //        goto end;
                //    }
                //    end:;
                //}




            }












            int dm_ret99 = dmae.CmpColor(132, 89, "ffffff", 0.9);
            int dm_ret98 = dmae.CmpColor(132, 7, "ffffff", 0.9);
            while (dm_ret99 == 0 && dm_ret98 == 0)
            {
                mouse.LeftClick(dmae, 17, 15, 129, 82);
                mouse.delayTime(1);
                dm_ret99 = dmae.CmpColor(132, 89, "ffffff", 0.9);
                dm_ret98 = dmae.CmpColor(132, 7, "ffffff", 0.9);
            }

            userBattleInfo.NeedToFix = false;
            dm_dict = dmae.UseDict(0);
        temp: mouse.LeftClickBackHome(dmae);

            try
            {
                return (temptime.Max() + userBattleInfo.RoundInterval + 5);
            }
            catch (InvalidOperationException)
            {

                return userBattleInfo.RoundInterval + 5;
            }
        }

        public void DismantlementGun(DmAe dmae,Mouse mouse,int count)
        {

            mouse.ClickFactory(dmae);
            mouse.ClickDismantlementGun(dmae);
            //第一次
            //count 拆解要大于10
            mouse.ClickChoice(dmae,count);
            mouse.LeftClickBackHome(dmae);


        }

        public void BuildEquipmentArea(int i, ref int x1,  ref int y1,  ref int x2, ref int y2)
        {
            switch (i)
            {
                case 0: { x1 = 444; y1 = 177; x2 = 607; y2 = 222; break; }
                case 1: { x1 = 444; y1 = 387; x2 = 600; y2 = 439; break; }
                case 2: { x1 = 446; y1 = 600; x2 = 611; y2 = 643; break; }
                default:
                    break;
            }
        }

        public void BuildEquipment(DmAe dmae, Mouse mouse)
        {
            dmae.UseDict(4);
            object intX1, intY1;
            int x1=0,y1=0,x2=0,y2=0;
            mouse.ClickFactory(dmae);
            mouse.ClickBuildEquipment(dmae);
            mouse.delayTime(2, 1);
            //读取两个格子的时间
            SystemInfo.AppState = "读取时间";
            for (int i = 0; i < 3; i++)
            {
                switch (mouse.CheckBuildEquipmentS(dmae, i))
                {
                    case 0:
                        {
                            im.gameData.User_BuildingEquipmentInfo[i].BuildEquipmentUsing= false;
                            im.gameData.User_BuildingEquipmentInfo[i].NeedToRecieve = false; break;//空 }
                        }
                    case 1:
                        {
                            im.gameData.User_BuildingEquipmentInfo[i].BuildEquipmentUsing = false;
                            im.gameData.User_BuildingEquipmentInfo[i].tempNeedToRecieve = true; break;//接收 }
                        }
                    case 2:
                        {
                            BuildEquipmentArea(i, ref x1, ref y1, ref x2, ref y2);
                            im.gameData.User_BuildingEquipmentInfo[i].BuildEquipmentUsing = true;
                            im.gameData.User_BuildingEquipmentInfo[i].NeedToRecieve = false;
                            im.gameData.User_BuildingEquipmentInfo[i].BuildEquipmentLastTime = getVolume(dmae.Ocr(x1,y1,x2,y2, "000000-101010", (double)((decimal)Settings.Default.FindTeamSlectStrSim / 100)));
                            break;//需要读取时间break; }

                        }
                }

            }

            //如果两个槽都要接收装备
            SystemInfo.AppState = "接收装备";
            for (int i = 0; i < 3; i++)
            {
                if (im.gameData.User_BuildingEquipmentInfo[i].tempNeedToRecieve == true)
                {
                    mouse.ClickBuildingArea(dmae, i);//点击建造槽接收装备
                    mouse.delayTime(8, 1);
                    mouse.ClickBuildingResult(dmae);
                    im.gameData.User_BuildingEquipmentInfo[i].tempNeedToRecieve = false;
                }
            }



            //如果第一个格子是空
            SystemInfo.AppState = "开始建造";
            for (int i = 0; i < 3; i++)
            {
                if (im.gameData.User_BuildingEquipmentInfo[i].BuildEquipmentUsing == false)
                {
                    //点击建造槽
                    mouse.ClickBuildingArea(dmae, i);

                    //点击日志
                    mouse.ClickBuildingLog(dmae);
                    //点击收藏夹
                    mouse.ClickBuildingFavorite(dmae);
                    //点击套用公式
                    mouse.ClickBuildingFavoriteFirst(dmae,im.gameData.User_BuildingEquipmentInfo[i].BuildingFavoriteNumber);
                    //点击开始制造
                    mouse.ClickStartBuilding(dmae);


                    //检查是否满仓

                    if (mouse.CheckEquipmentStorageFull(dmae))
                    {
                        while (mouse.CheckEquipmentStorageFull(dmae))
                        {
                            mouse.LeftClick(dmae, 455, 472, 598, 522);
                            mouse.delayTime(1, 1);
                        }
                        mouse.LeftClickBackHome(dmae);
                        return;
                    }

                    //识别时间

                    //等待加载


                    switch (i)
                    {
                        case 0:
                            {
                                while(dmae.FindColor(444, 177, 565, 222,"000000",1,0,out intX1,out intY1) == 0)
                                {
                                    mouse.delayTime(1);
                                }
                                im.gameData.User_BuildingEquipmentInfo[i].BuildEquipmentLastTime = getVolume(dmae.Ocr(444, 177, 607, 222, "000000-101010", (double)((decimal)Settings.Default.FindTeamSlectStrSim / 100)));
                                break;
                            }
                        case 1:
                            {
                                while (dmae.FindColor(444, 387, 565, 439, "000000", 1, 0, out intX1, out intY1) == 0)
                                {
                                    mouse.delayTime(1);
                                }
                                im.gameData.User_BuildingEquipmentInfo[i].BuildEquipmentLastTime = getVolume(dmae.Ocr(444, 387, 600, 439, "000000-101010", (double)((decimal)Settings.Default.FindTeamSlectStrSim / 100)));
                                break;
                            }
                        case 2:
                            {
                                while (dmae.FindColor(446, 600, 611, 643, "000000", 1, 0, out intX1, out intY1) == 0)
                                {
                                    mouse.delayTime(1);
                                }
                                im.gameData.User_BuildingEquipmentInfo[i].BuildEquipmentLastTime = getVolume(dmae.Ocr(446, 600, 611, 643, "000000-101010", (double)((decimal)Settings.Default.FindTeamSlectStrSim / 100)));
                                break;
                            }

                        default:
                            break;
                    }






                }
            }
            SystemInfo.AppState = "返回主页";
            mouse.LeftClickBackHome(dmae);
        }

        public void ChangeGun(DmAe dmae, Mouse mouse,string mainteam,int gun1,int gun2 ,int gun3 ,int gun4, int gun5)
        {
            mouse.ClickTeam(dmae);
            Team_S(dmae, mouse, mainteam,1);
            mouse.delayTime(1, 1);
            mouse.ChangeGun(dmae);

            mouse.LeftClickBackHome(dmae);

        }



        public void ChoseThebattle(DmAe dmae, Mouse mouse,ref UserBattleInfo userBattleInfo)
        {
            switch (userBattleInfo.TaskName)
            {
                case "0_1":
                    {
                        Battle0_1(dmae, mouse, ref userBattleInfo);
                        break;
                    }
                //case "0_4":
                //    {
                //        Battle0_4(dmae, mouse, mainteam, supportteam, tasktype, support,fix, fixmaxpercentage, setmap);
                //        break;
                //    }

                //case "1_2":
                //    {
                //        Battle1_2(dmae, mouse, mainteam, supportteam, support, setmap);
                //        break;
                //    }


                //case "1_4E":
                //    {
                //        Battle1_4E(dmae, mouse, mainteam, supportteam);
                //        break;
                //    }

                //case "2_1E":
                //    {
                //        Battle2_1E(dmae, mouse, mainteam, supportteam, support, setmap);
                //        break;
                //    }

                case "2_4E":
                    {
                        Battle2_4E(dmae, mouse, ref userBattleInfo);
                        break;
                    }
                case "3_2N":
                    {
                        Battle3_2N(dmae, mouse, ref userBattleInfo);
                        break;
                    }
                //case "3_3E":
                //    {
                //        Battle3_3E(dmae, mouse, mainteam, supportteam, tasktype, support,fix, fixmaxpercentage, setmap);
                //        break;
                //    }

                case "3_4E":
                    {
                        Battle3_4E(dmae, mouse,ref userBattleInfo);
                        break;
                    }

                //case "4_3":
                //    {
                //        Battle4_3(dmae, mouse, mainteam, supportteam);
                //        break;

                //    }
                //case "5_1E":
                //    {
                //        Battle5_1E(dmae, mouse, mainteam, supportteam, tasktype, setmap);
                //        break;
                //    }

                //case "5_2":
                //    {
                //        Battle5_2(dmae, mouse, mainteam, supportteam, tasktype, setmap);
                //        break;
                //    }

                case "5_4":
                    {
                        Battle5_4(dmae, mouse, ref userBattleInfo);
                        break;
                    }
                case "4_4E":
                    {
                        Battle4_4E(dmae, mouse, ref userBattleInfo);
                        break;
                    }
                case "5_4E":
                    {
                        Battle5_4E(dmae, mouse,ref userBattleInfo);
                        break;
                    }
                case "6_6":
                    {
                        Battle6_6(dmae, mouse, ref userBattleInfo);
                        break;
                    }

                //case "魔方行动E4":
                //    {
                //        SummerE4(dmae, mouse, mainteam, supportteam, tasktype, support,fix, fixmaxpercentage, setmap);
                //        break;
                //    }

                default:
                    break;
            }




        }

        public void SelectTeam(DmAe dmae, Mouse mouse, string team1, string team2, string team3, string team4)
        {
            int dm_ret0 = dmae.CmpColor(640, 300, "ffffff", 1);
            int dm_ret1 = dmae.CmpColor(740, 300, "ffffff", 1);
            int dm_ret2 = dmae.CmpColor(540, 300, "ffffff", 1);

            if (dm_ret0 == 0)
            {

            }

            if (dm_ret1 == 0 && dm_ret2 == 0)
            {
                int dm_ret99 = dmae.CmpColor(1000, 610, "ffffff", 0.9);
                while (dm_ret99 == 1) { mouse.LeftClick(dmae, 474, 196, 611, 465); mouse.delayTime(1); dm_ret99 = dmae.CmpColor(1000, 610, "ffffff", 0.9); }
                Team_S(dmae, mouse, team1);

                int dm_ret98 = dmae.CmpColor(975, 631, "ffffff", 1);
                while (dm_ret98 == 0) { mouse.LeftClick(dmae, 1105, 615, 1243, 664); mouse.delayTime(1); dm_ret98 = dmae.CmpColor(975, 631, "ffffff", 1); }

                dm_ret99 = dmae.CmpColor(1000, 610, "ffffff", 0.9);
                while (dm_ret99 == 1) { mouse.LeftClick(dmae, 671, 197, 818, 466); mouse.delayTime(1); dm_ret99 = dmae.CmpColor(1000, 610, "ffffff", 0.9); }
                Team_S(dmae, mouse, team2);
                int dm_ret97 = dmae.CmpColor(975, 631, "ffffff", 1);
                while (dm_ret97 == 0) { mouse.LeftClick(dmae, 1105, 615, 1243, 664); mouse.delayTime(1); dm_ret97 = dmae.CmpColor(975, 631, "ffffff", 1); }

                //点击确定
                dm_ret99 = dmae.CmpColor(530, 85, "ffffff", 0.9);
                while (dm_ret99 == 0) { mouse.LeftClick(dmae, 929, 557, 1063, 609); mouse.delayTime(1); dm_ret99 = dmae.CmpColor(530, 85, "ffffff", 0.9); }


            }
        }

        public int AutoBattle(DmAe dmae, Mouse mouse, string map, string team1, string team2, string team3, string team4,ref UserBattleInfo userbattleinfo)
        {
            string battle1;int battle2, battle3;
            AutoBattleTask(out battle1, out battle2, out battle3, map);
            mouse.LeftClickHomeToBattle(dmae, battle1, battle2, battle3);
            mouse.delayTime(1);
            mouse.ClickFightType(dmae, "self-discipline",ref userbattleinfo);
            mouse.delayTime(1);
            SelectTeam(dmae, mouse, team1, team2, team3, team4);

            mouse.LeftClickBackHome(dmae);
            return AutoBattleTime(map);
        }



        //public void Battle1_4E(DmAe dmae, Mouse mouse, string mainteam, string supportteam ) { }

        //public void Battle1_2(DmAe dmae, Mouse mouse, string mainteam, string supportteam, bool supply,bool setmap =false)
        //{

        //    mouse.LeftClickHomeToBattle(dmae, 1, 0, 2);
        //    mouse.delayTime(1);
        //    mouse.ClickFightType(dmae, "normal");
        //    mouse.delayTime(4);

        //    //地图初始化测试
        //    if(setmap == true)
        //    {
        //        mouse.MapSet(dmae, 237, 387, 265, 465,1,1, 72, 649);
        //    }




        //    //mouse.ScreenUp(dmae, 358, 250, 998, 338, 98, 633, 187, "94c6f7" + "|" + Settings.Default.AirPort, 633, 223, "94c6f7" + "|" + Settings.Default.AirPort); //900, 665
        //    mouse.Teamdispose(dmae, 221, 403, 281, 455, mainteam);//指挥部部署
        //    mouse.delayTime(1);


        //    mouse.BattleStart(dmae);
        //    mouse.delayTime(2);

        //    //开始补给

        //    if (supply == true) { mouse.Support(dmae, 226, 408, 278, 446); }

        //    mouse.MoveAndMove(dmae, 226, 408, 278, 446, 400, 300, 444, 327, 130, 412, 214, 441, 0, 0);//第一开始
        //    mouse.delayTime(1);

        //    mouse.MoveAndFight(dmae, 404, 291, 439, 325, 579, 185, 614, 218, 310, 290, 388, 326, 0, 0);//第二开始
        //    mouse.delayTime(1);

        //    //结束回合
        //    mouse.RoundEnd2(dmae);

        //    mouse.MoveAndFight(dmae, 575, 309, 619, 337, 779, 201, 812, 238, 483, 309, 561, 333, 0, 0);//第三开始
        //    mouse.delayTime(1);

        //    mouse.MoveAndFight(dmae, 775, 205, 811, 237, 961, 230, 1012, 284, 677, 201, 762, 232, 0, 0);//第四开始
        //    mouse.delayTime(1);

        //    mouse.MoveAndFight(dmae, 957, 236, 1021, 278, 751, 457, 797, 496, 1018, 247, 1144, 267, 1, 0);//第四开始
        //    mouse.delayTime(1);

        //    //结束回合
        //    mouse.RoundEnd2(dmae);

        //    mouse.MoveAndMove(dmae, 759, 347, 800, 378, 957, 110, 1009, 167, 631, 344, 745, 376, 0, 0);//第一开始
        //    mouse.delayTime(1);

        //    mouse.RoundEnd(dmae);

        //    mouse.delayTime(2);
        //    mouse.WaitToHome(dmae);
        //}

        //public void Battle2_1E(DmAe dmae, Mouse mouse, string mainteam, string supportteam , bool supply,bool setmap =false)
        //{

        //    mouse.LeftClickHomeToBattle(dmae, 2, 1, 1);
        //    mouse.delayTime(1);
        //    mouse.ClickFightType(dmae, "normal");
        //    mouse.delayTime(4);
        //    if(setmap == true)
        //    {
        //        mouse.MapSet(dmae, 635, 108, 219, 397, 1, 1, 130, 633);

        //    }

        //    mouse.ScreenUp(dmae, 358, 250, 998, 338, 98, 1,1,1,1,1,1); //900, 665
        //    mouse.Teamdispose(dmae, 184, 464, 223, 508, supportteam);//指挥部部署
        //    mouse.delayTime(1);

        //    mouse.Teamdispose(dmae, 618, 194, 649, 218, mainteam);//机场部署
        //    mouse.delayTime(1);

        //    mouse.BattleStart(dmae);
        //    mouse.delayTime(2);

        //    //开始补给

        //    if (supply == true) { mouse.Support(dmae, 618, 194, 649, 218); }

        //    mouse.MoveAndFight(dmae, 616, 193, 654, 223, 718, 355, 755, 380, 517, 186, 608, 217,0,0);//第一开始
        //    mouse.delayTime(1);

        //    mouse.MoveAndFight(dmae, 718, 354, 750, 380, 565, 360, 612, 395, 730, 392, 850, 402, 0,1);//第二开始
        //    mouse.delayTime(1);

        //    mouse.MoveAndFight(dmae, 576, 363, 609, 398, 407, 281, 431, 310, 586, 405, 595, 510,0, 1);//第三开始
        //    mouse.delayTime(1);

        //    mouse.MoveAndFight(dmae, 407, 281, 431, 310, 332, 436, 386, 479, 277, 276, 397, 311,0,0);//第四开始
        //    mouse.delayTime(1);

        //    mouse.RoundEnd(dmae);

        //    mouse.delayTime(2);
        //    mouse.WaitToHome(dmae);
        //}

        public void Battle2_4E(DmAe dmae, Mouse mouse, ref UserBattleInfo userBattleInfo)
        {

            object intX, intY;
            //MessageBox.Show("作者打了100多把都没有遇到强行撤离,使用时请注意", "少女前线");
            mouse.LeftClickHomeToBattle(dmae, "02", 1, 4);
            mouse.delayTime(1);
            mouse.ClickFightType(dmae, "normal", ref userBattleInfo);
            mouse.delayTime(4);


            if (userBattleInfo.SetMap == true)
            {
                mouse.MapSet(dmae, 236, 362, 261, 423, 1, 1, 214, 649);
            }

            mouse.ScreenUp(dmae, 39, 191, 167, 570, 100, 785, 283, 763, 297, 781, 297); //900, 665
            mouse.delayTime(1);

            mouse.Teamdispose(dmae, 266, 521, 303, 559, userBattleInfo.TaskMianTeam);//指挥部部署
            mouse.delayTime(1);

            mouse.BattleStart(dmae);

            //开始补给

            if (userBattleInfo.ChoiceToSupply == true) { mouse.Support(dmae, 266, 521, 303, 559); }

            mouse.MoveAndMove(dmae, 266, 521, 303, 559, 241, 359, 261, 378, 174, 516, 246, 534, 0, 0);//



            while (mouse.FindTeamSelectLine(dmae, 137, 348, 214, 361, 0) == 0)
            {
                mouse.LeftClick(dmae, 24, 142, 196, 248);
                mouse.delayTime(1);
            }

            mouse.Teamdispose(dmae, 266, 521, 303, 559, userBattleInfo.TaskSupportTeam1);//指挥部部署

            mouse.RoundEnd2(dmae);
            mouse.delayTime(10);

            mouse.ScreenUp(dmae, 39, 191, 167, 570, 100, 497, 412, 563, 503, 665, 478); //900, 665

            mouse.MoveAndFight(dmae, 233, 354, 269, 385, 359, 213, 391, 241, 121, 340, 212, 368, 1, 0);//

            mouse.ScreenUp(dmae, 39, 191, 167, 570, 100, 497, 412, 563, 503, 665, 478); //900, 665

            mouse.MoveAndFight(dmae, 355, 210, 393, 246, 580, 235, 614, 270, 238, 200, 335, 228, 0, 0);//need

            mouse.ScreenUp(dmae, 39, 191, 167, 570, 100, 497, 412, 563, 503, 665, 478); //900, 665

            mouse.MoveAndMove(dmae, 578, 236, 616, 262, 715, 306, 751, 349, 636, 228, 718, 248, 0, 0);//
            mouse.delayTime(1);

            mouse.RoundEnd(dmae, 713, 309, 756, 355, ref userBattleInfo);

            mouse.delayTime(2);
            mouse.WaitToHome(dmae);


        }

        //public void Battle3_3E(DmAe dmae, Mouse mouse, string mainteam, string supportteam, int tasktype, bool supply,bool fix,int fixmaxpercentage, bool setmap = false)
        //{

        //    mouse.LeftClickHomeToBattle(dmae, 3, 1, 3);
        //    mouse.delayTime(1);
        //    mouse.ClickFightType(dmae, "normal");
        //    mouse.delayTime(4);

        //    if(setmap == true)
        //    {
        //        mouse.MapSet(dmae, 359, 397, 902, 644, 1, 1, 130, 635);
        //    }



        //    //mouse.ScreenUp(dmae, 520, 136, 992, 203, 100, 649, 599, "94c6f7" + "|" + Settings.Default.AirPort, 811, 469, "94c6f7" + "|" + Settings.Default.AirPort); //900, 665
        //    //mouse.delayTime(1);

        //    if(tasktype == 1)
        //    {
        //        mouse.ScreenUp(dmae, 520, 136, 992, 203, 100, 1, 1, 1, 1, 1, 1); //900, 665    

        //        mouse.Teamdispose(dmae, 347, 471, 396, 521, mainteam);//指挥部部署
        //        mouse.delayTime(1);

        //        mouse.Teamdispose(dmae, 881, 666, 924, 698, supportteam);//机场部署
        //        mouse.delayTime(1);

        //        mouse.BattleStart(dmae);
        //        mouse.delayTime(2);

        //        if (supply == true) { mouse.Support(dmae, 349, 471, 402, 528); }

        //        mouse.MoveAndFight(dmae, 347, 471, 396, 521,/*第一个点*/
        //177, 357, 209, 391, /*第二个点*/412, 490, 520, 496/*检测范围*/, 0, 0);//


        //        mouse.MoveAndFight(dmae, 172, 354, 216, 392,/*第一个点*/ 394, 200, 448, 238, /*第二个点*/188, 408, 195, 520/*检测范围*/, 0, 1);//

        //        mouse.MoveAndMove(dmae, 402, 202, 449, 236, 170, 355, 211, 396, 460, 213, 570, 221, 0, 0);//
        //        mouse.delayTime(1);

        //        mouse.MoveToAirport(dmae, 164, 350, 218, 395, 343, 468, 406, 526,/**/ 188, 406, 196, 520, /*move坐标*/292, 418,/*点击移动坐标*/259, 429, 337, 454,1);//第四开始
        //        mouse.delayTime(1);
        //        //撤离
        //        mouse.Evacuate(dmae, 344, 417, 401, 464,fix, fixmaxpercentage);
        //        mouse.delayTime(1);
        //        mouse.StopBattle(dmae);

        //    }
        //    else if(tasktype == 2)
        //    {
        //        mouse.Teamdispose(dmae, 349, 471, 402, 528, supportteam);//指挥部部署
        //        mouse.delayTime(1);

        //        mouse.Teamdispose(dmae, 888, 664, 919, 701, mainteam);//机场部署
        //        mouse.delayTime(1);

        //        mouse.BattleStart(dmae);
        //        mouse.delayTime(2);

        //        //开始补给

        //        if (supply == true) { mouse.Support(dmae, 888, 664, 919, 701); }

        //        //第一开始
        //        mouse.ScreenUp(dmae, 520, 136, 992, 203, 100, 1, 1, 1, 1, 1, 1); //900, 665      

        //        mouse.MoveAndFight(dmae, 883, 668, 925, 698,/*第一个点*/808, 488, 847, 525, /*第二个点*/648, 677, 865, 682/*检测范围*/, 0, 0);//
        //                                                                                                                                            //第二开始
        //        mouse.MoveAndMove(dmae, 805, 408, 850, 449, 640, 254, 689, 296, 864, 424, 970, 433, 0, 0);//
        //        mouse.delayTime(1);
        //        //第三开始
        //        mouse.MoveAndMove(dmae, 639, 250, 689, 298, 833, 230, 890, 273, 701, 270, 810, 278, 0, 0);//
        //        mouse.delayTime(1);
        //        //第四开始
        //        mouse.MoveAndFight(dmae, 837, 234, 885, 273, 969, 97, 1042, 153, 899, 248, 1100, 258, 0, 0);//
        //                                                                                                    //结束回合
        //        mouse.RoundEnd(dmae);

        //        mouse.delayTime(2);
        //    }

        //    //不断双击直到回到主页
        //    mouse.WaitToHome(dmae);



        //}

        public void Battle3_4E(DmAe dmae, Mouse mouse, ref UserBattleInfo userBattleInfo)
        {

            mouse.LeftClickHomeToBattle(dmae, "03", 1, 4);

            mouse.ClickFightType(dmae, "normal", ref userBattleInfo);
            mouse.delayTime(4);

            if (userBattleInfo.SetMap == true)
            {
                mouse.MapSet(dmae, 407,227,751,187,614,359,640,417);

            }

            mouse.ScreenUp(dmae, 520, 136, 992, 203, 100, 519, 185, 881, 208, 271, 281); //900, 665





            mouse.Teamdispose(dmae, 1026, 212, 1075, 249,userBattleInfo.TaskSupportTeam1);//指挥部部署
            mouse.delayTime(1);

            mouse.Teamdispose(dmae, 707, 337, 733, 361, userBattleInfo.TaskMianTeam);//机场部署
            mouse.delayTime(1);

            mouse.BattleStart(dmae);
            mouse.delayTime(2);



            //开始补给

            if (userBattleInfo.ChoiceToSupply == true) { mouse.Support(dmae, 707, 337, 733, 361); }

            //第一开始
            mouse.MoveAndMove(dmae, 707, 337, 733, 361, 543, 345, 581, 378, 709, 230, 728, 278, 0, 1);//
            mouse.delayTime(1);
            mouse.MoveAndFight(dmae, 543, 345, 581, 378, 634, 492, 662, 531, 472, 346, 525, 356, 0, 0);//
            mouse.delayTime(1);

            mouse.ScreenDown(dmae, 61, 267, 262, 575, 250, 392, 483, 702, 482, 992, 455);

            //第二开始
            mouse.MoveAndMove(dmae, 630, 119, 667, 148, 571, 252, 601, 281, 686, 114, 712, 122, 0, 0);//
            mouse.delayTime(1);
            mouse.MoveAndFight(dmae, 569, 249, 603, 283, 497, 407, 543, 452, 621, 247, 699, 259, 0, 0);//

            mouse.ScreenDown(dmae, 61, 267, 262, 575, 250, 392, 483, 702, 482, 992, 455);
            //结束回合
            mouse.delayTime(1);
            mouse.RoundEnd(dmae, 497, 407, 543, 452,ref userBattleInfo);
            mouse.delayTime(2);
            //不断双击直到回到主页
            mouse.WaitToHome(dmae);
        }

        //public void Battle4_3(DmAe dmae, Mouse mouse, string mainteam, string supportteam, bool setmap = false)
        //{

        //    int ret = 0;
        //    mouse.LeftClickHomeToBattle(dmae, 4, 0, 3);
        //    mouse.delayTime(1);
        //    mouse.ClickFightType(dmae, "normal");
        //    mouse.delayTime(4);

        //    if (setmap == true)
        //    {
        //        //地图初始化测试
        //        mouse.MapSet(dmae, 678, 374, 642, 279, 1, 1, 662, 327);
        //    }


        //    mouse.Teamdispose(dmae, 378, 118, 422, 147, mainteam);//机场部署

        //    mouse.Teamdispose(dmae, 129, 526, 174, 568, supportteam);//指挥部部署

        //    mouse.BattleStart(dmae);
        //    mouse.delayTime(2);

        //    ret = mouse.MoveAndMove(dmae, 374, 115, 420, 148, 460, 261, 511, 294, 439, 126, 550, 133, 1, 0);

        //    if (ret == 1) { mouse.StopBattle(dmae); mouse.WaitToHome(dmae); return; }
        //    if (ret == 2) { mouse.StopBattle(dmae); mouse.WaitToHome(dmae); return; }

        //    mouse.delayTime(1);

        //    ret = mouse.MoveAndMove(dmae, 459, 260, 509, 295, 632, 312, 683, 353, 524, 270, 650, 279, 0, 0);

        //    ret = mouse.MoveAndMove(dmae, 635, 316, 680, 350, 616, 525, 657, 564, 698, 328, 820, 333, 1, 0);


        //    if (ret == 1) { mouse.StopBattle(dmae); mouse.WaitToHome(dmae); return; }
        //    if (ret == 2) { mouse.StopBattle(dmae); mouse.WaitToHome(dmae); return; }

        //    mouse.delayTime(1);

        //    ret = mouse.MoveAndMove(dmae, 616, 526, 657, 564, 378, 543, 436, 582, 678, 540, 800, 546, 1, 0);


        //    if (ret == 1) { mouse.StopBattle(dmae); mouse.WaitToHome(dmae); return; }
        //    if (ret == 2) { mouse.StopBattle(dmae); mouse.WaitToHome(dmae); return; }


        //    mouse.delayTime(1);
        //    mouse.StopBattle(dmae);


        //}

        public void Battle4_4E(DmAe dmae, Mouse mouse, ref UserBattleInfo userBattleInfo)
        {

            mouse.LeftClickHomeToBattle(dmae, "04", 1, 4);
            mouse.delayTime(1);
            mouse.ClickFightType(dmae, "normal", ref userBattleInfo);

            mouse.delayTime(4);


            //地图初始化测试
            if (userBattleInfo.SetMap == true)
            {
                mouse.MapSet(dmae, 399, 411, 906, 457, 158, 466, 220, 305);
            }


            mouse.Teamdispose(dmae, 1027, 452, 1077, 500, userBattleInfo.TaskSupportTeam1);//指挥部部署
            mouse.delayTime(1);
            mouse.ScreenUp(dmae, 358, 250, 998, 338, 450, 401, 171, 828, 222, 349, 263); //900, 665
            mouse.delayTime(1);
            mouse.Teamdispose(dmae, 1086, 144, 1119, 175, userBattleInfo.TaskMianTeam);//机场部署
            mouse.delayTime(1);

            mouse.BattleStart(dmae);
            mouse.delayTime(2);

            //开始补给


            if (userBattleInfo.ChoiceToSupply == true) { mouse.Support(dmae, 1084, 141, 1117, 178); }

            mouse.MoveAndFight(dmae, 1081, 140, 1125, 179, 844, 142, 883, 178, 1093, 182, 1112, 348, 0, 1);//第一开始

            mouse.ScreenUp(dmae, 358, 250, 998, 338, 450, 401, 171, 828, 222, 349, 263); //900, 665
            mouse.delayTime(1);

            mouse.MoveAndFight(dmae, 845, 141, 879, 173, 669, 140, 697, 176, 853, 189, 873, 276, 0, 1);//第二开始
            mouse.delayTime(1);
            mouse.ScreenUp(dmae, 358, 250, 998, 338, 450, 401, 171, 828, 222, 349, 263); //900, 665
            mouse.delayTime(1);

            if (userBattleInfo.TaskType == 2)
            {
                //第三开始
                mouse.MoveAndFight(dmae, 688, 157, 725, 186, 450, 158, 501, 195, 679, 184, 697, 255, 0, 1);//第二开始
                mouse.delayTime(1);
                mouse.ScreenUp(dmae, 358, 250, 998, 338, 450, 401, 171, 828, 222, 349, 263); //900, 665
                mouse.delayTime(1);
                //第四开始
                mouse.MoveAndFight(dmae, 452, 156, 492, 192, 185, 148, 238, 197, 464, 196, 483, 240, 0, 1);//第二开始
                mouse.delayTime(1);
                mouse.ScreenUp(dmae, 358, 250, 998, 338, 450, 401, 171, 828, 222, 349, 263); //900, 665
                mouse.delayTime(1);

                //结束回合
                mouse.delayTime(1);
                mouse.RoundEnd(dmae, 187, 142, 239, 196, ref userBattleInfo);

                mouse.delayTime(2);
                //不断双击直到回到主页
                mouse.WaitToHome(dmae);

            }

            else
            {

                //mouse.ScreenUp(dm, 358, 250, 998, 338, 99, 1084, 150, "94c6f7", 1083, 190, "94c6f7"); //900, 665
                mouse.delayTime(1);
                mouse.MoveAndMove(dmae, 670, 146, 706, 177, 843, 143, 882, 173, 680, 184, 702, 252, 0, 1);//第三开始

                mouse.ScreenUp(dmae, 358, 250, 998, 338, 450, 401, 171, 828, 222, 349, 263); //900, 665
                mouse.delayTime(1);

                mouse.delayTime(1);
                mouse.MoveToAirport(dmae, 843, 143, 882, 173, 1082, 139, 1123, 182, 856, 182, 872, 261, /*move坐标*/1060, 144,/*点击移动坐标*/987, 144, 1060, 175, 1);//第四开始
                mouse.delayTime(1);
                //撤离
                mouse.Evacuate(dmae, 1064, 152, 1105, 190, ref userBattleInfo);
                mouse.delayTime(1);
                mouse.StopBattle(dmae);

            }

        }

        //public void Battle5_1E(DmAe dmae, Mouse mouse, string mainteam, string supportteam, int tasktype,bool setmap = false)
        //{

        //    int ret = 0;
        //    mouse.LeftClickHomeToBattle(dmae, 5, 1, 1);
        //    mouse.delayTime(1);
        //    mouse.ClickFightType(dmae, "normal");
        //    mouse.delayTime(4);


        //    //地图初始化测试
        //    if(setmap == true)
        //    {
        //        mouse.MapSet(dmae, 194, 169, 190, 132, 1, 1, 500, 120);
        //    }



        //    mouse.Teamdispose(dmae, 1019, 127, 1063, 170, mainteam);//指挥部部署

        //    mouse.BattleStart(dmae);
        //    mouse.delayTime(2);

        //    ret = mouse.MoveAndMove(dmae, 1019, 127, 1063, 170, 867, 113, 906, 140, 1071, 140, 1151, 150 , 1, 0);//第一开始

        //    if (ret == 1) { mouse.WaitToHome(dmae); return; }
        //    if (ret == 2) { mouse.ImposedLeave(dmae); mouse.WaitToHome(dmae); return; }

        //    mouse.delayTime(1);


        //    mouse.MoveToAirport(dmae, 871, 115, 904, 140, 1019, 126, 1063, 174,/**/781, 124, 861, 132, /*move坐标*/1010, 130,/*点击移动坐标*/941, 133, 987, 163);//第二开始
        //    mouse.delayTime(1);



        //    ret = mouse.MoveAndMove(dmae, 1018, 126, 1066, 169, 976, 258, 1007, 287, 1071, 140, 1151, 150, 1, 0);


        //    if (ret == 1) { mouse.WaitToHome(dmae); return; }
        //    if (ret == 2) { mouse.ImposedLeave(dmae); mouse.WaitToHome(dmae); return; }

        //    mouse.delayTime(1);



        //    mouse.delayTime(1);
        //    mouse.StopBattle(dmae);


        //}

        //public void Battle5_2(DmAe dmae, Mouse mouse, string mainteam, string supportteam, int tasktype,bool setmap = false)
        //{

        //    int ret = 0;
        //    mouse.LeftClickHomeToBattle(dmae, 5, 0, 2);
        //    mouse.delayTime(1);
        //    mouse.ClickFightType(dmae, "normal");
        //    mouse.delayTime(4);

        //    if(setmap == true)
        //    {
        //        //地图初始化测试
        //        mouse.MapSet(dmae, 678, 374, 642, 279, 1, 1, 662, 327);
        //    }


        //    mouse.Teamdispose(dmae, 622, 291, 694, 366, mainteam );//指挥部部署

        //    mouse.BattleStart(dmae);
        //    mouse.delayTime(2);

        //    ret = mouse.MoveAndMove(dmae, 617, 292, 700, 366, 822, 218, 867, 259, 706, 322, 810, 331, 1, 0);

        //    if (ret == 1) { mouse.WaitToHome(dmae); return; }
        //    if(ret ==2) { mouse.ImposedLeave(dmae);mouse.WaitToHome(dmae); return; }

        //    mouse.delayTime(1);

        //    ret = mouse.MoveAndMove(dmae, 814, 217, 863, 256, 883, 5, 937, 30, 911, 233, 1020, 243, 1, 0);


        //    if (ret == 1) { mouse.WaitToHome(dmae); return; }
        //    if (ret == 2) { mouse.ImposedLeave(dmae); mouse.WaitToHome(dmae); return; }

        //    mouse.delayTime(1);



        //    mouse.delayTime(1);
        //    mouse.StopBattle(dmae);


        //}

        //public void Battle5_4(DmAe dmae, Mouse mouse, string mainteam, string supportteam, int tasktype,bool supply, bool fix, int fixmaxpercentage,bool setmap = false)
        //{

        //    mouse.LeftClickHomeToBattle(dmae, 5, 0, 4);
        //    mouse.delayTime(1);
        //    mouse.ClickFightType(dmae, "normal");
        //    mouse.delayTime(4);

        //    if(setmap == true)
        //    {
        //        mouse.MapSet(dmae, 270, 185, 930, 651, 440, 155, 430, 646);
        //    }

        //    mouse.Teamdispose(dmae, 1090, 158, 1147, 204, supportteam);//指挥部部署
        //    mouse.delayTime(1);

        //    //mouse.Teamdispose(dmae, 159, 215, 208, 245, mainteam);//指挥部部署
        //    //mouse.delayTime(1);

        //    //mouse.BattleStart(dmae);
        //    //mouse.delayTime(2);
        //    //if (supply == true) { mouse.Support(dmae, 159, 215, 208, 245); }

        //    //mouse.MoveAndFight(dmae, 159, 215, 208, 245, /*第一个点坐标*/327, 143, 356, 174,/*第二个点坐标*/ 245, 194, 303, 207/*监测点坐标*/, 0, 0);//第一开始
        //    //mouse.delayTime(1);

        //    //mouse.MoveAndFight(dmae, 323, 143, 360, 177, /*第一个点坐标*/471, 138, 500, 169,/*第二个点坐标*/ 339, 292, 346, 341/*监测点坐标*/, 0, 1);//第二开始
        //    //mouse.delayTime(1);

        //    //mouse.MoveAndFight(dmae, 468, 138, 501, 171, /*第一个点坐标*/646, 149, 667, 183,/*第二个点坐标*/ 480, 183, 495, 218/*监测点坐标*/, 0, 1);//第三开始
        //    //mouse.delayTime(1);

        //    //int dm_ret0 = mouse.MoveAndFight(dmae, 635, 154, 670, 183, /*第一个点坐标*/647, 283, 680, 315,/*第二个点坐标*/ 540, 149, 612, 163/*监测点坐标*/, 1, 0);//第四开始
        //    //mouse.delayTime(1);
        //    //if(dm_ret0 == 2) { mouse.StopBattle(dmae); return; }

        //    //mouse.MoveAndFight(dmae, 648, 282, 679, 315, /*第一个点坐标*/634, 384, 678, 435,/*第二个点坐标*/ 706, 279, 762, 290/*监测点坐标*/, 0, 0);//第五开始
        //    //mouse.delayTime(1);

        //    mouse.Teamdispose(dmae, 186, 631, 217, 662, mainteam);//指挥部部署
        //    mouse.delayTime(1);

        //    mouse.BattleStart(dmae);
        //    mouse.delayTime(2);
        //    if (supply == true) { mouse.Support(dmae, 186, 631, 217, 662); }

        //    mouse.MoveAndMove(dmae, 182, 624, 224, 667, /*第一个点坐标*/316, 541, 353, 571,/*第二个点坐标*/ 242, 628, 305, 641/*监测点坐标*/, 0, 0);//第一开始
        //    mouse.delayTime(1);

        //    mouse.MoveAndMove(dmae, 316, 541, 353, 571, /*第一个点坐标*/496, 528, 525, 558,/*第二个点坐标*/ 327, 579, 341, 625/*监测点坐标*/, 0, 1);//第二开始
        //    mouse.delayTime(1);

        //    mouse.MoveAndFight(dmae, 496, 528, 525, 558, /*第一个点坐标*/643, 525, 677, 552,/*第二个点坐标*/ 494, 567, 527, 676/*监测点坐标*/, 0, 1);//第三开始
        //    mouse.delayTime(1);


        //    //地图往下移
        //    mouse.ScreenDown(dmae, 12, 112, 130, 318, 100, 441, 551, 922, 210, 1024, 501);


        //    mouse.MoveAndFight(dmae, 647, 428, 680, 457, /*第一个点坐标*/625, 288, 680, 345,/*第二个点坐标*/ 655, 465, 670, 555/*监测点坐标*/, 0, 1);//第三开始
        //    mouse.delayTime(1);

        //    //地图往下移
        //    mouse.ScreenDown(dmae, 12, 112, 130, 318, 100, 441, 551, 922, 210, 1024, 501);


        //    mouse.RoundEnd(dmae, 631, 286, 680, 343, fix,fixmaxpercentage);
        //    mouse.delayTime(2);
        //    mouse.WaitToHome(dmae);

        //}
        public void Battle0_1(DmAe dmae, Mouse mouse, ref UserBattleInfo userBattleInfo)
        {

            mouse.LeftClickHomeToBattle(dmae, "00", 0, 1);
            mouse.delayTime(1);
            mouse.ClickFightType(dmae, "normal", ref userBattleInfo);

            mouse.delayTime(4);
            if (userBattleInfo.SetMap == true)
            {
                mouse.MapSet(dmae, 573, 87, 861, 128, 499, 195, 171, 701, "ScreenDown");
            }


            mouse.delayTime(1);
            if (mouse.Teamdispose(dmae, 332, 325, 435, 424, userBattleInfo.TaskMianTeam) == -1)//指挥部部署
            {
                mouse.BackToHomeFromBattlePageREADY(dmae);
                userBattleInfo.Team_Serror = true;
                return;
            }


            mouse.BattleStart(dmae);

            //x1,y1,x2,y2起始范围,amount启动的像素点 ,x4 y4 为检测点,x5y5x6y6,col5col6col4为颜色
            //开始补给

            if (userBattleInfo.ChoiceToSupply == true) { mouse.Support(dmae, 332, 325, 435, 424); }

            mouse.MoveAndMove(dmae, 342, 322, 426, 407, /*第一个点坐标*/486, 433, 541, 491,/*第二个点坐标*/199, 326, 322, 347/*监测点坐标*/, 0, 0);//第一开始
            mouse.MoveAndFight(dmae, 486, 433, 541, 491, /*第一个点坐标*/579, 237, 636, 297,/*第二个点坐标*/ 348, 434, 457, 450/*监测点坐标*/, 0, 0);//第一开始
            mouse.ScreenDown(dmae, 59, 212, 268, 482, 200, 891, 99, 544, 96, 499, 195);//x1,y1,x2,y2起始范围,x3启动的像素点 ,x4 y4 为检测点，string col为颜色

            mouse.RoundEnd2(dmae);
            mouse.ScreenDown(dmae, 59, 212, 268, 482, 200, 891, 99, 544, 96, 499, 195);//x1,y1,x2,y2起始范围,x3启动的像素点 ,x4 y4 为检测点，string col为颜色

            mouse.MoveAndMove(dmae, 578, 247, 636, 290, /*第一个点坐标*/448, 139, 484, 155,/*第二个点坐标*/394, 234, 548, 254/*监测点坐标*/, 0, 0);//第一开始
            mouse.MoveAndMove(dmae, 436, 112, 494, 157, /*第一个点坐标*/678, 73, 703, 102,/*第二个点坐标*/291, 104, 406, 119/*监测点坐标*/, 0, 0);//第一开始
            mouse.MoveAndFight(dmae, 646, 66, 702, 98, /*第一个点坐标*/768, 158, 824, 210,/*第二个点坐标*/ 661, 102, 686, 194/*监测点坐标*/, 0, 1);//第一开始

            mouse.ScreenDown(dmae, 59, 212, 268, 482, 200, 891, 99, 544, 96, 499, 195);//x1,y1,x2,y2起始范围,x3启动的像素点 ,x4 y4 为检测点，string col为颜色
            mouse.RoundEnd(dmae, 770, 157, 824, 210, ref userBattleInfo);



        }







        public void Battle3_2N(DmAe dmae, Mouse mouse, ref UserBattleInfo userBattleInfo)
        {


            mouse.LeftClickHomeToBattle(dmae, "03", 2, 2);
            mouse.delayTime(1);
            mouse.ClickFightType(dmae, "normal", ref userBattleInfo);

            mouse.delayTime(4);


            if (userBattleInfo.SetMap == true)
            {
                mouse.MapSet(dmae, 907, 566, 920, 574, 959, 566, 88, 613);//x1,y1,x2,y2,x3,y3是地图缩放到最小的监测点x4y4鼠标移动位置
            }

            mouse.delayTime(1);
            mouse.Teamdispose(dmae, 244, 206, 274, 241, userBattleInfo.TaskMianTeam);//指挥部部署

            mouse.Teamdispose(dmae, 294, 543, 336, 588, userBattleInfo.TaskSupportTeam1);//指挥部部署

            mouse.BattleStart(dmae);
            mouse.delayTime(2);

            //关掉任务简报
            mouse.ClosMissionHelp(dmae);
            //开始补给
            if (userBattleInfo.ChoiceToSupply == true) { mouse.Support(dmae, 244, 206, 274, 241); }
            mouse.MoveAndFight(dmae, 244, 206, 274, 241, /*第一个点坐标*/472, 165, 520, 203,/*第二个点坐标*/135, 203, 215, 211/*监测点坐标*/, 0, 0);//第一开始

            mouse.MoveAndFight(dmae, 472, 165, 520, 203, /*第一个点坐标*/643, 281, 679, 317,/*第二个点坐标*/319, 157, 450, 177/*监测点坐标*/, 0, 0);//第一开始

            switch (userBattleInfo.TaskType)
            {
                case 1:
                    {
                        mouse.MoveAndMove(dmae, 643, 281, 679, 317, /*第一个点坐标*/472, 165, 520, 203,/*第二个点坐标*/463, 272, 594, 296/*监测点坐标*/, 0, 0);//第二开始

                        mouse.MoveToAirport(dmae, 456, 163, 494, 199, 219, 206, 259, 238,/**/ 332, 155, 426, 177, /*move坐标*/221, 205,/*点击移动坐标*/145, 203, 222, 239);//第四开始

                        mouse.Evacuate(dmae, 240, 208, 273, 239, ref userBattleInfo);
                        mouse.delayTime(1);
                        mouse.StopBattle(dmae);
                        break;
                    }
                case 2:
                    {
                        mouse.MoveAndFight(dmae, 619, 283, 661, 318, /*第一个点坐标*/507, 500, 552, 538,/*第二个点坐标*/463, 272, 594, 296/*监测点坐标*/, 0, 0);//第一开始

                        mouse.MoveToAirport(dmae, 530, 500, 569, 535, 290, 543, 332, 580,/**/595, 498, 663, 506, /*move坐标*/240, 545,/*点击移动坐标*/196, 547, 273, 578);//第四开始
                        mouse.Evacuate(dmae, 291, 545, 330, 576, ref userBattleInfo);
                        mouse.delayTime(1);
                        mouse.StopBattle(dmae);

                        break;
                    }
            }




        }

































        public void Battle5_4(DmAe dmae, Mouse mouse, ref UserBattleInfo userBattleInfo)
        {
            mouse.LeftClickHomeToBattle(dmae, "05", 0, 4);
            mouse.delayTime(1);
            mouse.ClickFightType(dmae, "normal", ref userBattleInfo);



            mouse.delayTime(4);
            if (userBattleInfo.SetMap == true)
            {
                mouse.MapSet(dmae, 971, 158, 876, 651, 286, 589, 377, 327);
            }



            switch (userBattleInfo.TaskType)
            {

                case 1://4战
                    {

                        mouse.delayTime(1);
                        if (mouse.Teamdispose(dmae, 1020, 148, 1076, 193, userBattleInfo.TaskMianTeam) == -1)//指挥部部署
                        {
                            mouse.BackToHomeFromBattlePageREADY(dmae);
                            userBattleInfo.Team_Serror = true;
                            return;
                        }
                        mouse.delayTime(1);
                        if (mouse.Teamdispose(dmae, 183, 197, 224, 230, userBattleInfo.TaskSupportTeam1) == -1)//机场部署
                        {
                            mouse.BackToHomeFromBattlePageREADY(dmae);
                            userBattleInfo.Team_Serror = true;
                        }
                        mouse.delayTime(1);

                        mouse.BattleStart(dmae);
                        mouse.delayTime(2);

                        //x1,y1,x2,y2起始范围,amount启动的像素点 ,x4 y4 为检测点,x5y5x6y6,col5col6col4为颜色
                        //开始补给

                        if (userBattleInfo.ChoiceToSupply == true) { mouse.Support(dmae, 1020, 148, 1076, 193); }

                        mouse.MoveAndFight(dmae, 1020, 148, 1076, 193, /*第一个点坐标*/830, 125, 860, 154,/*第二个点坐标*/ 1086, 151, 1149, 161/*监测点坐标*/, 0, 0);//第一开始
                        mouse.ScreenUp(dmae, 70, 270, 269, 369, 100, 971, 158, 876, 651, 286, 589);



                        mouse.MoveAndFight(dmae, 827, 123, 861, 151, 642, 152, 675, 182, 841, 553, 854, 625, 0, 1);//第二开始
                        mouse.ScreenUp(dmae, 70, 270, 269, 369, 100, 971, 158, 876, 651, 286, 589);
                        mouse.delayTime(1);

                        mouse.MoveAndFight(dmae, 638, 152, 675, 188, 646, 285, 680, 314, 694, 147, 782, 158, 0, 0);//第三开始
                        mouse.ScreenUp(dmae, 70, 270, 269, 369, 100, 971, 158, 876, 651, 286, 589);

                        mouse.MoveAndFight(dmae, 646, 285, 680, 314, 632, 389, 679, 434, 703, 281, 786, 289, 0, 0);//第四开始
                        mouse.ScreenUp(dmae, 70, 270, 269, 369, 100, 971, 158, 876, 651, 286, 589);

                        mouse.delayTime(1);
                        mouse.RoundEnd(dmae, 626, 393, 677, 433, ref userBattleInfo);

                        break;
                    }

                case 2:
                    {
                        mouse.delayTime(1);
                        if (mouse.Teamdispose(dmae, 185, 635, 227, 665, userBattleInfo.TaskMianTeam) == -1)//指挥部部署
                        {
                            mouse.BackToHomeFromBattlePageREADY(dmae);
                            userBattleInfo.Team_Serror = true;
                            return;
                        }
                        mouse.delayTime(1);
                        if (mouse.Teamdispose(dmae, 1027, 149, 1068, 194, userBattleInfo.TaskSupportTeam1) == -1)//机场部署
                        {
                            mouse.BackToHomeFromBattlePageREADY(dmae);
                            userBattleInfo.Team_Serror = true;
                            return;
                        }
                        mouse.delayTime(1);

                        mouse.BattleStart(dmae);
                        mouse.delayTime(2);

                        mouse.ScreenDown(dmae, 36, 228, 145, 333, 100, 279, 552, 471, 550, 555, 449);
                        //x1,y1,x2,y2起始范围,amount启动的像素点 ,x4 y4 为检测点,x5y5x6y6,col5col6col4为颜色
                        //开始补给

                        if (userBattleInfo.ChoiceToSupply == true) { mouse.Support(dmae, 187, 544, 218, 571); }

                        mouse.ScreenDown(dmae, 36, 228, 145, 333, 100, 279, 552, 471, 550, 555, 449);
                        mouse.MoveAndMove(dmae, 187, 544, 218, 571, /*第一个点坐标*/314, 451, 353, 478,/*第二个点坐标*/57, 535, 162, 550/*监测点坐标*/, 0, 0);//第一开始


                        mouse.ScreenDown(dmae, 36, 228, 145, 333, 100, 447, 551, 288, 176, 869, 433);

                        mouse.MoveAndMove(dmae, 314, 451, 353, 478, /*第一个点坐标*/496, 439, 525, 471,/*第二个点坐标*/327, 485, 342, 568/*监测点坐标*/, 0, 1);//第二开始


                        mouse.ScreenDown(dmae, 36, 228, 145, 333, 100, 447, 551, 288, 176, 869, 433);

                        mouse.MoveAndFight(dmae, 496, 439, 525, 471, /*第一个点坐标*/648, 429, 679, 462,/*第二个点坐标*/ 504, 579, 516, 642/*监测点坐标*/, 0, 1);//第三开始


                        mouse.ScreenDown(dmae, 36, 228, 145, 333, 100, 447, 551, 288, 176, 869, 433);

                        mouse.MoveAndFight(dmae, 649, 433, 679, 461, /*第一个点坐标*/634, 290, 674, 339,/*第二个点坐标*/538, 422, 621, 436/*监测点坐标*/, 0, 0);//第四开始



                        //结束回合
                        mouse.ScreenUp(dmae, 70, 270, 269, 369, 100, 971, 158, 876, 651, 286, 589);

                        mouse.delayTime(1);
                        mouse.RoundEnd(dmae, 626, 393, 677, 433, ref userBattleInfo);

                        break;
                    }

                default:
                    break;
            }
        }
        public void Battle5_4E(DmAe dmae, Mouse mouse, ref UserBattleInfo userBattleInfo)
        {


            mouse.LeftClickHomeToBattle(dmae, "05", 1, 4);
            mouse.delayTime(1);
            mouse.ClickFightType(dmae, "normal", ref userBattleInfo);



            mouse.delayTime(4);
            if (userBattleInfo.SetMap == true)
            {
                mouse.MapSet(dmae, 183, 121, 751, 172, 571, 473, 88, 613);
            }



            switch (userBattleInfo.TaskType)
            {

                case 1:
                    {

                        mouse.delayTime(1);
                        if (mouse.Teamdispose(dmae, 1010, 506, 1072, 558, userBattleInfo.TaskMianTeam) == -1)//指挥部部署
                        {
                            mouse.BackToHomeFromBattlePageREADY(dmae);
                            userBattleInfo.Team_Serror = true;
                            return;
                        }

                        mouse.delayTime(1);
                        mouse.ScreenUp(dmae, 231, 115, 1184, 219, 300, 587, 633, 446, 249, 229, 252);
                        mouse.delayTime(1);

                        if(mouse.Teamdispose(dmae, 1045, 122, 1080, 154, userBattleInfo.TaskSupportTeam1)==-1)//机场部署
                        {
                            mouse.BackToHomeFromBattlePageREADY(dmae);
                            userBattleInfo.Team_Serror = true;
                            return;
                        }
                        mouse.delayTime(1);
                        //画面往下移动
                        mouse.ScreenDown(dmae, 333, 197, 1132, 243, 360, 183, 121, 751, 172, 571, 473);

                        mouse.BattleStart(dmae);
                        mouse.delayTime(2);

                        //画面往下移动

                        //x1,y1,x2,y2起始范围,amount启动的像素点 ,x4 y4 为检测点,x5y5x6y6,col5col6col4为颜色
                        //开始补给

                        if (userBattleInfo.ChoiceToSupply == true) { mouse.Support(dmae, 1020, 505, 1072, 562); }

                        mouse.MoveAndFight(dmae, 1021, 501, 1074, 557, /*第一个点坐标*/1077, 264, 1112, 291,/*第二个点坐标*/ 839, 529, 996, 546/*监测点坐标*/, 0,0);//第一开始

                        mouse.ScreenDown(dmae, 333, 197, 1132, 243, 360, 183, 121, 751, 172, 571, 473);



                        mouse.MoveAndFight(dmae, 1074, 264, 1111, 296, 886, 337, 924, 371, 967, 255, 1056, 274, 0,0);//第二开始
                        mouse.delayTime(1);


                        mouse.ScreenDown(dmae, 333, 197, 1132, 243, 360, 183, 121, 751, 172, 571, 473);
                        mouse.delayTime(1);

                        mouse.MoveAndFight(dmae, 889, 338, 929, 376, 766, 488, 808, 527, 803, 333, 867, 349, 0,0);//第三开始
                        mouse.ScreenDown(dmae, 333, 197, 1132, 243, 360, 183, 121, 751, 172, 571, 473);

                        //mouse.ScreenDown(dmae, 333, 197, 1132, 243, 360, 378, 217, "94c6f7" + "|" + Settings.Default.AirPort, 1022, 130, "94c6f7" + "|" + Settings.Default.AirPort);
                        //mouse.delayTime(1);

                        mouse.MoveToAirport(dmae, 771, 496, 802, 523, 1013, 532, 1068, 578,/**/676, 486, 748, 501, /*move坐标*/960, 537,/*点击移动坐标*/926, 537, 1005, 566);//第四开始
                        mouse.delayTime(1);
                        //撤离
                        mouse.Evacuate(dmae, 1019, 515, 1068, 555, ref userBattleInfo);
                        mouse.delayTime(1);
                        mouse.StopBattle(dmae);
                        break;
                    }

                case 2:
                    {
                        mouse.delayTime(1);
                        if(mouse.Teamdispose(dmae, 1010, 506, 1072, 558, userBattleInfo.TaskSupportTeam1)==-1)//指挥部部署
                        {
                            mouse.BackToHomeFromBattlePageREADY(dmae);
                            userBattleInfo.Team_Serror = true;
                            return;
                        }
                        mouse.delayTime(1);
                        mouse.ScreenUp(dmae, 231, 115, 1184, 219, 300, 587, 633, 446, 249, 229, 252);
                        mouse.delayTime(1);
                        if(mouse.Teamdispose(dmae, 1045, 122, 1080, 154, userBattleInfo.TaskMianTeam)==-1)//机场部署
                        {
                            mouse.BackToHomeFromBattlePageREADY(dmae);
                            userBattleInfo.Team_Serror = true;
                            return;
                        }
                        mouse.delayTime(1);

                        mouse.BattleStart(dmae);
                        mouse.delayTime(2);

                        if (userBattleInfo.ChoiceToSupply == true) { mouse.Support(dmae, 1045, 122, 1080, 154); }

                        mouse.MoveAndFight(dmae, 1041, 125, 1081, 154, /*第一个点坐标*/824, 102, 866, 132,/*第二个点坐标*/1136, 163, 1266, 172/*监测点坐标*/, 0,0);//第一开始


                        mouse.ScreenUp(dmae, 231, 115, 1184, 219, 300, 587, 633, 446, 249, 229, 252);


                        mouse.MoveAndFight(dmae, 843, 143, 876, 174, /*第一个点坐标*/665, 202, 702, 232,/*第二个点坐标*/742, 136, 817, 155/*监测点坐标*/, 0,0);//第二开始


                        mouse.ScreenUp(dmae, 231, 115, 1184, 219, 300, 587, 633, 446, 249, 229, 252);


                        mouse.MoveAndFight(dmae, 666, 199, 708, 233, /*第一个点坐标*/457, 169, 503, 200,/*第二个点坐标*/ 678, 297, 694, 391/*监测点坐标*/, 0,1);//第三开始


                        mouse.ScreenUp(dmae, 231, 115, 1184, 219, 300, 587, 633, 446, 249, 229, 252);


                        mouse.MoveAndFight(dmae, 459, 168, 496, 196, /*第一个点坐标*/229, 191, 292, 241,/*第二个点坐标*/700, 161, 762, 180/*监测点坐标*/, 0,0);//第四开始


                        mouse.ScreenUp(dmae, 231, 115, 1184, 219, 300, 587, 633, 446, 249, 229, 252);


                        //结束回合

                        mouse.RoundEnd(dmae, 229, 191, 292, 241,ref userBattleInfo);

                        break;
                    }
                case 3:
                    {

                        mouse.delayTime(1);
                        if(mouse.Teamdispose(dmae, 1010, 506, 1072, 558, userBattleInfo.TaskMianTeam)==-1)//指挥部部署
                        {
                            mouse.BackToHomeFromBattlePageREADY(dmae);
                            userBattleInfo.Team_Serror = true;
                            return;
                        }

                        mouse.delayTime(1);
                        mouse.ScreenUp(dmae, 231, 115, 1184, 219, 300, 587, 633, 446, 249, 229, 252);
                        mouse.delayTime(1);
                        if(mouse.Teamdispose(dmae, 1045, 122, 1080, 154, userBattleInfo.TaskSupportTeam1)==-1)//机场部署
                        {
                            mouse.BackToHomeFromBattlePageREADY(dmae);
                            userBattleInfo.Team_Serror = true;
                            return;
                        }
                        mouse.delayTime(1);

                        mouse.BattleStart(dmae);
                        mouse.delayTime(2);

                        //画面往下移动
                        mouse.ScreenDown(dmae, 333, 197, 1132, 243, 360, 276, 106, 818, 78, 997, 127);
                        //开始补给

                        if (userBattleInfo.ChoiceToSupply == true) { mouse.Support(dmae, 1020, 505, 1072, 562); }

                        mouse.MoveAndFight(dmae, 1021, 501, 1074, 557, /*第一个点坐标*/1065, 306, 1097, 338,/*第二个点坐标*/ 1075, 525, 1201, 535/*监测点坐标*/, 0, 0);//第一开始
                        mouse.delayTime(1);

                        mouse.MoveToAirport(dmae, 1066, 308, 1108, 343, 1018, 509, 1070, 559,/**/1114, 321, 1214, 330, /*move坐标*/1000, 515,/*点击移动坐标*/930, 523, 1007, 548);//第四开始
                        mouse.delayTime(1);

                        mouse.MoveAndFight(dmae, 1015, 508, 1074, 549, 755, 538, 794, 569, 1075, 525, 1201, 535, 0, 0);//第二开始
                        mouse.delayTime(1);

                        mouse.MoveToAirport(dmae, 759, 541, 789, 572, 1019, 515, 1068, 555,/**/ 807, 551, 910, 560, /*move坐标*/1020, 525,/*点击移动坐标*/920, 514, 1012, 547);//第四开始
                        mouse.delayTime(1);

                        //撤离
                        mouse.Evacuate(dmae, 1019, 515, 1068, 555,ref userBattleInfo);
                        mouse.delayTime(1);
                        mouse.StopBattle(dmae);
                        break;
                    }

                case 4:
                    {

                        mouse.delayTime(1);
                        if(mouse.Teamdispose(dmae, 1010, 506, 1072, 558, userBattleInfo.TaskMianTeam)==-1)//指挥部部署
                        {
                            mouse.BackToHomeFromBattlePageREADY(dmae);
                            userBattleInfo.Team_Serror = true;
                            return;
                        }
                        mouse.delayTime(1);
                        mouse.ScreenUp(dmae, 231, 115, 1184, 219, 300, 587, 633, 446, 249, 229, 252);
                        mouse.delayTime(1);
                        if(mouse.Teamdispose(dmae, 1045, 122, 1080, 154, userBattleInfo.TaskSupportTeam1)==-1)//机场部署
                        {
                            mouse.BackToHomeFromBattlePageREADY(dmae);
                            userBattleInfo.Team_Serror = true;
                            return;
                        }

                        mouse.delayTime(1);

                        mouse.BattleStart(dmae);
                        mouse.delayTime(2);

                        //画面往下移动
                        mouse.ScreenDown(dmae, 333, 197, 1132, 243, 360, 276, 106, 818, 78, 997, 127);
                        //开始补给

                        if (userBattleInfo.ChoiceToSupply == true) { mouse.Support(dmae, 1020, 505, 1072, 562); }

                        mouse.MoveAndFight(dmae, 1021, 501, 1074, 557, /*第一个点坐标*/1065, 306, 1097, 338,/*第二个点坐标*/ 1075, 526, 1200, 534/*监测点坐标*/, 0, 0);//第一开始
                        mouse.delayTime(1);

                        mouse.MoveAndFight(dmae, 1064, 308, 1104, 340, 1008, 136, 1053, 169, 1114, 321, 1214, 330, 0, 0);//第二开始
                        mouse.delayTime(1);

                        mouse.MoveAndMove(dmae, 1008, 377, 1049, 408, 1063, 547, 1100, 580, 1061, 385, 1200, 394, 0, 0);//
                        mouse.delayTime(1);

                        mouse.ScreenDown(dmae, 333, 197, 1132, 243, 360, 276, 106, 818, 78, 997, 127);
                        mouse.delayTime(1);

                        mouse.MoveToAirport(dmae, 1059, 309, 1104, 343, 1014, 508, 1070, 557,/**/  1114, 321, 1214, 330, /*move坐标*/1000, 515,/*点击移动坐标*/930, 523, 1007, 548);//第四开始
                        mouse.delayTime(1);

                        //撤离
                        mouse.Evacuate(dmae, 1019, 515, 1068, 555,ref userBattleInfo);
                        mouse.delayTime(1);
                        mouse.StopBattle(dmae);
                        break;
                    }

                default:
                    break;
            }



            
        }

        public void Battle6_6(DmAe dmae, Mouse mouse, ref UserBattleInfo userBattleInfo)
        {

            mouse.LeftClickHomeToBattle(dmae, "06", 0, 6);
            mouse.delayTime(1);
            mouse.ClickFightType(dmae, "normal", ref userBattleInfo);
            if (userBattleInfo.NeetToDismantleGun == true)  return; 


            mouse.delayTime(4);
            if (userBattleInfo.SetMap == true)
            {
                mouse.MapSet(dmae, 830, 378, 802, 384, 810, 366, 307, 146, "ScreenUp");
            }


            mouse.delayTime(1);
            if (mouse.Teamdispose(dmae, 130, 190, 170, 234, userBattleInfo.TaskMianTeam) == -1)//指挥部部署
            {
                mouse.BackToHomeFromBattlePageREADY(dmae);
                userBattleInfo.Team_Serror = true;
                return;
            }


            mouse.BattleStart(dmae);

            //x1,y1,x2,y2起始范围,amount启动的像素点 ,x4 y4 为检测点,x5y5x6y6,col5col6col4为颜色
            //开始补给

            if (userBattleInfo.ChoiceToSupply == true) { mouse.Support(dmae, 130, 190, 170, 234); }


            mouse.MoveAndFight(dmae, 130, 190, 170, 234, /*第一个点坐标*/359, 203, 396, 229,/*第二个点坐标*/ 144, 230, 160, 293/*监测点坐标*/, 0, 1);//第一开始

            mouse.MoveAndMove(dmae, 363, 204, 396, 230, /*第一个点坐标*/541, 209, 574, 241,/*第二个点坐标*/373, 234, 389, 308/*监测点坐标*/, 0, 1);//第一开始

            mouse.MoveAndFight(dmae, 543, 209, 572, 235, /*第一个点坐标*/672, 206, 704, 239,/*第二个点坐标*/ 551, 262, 565, 315/*监测点坐标*/, 0, 1);//第一开始

            mouse.RoundEnd2(dmae);

            mouse.Support(dmae, 673, 213, 705, 237);

            mouse.MoveAndFight(dmae, 673, 213, 705, 237, /*第一个点坐标*/611, 324, 642, 359,/*第二个点坐标*/ 564, 201, 655, 222/*监测点坐标*/, 1, 0);//第一开始

            mouse.MoveAndMove(dmae, 607, 327, 639, 356, /*第一个点坐标*/536, 522, 566, 555,/*第二个点坐标*/656, 322, 748, 335/*监测点坐标*/, 0, 0);//第一开始

            mouse.MoveAndFight(dmae, 533, 520, 563, 549, /*第一个点坐标*/729, 558, 757, 584,/*第二个点坐标*/ 583, 521, 635, 531/*监测点坐标*/, 0, 0);//第一开始

            mouse.ScreenUp(dmae, 547, 95, 903, 146, 300, 830, 378, 802, 384, 810, 366);//x1,y1,x2,y2起始范围,x3启动的像素点 ,x4 y4 为检测点，string col为颜色

            mouse.MoveAndFight(dmae, 729, 558, 763, 589, /*第一个点坐标*/752, 392, 792, 438,/*第二个点坐标*/ 775, 553, 854, 570/*监测点坐标*/, 0, 0);//第一开始

            mouse.ScreenUp(dmae, 547, 95, 903, 146, 300, 830, 378, 802, 384, 810, 366);//x1,y1,x2,y2起始范围,x3启动的像素点 ,x4 y4 为检测点，string col为颜色

            mouse.RoundEnd(dmae, 749, 389, 800, 440, ref userBattleInfo);



        }



        //public void SummerE4(DmAe dmae, Mouse mouse, string mainteam, string supportteam, int tasktype, bool supply,bool fix,int fixmaxpercentage, bool setmap = false)
        //{

        //    object intX, intY;
        //    bool ret0;
        //    mouse.LeftClickHomeToBattle(dmae, 11,0, 14);
        //    mouse.delayTime(1);
        //    mouse.ClickFightType(dmae, "normal");

        //    mouse.delayTime(4);


        //    if (setmap == true)
        //    {
        //        mouse.MapSet(dmae, 1031, 495, 1056, 563, 1, 1, 120, 650);
        //    }

        //    mouse.delayTime(1);
        //    mouse.Teamdispose(dmae, 571, 100, 604, 140, mainteam);//指挥部部署

        //    mouse.BattleStart(dmae);
        //    mouse.delayTime(2);

        //    //关掉任务简报
        //    mouse.ClosMissionHelp(dmae);
        //    //开始补给

        //    if (supply == true) { mouse.Support(dmae, 571, 100, 604, 140); }

        //    mouse.MoveAndMove(dmae, 571, 100, 604, 140, 578, 241, 606, 268, 610, 115, 710, 122, 0, 0);//
        //    mouse.delayTime(1);

        //    mouse.MoveAndMove(dmae, 578, 241, 606, 268, 552, 399, 585, 424, 615, 250, 715, 257, 0, 0);//
        //    mouse.delayTime(1);

        //    mouse.RoundEnd2(dmae);
        //    mouse.delayTime(1,1);
        //    //回合结束

        //    int ret = mouse.MoveAndFight(dmae, 552, 397, 584, 425, /*第一个点坐标*/570, 506, 603, 533,/*第二个点坐标*/ 590, 407, 690, 414/*监测点坐标*/, 1, 0);//第一开始
        //    mouse.delayTime(1, 1);
        //    if (ret == 1) { mouse.WaitToHome(dmae); return; }
        //    if (ret == 2) { mouse.ImposedLeave(dmae); mouse.WaitToHome(dmae); return; }

        //    mouse.MoveAndMove(dmae, 571, 424, 602, 448, 559, 546, 598, 578, 613, 433, 713, 439, 0, 0);//
        //    mouse.delayTime(1);
        //    mouse.RoundEnd2(dmae);
        //    //回合结束

        //    //分歧开始
        //    switch (tasktype)
        //    {
        //        case 1:
        //            {
        //                mouse.ScreenDown(dmae, 333, 197, 1132, 243, 360, 1, 1, 1, 1, 1, 1);

        //                mouse.MoveAndMove(dmae, 558, 204, 594, 239, 580, 309, 612, 339, 440, 218, 555, 223, 0, 0);//
        //                mouse.delayTime(1);

        //                int dm_ret0 =mouse.FindTeamSelectLine(dmae, 730, 322, 843, 328, 0);

        //                while (dm_ret0 == 1)
        //                {
        //                    mouse.LeftClick(dmae, 585, 312, 615, 338);
        //                    mouse.delayTime(1);
        //                    dm_ret0 = dm_ret0 = mouse.FindTeamSelectLine(dmae, 730, 322, 843, 328, 0);
        //                    //mouse.CheckTeamSlect(dmae);
        //                }

        //                while (dm_ret0 == 0)
        //                {
        //                    mouse.LeftClick(dmae, 72, 154, 346, 312);
        //                    mouse.delayTime(1);
        //                    dm_ret0 = dm_ret0 = mouse.FindTeamSelectLine(dmae, 730, 322, 843, 328, 0);
        //                    //mouse.CheckTeamSlect(dmae);
        //                }

        //                mouse.Teamdispose(dmae, 565, 208, 586, 237, supportteam);//机场部署2队
        //                mouse.delayTime(1);

        //                mouse.MoveToAirport(dmae, 578, 311, 611, 340 , 562, 208, 595, 229, 624, 322, 730, 328, 515, 203, 465, 209, 538, 232);

        //                //撤离
        //                mouse.Evacuate(dmae, 563, 203, 594, 234,fix, fixmaxpercentage);
        //                mouse.delayTime(1);
        //                mouse.StopBattle(dmae);
        //                                        break;
        //            }

        //        case 2:
        //            {
        //                mouse.MoveAndMove(dmae, 554, 232, 600, 270, 584, 344, 610, 371, 426, 228, 555, 265, 0, 0);//
        //                mouse.delayTime(1);

        //                mouse.MoveAndMove(dmae, 580, 344, 614, 373, 581, 459, 609, 490, 484, 341, 577, 365, 0, 0);//
        //                mouse.delayTime(1);

        //                //回合结束
        //                mouse.RoundEnd2(dmae);
        //                mouse.delayTime(1, 1);

        //                mouse.MoveAndFight(dmae, 580, 434, 609, 461, /*第一个点坐标*/438, 390, 474, 419,/*第二个点坐标*/ 469, 429, 570, 454/*监测点坐标*/, 0, 0);//第一开始
        //                mouse.delayTime(1, 1);

        //                mouse.MoveAndMove(dmae, 435, 388, 470, 420, 315, 365, 346, 395, 363, 390, 430, 413, 0, 0);//
        //                mouse.delayTime(1);

        //                //回合结束
        //                mouse.RoundEnd2(dmae);
        //                mouse.delayTime(1, 1);

        //                ret = mouse.MoveAndMove(dmae, 321, 368, 343, 395, 343, 487, 375, 517, 233, 362, 308, 391, 1, 0,1);//
        //                mouse.delayTime(1);

        //                if (ret == 1) { mouse.WaitToHome(dmae); return; }
        //                if (ret == 2) { mouse.ImposedLeave(dmae); mouse.WaitToHome(dmae); return; }

        //                mouse.MoveAndMove(dmae, 338, 491, 371, 515, 281, 581, 321, 613, 377, 487, 464, 509, 0, 0);//
        //                mouse.delayTime(1);
        //                //回合结束
        //                mouse.RoundEnd2(dmae);
        //                mouse.delayTime(1, 1);

        //                mouse.MoveAndMove(dmae, 283, 582, 321, 612, 342, 486, 371, 516, 328, 583, 395, 606, 0, 0);//
        //                mouse.delayTime(1);


        //                int dm_ret0 = mouse.FindTeamSelectLine(dmae, 378, 490, 469, 515, 0);
        //                while (dm_ret0 == 0)
        //                {
        //                    mouse.LeftClick(dmae, 362, 668, 892, 716);
        //                    mouse.delayTime(1);
        //                    dm_ret0 = dm_ret0 = mouse.FindTeamSelectLine(dmae, 378, 490, 469, 515, 0);
        //                    //mouse.CheckTeamSlect(dmae);
        //                }

        //                ret = mouse.Teamdispose(dmae, 288, 582, 320, 616, supportteam,1);//机场部署2队  x=1可能会遇到特殊情况
        //                mouse.delayTime(1);
        //                if (ret == -1)
        //                {
        //                    mouse.StopBattle(dmae);
        //                    break;
        //                }

        //                mouse.MoveToAirport(dmae, 338, 489, 374, 511, 283, 588, 323, 613, 348, 419, 361, 473, 223, 579, 195, 583, 271, 617,1);

        //                //撤离
        //                mouse.Evacuate(dmae, 288, 582, 320, 616, fix, fixmaxpercentage);
        //                mouse.delayTime(1);
        //                mouse.StopBattle(dmae);
        //                break;
        //            }

        //        case 3:
        //            {
        //                mouse.MoveAndMove(dmae, 553, 236, 602, 269, 740, 224, 769, 248, 567, 663, 593, 719, 1, 1,1);//
        //                mouse.delayTime(1);

        //                //等待黄线
        //                int dm_ret0 = mouse.FindTeamSelectLine(dmae, 776, 224, 838, 242, 0);
        //                while (dm_ret0 == 0)
        //                {
        //                    mouse.delayTime(1);
        //                    dm_ret0 = mouse.FindTeamSelectLine(dmae, 776, 224, 838, 242, 0);
        //                }

        //                dm_ret0 = mouse.FindTeamSelectLine(dmae, 776, 224, 838, 242, 0);
        //                while (dm_ret0 == 0)
        //                {
        //                    mouse.LeftClick(dmae, 362, 668, 892, 716);
        //                    mouse.delayTime(1);
        //                    dm_ret0 = dm_ret0 = mouse.FindTeamSelectLine(dmae, 776, 224, 838, 242, 0);
        //                    //mouse.CheckTeamSlect(dmae);
        //                }

        //                mouse.Teamdispose(dmae, 556, 234, 599, 269, supportteam);//机场部署2队
        //                mouse.delayTime(1);

        //                //回合结束
        //                mouse.RoundEnd2(dmae);
        //                mouse.delayTime(1, 1);


        //                mouse.MoveAndFight(dmae, 734, 215, 770, 248, /*第一个点坐标*/686, 77, 717, 105,/*第二个点坐标*/ 778, 221, 866, 247/*监测点坐标*/, 0, 0);//第一开始
        //                mouse.delayTime(1, 1);

        //                mouse.MoveAndMove(dmae, 686, 469, 721, 501, 733, 612, 770, 641, 727, 475, 808, 497, 0, 0);//
        //                mouse.delayTime(1);

        //                mouse.MoveToAirport(dmae, 733, 616, 778, 641,/*第一个点坐标*/ 562, 630, 597, 662, /*第二个点坐标*/780, 611, 861, 644,/*监测点坐标*/ 500, 630,/*监测点坐标*/474, 632, 544, 663);
        //                mouse.delayTime(1);

        //                //画面往下移动
        //                mouse.ScreenDown(dmae, 359, 659, 506, 708, 360, 1, 1, 1, 1, 1, 1);
        //                mouse.delayTime(1);

        //                mouse.MoveAndMove(dmae, 563, 206, 595, 234, 587, 316, 611, 337, 469, 207, 560, 236, 0, 0);//
        //                mouse.delayTime(1);

        //                //回合结束
        //                mouse.RoundEnd2(dmae);
        //                mouse.delayTime(1, 1);

        //                mouse.MoveAndFight(dmae, 582, 309, 609, 338, /*第一个点坐标*/574, 430, 604, 458,/*第二个点坐标*/ 479, 307, 575, 343/*监测点坐标*/, 0, 0);//第一开始
        //                mouse.delayTime(1, 1);

        //                mouse.MoveAndMove(dmae, 578, 432, 608, 455, 579, 313, 615, 339, 616, 432, 694, 459, 0, 0);//
        //                mouse.delayTime(1);


        //                mouse.MoveToAirport(dmae, 582, 315, 609, 336,/*第一个点坐标*/ 556, 204, 599, 240, /*第二个点坐标*/464, 308, 574, 338,/*监测点坐标*/ 550, 235,/*监测点坐标*/462, 238, 542, 266);
        //                mouse.delayTime(1);

        //                mouse.Evacuate(dmae, 558, 239, 600, 267,fix, fixmaxpercentage);
        //                mouse.delayTime(1);
        //                mouse.StopBattle(dmae);
        //                break;
        //            }
        //                default:
        //            break;
        //    }






        //}




        //public void Battle0_4(DmAe dmae, Mouse mouse, string mainteam, string supportteam, int tasktype, bool supply,bool fix,int fixmaxpercentage, bool setmap =false)
        //{

        //    object intX, intY;
        //    bool ret0;
        //    mouse.LeftClickHomeToBattle(dmae, 0, 0, 4);
        //    mouse.delayTime(1);
        //    mouse.ClickFightType(dmae, "normal");
        //    mouse.delayTime(4);

        //    if(setmap == true)
        //    {
        //        mouse.MapSet(dmae, 635, 108, 846, 405, 1, 1, 264, 651);
        //    }

        //    mouse.Teamdispose(dmae, 661, 376, 683, 391, supportteam);//指挥部部署
        //    mouse.delayTime(1);

        //    mouse.Teamdispose(dmae, 807, 364, 852, 403, mainteam);//机场部署
        //    mouse.delayTime(1);

        //    mouse.BattleStart(dmae);
        //    mouse.delayTime(2);



        //    //开始补给

        //    if (supply == true) { mouse.Support(dmae, 807, 364, 852, 403); }


        //    mouse.MoveAndMove(dmae, 807, 364, 852, 403, 755, 518, 808, 562, 718, 366, 793, 394, 0, 0);//第一开始
        //    mouse.delayTime(1);

        //    mouse.MoveAndFight(dmae, 757, 519, 801, 560, 624, 605, 668, 646, 634, 513, 745, 553, 0, 0);//第二开始
        //    mouse.delayTime(1);


        //    mouse.MoveAndMove(dmae, 620, 243, 674, 290, 753, 162, 805, 198, 510, 251, 607, 276, 0, 0);//第三开始
        //    mouse.delayTime(1);

        //    mouse.MoveToAirport(dmae, 753, 157, 800, 201, 813, 11, 852, 43,/**/640, 166, 741, 195, /*move坐标*/800, 360,/*点击移动坐标*/707, 367, 801, 393);//第四开始
        //    mouse.delayTime(1);
        //    //撤离
        //    mouse.Evacuate(dmae, 801, 360, 858, 402,fix, fixmaxpercentage);
        //    mouse.delayTime(1);
        //    mouse.StopBattle(dmae);

        //}





        //   public void Battle1_6(DmAe dmae, Mouse mouse, string MainTeam, string SupportTeam,bool fix,int fixmintime, ref bool Battletask1Used, ref int case0)
        //   {

        //       object intX, intY;

        //       mouse.LeftClickHomeToBattle(dmae, 1, 1, 4);
        //       mouse.delayTime(1);
        //       mouse.ClickFightType(dmae, "normal");
        //       mouse.delayTime(4);


        //       //mouse.ScreenUp(dm, 520, 136, 992, 203, 100, 900, 664, "94c6f7"); //900, 665
        //       mouse.delayTime(1);




        //       mouse.Teamdispose(dmae, 1057, 476, 1110, 524, MainTeam);//指挥部部署
        //       mouse.delayTime(1);
        //       mouse.ScreenUp(dmae, 358, 250, 998, 338, 300, 1, 1, 1, 1, 1, 1); //900, 665
        //       mouse.delayTime(1);
        //       mouse.Teamdispose(dmae, 1063, 156, 1106, 185, SupportTeam);//机场部署
        //       mouse.delayTime(1);

        //       mouse.BattleStart(dmae);
        //       mouse.delayTime(2);



        //   //    mouse.MoveAndFight(dm, 1063, 156, 1106, 185, 866, 151, 906, 187, 1125, 170);//第一开始

        //       mouse.ScreenUp(dmae, 358, 250, 998, 338, 300, 1, 1, 1, 1, 1, 1); //900, 665
        //       mouse.delayTime(1);
        ////       mouse.MoveAndFight(dm, 866, 151, 906, 187, 688, 155, 725, 191, 845, 167);//第二开始
        //       mouse.delayTime(1);

        //       mouse.ScreenUp(dmae, 358, 250, 998, 338, 300, 1, 1, 1, 1, 1, 1); //900, 665
        //       mouse.delayTime(1);
        //       //mouse.MoveAndMove(dm, 688, 155, 725, 191, 866, 151, 906, 187, 667, 171);//第三开始

        //       mouse.delayTime(1);
        //       //mouse.MoveToAirport(dm, 869, 151, 906, 185, 1065, 159, 1099, 186, 887, 200, /*move坐标*/1002, 156, /*点击移动坐标*/971, 157, 1047, 190);//第四开始
        //       mouse.delayTime(1);
        //       //撤离
        //       mouse.Evacuate(dmae, 1064, 152, 1105, 190,fix, fixmintime);
        //       mouse.delayTime(1);
        //       mouse.StopBattle(dmae);

        //       mouse.delayTime(2);
        //       mouse.WaitToHome(dmae);
        //   }


























    }
















}


