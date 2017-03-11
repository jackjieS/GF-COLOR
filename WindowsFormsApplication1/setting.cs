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
            trackBar1.Value = Convert.ToInt32(Properties.Settings.Default.WaitTime * 10);
            decimal result = (decimal)trackBar1.Value / 10;
            label8.Text = result.ToString();

            trackBar2.Value = Convert.ToInt32(Properties.Settings.Default.FindTeamSlectStrSim);
            decimal result1 = (decimal)trackBar2.Value / 100;
            label10.Text = result1.ToString();

            //地图缩放文字表达
            if (Properties.Settings.Default.SetMapType == 0) { label14.Text = "右键平移"; }
            if (Properties.Settings.Default.SetMapType == 1) { label14.Text = "右键加滚动滑轮"; }

            //地图缩放选项
            comboBox4.SelectedIndex = Properties.Settings.Default.SetMapType;

            trackBar4.Value =Convert.ToInt32(Properties.Settings.Default.FindTeamSlectStrColorOffset);
            label12.Text = trackBar4.Value.ToString();

            textBox1.Text = Properties.Settings.Default.WaitTime.ToString();
            comboBox2.SelectedIndex = Properties.Settings.Default.Simulator;
            comboBox3.Text = Properties.Settings.Default.BindWindowsType.ToString();
            textBox2.Text = BaseData.SystemInfo.hwnd.ToString();
            checkBox3.Checked = BaseData.SystemInfo.RanControlinterval;
            checkBox4.Checked = Properties.Settings.Default.LockWindows;

            //闪退间隔设置
            textBox4.Text = Properties.Settings.Default.SimulatorHomeCheckTime.ToString();
            textBox3.Text = Properties.Settings.Default.GameIconX.ToString();
            textBox5.Text = Properties.Settings.Default.GameIconY.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var SetColor = new SetColor(im);
            SetColor.StartPosition = FormStartPosition.CenterParent;
            SetColor.ShowDialog(this);
        }

        private void button1_Click_1(object sender, EventArgs e)// 保存
        {
            Properties.Settings.Default.resolution = comboBox1.Text;
            Properties.Settings.Default.BindWindowsType=Int32.Parse(comboBox3.Text);
            Properties.Settings.Default.DebugMode = checkBox1.Checked;
            Properties.Settings.Default.WaitTime = Convert.ToDouble(textBox1.Text);
            Properties.Settings.Default.FindTeamSlectStrSim = trackBar2.Value;//图像识别精度
            Properties.Settings.Default.FindTeamSlectStrColorOffset = trackBar4.Value.ToString();//图像色彩偏移度
            Properties.Settings.Default.RandomNotes = checkBox2.Checked;
            Properties.Settings.Default.Simulator = comboBox2.SelectedIndex;//保存模拟器设置
            BaseData.SystemInfo.Simulator = comboBox2.SelectedIndex;
            BaseData.SystemInfo.hwnd = Int32.Parse(textBox2.Text);
            Properties.Settings.Default.Save();
            Properties.Settings.Default.SetMapType = comboBox4.SelectedIndex;//保存地图缩放设置
            Properties.Settings.Default.LockWindows = checkBox4.Checked;
            //闪退设置
            Properties.Settings.Default.SimulatorHomeCheckTime = Convert.ToInt32(textBox4.Text);
            Properties.Settings.Default.GameIconX = Convert.ToInt32(textBox3.Text);
            Properties.Settings.Default.GameIconY = Convert.ToInt32(textBox5.Text);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(BaseData.SystemInfo.MacCode, "少女前线");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "1") { MessageBox.Show("注意，模式1模拟器需为极速模式", "少女前线"); }
            if (comboBox3.Text == "2") { MessageBox.Show("注意，模式2模式模拟器需为兼容模式", "少女前线"); }
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
