using System;
using System.Windows.Forms;
using testdm;
using WindowsFormsApplication1.Properties;
using WindowsFormsApplication1;
namespace WindowsFormsApplication1
{
    partial class SetColor : Form
    {
        private InstanceManager im;
        public SetColor(InstanceManager im)
        {
            this.im = im;
            InitializeComponent();

        }
        CDmSoft dm99 = new CDmSoft();
        DmAe dmae = new DmAe();
        //AELib.AeSoft ae99 = new AELib.AeSoft();



        private void button1_Click(object sender, EventArgs e)
        {
            //Settings.Default.HomePage0 = dm99.GetColor(40, 85);
            //Settings.Default.HomePage1 = dm99.GetColor(900, 35);
            //Settings.Default.HomePage2 = dm99.GetColor(85, 590);
            //Settings.Default.HomePage0 = dmae.GetColor(40, 85);
            //Settings.Default.HomePage1 = dmae.GetColor(900, 35);
            //Settings.Default.HomePage2 = dmae.GetColor(710, 690); 
            //button2.Enabled = true;
        }

        private void SetColorcs_Load(object sender, EventArgs e)
        {
            TabPage tp = tabControl1.TabPages[4];//在这里先保存，以便以后还要显示
            tabControl1.TabPages.Remove(tp);//隐藏（删除）

            dmae.BindWindow();
            string directPath = Application.StartupPath + "\\Debug";    //获得文件夹路径

            dmae.SetDict();
            dmae.SetPath(directPath);
            object width, height;
            dmae.GetClientSize(BaseData.SystemInfo.GameWindowsHwnd,out width,out height);

            label36.Text = "当前游戏分辨率为 "+Convert.ToString(width) +" * "+ Convert.ToString(height);

            if(Convert.ToInt32(width) != 1280 || Convert.ToInt32(height) != 720)
            {
                label36.Text = "当前游戏分辨率为 " + Convert.ToString(width) + " * " + Convert.ToString(height);
                label37.Text = "请注意，在当前分辨率进行颜色校准将会出错";
            }
            else
            {
                label36.Text = "当前游戏分辨率为 " + Convert.ToString(width) + " * " + Convert.ToString(height);
                label37.Text = "请进行颜色校对";
            }

            //模拟器主页闪退设置

            textBox1.Text = Properties.Settings.Default.SimulatorHomeCapX1.ToString();
            textBox7.Text = Properties.Settings.Default.SimulatorHomeCapY1.ToString();
            textBox5.Text = Properties.Settings.Default.SimulatorHomeCapX2.ToString();
            textBox6.Text = Properties.Settings.Default.SimulatorHomeCapY2.ToString();

            textBox8.Text = Properties.Settings.Default.SimulatorHomeCheckX1.ToString();
            textBox3.Text = Properties.Settings.Default.SimulatorHomeCheckY1.ToString();
            textBox4.Text = Properties.Settings.Default.SimulatorHomeCheckX2.ToString();
            textBox2.Text = Properties.Settings.Default.SimulatorHomeCheckY2.ToString();



        }


