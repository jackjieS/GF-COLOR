﻿using EyLogin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using testdm;
using WindowsFormsApplication1;
using WindowsFormsApplication1.BaseData;
using WindowsFormsApplication1.Properties;

namespace TaskList
{

    public partial class Form1 : Form
    {
        private InstanceManager im;
        DmAe dmae = new DmAe();


        public Form1()
        {
            this.im = new InstanceManager(this);
            im.configManager.readConfig();
            InitializeComponent();

        }


 
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            im.gameData.User_operationInfo[0].OperationTeamName = comboBox1.Text;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            im.gameData.User_operationInfo[0].OperationName = comboBox5.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            im.gameData.User_operationInfo[1].OperationTeamName = comboBox2.Text;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            im.gameData.User_operationInfo[2].OperationTeamName = comboBox3.Text;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            im.gameData.User_operationInfo[3].OperationTeamName = comboBox4.Text;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            im.gameData.User_operationInfo[1].OperationName = comboBox6.Text;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            im.gameData.User_operationInfo[2].OperationName = comboBox7.Text;
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            im.gameData.User_operationInfo[3].OperationName = comboBox8.Text;
        }







        private void Form1_Load(object sender, EventArgs e)//初始化
        {
            //检查UIconfig版本
            this.Text = "少女前线 "+ Assembly.GetExecutingAssembly().GetName().Version.ToString();





            SystemInfo.Time15AddGetFriendBattery = im.Form1.checkBox1.Checked;
            SystemInfo.Time3AddGetFriendBattery = im.Form1.checkBox4.Checked;

            im.dormitory.ReadLogFriendListFromStart();
            im.dormitory.ReadtempFriendListFromStart();

            im.Form1.checkBox2.Checked = SystemInfo.GetFriendBatterySecondLoop;
            im.Form1.checkBox3.Checked = SystemInfo.GetFriendBatteryCapt;
            im.Form1.textBox29.Text = SystemInfo.GetFriendBattleryDelayM.ToString();

            im.gameData.User_operationInfo[0].OperationName = SystemInfo.LogisticsTask1;
            im.gameData.User_operationInfo[1].OperationName = SystemInfo.LogisticsTask2;
            im.gameData.User_operationInfo[2].OperationName = SystemInfo.LogisticsTask3;
            im.gameData.User_operationInfo[3].OperationName = SystemInfo.LogisticsTask4;

            im.gameData.User_operationInfo[0].OperationTeamName = "第一梯队";
            im.gameData.User_operationInfo[1].OperationTeamName = "第二梯队";
            im.gameData.User_operationInfo[2].OperationTeamName = "第三梯队";
            im.gameData.User_operationInfo[3].OperationTeamName = "第四梯队";

            im.Form1.comboBox11.SelectedIndex = 0;
            im.Form1.comboBox10.SelectedIndex = 0;
            im.Form1.comboBox9.SelectedIndex = 0;


            this.MaximizeBox = false;
            Control.CheckForIllegalCrossThreadCalls = false;


            if(IsAdministrator() == false)
            {
                MessageBox.Show("请使用管理员权限打开", "少女前线");
                this.Close();
            }

            //模拟器设定





        }

        

        public bool IsAdministrator()
        {
            WindowsIdentity current = WindowsIdentity.GetCurrent();
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
            return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }

       





        private void label20_Click(object sender, EventArgs e)
        {
            im.Form1.tabControl1.SelectedIndex = 0;
        }

        private void label21_Click(object sender, EventArgs e)
        {
            im.Form1.tabControl1.SelectedIndex = 1;
        }

        private void label22_Click(object sender, EventArgs e)
        {
            im.Form1.tabControl1.SelectedIndex = 2;
        }

        private void label27_Click(object sender, EventArgs e)
        {
            im.Form1.tabControl1.SelectedIndex = 3;
        }

        private void label28_Click(object sender, EventArgs e)
        {
            im.Form1.tabControl1.SelectedIndex = 4;
        }

