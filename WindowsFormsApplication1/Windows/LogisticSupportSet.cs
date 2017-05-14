using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    partial class LogisticSupportSet : Form
    {
        private InstanceManager im;
        public LogisticSupportSet(InstanceManager im)
        {
            this.im = im;
            InitializeComponent();
        }

        private void LogisticSupportSet_Load(object sender, EventArgs e)
        {
            textBox1.Text = WindowsFormsApplication1.Properties.Settings.Default.LogisticFinishWaittingTime.ToString();
            textBox2.Text = WindowsFormsApplication1.Properties.Settings.Default.LogisticLoopTimeMAX.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Properties.Settings.Default.LogisticFinishWaittingTime = Convert.ToInt32(textBox1.Text);
            WindowsFormsApplication1.Properties.Settings.Default.LogisticLoopTimeMAX = Convert.ToInt32(textBox2.Text);
            WindowsFormsApplication1.Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
