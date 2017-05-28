using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.BaseData;

namespace WindowsFormsApplication1.Events
{
     class Dormitory
    {
        private InstanceManager im;
        public Dormitory(InstanceManager im)
        {
            this.im = im;
        }

        public void VoteDormitoryLoop(DmAe dmae)
        {
            bool Loop = true;

            im.mouse.ClickHomeDormitory(dmae);


            while (Loop)
            {
                //点击参观他人宿舍
                im.mouse.ClickVisitDormitory(dmae);
                im.mouse.delayTime(1);
                //点击我的好友
                im.mouse.ClickMyFriendsList(dmae);
                im.mouse.delayTime(1);
                //点击随机参观
                im.mouse.ClickRandomVisit(dmae);
                im.mouse.delayTime(1);
                //点赞                //获得奖励
                Loop = im.mouse.ClickVote(dmae);
                im.mouse.delayTime(1);

                //返回宿舍
                im.mouse.ClickBackTOmyDormitory(dmae);
                im.mouse.delayTime(1);
                //判断是否重复
            }






            //若结束则返回主页
            im.mouse.ClickBackToHomeFromDomitory(dmae);
            im.mouse.delayTime(1);
            
        }

        public void ReadAndSaveFriendsDormitoryList(DmAe dmae)
        {
            int count = 1;
            object intX = 0, intY = 0;
            im.mouse.ClickHomeDormitory(dmae);

            //点击参观他人宿舍
            im.mouse.ClickVisitDormitory(dmae);
            im.mouse.delayTime(1);
            //点击我的好友
            im.mouse.ClickMyFriendsList(dmae);
            im.mouse.delayTime(1);
            //点击第一位
            im.mouse.ClickFirstFriendsDormitory(dmae);
            //保存好友名字 用做终止

            //做好延迟

            
            while (true)
            {

                //保存图片
                if (count == 1)
                {
                    SaveFriendName(dmae, count, "firstname");
                }

                SaveFriendName(dmae, count);
                im.Form1.imageList1.Images.Add(Image.FromFile(Application.StartupPath + "\\FriendList\\" + "temp" + count.ToString() + ".bmp"));

                if (im.Form1.pictureBox1.Image != null)
                {
                    //有图片     
                }
                else
                {
                    im.Form1.pictureBox1.Image = im.Form1.imageList1.Images[0];
                    //无图片     
                }


                count++;


                //点击NEXT
                im.mouse.ClickNextFriendDormitory(dmae);

                //如果当前名字和temp一样则退出循环
                if(ComPFirstFriendName(dmae)==true)
                {
                    break;
                }
            }
            File.Delete(Application.StartupPath + @"\FriendList\temp0.bmp");

            im.mouse.ClickBackTOmyDormitory(dmae);
            //若结束则返回主页
            im.mouse.ClickBackToHomeFromDomitory(dmae);
            im.mouse.delayTime(1);
        }

        public void GetFriendBattery(DmAe dmae,bool NeedSecondTime,bool NeetTOCap=true)
        {
            object intX = 0, intY = 0;
            bool FirstName = true;
            bool secondtime = false;
            string Name= GetMyLogFriendName(dmae);
            im.mouse.ClickHomeDormitory(dmae);

            //点击参观他人宿舍
            im.mouse.ClickVisitDormitory(dmae);
            im.mouse.delayTime(1);
            //点击我的好友
            im.mouse.ClickMyFriendsList(dmae);
            im.mouse.delayTime(1);
            //点击第一位
            im.mouse.ClickFirstFriendsDormitory(dmae);
            //保存好友名字 用做终止




            //做好延迟


            while (true)
            {

                while (im.mouse.CheckDormitoryLoad(dmae) == false)
                {
                    im.mouse.delayTime(1);
                }

                //保存图片
                if (FirstName)
                {
                    SaveFriendName(dmae, 0, "firstname");
                    FirstName = false;
                }




                //开始比较如果名字符合则检查是否有电池
                //重置镜头
                im.mouse.ClickRestDormitoryMLeft(dmae);
                //对比名字
                if (ComPFriendName(dmae, Name) == true)
                {
                    //确认到名字
                    //检查电池
                    if (im.mouse.CheckFriendDormitoryBattery(dmae) == true)
                    {
                        im.mouse.ClickFriendDormitoryBattery(dmae);
                        im.mouse.ClickFriendDormitoryBatteryWindow(dmae);
                    }

                }
                //二次循环
                if (im.mouse.CheckFriendDormitoryBattery(dmae) == true && secondtime == true)
                {
                    im.mouse.ClickFriendDormitoryBattery(dmae);
                    im.mouse.ClickFriendDormitoryBatteryWindow(dmae);
                }


                //点击NEXT
                im.mouse.ClickNextFriendDormitory(dmae);
                
                //如果当前名字和temp一样则退出循环
                //二次循环检查
                if (ComPFirstFriendName(dmae) == true && secondtime == true)
                {
                    break;
                }
                if (ComPFirstFriendName(dmae) == true && secondtime == false)
                {
                    SystemInfo.AppState = "二次循环";
                    if (NeedSecondTime == true)
                    {
                        secondtime = true;
                    }
                }
            }

            //删除第一张图片临时图片
            File.Delete(Application.StartupPath + @"\FriendList\temp0.bmp");

            im.mouse.ClickBackTOmyDormitory(dmae);
            //若结束则返回主页
            im.mouse.ClickBackToHomeFromDomitory(dmae);
            im.mouse.delayTime(1);
        }




        