        private void label32_Click(object sender, EventArgs e)
        {
            im.Form1.tabControl1.SelectedIndex = 5;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            WriteLog.WriteError("初始化成功*****************************");
            string mcode = im.eyLogin.GetMachineCode();
            if (mcode == "37797B15343158143F7C7B15CA627BDE" || im.commonHelp.checkT(mcode))
            {
                //if (true)
                //{
                //模拟器选择
                int dm_ret = 0;
                dm_ret = dmae.BindWindow();
                if (dm_ret == 0)
                {
                    MessageBox.Show("绑定窗口错误");
                }
                dmae.SetDict();//设置系统路径和字典

                if (im.commonHelp.CheckClientSize(dmae) == false)
                {
                    MessageBox.Show(" 当前分辨率有问题，脚本将会出错。 ");
                }


                if (dm_ret == 1)
                {
                    //注意这里要检查UICFG版本号
                    //if (Settings.Default.FirstTimeU == true)
                    //{
                    //    MessageBox.Show("检测到第一次运行，请校对颜色", "少女前线");
                    //    var SetColor = new SetColor(im);
                    //    SetColor.StartPosition = FormStartPosition.CenterParent;
                    //    SetColor.ShowDialog(this);
                    //}


                    im.Form1.button1.Enabled = false;
                    im.Form1.button8.Enabled = true;
                    im.Form1.button9.Enabled = true;
                    im.Form1.button10.Enabled = true;
                    im.Form1.button11.Enabled = true;
                    im.Form1.button12.Enabled = true;
                    im.Form1.button13.Enabled = true;
                    im.Form1.button2.Enabled = true;
                    im.Form1.button16.Enabled = true;
                    im.Form1.button6.Enabled = true;
                    im.Form1.button5.Enabled = true;
                    im.Form1.button3.Enabled = true;
                    im.Form1.button7.Enabled = true;
                    im.Form1.button15.Enabled = true;
                    im.Form1.button17.Enabled = true;
                    im.Form1.button18.Enabled = true;
                    im.Form1.button19.Enabled = true;
                    im.Form1.button20.Enabled = true;
                    im.Form1.button34.Enabled = true;
                    im.Form1.button21.Enabled = true;
                    im.Form1.button35.Enabled = true;
                    im.Form1.button36.Enabled = true;
                    im.Form1.button37.Enabled = true;
                    im.Form1.button38.Enabled = true;
                    im.Form1.button39.Enabled = true;
                    im.CountDown = new Thread(im.backGroundThread.CountDown);
                    im.CountDown.IsBackground = true;
                    im.CountDown.Start();

                    im.CompleteMisson = new Thread(im.backGroundThread.CompleteMisson);
                    im.CompleteMisson.IsBackground = true;
                    im.CompleteMisson.Start();

                    im.ThreadT = new Thread(im.backGroundThread.ThreadT);
                    im.ThreadT.IsBackground = true;
                    im.ThreadT.Start();

                    im.MonitorPic = new Thread(im.backGroundThread.MonitorPic);//2线程用于监控，如闪退
                    im.MonitorPic.IsBackground = true;
                    im.MonitorPic.Start();


                    WriteLog.WriteError("初始化成功*****************************");
                }
                else
                {
                    //if(variables.Simulator == 0)//使用的是猩猩模拟器
                    {
                        if (dm_ret == -2) { MessageBox.Show("-2找不到游戏窗口句柄，请尝试手动指定", "少女前线"); }
                        if (dm_ret == -1) { MessageBox.Show("-1因为模拟器有保护，或者模拟器没有以管理员权限打开导致初始化失败", "少女前线"); }
                        if (dm_ret == 0) { MessageBox.Show("0因为模拟器有保护，或者模拟器没有以管理员权限打开导致初始化失败", "少女前线"); }
                        if (dm_ret == -81) { MessageBox.Show("此窗口不适合ogl模式导致初始化失败", "少女前线"); }
                        if (dm_ret == -91) { MessageBox.Show("此窗口不适合ogl模式导致初始化失败", "少女前线"); }
                        if (dm_ret == -92) { MessageBox.Show("-92因为模拟器有保护，或者模拟器没有以管理员权限打开导致初始化失败", "少女前线"); }
                    }
                }
            }
            //验证失败代码
            else
            {
                var Battle = new check(mcode);
                Battle.StartPosition = FormStartPosition.CenterParent;
                Battle.ShowDialog(this);
            }
        }//初始化按钮

