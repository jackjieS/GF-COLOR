using EyLogin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            InitializeComponent();
            this.im= new InstanceManager(this);
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

            im.gameData.User_operationInfo[0].OperationName = Settings.Default.LogisticsTask1;
            im.gameData.User_operationInfo[1].OperationName = Settings.Default.LogisticsTask2;
            im.gameData.User_operationInfo[2].OperationName = Settings.Default.LogisticsTask3;
            im.gameData.User_operationInfo[3].OperationName = Settings.Default.LogisticsTask4;

            im.gameData.User_operationInfo[0].OperationTeamName = "第一梯队";
            im.gameData.User_operationInfo[1].OperationTeamName = "第二梯队";
            im.gameData.User_operationInfo[2].OperationTeamName = "第三梯队";
            im.gameData.User_operationInfo[3].OperationTeamName = "第四梯队";

            im.Form1.comboBox11.SelectedIndex = 0;
            im.Form1.comboBox10.SelectedIndex = 0;
            im.Form1.comboBox9.SelectedIndex = 0;

            OperatingSystem osInfo = Environment.OSVersion;// 获取系统操作版本
            WindowsFormsApplication1.BaseData.SystemInfo.OsType = osInfo.Version.Major;
            Settings.Default.OsType = WindowsFormsApplication1.BaseData.SystemInfo.OsType;
            Settings.Default.Save();// 保存系统操作版本
            WriteLog.WriteError("***********************************************");
            WriteLog.WriteError("当前系统   windows " + WindowsFormsApplication1.BaseData.SystemInfo.OsType);
            this.MaximizeBox = false;
            Control.CheckForIllegalCrossThreadCalls = false;


            if(IsAdministrator() == false)
            {
                MessageBox.Show("请使用管理员权限打开", "少女前线");
                this.Close();
            }

            //模拟器设定
            WindowsFormsApplication1.BaseData.SystemInfo.Simulator = Settings.Default.Simulator;




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

        private void button1_Click(object sender, EventArgs e)
        {
            WriteLog.WriteError("初始化成功*****************************");
            string mcode = im.eyLogin.GetMachineCode();
            if (mcode == "37797B15343158143F7C7B15CA627BDE" || im.commonHelp.checkT(mcode) == true)
            {
                //模拟器选择
                int dm_ret = 0;
                dm_ret = dmae.BindWindow();
                dmae.SetDict();//设置系统路径和字典

                if (im.commonHelp.CheckClientSize(dmae) == false)
                {
                    MessageBox.Show(" 当前分辨率有问题，脚本将会出错。 ");
                }


                if (dm_ret == 1)
                {
                    if (Settings.Default.FirstTimeU == true)
                    {
                        MessageBox.Show("检测到第一次运行，请校对颜色", "少女前线");
                        var SetColor = new SetColor(im);
                        SetColor.StartPosition = FormStartPosition.CenterParent;
                        SetColor.ShowDialog(this);
                    }


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
                    im.Form1.button21.Enabled = true;

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
            if (im.gameData.User_battleInfo[3].Used == true) { im.gameData.User_battleInfo[3].BattleFixTime = -1; im.gameData.User_battleInfo[3].Used = false; return; }
            if (im.gameData.User_battleInfo[2].Used == true) { im.gameData.User_battleInfo[2].BattleFixTime = -1; im.gameData.User_battleInfo[2].Used = false; return; }
            if (im.gameData.User_battleInfo[1].Used == true) { im.gameData.User_battleInfo[1].BattleFixTime = -1; im.gameData.User_battleInfo[1].Used = false; return; }
            if (im.gameData.User_battleInfo[0].Used == true) { im.gameData.User_battleInfo[0].BattleFixTime = -1; im.gameData.User_battleInfo[0].Used = false; return; }
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
            //im.mouse.LeftClickHomeToBattle(dmae, "06", 0, 6);
            im.dormitory.VoteDormitoryLoop(dmae);

            //bool i=im.mouse.CheckNewGunEquipmentPage(dmae);
            //int i1 = im.mouse.CheckBuildEquipmentS(dmae, 0);
            //int i2 = im.mouse.CheckBuildEquipmentS(dmae, 1);
            //int i = dmae.UseDict(4);
            //string time= dmae.Ocr(444, 177, 607, 222, "000000-101010", (double)((decimal)Settings.Default.FindTeamSlectStrSim / 100));
            //im.mouse.MapSet(dmae, 905, 571, 904, 566, 961, 566, 88, 613);//x1,y1,x2,y2,x3,y3是地图缩放到最小的监测点x4y4鼠标移动位置
            //im.mouse.MapSet(dmae, 183, 121, 751, 172, 571, 473, 88, 613);
            //int y=0;
            ////317,103
            ////86
            //for(int y1 = 103; y1 < 720; y1++)
            //{
            //    string tempcolor1 = dmae.GetColor(317, y1);
            //    if (tempcolor1 == "ffffff")
            //    {
            //        for(int y2 = y1; y2 <= y1 + 68; y2++)
            //        {
            //            int result = dmae.CmpColor(317, y2,"ffffff",1);
            //            if (result == 0)//0=颜色匹配
            //            {
            //                if (y2 == y1 + 68)
            //                {
            //                    y = y1;
            //                    goto a;
            //                }
            //            }
            //        }
            //    }
            //}

            //a: List<LMainColor> Lmaincolor = new List<LMainColor>();
            //Lmaincolor.Add(new LMainColor("", 0));
            //string tempcolor;
            //for (int y1 = y; y1 <= y+69; y1++)
            //{
            //    for (int x1 = 256; x1 <= 314; x1++)
            //    {
            //        tempcolor = dmae.GetColor(x1, y1);
            //        for (int i = 0; i < Lmaincolor.Count(); i++)
            //        {
            //            if (tempcolor == Lmaincolor[i].Color)
            //            {
            //                Lmaincolor[i].Count++;
            //                break;
            //            }
            //            if (i+1 == Lmaincolor.Count())
            //            {
            //                Lmaincolor.Add(new LMainColor(tempcolor,1));
            //                break;
            //            }
            //        }
            //    }
            //}
            //Lmaincolor.Sort((LMainColor l1, LMainColor l2) =>
            //{
            //    return l2.Count.CompareTo(l1.Count);
            //});
        }



        private void button15_Click(object sender, EventArgs e)
        {
            im.gameData.User_operationInfo[0].OperationLastTime = Convert.ToInt32(textBox21.Text) * 60 + Convert.ToInt32(textBox28.Text);
        }


        private void button16_Click(object sender, EventArgs e)
        {

            var Battle = new Battle(im);
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
            Settings.Default.LogisticsTask1 = comboBox5.Text;
            Settings.Default.LogisticsTask2 = comboBox6.Text;
            Settings.Default.LogisticsTask3 = comboBox7.Text;
            Settings.Default.LogisticsTask4 = comboBox8.Text;
            Settings.Default.Save();
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

        private void button21_Click(object sender, EventArgs e)
        {
            im.taskList.taskadd(WindowsFormsApplication1.BaseData.TaskList.VoteOthersDormitory);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            var LogisticSupportSet = new LogisticSupportSet(im);
            LogisticSupportSet.StartPosition = FormStartPosition.CenterParent;
            LogisticSupportSet.ShowDialog(this);

        }
    }
}