        public void SaveFriendName(DmAe dmae,int count,string type="normal")
        {
            while (im.mouse.CheckMyFriendDormitory(dmae) == -1)
            {
                im.mouse.delayTime(1);
            }

            while (im.mouse.CheckDormitoryLoad(dmae)==false)
            {
                im.mouse.delayTime(1);
            }

            if (type == "firstname")
            {
                dmae.Capture(900, 15, 1065, 50, "\\FriendList\\temp0.bmp");
            }

            int dm_retsave = dmae.Capture(900, 15, 1065, 50, "\\FriendList\\" + "temp" + count.ToString() + ".bmp");

        }

        public string GetMyLogFriendName(DmAe dmae)
        {
            int i = 1;
            string Name="";
            while (i < 100)
            {
                if (File.Exists(Application.StartupPath + "\\FriendList\\NO" + i.ToString() + ".bmp"))
                {
                    Name = Name + "\\FriendList\\NO" + i.ToString() + ".bmp|";
                }
                i++;

            }
            Name =  Name.Remove(Name.Length - 1,1);
            return Name;
        }

        public bool ComPFirstFriendName(DmAe dmae)
        {
            object intX, intY;
            while (im.mouse.CheckMyFriendDormitory(dmae) == -1)
            {
                im.mouse.delayTime(1);
            }

            if (dmae.FindPic(899, 14, 1066, 51, "\\FriendList\\temp0.bmp", "000000", 0.9, 0, out intX, out intY) != -1)
            {
                return true;
            }
            return false;
        }

        public bool ComPFriendName(DmAe dmae,string name)
        {
            object intX, intY;
            while (im.mouse.CheckMyFriendDormitory(dmae) == -1)
            {
                im.mouse.delayTime(1);
            }
            if (dmae.FindPic(899, 14, 1066, 51, name, "000000", 0.9, 0, out intX, out intY) != -1)
            {
                return true;
            }

            return false;
        }

        public void ReadLogFriendListFromStart()
        {
            int i=1;
            while (i<100)
            {
                if(File.Exists(Application.StartupPath+ "\\FriendList\\NO" + i.ToString() + ".bmp"))
                {
                    im.Form1.imageList2.Images.Add(Image.FromFile(Application.StartupPath + "\\FriendList\\NO" + i.ToString() + ".bmp"));
                    im.Form1.pictureBox2.Image = im.Form1.imageList2.Images[0];
                    i++;
                    CommonHelp.PictureBox2Count++;
                }
                else
                {
                    return;
                }
            }
        }
        public void ReadtempFriendListFromStart()
        {
            int i = 1;
            while (i < 100)
            {
                if (File.Exists(Application.StartupPath + "\\FriendList\\temp" + i.ToString() + ".bmp"))
                {
                    im.Form1.imageList1.Images.Add(Image.FromFile(Application.StartupPath + "\\FriendList\\temp" + i.ToString() + ".bmp"));
                    im.Form1.pictureBox1.Image = im.Form1.imageList1.Images[0];
                    i++;
                    CommonHelp.PictureBox1Count++;
                }
                else
                {
                    return;
                }
            }
        }
        public void CleanALLtempPic()
        {
            int i = 1;
            im.Form1.imageList1.Images.Clear();
            im.Form1.pictureBox1.Image = null;
            while (i < 100)
            {
                if (File.Exists(Application.StartupPath + "\\FriendList\\temp" + i.ToString() + ".bmp"))
                {
                    File.Delete(Application.StartupPath + "\\FriendList\\temp" + i.ToString() + ".bmp");
                }
                i++;
            }
        }

        public void CleanALLLogPic()
        {
            int i = 1;
            im.Form1.imageList2.Images.Clear();
            im.Form1.pictureBox2.Image = null;
            while (i < 100)
            {
                if (File.Exists(Application.StartupPath + "\\FriendList\\NO" + i.ToString() + ".bmp"))
                {
                    File.Delete(Application.StartupPath + "\\FriendList\\NO" + i.ToString() + ".bmp");
                }
                i++;

            }
        }


    }
}