        private void button2_Click(object sender, EventArgs e)//停止战斗任务从尾开始
        {
            im.gameData.User_battleInfo[0].BattleLoopTime = 0; im.gameData.User_battleInfo[0].BattleFixTime = -1; im.gameData.User_battleInfo[0].Used = false; im.gameData.User_battleInfo[0].BattleGunPostionMove.Clear();
            //if (im.gameData.User_battleInfo[3].Used == true) { im.gameData.User_battleInfo[3].BattleLoopTime = 0; im.gameData.User_battleInfo[3].BattleFixTime = -1; im.gameData.User_battleInfo[3].Used = false; im.gameData.User_battleInfo[3].BattleGunPostionMove.Clear(); return; }
            //if (im.gameData.User_battleInfo[2].Used == true) { im.gameData.User_battleInfo[2].BattleLoopTime = 0; im.gameData.User_battleInfo[2].BattleFixTime = -1; im.gameData.User_battleInfo[2].Used = false; im.gameData.User_battleInfo[2].BattleGunPostionMove.Clear(); return; }
            //if (im.gameData.User_battleInfo[1].Used == true) { im.gameData.User_battleInfo[1].BattleLoopTime = 0; im.gameData.User_battleInfo[1].BattleFixTime = -1; im.gameData.User_battleInfo[1].Used = false; im.gameData.User_battleInfo[1].BattleGunPostionMove.Clear(); return; }
            //if (im.gameData.User_battleInfo[0].Used == true) { im.gameData.User_battleInfo[0].BattleLoopTime = 0; im.gameData.User_battleInfo[0].BattleFixTime = -1; im.gameData.User_battleInfo[0].Used = false; im.gameData.User_battleInfo[0].BattleGunPostionMove.Clear(); return; }
        }

        private void button3_Click(object sender, EventArgs e)//截图
        {
            im.time.SaveBmp(dmae, 0, 0, 2000, 2000, "\\Debug\\");
            label99.Text = "截图成功";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var setting = new setting(im);
            setting.StartPosition = FormStartPosition.CenterParent;
            setting.ShowDialog(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "暂停")
            {
                im.mouse.BindWindowS(dmae, 0);
                im.CompleteMisson.Suspend();
                button5.Text = "继续";
                button6.Enabled = false;
            }
            else
            {
                im.mouse.BindWindowS(dmae, 1);
                im.CompleteMisson.Resume();
                button5.Text = "暂停";
                button6.Enabled = true;
            }


        }

        public void button6_Click(object sender, EventArgs e)//紧急停止
        {
            im.CompleteMisson.Abort();
            im.CountDown.Abort();//倒计时
            im.ThreadT.Abort();
            im.MonitorPic.Abort();
            button5.Enabled = false;
            button6.Enabled = false;
            button1.Enabled = true;
            im.mouse.BindWindowS(dmae, 0);
            CommonHelp.gametasklist.Clear();
            WindowsFormsApplication1.BaseData.SystemInfo.ThreadTCase = 1;


        }

        private void button7_Click(object sender, EventArgs e)
        {
            im.taskList.taskremove();
        }

        private void button8_Click(object sender, EventArgs e)//开始后勤任务1
        {
            im.taskList.taskadd(WindowsFormsApplication1.BaseData.TaskList.StartLogisticsTask1);
        }

        private void button9_Click(object sender, EventArgs e)//开始后勤任务2
        {
            im.taskList.taskadd(WindowsFormsApplication1.BaseData.TaskList.StartLogisticsTask2);
        }
        private void button10_Click(object sender, EventArgs e)//开始后勤任务3
        {
            im.taskList.taskadd(WindowsFormsApplication1.BaseData.TaskList.StartLogisticsTask3);
        }
        private void button11_Click(object sender, EventArgs e)//开始后勤任务4
        {
            im.taskList.taskadd(WindowsFormsApplication1.BaseData.TaskList.StartLogisticsTask4);
        }
        private void button12_Click(object sender, EventArgs e)//开始全部后勤
        {
            im.taskList.taskadd(WindowsFormsApplication1.BaseData.TaskList.StartLogistics);
        }
        private void button13_Click(object sender, EventArgs e)
        {
            im.taskList.taskadd(WindowsFormsApplication1.BaseData.TaskList.ReadLogisticsTaskTime);
        }


        private void button14_Click_1(object sender, EventArgs e)
        {

            //im.pagecheck.Ver(dmae.dm);
            //im.pagecheck.CheckPointIsEmpty(dmae.dm, 299, 338, 337, 371);
            //im.mouse.CheckBattleSettlementPage(dmae);
            im.mouse.LeftClickHomeToBattle(dmae, "101", -1, 13, -1);
            //im.mouse.MapSet(dmae, 977, 565, 566, 693, 237, 212, 208, 650, "ScreenUp");//x1,y1,x2,y2,x3,y3是地图缩放到最小的监测点x4y4鼠标移动位置

            ////右下角白点转圈
            ////1157,546,1279,665
            ////1160,574,1185,639
            //int x1, y1;
            //while (true)
            //{
            //    int dm_ret = 0;

            //    for (x1 = 1160, y1 = 574; y1 <= 639; y1++)
            //    {
            //        for (x1 = 1160; x1 <= 1185; x1++)
            //        {
            //            if (dmae.CmpColor(x1, y1, "ffffff", 1) == 0)
            //            {
            //                dm_ret = dm_ret + 1;
            //            }
            //        }
            //    }
            //    MessageBox.Show(string.Format("WhiteCount = {0}", dm_ret.ToString()));
            //}

        }



