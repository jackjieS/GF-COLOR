using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class CommonHelp
    {
        private InstanceManager im;
        public CommonHelp(InstanceManager im)
        {
            this.im = im;
        }
        public bool checkT(string mcode)
        {
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();//获取主版本号     

            im.eyLogin.SetAppKey("D5FA256E997E4E728DCEC4FB5111ACDF"); // 设置程序秘钥~一定要设置,否则无法正常使用控件
            BaseData.SystemInfo.MacCode = mcode;

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            BaseData.SystemInfo.MacCode = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(BaseData.SystemInfo.MacCode)), 4, 8);
            BaseData.SystemInfo.MacCode = BaseData.SystemInfo.MacCode.Replace("-", "");
            BaseData.SystemInfo.MacCode = BaseData.SystemInfo.MacCode.ToLower();
            BaseData.SystemInfo.MacCode = BaseData.SystemInfo.MacCode.Remove(0, 1);
            BaseData.SystemInfo.MacCode = BaseData.SystemInfo.MacCode.Insert(0, "a");



            int ret0 = im.eyLogin.UserLogin(WindowsFormsApplication1.BaseData.SystemInfo.MacCode, "a123456789", version, mcode);

            if (ret0 == 0)
            {
                WindowsFormsApplication1.BaseData.SystemInfo.AppState = "验证失败";
                if (im.eyLogin.GetLastError() == -203)
                {
                    MessageBox.Show("发现新版本，请在GFH群获取新版本。", "少女前线");
                    WriteLog.WriteError("发现新版本，请在GFH群获取新版本。");
                    Environment.Exit(0);

                }
                //MessageBox.Show(eyLogin.GetLastError().ToString(), "少女前线");
                return false;
            }
            else
            {

                string ret1 = im.eyLogin.GetLatestVersion();
                if (ret1 != version)
                {
                    MessageBox.Show("发现新版本，请在GFH群获取新版本。", "少女前线");
                    Environment.Exit(0);
                    return false;
                }
                BaseData.SystemInfo.AppState = "验证成功";
                WriteLog.WriteError("验证成功。");
                int ret2 = im.eyLogin.OpenUserCheck();

                if (ret2 == 0)

                {

                    MessageBox.Show("开启自动校验用户状态失败.");
                }




                return true;
            }

        }
        public bool CheckClientSize(DmAe dmae)
        {
            object width, height;
            dmae.GetClientSize(BaseData.SystemInfo.GameWindowsHwnd, out width, out height);

            if (Convert.ToInt32(width) != 1280 || Convert.ToInt32(height) != 720)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



    }
}
