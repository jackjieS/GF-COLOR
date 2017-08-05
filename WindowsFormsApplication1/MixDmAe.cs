using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
//using AELib;
using testdm;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Configuration;
using dmtext;
namespace WindowsFormsApplication1
{

    public class DmAe
    {

        public dmtext.CDmSoft dm= new dmtext.CDmSoft();
        public DmAe()
        {
        }

        public int FindWindow()
        {
            switch (BaseData.SystemInfo.Simulator)
            {
                case 0:
                    {
                        try
                        {
                            //QWidgetClassWindow
                            //Qt5QWindowIcon
                            //string temp0 = dm.EnumWindow(0, "QWidgetClassWindow", "Qt5QWindowIcon", 1 + 2);//temp自动找
                            string temp0 = dm.EnumWindow(0, "夜神模拟器", "Qt5QWindowIcon", 1 + 4 + 8 + 16);//temp自动找
                            temp0 = dm.EnumWindow(Convert.ToInt32(temp0), "ScreenBoardClassWindow", "Qt5QWindowIcon", 1 + 4 + 8 + 16);
                            temp0 = dm.EnumWindow(Convert.ToInt32(temp0), "QWidgetClassWindow", "Qt5QWindowIcon", 1 + 4 + 8 + 16);
                            if (temp0 != "")
                            {
                                BaseData.SystemInfo.GameWindowsHwnd = Convert.ToInt32(temp0);
                            }
                            return -2;
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("无法找到模拟器窗口", "少女前线");
                            WriteLog.WriteError("查找句柄" + ex.ToString());
                            return -2;
                        }

                    }
                case 1:
                    {
                        try
                        {
                            BaseData.SystemInfo.GameWindowsHwnd = Convert.ToInt32(dm.EnumWindow(0, "WndTxtCore", "XXEmulatorCore", 1 + 2));//temp自动找
                            break;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("无法找到模拟器窗口", "少女前线");
                            WriteLog.WriteError("查找句柄" + ex.ToString());
                            return -2;
                        }

                    }
                case 2:
                    {
                        try
                        {
                            BaseData.SystemInfo.GameWindowsHwnd = Convert.ToInt32(dm.EnumWindow(0, "kaopu001_tiantianplayer_opengl_wndWindow", "Qt5QWindowIcon", 1 + 2));//temp自动找
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("无法找到模拟器窗口", "少女前线");
                            WriteLog.WriteError("查找句柄" + ex.ToString());
                            return -2;
                        }
                        //variables.GameWindowsHwnd = Convert.ToInt32(dm.EnumWindow(0, "kaopu001_tiantianplayer_opengl_wndWindow", "Qt5QWindowIcon", 1 + 2));//temp自动找
                        break;
                    }

                case 3://靠谱助手 BS2HD
                    {

                        try
                        {
                            string temp0 = dm.EnumWindow(0, "kpzs  -- Power plus BlueStacks", "", 1 + 2);//temp自动找
                            if (temp0 != "")
                            {
                                string[] s = temp0.Split(new char[] { ',' });
                                BaseData.SystemInfo.GameWindowsHwnd = Int32.Parse(s[0]);
                            }
                            return -2;
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("无法找到模拟器窗口", "少女前线");
                            WriteLog.WriteError("查找句柄" + ex.ToString());
                            return -2;
                        }

                        //variables.GameWindowsHwnd = Convert.ToInt32(dm.EnumWindow(0, "kpzs  -- Power plus BlueStacks", "", 1 + 2));//temp自动找
                    }
                case 4://靠谱助手 BS
                    {
                        try
                        {
                            string temp0 = dm.EnumWindow(0, "kpzs  -- Power by BlueStacks", "Mono.WinForms.0.0", 1 + 2);//temp自动找
                            if (temp0 != "")
                            {
                                string[] s = temp0.Split(new char[] { ',' });
                                BaseData.SystemInfo.GameWindowsHwnd = Int32.Parse(s[0]);
                            }
                            return -2;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("无法找到模拟器窗口", "少女前线");
                            WriteLog.WriteError("查找句柄" + ex.ToString());
                            return -2;
                        }

                        //variables.GameWindowsHwnd = Convert.ToInt32(dm.EnumWindow(0, "kpzs  -- Power plus BlueStacks", "", 1 + 2));//temp自动找
                    }
                case 5:
                    {
                        try
                        {
                            string temp0 = dm.EnumWindow(0, "AEngineRenderWindow", "AEngineRenderWindowClass", 1 + 2);//temp自动找
                            if (temp0 != "")
                            {
                                BaseData.SystemInfo.GameWindowsHwnd = Int32.Parse(temp0);
                                break;
                            }
                            return -2;
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("无法找到模拟器窗口", "少女前线");
                            WriteLog.WriteError("查找句柄" + ex.ToString());
                            return -2;
                        }

                    }
                default:
                    break;
            }
            return -1;
        }

