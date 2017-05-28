using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    partial class setting : Form
    {
        private InstanceManager im;
        public setting(InstanceManager im)
        {
            this.im = im;
            InitializeComponent();
        }





        private void setting_Load(object sender, EventArgs e)
        {
            trackBar1.Value = Convert.ToInt32(WindowsFormsApplication1.BaseData.SystemInfo.WaitTime * 10);
            decimal result = (decimal)trackBar1.Value / 10;
            label8.Text = result.ToString();

            trackBar2.Value = Convert.ToInt32(WindowsFormsApplication1.BaseData.SystemInfo.FindTeamSlectStrSim);
            decimal result1 = (decimal)trackBar2.Value / 100;
            label10.Text = result1.ToString();

            //地图缩放文字表达
            if (WindowsFormsApplication1.BaseData.SystemInfo.SetMapType == 0) { label14.Text = "右键平移"; }
            if (WindowsFormsApplication1.BaseData.SystemInfo.SetMapType == 1) { label14.Text = "ctrl加滚动滑轮"; }

            //地图缩放选项
            comboBox4.SelectedIndex = WindowsFormsApplication1.BaseData.SystemInfo.SetMapType;

            trackBar4.Value = WindowsFormsApplication1.BaseData.SystemInfo.FindTeamSlectStrColorOffset;
            label12.Text = trackBar4.Value.ToString();

            textBox1.Text = WindowsFormsApplication1.BaseData.SystemInfo.WaitTime.ToString();

            comboBox2.SelectedIndex = WindowsFormsApplication1.BaseData.SystemInfo.Simulator;
            comboBox3.Text = WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType.ToString();
            textBox2.Text = BaseData.SystemInfo.hwnd.ToString();
            checkBox3.Checked = BaseData.SystemInfo.RanControlinterval;
            checkBox4.Checked = WindowsFormsApplication1.BaseData.SystemInfo.LockWindows;
            checkBox1.Checked = WindowsFormsApplication1.BaseData.SystemInfo.DebugMode;

            //闪退间隔设置
            textBox4.Text = WindowsFormsApplication1.BaseData.SystemInfo.SimulatorCheckTime.ToString();
            //textBox3.Text = Properties.Settings.Default.GameIconX.ToString();
            //textBox5.Text = Properties.Settings.Default.GameIconY.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var SetColor = new SetColor(im);
            SetColor.StartPosition = FormStartPosition.CenterParent;
            SetColor.ShowDialog(this);
        }

        private void button1_Click_1(object sender, EventArgs e)// 保存
        {
            WindowsFormsApplication1.BaseData.SystemInfo.ResolutionRatio = comboBox1.Text;
            WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType =Int32.Parse(comboBox3.Text);
            WindowsFormsApplication1.BaseData.SystemInfo.DebugMode = checkBox1.Checked;
            WindowsFormsApplication1.BaseData.SystemInfo.WaitTime = Convert.ToDouble(textBox1.Text);
            WindowsFormsApplication1.BaseData.SystemInfo.FindTeamSlectStrSim = trackBar2.Value;//图像识别精度
            WindowsFormsApplication1.BaseData.SystemInfo.FindTeamSlectStrColorOffset = trackBar4.Value;//图像色彩偏移度
            WindowsFormsApplication1.BaseData.SystemInfo.Supply = checkBox2.Checked;
            WindowsFormsApplication1.BaseData.SystemInfo.Simulator = comboBox2.SelectedIndex;//保存模拟器设置
            BaseData.SystemInfo.Simulator = comboBox2.SelectedIndex;
            BaseData.SystemInfo.hwnd = Int32.Parse(textBox2.Text);
            Properties.Settings.Default.Save();
            WindowsFormsApplication1.BaseData.SystemInfo.SetMapType = comboBox4.SelectedIndex;//保存地图缩放设置
            WindowsFormsApplication1.BaseData.SystemInfo.LockWindows = checkBox4.Checked;
            //闪退设置
            WindowsFormsApplication1.BaseData.SystemInfo.SimulatorCheckTime = Convert.ToInt32(textBox4.Text);
            //Properties.Settings.Default.GameIconX = Convert.ToInt32(textBox3.Text);
            //Properties.Settings.Default.GameIconY = Convert.ToInt32(textBox5.Text);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(BaseData.SystemInfo.MacCode, "少女前线");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "1") { MessageBox.Show("注意，模式1模拟器需为极速模式", "少女前线"); }
            if (comboBox3.Text == "2") { MessageBox.Show("注意，夜神模拟器请使用模式2", "少女前线"); }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            decimal result = (decimal)trackBar1.Value / 10;
            textBox1.Text = result.ToString();
            label8.Text = result.ToString();
        }


        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox3.Checked == true) { BaseData.SystemInfo.RanControlinterval = true; trackBar1.Enabled = false;label8.Enabled=false; } else { BaseData.SystemInfo.RanControlinterval = false; trackBar1.Enabled = true;label8.Enabled = true; }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void trackBar2_ValueChanged_1(object sender, EventArgs e)
        {
            decimal result = (decimal)trackBar2.Value / 100;
            //textBox1.Text = result.ToString();
            label10.Text = result.ToString();

        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            label12.Text = trackBar4.Value.ToString();
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == 0) { label14.Text = "右键平移"; }
            if (comboBox4.SelectedIndex == 1) { label14.Text = "右键加滚动滑轮"; }
        }
    }
}
