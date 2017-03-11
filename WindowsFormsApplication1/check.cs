using System;
using System.Security.Principal;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class check : Form
    {
        private string temp;
        public check(string nTemp)
        {
            InitializeComponent();
            this.temp = nTemp;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if(IsAdministrator() == false)
            {
                label3.Text = "请使用管理员权限打开";
            }
            textBox1.BackColor = System.Drawing.SystemColors.Control;
            textBox1.Text = BaseData.SystemInfo.MacCode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public bool IsAdministrator()
        {
            WindowsIdentity current = WindowsIdentity.GetCurrent();
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
            return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