        public int BindWindow()
        {

            FindWindow();
            dm.SetShowErrorMsg(0);

            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.BindWindow(BaseData.SystemInfo.GameWindowsHwnd, "dx2", "dx2", "dx", 4);
                    }
                case 2:
                    {

                        return dm.BindWindow(BaseData.SystemInfo.GameWindowsHwnd, "dx2", "windows", "windows", 0);
                    }
                default:
                    break;
            }
            return -2;

        }

        public int LockInput(int a)
        {
            return dm.LockInput(a);
        }
        public int BindWindowLock()
        {

            if (WindowsFormsApplication1.BaseData.SystemInfo.LockWindows)
            {
                switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
                {
                    case 1://1是大漠2是AE
                        {
                            return dm.LockInput(1);/*dm.BindWindow(variables.GameWindowsHwnd, "dx2", "windows2", "windows", 4);*/
                        }
                    case 2:
                        {
                            return 0;
                        }
                    default:
                        break;
                }
                return 0;
            }

            else
            {

                return 0;
            }
        }
        public int BindWindowUnLock()
        {
            if (WindowsFormsApplication1.BaseData.SystemInfo.LockWindows)
            {
                switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
                {
                    case 1://1是大漠2是AE
                        {
                            return dm.LockInput(0);/*dm.BindWindow(variables.GameWindowsHwnd, "dx2", "windows", "windows", 0);*/
                        }
                    case 2:
                        {
                            return 0;
                        }
                    default:
                        return 0;
                }
            }
            else
            {
                return 0;

            }
        }
        public int UnBindWindow()
        {
            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.UnBindWindow();
                    }
                case 2:
                    {
                        return dm.UnBindWindow();
                    }
                default:
                    return 0;
            }
        }

        public int SetWindowSize(int hwnd, int width, int height)
        {
            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.SetWindowSize(hwnd, width, height);
                    }
                case 2:
                    {
                        return dm.SetWindowSize(hwnd, width, height);
                    }
                default:
                    break;
            }

            return 0;
        }


        public string GetMachineCode()
        {
            return dm.GetMachineCode();
        }

        public int GetClientSize(int hwnd, out object width, out object height)
        {
            height = width = -1;

            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.GetClientSize(hwnd, out width, out height);
                    }
                case 2:
                    {
                        return dm.GetClientSize(hwnd, out width, out height);
                    }
                default:
                    return 0;
            }
        }
        public int Capture(int x1, int y1, int x2, int y2, string file)
        {

            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.Capture(x1, y1, x2, y2, file);
                    }
                case 2:
                    {
                        return dm.Capture(x1, y1, x2, y2, file);
                    }
                default:
                    return 0;
            }
        }

        public int SetPath(string path)
        {
            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.SetPath(path);
                    }
                case 2:
                    {
                        return dm.SetPath(path);
                    }
                default:
                    return 0;
            }
        }



        public bool SetDict()//设置系统路径和字典
        {
            int dmae;
            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        dmae = dm.SetPath(Application.StartupPath);
                        if (dmae == 1) {; } else { WriteLog.WriteError("设置路径失败"); }
                        dmae = dm.SetDict(0, @"\Resources\dm_soft0.txt");
                        dmae = dm.SetDict(1, @"\Resources\TeamList.txt");
                        dmae = dm.SetDict(2, @"\Resources\dm_soft2.txt");
                        dmae = dm.SetDict(3, @"\Resources\LTeamList.txt");
                        dmae = dm.SetDict(4, @"\Resources\BTime.txt");
                        dmae = dm.SetDict(5, @"\Resources\Mission.txt");
                        if (dmae == 1) {; } else { WriteLog.WriteError("初始化字典失败"); }
                        if (dmae == 1) { return true; } else { return false; }
                    }
                case 2:
                    {
                        dmae = dm.SetPath(Application.StartupPath);
                        if (dmae == 1) {; } else { WriteLog.WriteError("设置路径失败"); }
                        dmae = dm.SetDict(0, @"\Resources\dm_soft0.txt");
                        dmae = dm.SetDict(1, @"\Resources\TeamList.txt");
                        dmae = dm.SetDict(2, @"\Resources\dm_soft2.txt");
                        dmae = dm.SetDict(3, @"\Resources\LTeamList.txt");
                        dmae = dm.SetDict(4, @"\Resources\BTime.txt");
                        dmae = dm.SetDict(5, @"\Resources\Mission.txt");
                        if (dmae == 1) {; } else { WriteLog.WriteError("初始化字典失败"); }
                        if (dmae == 1) { return true; } else { return false; }
                    }
                default:
                    return false;
            }
        }

        public int UseDict(int x)
        {
            long dmae;
            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        dmae = dm.UseDict(x);
                        if (dmae == 1) {; } else { WriteLog.WriteError("字典设置失败"); return 0; }
                        return 1;
                    }
                case 2:
                    {
                        dmae = dm.UseDict(x);
                        if (dmae == 1) {; } else { WriteLog.WriteError("字典设置失败"); return 0; }
                        return 1;
                    }
                default:
                    return 0;
            }
        }

        public int MoveTo(int x, int y)
        {
            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.MoveTo(x, y);
                    }
                case 2:
                    {
                        return dm.MoveTo(x, y);
                    }
                default:
                    return 0;
            }
        }

        public int WheelDown()
        {

            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.WheelDown();
                    }
                case 2:
                    {
                        return dm.WheelDown();
                    }
                default:
                    return 0;
            }
        }

        public int WheelUp()
        {

            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.WheelUp();
                    }
                case 2:
                    {
                        return dm.WheelUp();
                    }
                default:
                    return 0;
            }
        }

        public int KeyDown(int vk_code)
        {

            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.KeyDown(vk_code);
                    }
                case 2:
                    {
                        return dm.KeyDown(vk_code);
                    }
                default:
                    return 0;
            }
        }

        public int KeyUp(int vk_code)
        {

            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.KeyUp(vk_code);
                    }
                case 2:
                    {
                        return dm.KeyUp(vk_code);
                    }
                default:
                    return 0;
            }
        }

        public int LeftDown()
        {
            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.LeftDown();
                    }
                case 2:
                    {
                        return dm.LeftDown();
                    }
                default:
                    return 0;
            }
        }
        public int RightDown()
        {
            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.RightDown();
                    }
                case 2:
                    {
                        return dm.RightDown();
                    }
                default:
                    return 0;
            }
        }
        public int RightUp()
        {
            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.RightUp();
                    }
                case 2:
                    {
                        return dm.RightUp();
                    }
                default:
                    return 0;
            }
        }
        public int LeftUp()
        {
            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.LeftUp();
                    }
                case 2:
                    {
                        return dm.LeftUp();
                    }
                default:
                    return 0;
            }
        }

        public string GetColor(int x, int y)
        {
            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.GetColor(x, y);
                    }
                case 2:
                    {
                        return dm.GetColor(x, y);
                    }
                default:
                    return "";
            }
        }

        public int FindColor(int x1, int y1, int x2, int y2, string color, double sim, int dir, out object intX, out object intY)
        {
            intX = intY = -1;
            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.FindColor(x1, y1, x2, y2, color, sim, dir, out intX, out intY);
                    }
                case 2:
                    {
                        return dm.FindColor(x1, y1, x2, y2, color, sim, dir, out intX, out intY);
                    }
                default:
                    return 0;
            }
        }

        public int LoadPic(string all_pic)
        {
            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.LoadPic(all_pic);
                    }
                case 2:
                    {
                        return dm.LoadPic(all_pic);
                    }
                default:
                    return 0;
            }
        }

        public int FindPic(int x1, int y1, int x2, int y2, string pic_name, string delta_color, double sim, int dir, out object intX, out object intY)//返回找到的图片的序号,从0开始索引.如果没找到返回-1
        {
            //返回找到的图片的序号,从0开始索引.如果没找到返回-1
            intX = intY = -1;
            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.FindPic(x1, y1, x2, y2, pic_name, delta_color, sim, dir, out intX, out intY);
                    }
                case 2:
                    {
                        return dm.FindPic(x1, y1, x2, y2, pic_name, delta_color, sim, dir, out intX, out intY);
                    }
                default:
                    return -1;
            }
        }

        public int CmpColor(int x, int y, string color, double sim)
        {
            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.CmpColor(x, y, color, sim);
                    }
                case 2:
                    {
                        return dm.CmpColor(x, y, color, sim);
                    }
                default:
                    return 1;
            }
        }

        public string FindMultiColorEx(int x1, int y1, int x2, int y2, string first_color, string offset_color, double sim, int dir)
        {
            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.FindMultiColorEx(x1, y1, x2, y2, first_color, offset_color, sim, dir);
                    }
                case 2:
                    {
                        return dm.FindMultiColorEx(x1, y1, x2, y2, first_color, offset_color, sim, dir);
                    }
                default:
                    return "false";
            }
        }
        public long GetResultCount(string ret)
        {
            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.GetResultCount(ret);
                    }
                case 2:
                    {
                        return dm.GetResultCount(ret);
                    }
                default:
                    return 0;
            }
        }

        public string FindColorEx(int x1,int y1,int x2,int  y2,string color,double sim,int dir)
        {
            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return FindColorEx(x1, y1, x2, y2, color, sim, dir);
                    }
                case 2:
                    {
                        return FindColorEx(x1, y1, x2, y2, color, sim, dir);
                    }
                default:
                    return "false";
            }
        }

        public int FindStr(int x1, int y1, int x2, int y2, string str, string color_format, double sim, out object intX, out object intY)
        {

            intX = intY = -1;
            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.FindStr(x1, y1, x2, y2, str, color_format, sim, out intX, out intY);
                    }
                case 2:
                    {
                        return dm.FindStr(x1, y1, x2, y2, str, color_format, sim, out intX, out intY);
                    }
                default:
                    return -1;
            }
        }

        public int FindStrFast(int x1, int y1, int x2, int y2, string str, string color_format, double sim, out object intX, out object intY)
        {
            intX = intY = -1;
            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.FindStrFast(x1, y1, x2, y2, str, color_format, sim, out intX, out intY);
                    }
                case 2:
                    {
                        return dm.FindStrFast(x1, y1, x2, y2, str, color_format, sim, out intX, out intY);
                    }
                default:
                    return 0;
            }
        }

        public string Ocr(int x1, int y1, int x2, int y2, string color_format, double sim)
        {
            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                    {
                        return dm.Ocr(x1, y1, x2, y2, color_format, sim);
                    }
                case 2:
                    {
                        return dm.Ocr(x1, y1, x2, y2, color_format, sim);
                    }
                default:
                    return "";
            }
        }
        public string GetAveRGB(int x1, int y1,int x2,int y2)
        {
            switch (WindowsFormsApplication1.BaseData.SystemInfo.BindWindowsType)
            {
                case 1://1是大漠2是AE
                {
                    return dm.GetAveRGB(x1, y1, x2, y2);
                }
            case 2:
                {
                        return dm.GetAveRGB(x1, y1, x2, y2);
                    }
            default:
                return "";
            }
        }

    }





    class WriteLog
    {
        private InstanceManager im;
        public WriteLog(InstanceManager im)
        {
            this.im = im;
        }
        private static StreamWriter streamWriter; //写文件  

        public static void WriteError(string message)
        {
            try
            {
                //DateTime dt = new DateTime();
                string directPath = Application.StartupPath + "\\Debug";    //获得文件夹路径
                if (!Directory.Exists(directPath))   //判断文件夹是否存在，如果不存在则创建
                {
                    Directory.CreateDirectory(directPath);
                }
                directPath += string.Format(@"\Log.log"/*, DateTime.Now.ToString("yyyy-MM-dd")*/);
                if (streamWriter == null)
                {
                    streamWriter = !File.Exists(directPath) ? File.CreateText(directPath) : File.AppendText(directPath);    //判断文件是否存在如果不存在则创建，如果存在则添加。
                }
                //streamWriter.WriteLine("***********************************************************************");
                //streamWriter.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                //streamWriter.WriteLine("输出信息：错误信息");
                if (message != null)
                {
                    streamWriter.WriteLine("【" + DateTime.Now.ToString("HH:mm:ss") + "】" + "      " +  /*"异常信息：\r\n"*/ message);
                }
            }

            catch (Exception ex)
            {

                WriteError("记录输出异常：" + ex.Message);
            }

            finally
            {
                if (streamWriter != null)
                {
                    try
                    {
                        streamWriter.Flush();
                        streamWriter.Dispose();
                        streamWriter = null;
                    }
                    catch (Exception ex)
                    {

                        WriteError("记录输出异常：" + ex.Message);
                    }

                }
            }
        }





















    }

    public class CheckPage
    {
        //检测是否在选择梯队页面（部署梯队） 

    }

}