        private void button15_Click(object sender, EventArgs e)
        {
            im.gameData.User_operationInfo[0].OperationLastTime = Convert.ToInt32(textBox21.Text) * 60 + Convert.ToInt32(textBox28.Text);
        }


        private void button16_Click(object sender, EventArgs e)
        {

            var Battle = new Battle(im,0);
            Battle.StartPosition = FormStartPosition.CenterParent;
            Battle.ShowDialog(this);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            im.gameData.User_operationInfo[1].OperationLastTime = Convert.ToInt32(textBox21.Text) * 60 + Convert.ToInt32(textBox28.Text);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            im.gameData.User_operationInfo[2].OperationLastTime = Convert.ToInt32(textBox21.Text) * 60 + Convert.ToInt32(textBox28.Text);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            im.gameData.User_operationInfo[3].OperationLastTime = Convert.ToInt32(textBox21.Text)*60 + Convert.ToInt32(textBox28.Text);
        }




        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WindowsFormsApplication1.BaseData.SystemInfo.LogisticsTask1 = comboBox5.Text;
            WindowsFormsApplication1.BaseData.SystemInfo.LogisticsTask2 = comboBox6.Text;
            WindowsFormsApplication1.BaseData.SystemInfo.LogisticsTask3 = comboBox7.Text;
            WindowsFormsApplication1.BaseData.SystemInfo.LogisticsTask4 = comboBox8.Text;


            im.Form1.checkBox1.Checked = SystemInfo.Time15AddGetFriendBattery;
            im.Form1.checkBox4.Checked = SystemInfo.Time3AddGetFriendBattery;
            SystemInfo.GetFriendBatterySecondLoop = im.Form1.checkBox2.Checked;
            SystemInfo.GetFriendBatteryCapt = im.Form1.checkBox3.Checked;
            SystemInfo.GetFriendBattleryDelayM = Convert.ToInt32(im.Form1.textBox29.Text);

