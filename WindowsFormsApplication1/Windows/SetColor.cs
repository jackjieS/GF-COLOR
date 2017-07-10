﻿using System;
using System.Windows.Forms;
using dmtext;
using WindowsFormsApplication1.Properties;
using WindowsFormsApplication1;
using WindowsFormsApplication1.BaseData;

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

            //textBox1.Text = Properties.Settings.Default.SimulatorHomeCapX1.ToString();
            //textBox7.Text = Properties.Settings.Default.SimulatorHomeCapY1.ToString();
            //textBox5.Text = Properties.Settings.Default.SimulatorHomeCapX2.ToString();
            //textBox6.Text = Properties.Settings.Default.SimulatorHomeCapY2.ToString();

            //textBox8.Text = Properties.Settings.Default.SimulatorHomeCheckX1.ToString();
            //textBox3.Text = Properties.Settings.Default.SimulatorHomeCheckY1.ToString();
            //textBox4.Text = Properties.Settings.Default.SimulatorHomeCheckX2.ToString();
            //textBox2.Text = Properties.Settings.Default.SimulatorHomeCheckY2.ToString();

            label59.Text = ((double)((decimal)SystemInfo.BattleMissionSlectStrSim / 100)).ToString();

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

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Settings.Default.selfdiscipline = dmae.GetColor(608, 546);//绿色
            //Settings.Default.normal = dmae.GetColor(806, 546);//黄色
            //int dm_ret = dmae.Capture(Properties.Settings.Default.SimulatorHomeCapX1, Properties.Settings.Default.SimulatorHomeCapY1, Properties.Settings.Default.SimulatorHomeCapX2, Properties.Settings.Default.SimulatorHomeCapY2, "A.bmp");
            button6.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            object intX, intY;
            intX = intY = -1;
            string directPath = Application.StartupPath + "\\Debug";    //获得文件夹路径
            dmae.SetPath(directPath);

            //Properties.Settings.Default.SimulatorHomeCapX1 = Convert.ToInt32(textBox1.Text);
            //Properties.Settings.Default.SimulatorHomeCapY1 = Convert.ToInt32(textBox7.Text);
            //Properties.Settings.Default.SimulatorHomeCapX2 = Convert.ToInt32(textBox5.Text);
            //Properties.Settings.Default.SimulatorHomeCapY2 = Convert.ToInt32(textBox6.Text);

            //Properties.Settings.Default.SimulatorHomeCheckX1 = Convert.ToInt32(textBox8.Text);
            //Properties.Settings.Default.SimulatorHomeCheckY1 = Convert.ToInt32(textBox3.Text);
            //Properties.Settings.Default.SimulatorHomeCheckX2 = Convert.ToInt32(textBox4.Text);
            //Properties.Settings.Default.SimulatorHomeCheckY2 = Convert.ToInt32(textBox2.Text);

            //if (dmae.FindPic(Properties.Settings.Default.SimulatorHomeCheckX1, Properties.Settings.Default.SimulatorHomeCheckY1, Properties.Settings.Default.SimulatorHomeCheckX2, Properties.Settings.Default.SimulatorHomeCheckY2, "A.bmp", "000000", 1, 0, out intX, out intY) == -1)//用户自定义检测范围
            //{
            //    label6.Text = "测试失败";
            //}
            //else
            //{
            //    label6.Text = "测试成功";
            //}
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)//保存退出
        {
            int dm_ret = dmae.UnBindWindow();

            //Properties.Settings.Default.SimulatorHomeCapX1 = Convert.ToInt32(textBox1.Text);
            //Properties.Settings.Default.SimulatorHomeCapY1 = Convert.ToInt32(textBox7.Text);
            //Properties.Settings.Default.SimulatorHomeCapX2 = Convert.ToInt32(textBox5.Text);
            //Properties.Settings.Default.SimulatorHomeCapY2 = Convert.ToInt32(textBox6.Text);

            //Properties.Settings.Default.SimulatorHomeCheckX1 = Convert.ToInt32(textBox8.Text);
            //Properties.Settings.Default.SimulatorHomeCheckY1 = Convert.ToInt32(textBox3.Text);
            //Properties.Settings.Default.SimulatorHomeCheckX2 = Convert.ToInt32(textBox4.Text);
            //Properties.Settings.Default.SimulatorHomeCheckY2 = Convert.ToInt32(textBox2.Text);



            Settings.Default.Save();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {


        }

        private void button12_Click(object sender, EventArgs e)
        {
 
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
           
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {


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

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            dmae.UseDict(5);

            int result0 = dmae.FindStr(254, 97, 380, 719, "00", "313031-323132|5E4D25-2E1C0C", (double)((decimal)SystemInfo.BattleMissionSlectStrSim / 100), out object intX0, out object intY0);
            if(result0 == 0)
            {
                label4.Text = "第零战役成功识别";
            }
            else
            {
                label4.Text = "第零战役无法识别";
            }

            int result1 = dmae.FindStr(254, 97, 380, 719, "01", "313031-323132|5E4D25-2E1C0C", (double)((decimal)SystemInfo.BattleMissionSlectStrSim / 100), out object intX1, out object intY1);
            if (result1 == 0)
            {
                label38.Text = "第一战役成功识别";
            }
            else
            {
                label38.Text = "第一战役无法识别";
            }

            int result2 = dmae.FindStr(254, 97, 380, 719, "02", "313031-323132|5E4D25-2E1C0C", (double)((decimal)SystemInfo.BattleMissionSlectStrSim / 100), out object intX2, out object intY2);
            if (result2 == 0)
            {
                label51.Text = "第二战役成功识别";
            }
            else
            {
                label51.Text = "第二战役无法识别";
            }

            int result3 = dmae.FindStr(254, 97, 380, 719, "03", "313031-323132|5E4D25-2E1C0C", (double)((decimal)SystemInfo.BattleMissionSlectStrSim / 100), out object intX3, out object intY3);
            if (result3 == 0)
            {
                label50.Text = "第三战役成功识别";
            }
            else
            {
                label50.Text = "第三战役无法识别";
            }

            int result4 = dmae.FindStr(254, 97, 380, 719, "04", "313031-323132|5E4D25-2E1C0C", (double)((decimal)SystemInfo.BattleMissionSlectStrSim / 100), out object intX4, out object intY4);
            if (result4 == 0)
            {
                label55.Text = "第四战役成功识别";
            }
            else
            {
                label55.Text = "第四战役无法识别";
            }

            int result5 = dmae.FindStr(254, 97, 380, 719, "05", "313031-323132|5E4D25-2E1C0C", (double)((decimal)SystemInfo.BattleMissionSlectStrSim / 100), out object intX5, out object intY5);
            if (result5 == 0)
            {
                label54.Text = "第五战役成功识别";
            }
            else
            {
                label54.Text = "第五战役无法识别";
            }

            int result6 = dmae.FindStr(254, 97, 380, 719, "06", "313031-323132|5E4D25-2E1C0C", (double)((decimal)SystemInfo.BattleMissionSlectStrSim / 100), out object intX6, out object intY6);
            if (result6 == 0)
            {
                label53.Text = "第六战役成功识别";
            }
            else
            {
                label53.Text = "第六战役无法识别";
            }

            int result7 = dmae.FindStr(254, 97, 380, 719, "07", "313031-323132|5E4D25-2E1C0C", (double)((decimal)SystemInfo.BattleMissionSlectStrSim / 100), out object intX7, out object intY7);
            if (result7 == 0)
            {
                label52.Text = "第七战役成功识别";
            }
            else
            {
                label52.Text = "第七战役无法识别";
            }

            int result8 = dmae.FindStr(254, 97, 380, 719, "08", "313031-323132|5E4D25-2E1C0C", (double)((decimal)SystemInfo.BattleMissionSlectStrSim / 100), out object intX8, out object intY8);
            if (result8 == 0)
            {
                label56.Text = "第八战役成功识别";
            }
            else
            {
                label56.Text = "第八战役无法识别";
            }







        }
    }
}