        private void button2_Click(object sender, EventArgs e)
        {
            //int dm_ret0 = dm99.CmpColor(40, 85, Settings.Default.HomePage0, 0.9);
            //int dm_ret1 = dm99.CmpColor(900, 35, Settings.Default.HomePage1, 0.9);
            //int dm_ret2 = dm99.CmpColor(85, 590, Settings.Default.HomePage2, 0.9);
            //int dm_ret0 = dmae.CmpColor(40, 85, Settings.Default.HomePage0, 0.9);
            //int dm_ret1 = dmae.CmpColor(900, 35, Settings.Default.HomePage1, 0.9);
            //int dm_ret2 = dmae.CmpColor(710, 690, "ffffff", 0.9);
            //if (dm_ret0 == 0&& dm_ret1 == 0 && dm_ret2 == 0)
            //{
            //    label2.Text = "测试成功";
            //}
            //else
            //{
            //    label2.Text = "测试失败";
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dmae.UseDict(5);
            im.mouse.ChooseBattle(dmae, "00",1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dmae.UseDict(5);
            im.mouse.ChooseBattle(dmae, "01", 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Settings.Default.selfdiscipline = dmae.GetColor(608, 546);//绿色
            //Settings.Default.normal = dmae.GetColor(806, 546);//黄色
            int dm_ret = dmae.Capture(Properties.Settings.Default.SimulatorHomeCapX1, Properties.Settings.Default.SimulatorHomeCapY1, Properties.Settings.Default.SimulatorHomeCapX2, Properties.Settings.Default.SimulatorHomeCapY2, "A.bmp");
            button6.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            object intX, intY;
            intX = intY = -1;
            string directPath = Application.StartupPath + "\\Debug";    //获得文件夹路径
            dmae.SetPath(directPath);

            Properties.Settings.Default.SimulatorHomeCapX1 = Convert.ToInt32(textBox1.Text);
            Properties.Settings.Default.SimulatorHomeCapY1 = Convert.ToInt32(textBox7.Text);
            Properties.Settings.Default.SimulatorHomeCapX2 = Convert.ToInt32(textBox5.Text);
            Properties.Settings.Default.SimulatorHomeCapY2 = Convert.ToInt32(textBox6.Text);

            Properties.Settings.Default.SimulatorHomeCheckX1 = Convert.ToInt32(textBox8.Text);
            Properties.Settings.Default.SimulatorHomeCheckY1 = Convert.ToInt32(textBox3.Text);
            Properties.Settings.Default.SimulatorHomeCheckX2 = Convert.ToInt32(textBox4.Text);
            Properties.Settings.Default.SimulatorHomeCheckY2 = Convert.ToInt32(textBox2.Text);

            if (dmae.FindPic(Properties.Settings.Default.SimulatorHomeCheckX1, Properties.Settings.Default.SimulatorHomeCheckY1, Properties.Settings.Default.SimulatorHomeCheckX2, Properties.Settings.Default.SimulatorHomeCheckY2, "A.bmp", "000000", 1, 0, out intX, out intY) == -1)//用户自定义检测范围
            {
                label6.Text = "测试失败";
            }
            else
            {
                label6.Text = "测试成功";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Settings.Default.Battle0 = dmae.GetColor(285, 40);//橙色
            Settings.Default.AirPort = dmae.GetColor(340, 441);//
            Settings.Default.TeamSelect = dmae.GetColor(313, 476);//黄色

            WriteLog.WriteError("取色battle0 = " + Settings.Default.Battle0.ToString());
            WriteLog.WriteError("取色AirPort = " + Settings.Default.AirPort.ToString());
            WriteLog.WriteError("取色TeamSelect = " + Settings.Default.TeamSelect.ToString());
            //Settings.Default.TeamSelect = dmae.GetColor(313, 476);//黄色
            button8.Enabled = true;
            button9.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int dm_ret0 = dmae.CmpColor(285, 40, Settings.Default.Battle0, 0.9);
            int dm_ret1 = dmae.CmpColor(340, 441, Settings.Default.AirPort, 0.9);

            if (dm_ret0 == 0 && dm_ret1 == 0)
            {
                label8.Text = "测试成功";
            }
            else
            {
                label8.Text = "测试失败";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int dm_ret0 = dmae.CmpColor(313, 476, Settings.Default.TeamSelect, 0.9);

            if (dm_ret0 == 0 )
            {
                label9.Text = "梯队已选上";
            }
            else
            {
                label9.Text = "没有选上梯队";
            }
        }

        private void button10_Click(object sender, EventArgs e)//保存退出
        {
            int dm_ret = dmae.UnBindWindow();

            Properties.Settings.Default.SimulatorHomeCapX1 = Convert.ToInt32(textBox1.Text);
            Properties.Settings.Default.SimulatorHomeCapY1 = Convert.ToInt32(textBox7.Text);
            Properties.Settings.Default.SimulatorHomeCapX2 = Convert.ToInt32(textBox5.Text);
            Properties.Settings.Default.SimulatorHomeCapY2 = Convert.ToInt32(textBox6.Text);

            Properties.Settings.Default.SimulatorHomeCheckX1 = Convert.ToInt32(textBox8.Text);
            Properties.Settings.Default.SimulatorHomeCheckY1 = Convert.ToInt32(textBox3.Text);
            Properties.Settings.Default.SimulatorHomeCheckX2 = Convert.ToInt32(textBox4.Text);
            Properties.Settings.Default.SimulatorHomeCheckY2 = Convert.ToInt32(textBox2.Text);


            Settings.Default.FirstTimeU = false;
            Settings.Default.Save();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Settings.Default.TeamListSelect0 = dmae.GetColor(87,175);//梯队颜色
            WriteLog.WriteError("读取颜色  x = 86 y = 176 " + dmae.GetColor(86, 176).ToString());
            Settings.Default.TeamListSelect1 = dmae.GetColor(5, 176);//梯队颜色
            WriteLog.WriteError("读取颜色  x = 5 y = 176 " + dmae.GetColor(5, 176).ToString());
            Settings.Default.TeamListSelect2 = dmae.GetColor(10, 200);//梯队颜色
            WriteLog.WriteError("读取颜色  x = 10 y = 200 " + dmae.GetColor(10, 200).ToString());
            button12.Enabled = true;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            int dm_ret0 = dmae.UseDict(1);
            object intX1, intY1, intY2, intY3, intY4, intY5, intY6, intY7, intY8;
            int dm_ret1 = dmae.FindStr(75, 155, 105, 720, "第一梯队", Settings.Default.TeamListSelect0, 0.9, out intX1, out intY1);
            int dm_ret2 = dmae.FindStr(75, 155, 105, 720, "第二梯队", Settings.Default.TeamListSelect0, 0.9, out intX1, out intY2);
            int dm_ret3 = dmae.FindStr(75, 155, 105, 720, "第三梯队", Settings.Default.TeamListSelect0, 0.9, out intX1, out intY3);
            int dm_ret4 = dmae.FindStr(75, 155, 105, 720, "第四梯队", Settings.Default.TeamListSelect0, 0.9, out intX1, out intY4);
            int dm_ret5 = dmae.FindStr(75, 155, 105, 720, "第五梯队", Settings.Default.TeamListSelect0, 0.9, out intX1, out intY5);
            int dm_ret6 = dmae.FindStr(75, 155, 105, 720, "第六梯队", Settings.Default.TeamListSelect0, 0.9, out intX1, out intY6);
            int dm_ret7 = dmae.FindStr(75, 155, 105, 720, "第七梯队", Settings.Default.TeamListSelect0, 0.9, out intX1, out intY7);
            int dm_ret8 = dmae.FindStr(75, 155, 105, 720, "第八梯队", Settings.Default.TeamListSelect0, 0.9, out intX1, out intY8);

            if (dm_ret1 != -1)
            {
                label12.Text = "第一梯队";
                //int dm_ret9 = dmae.CmpColor(5, Convert.ToInt32(intY1), Settings.Default.TeamListSelect2, 0.9);
                //if (dm_ret9 == 0) { label39.Text = "当前选中第一梯队"; }
            }
            else
            {

                label12.Text = "";
            }


            if (dm_ret2 != -1)
            {
                label13.Text = "第二梯队";
                //int dm_ret9 = dmae.CmpColor(5, Convert.ToInt32(intY2), Settings.Default.TeamListSelect2, 0.9);
                //if (dm_ret9 == 0) { label39.Text = "当前选中第二梯队"; }

            }
            else
            {
                label13.Text = "";
            }
            if (dm_ret3 != -1)
            {
                label14.Text = "第三梯队";
                //int dm_ret9 = dmae.CmpColor(5, Convert.ToInt32(intY3), Settings.Default.TeamListSelect2, 0.9);
                //if (dm_ret9 == 0) { label39.Text = "当前选中第三梯队"; }

            } else { label14.Text = ""; }
            if (dm_ret4 != -1)
            {
                label15.Text = "第四梯队";
                //int dm_ret9 = dmae.CmpColor(5, Convert.ToInt32(intY4), Settings.Default.TeamListSelect2, 0.9);
                //if (dm_ret9 == 0) { label39.Text = "当前选中第四梯队"; }

            } else { label15.Text = ""; }
            if (dm_ret5 != -1)
            {
                label19.Text = "第五梯队";
                //int dm_ret9 = dmae.CmpColor(5, Convert.ToInt32(intY5), Settings.Default.TeamListSelect2, 0.9);
                //if (dm_ret9 == 0) { label39.Text = "当前选中第五梯队"; }

            } else { label19.Text = ""; }
            if (dm_ret6 != -1)
            {
                label18.Text = "第六梯队";
                //int dm_ret9 = dmae.CmpColor(5, Convert.ToInt32(intY6), Settings.Default.TeamListSelect2, 0.9);
                //if (dm_ret9 == 0) { label39.Text = "当前选中第二六梯队"; }

            } else { label18.Text = ""; }
            if (dm_ret7 != -1)
            {
                label17.Text = "第七梯队";
                //int dm_ret9 = dmae.CmpColor(5, Convert.ToInt32(intY7), Settings.Default.TeamListSelect2, 0.9);
                //if (dm_ret9 == 0) { label39.Text = "当前选中第七梯队"; }

            } else { label17.Text = ""; }
            if (dm_ret8 != -1)
            {
                label16.Text = "第八梯队";
                //int dm_ret9 = dmae.CmpColor(5, Convert.ToInt32(intY8), Settings.Default.TeamListSelect2, 0.9);
                //if (dm_ret9 == 0) { label39.Text = "当前选中第八梯队"; }

            } else { label16.Text = ""; }
            dm_ret0 = dmae.UseDict(0);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Settings.Default.LogisticsTeamColor = dmae.GetColor(475, 534);//后勤梯队颜色
            button14.Enabled = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int dm_ret0 = dmae.UseDict(1);
            object intX1, intY1;
            int dm_ret1 = dmae.FindStr(391, 517, 1258, 553, "第一梯队", Settings.Default.LogisticsTeamColor, 0.9, out intX1, out intY1);
            int dm_ret2 = dmae.FindStr(391, 517, 1258, 553, "第二梯队", Settings.Default.LogisticsTeamColor, 0.9, out intX1, out intY1);
            int dm_ret3 = dmae.FindStr(391, 517, 1258, 553, "第三梯队", Settings.Default.LogisticsTeamColor, 0.9, out intX1, out intY1);
            int dm_ret4 = dmae.FindStr(391, 517, 1258, 553, "第四梯队", Settings.Default.LogisticsTeamColor, 0.9, out intX1, out intY1);
            int dm_ret5 = dmae.FindStr(391, 517, 1258, 553, "第五梯队", Settings.Default.LogisticsTeamColor, 0.9, out intX1, out intY1);
            int dm_ret6 = dmae.FindStr(391, 517, 1258, 553, "第六梯队", Settings.Default.LogisticsTeamColor, 0.9, out intX1, out intY1);
            int dm_ret7 = dmae.FindStr(391, 517, 1258, 553, "第七梯队", Settings.Default.LogisticsTeamColor, 0.9, out intX1, out intY1);
            int dm_ret8 = dmae.FindStr(391, 517, 1258, 553, "第八梯队", Settings.Default.LogisticsTeamColor, 0.9, out intX1, out intY1);

            if (dm_ret1 != -1) { label21.Text = "第一梯队"; } else { label21.Text = ""; }
            if (dm_ret2 != -1) { label22.Text = "第二梯队"; } else { label22.Text = ""; }
            if (dm_ret3 != -1) { label23.Text = "第三梯队"; } else { label23.Text = ""; }
            if (dm_ret4 != -1) { label24.Text = "第四梯队"; } else { label24.Text = ""; }
            if (dm_ret5 != -1) { label25.Text = "第五梯队"; } else { label25.Text = ""; }
            if (dm_ret6 != -1) { label26.Text = "第六梯队"; } else { label26.Text = ""; }
            if (dm_ret7 != -1) { label27.Text = "第七梯队"; } else { label27.Text = ""; }
            if (dm_ret8 != -1) { label28.Text = "第八梯队"; } else { label28.Text = ""; }

            dm_ret0 = dmae.UseDict(0);
            string dm_ret9 = dmae.Ocr(391, 550, 594, 584, Settings.Default.LogisticsTeamColor+"-101010", 0.9);
            string dm_ret10 = dmae.Ocr(614, 551, 812, 582, Settings.Default.LogisticsTeamColor + "-101010", 0.9);
            string dm_ret11 = dmae.Ocr(837, 553, 1036, 584, Settings.Default.LogisticsTeamColor + "-101010", 0.9);
            string dm_ret12 = dmae.Ocr(1060, 551, 1252, 582, Settings.Default.LogisticsTeamColor + "-101010", 0.9);

            if (dm_ret9 != null) { label29.Text = dm_ret9; } else { label29.Text = ""; }
            if (dm_ret10 != null) { label30.Text = dm_ret10; } else { label30.Text = ""; }
            if (dm_ret11 != null) { label31.Text = dm_ret11; } else { label31.Text = ""; }
            if (dm_ret12 != null) { label32.Text = dm_ret12; } else { label32.Text = ""; }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Settings.Default.TeamListSelect2 = dmae.GetColor(10, 200);//梯队颜色
            button16.Enabled = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int dm_ret0 = dmae.CmpColor(10, 200, Settings.Default.TeamListSelect2, 0.9);


            if (dm_ret0 == 0)
            {
                label34.Text = "测试成功";
            }
            else
            {
                label34.Text = "测试失败";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            dmae.UseDict(5);
            im.mouse.ChooseBattle(dmae, "02", 1);

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("设置游戏窗口分辨率为1280*720");
            int ret = dmae.SetWindowSize(BaseData.SystemInfo.GameWindowsHwnd, 1280, 720);
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dmae.UseDict(5);
            im.mouse.ChooseBattle(dmae, "03", 1);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dmae.UseDict(5);
            im.mouse.ChooseBattle(dmae, "04", 1);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            dmae.UseDict(5);
            im.mouse.ChooseBattle(dmae, "05", 1);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            dmae.UseDict(5);
            im.mouse.ChooseBattle(dmae, "06", 1);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            dmae.UseDict(5);
            im.mouse.ChooseBattle(dmae, "07", 1);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            dmae.UseDict(5);
            im.mouse.ChooseBattle(dmae, "08", 1);
        }
    }
}