            im.configManager.saveConfig();
            int ret = im.eyLogin.LogOut();
            int dm_ret0 = dmae.UnBindWindow();
            try
            {
                im.CountDown.Abort();
                im.CompleteMisson.Abort();
                im.MonitorPic.Abort();
                im.ThreadT.Abort();
            }
            catch (Exception ex)
            {
                WriteLog.WriteError("关闭线程是发生异常:     " + ex.Message);
                //throw;
            }

        }

        private void button20_Click(object sender, EventArgs e)
        {
            CommonHelp.gametasklist.Add(WindowsFormsApplication1.BaseData.TaskList.BuildEquipment);
            im.gameData.User_BuildingEquipmentInfo[0].BuildingFavoriteNumber = im.Form1.comboBox9.SelectedIndex;
            im.gameData.User_BuildingEquipmentInfo[1].BuildingFavoriteNumber = im.Form1.comboBox10.SelectedIndex;
            im.gameData.User_BuildingEquipmentInfo[2].BuildingFavoriteNumber = im.Form1.comboBox11.SelectedIndex;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            var LogisticSupportSet = new LogisticSupportSet(im);
            LogisticSupportSet.StartPosition = FormStartPosition.CenterParent;
            LogisticSupportSet.ShowDialog(this);

        }

        private void button25_Click(object sender, EventArgs e)
        {
            im.taskList.taskadd(WindowsFormsApplication1.BaseData.TaskList.ReadAndSaveFriendsDormitoryList);
        }

        private void button23_Click(object sender, EventArgs e)//上一张图片
        {
            try
            {
                if (CommonHelp.PictureBox1Count != 1)
                {
                    CommonHelp.PictureBox1Count--;
                    im.Form1.pictureBox1.Image = im.Form1.imageList1.Images[CommonHelp.PictureBox1Count-1];
                }
            }
            catch (Exception)
            {

            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonHelp.PictureBox1Count < im.Form1.imageList1.Images.Count)
                {
                    CommonHelp.PictureBox1Count++;
                    im.Form1.pictureBox1.Image = im.Form1.imageList1.Images[CommonHelp.PictureBox1Count-1];
                }
            }
            catch (Exception)
            {


            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            //复制图片到正式名字 NOX.BMP
            string path1, path2;
            path1 = Application.StartupPath + "\\FriendList\\temp" + CommonHelp.PictureBox1Count.ToString() + ".bmp";
            path2 = Application.StartupPath + "\\FriendList\\NO" + (CommonHelp.PictureBox2Count+1).ToString() + ".bmp";
            im.Form1.imageList2.Images.Add(im.Form1.imageList1.Images[CommonHelp.PictureBox1Count - 1]);
            File.Copy(path1, path2, true);




            if (im.Form1.pictureBox2.Image != null)
            {
                //有图片     
            }
            else
            {
                CommonHelp.PictureBox2Count = 1;
                im.Form1.pictureBox2.Image = im.Form1.imageList2.Images[0];
                //无图片     
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonHelp.PictureBox2Count >1)
                {
                    CommonHelp.PictureBox2Count--;
                    im.Form1.pictureBox2.Image = im.Form1.imageList2.Images[CommonHelp.PictureBox2Count - 1];
                }
            }
            catch (Exception)
            {

            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonHelp.PictureBox2Count < im.Form1.imageList2.Images.Count)
                {
                    CommonHelp.PictureBox2Count++;
                    im.Form1.pictureBox2.Image = im.Form1.imageList2.Images[CommonHelp.PictureBox2Count - 1];
                }
            }
            catch (Exception)
            {


            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            try
            {
                im.Form1.imageList2.Images.RemoveAt(CommonHelp.PictureBox2Count - 1);
                File.Delete(Application.StartupPath+ @"\FriendList\NO"+CommonHelp.PictureBox2Count.ToString()+".bmp");



                if (im.Form1.imageList2.Images.Count == 0) { im.Form1.pictureBox2.Image = null; CommonHelp.PictureBox2Count = 0; }
                else
                {
                    CommonHelp.PictureBox2Count--;
                }
                im.Form1.pictureBox2.Image = im.Form1.imageList2.Images[CommonHelp.PictureBox2Count - 1];

            }
            catch (Exception)
            {


            }


        }

        private void button31_Click(object sender, EventArgs e)
        {
            im.dormitory.CleanALLtempPic();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            im.dormitory.CleanALLLogPic();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            im.taskList.taskadd(WindowsFormsApplication1.BaseData.TaskList.GetFriendDormitoryBattery);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            try
            {
                //获取当前数目
                int count = im.Form1.imageList1.Images.Count;
                //截图
                int dm_retsave = dmae.Capture(900, 15, 1065, 50, "\\FriendList\\temp" + count.ToString() + ".bmp");
                //入队
                im.Form1.imageList1.Images.Add(Image.FromFile(Application.StartupPath + "\\FriendList\\temp" + count.ToString() + ".bmp"));
            }
            catch (Exception)
            {


            }
        }


        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            int min = Convert.ToInt32(textBox29.Text);
            SystemInfo.GetFriendBattleryDelayH = min / 60;
            SystemInfo.GetFriendBattleryDelayM = min % 60;
            if (SystemInfo.GetFriendBattleryDelayH >= 24) { MessageBox.Show("延迟24小时?mdzz"); textBox29.Text = "0"; }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            var Battle = new Battle(im, 1);
            Battle.StartPosition = FormStartPosition.CenterParent;
            Battle.ShowDialog(this);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            var Battle = new Battle(im, 2);
            Battle.StartPosition = FormStartPosition.CenterParent;
            Battle.ShowDialog(this);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            var Battle = new Battle(im, 3);
            Battle.StartPosition = FormStartPosition.CenterParent;
            Battle.ShowDialog(this);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            var Battle = new Battle(im, 0);
            Battle.StartPosition = FormStartPosition.CenterParent;
            Battle.ShowDialog(this);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            im.gameData.User_battleInfo[1].BattleLoopTime = 0; im.gameData.User_battleInfo[1].BattleFixTime = -1; im.gameData.User_battleInfo[1].Used = false; im.gameData.User_battleInfo[1].BattleGunPostionMove.Clear();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            im.gameData.User_battleInfo[2].BattleLoopTime = 0; im.gameData.User_battleInfo[2].BattleFixTime = -1; im.gameData.User_battleInfo[2].Used = false; im.gameData.User_battleInfo[2].BattleGunPostionMove.Clear();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            im.gameData.User_battleInfo[3].BattleLoopTime = 0; im.gameData.User_battleInfo[3].BattleFixTime = -1; im.gameData.User_battleInfo[3].Used = false; im.gameData.User_battleInfo[3].BattleGunPostionMove.Clear();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            MessageBox.Show("主页检测第一个点 color1 = " + dmae.GetColor(1100, 690));
            MessageBox.Show("主页检测第二个点 color2 = " + dmae.GetColor(975, 680));
            MessageBox.Show("主页检测第三个点 color3 = " + dmae.GetColor(695, 25));
            MessageBox.Show("主页检测 result = "+ im.pagecheck.CheckHomePage(dmae.dm).ToString());
        }
    }
}
