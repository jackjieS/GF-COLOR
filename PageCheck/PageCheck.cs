using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dmtext;
namespace PageCheck
{
    public class PageCheck
    {


        public PageCheck()
        {

        }
        public void Ver(CDmSoft dm)
        {
            Console.WriteLine("我是来自PageCheck的调用");
            Console.WriteLine(dm.Ver());
        }
        //------------------多点比较颜色函数

        public int CheckToFix(CDmSoft dm,int N)//梯队列表检查是否需要维修
        {
            int x1, y1, x2, y2, x3, y3, i;
            string dm_ret0, dm_ret1, dm_ret2;

            switch (N)
            {
                case 1:
                    {
                        x1 = 204; y1 = 523; x2 = 308; y2 = 523; x3 = 207; y3 = 512;
                        break;
                    }
                case 2:
                    {
                        x1 = 391; y1 = 523; x2 = 494; y2 = 523; x3 = 393; y3 = 512;
                        break;
                    }
                case 3:
                    {
                        x1 = 577; y1 = 523; x2 = 681; y2 = 523; x3 = 579; y3 = 512;
                        break;
                    }

                case 4:
                    {
                        x1 = 763; y1 = 523; x2 = 867; y2 = 523; x3 = 766; y3 = 512;
                        break;
                    }

                case 5:
                    {
                        x1 = 949; y1 = 523; x2 = 1053; y2 = 523; x3 = 952; y3 = 512;
                        break;
                    }
                default:
                    return -1;
            }

            dm_ret0 = dm.GetColor(x1, y1);
            dm_ret1 = dm.GetColor(x2, y2);
            if (dm_ret0 == dm_ret1)//判断是否满血或者没血
            {
                dm_ret2 = dm.GetColor(x3, y3);
                if (dm_ret2 == dm_ret1)
                {
                    Console.WriteLine("0血");
                    return 0;
                    //0血状态
                }
                Console.WriteLine("满血");
                return 100;
                //满血状态
            }
            else
            {
                for (i = 0; i < (x2 - x1); i++)
                {
                    string dm_ret3 = dm.GetColor(x1 + i, y1);
                    if (dm_ret3 != dm_ret0)
                    {
                        Console.WriteLine("x = " + (x1 + i).ToString());
                        break;
                    }
                }
                //检查
                Console.WriteLine("遍历完成 i = " + i.ToString());
                Console.WriteLine("百分比为" + Convert.ToInt32(((float)i / (x2 - x1) * 100) + 0.5).ToString());
                return Convert.ToInt32(((float)i / (x2 - x1) * 100) + 0.5);
            }


        }

        public int FixPageCheckTheHP(CDmSoft dm, int N)//修复页面列表读取血量
        {
            int x1, y1, x2, y2, x3, y3, i;
            string dm_ret0, dm_ret1, dm_ret2;

            switch (N)
            {
                case 1:
                    {
                        x1 = 9; y1 = 335; x2 = 167; y2 = 335;
                        break;
                    }
                case 2:
                    {
                        x1 = 187; y1 = 335; x2 = 346; y2 = 335;
                        break;
                    }
                case 3:
                    {
                        x1 = 366; y1 = 335; x2 = 525; y2 = 335;
                        break;
                    }

                case 4:
                    {
                        x1 = 545; y1 = 335; x2 = 704; y2 = 335;
                        break;
                    }

                case 5:
                    {
                        x1 = 724; y1 = 335; x2 = 882; y2 = 335;
                        break;
                    }
                case 6:
                    {
                        x1 = 902; y1 = 335; x2 = 1061; y2 = 335;
                        break;
                    }
                case 7:
                    {
                        x1 = 9; y1 = 638; x2 = 167; y2 = 638;
                        break;
                    }
                case 8:
                    {
                        x1 = 167; y1 = 638; x2 = 346; y2 = 638;
                        break;
                    }
                case 9:
                    {
                        x1 = 367; y1 = 638; x2 = 525; y2 = 638;
                        break;
                    }
                case 10:
                    {
                        x1 = 546; y1 = 638; x2 = 704; y2 = 638;
                        break;
                    }
                case 11:
                    {
                        x1 = 725; y1 = 638; x2 = 882; y2 = 638;
                        break;
                    }
                case 12:
                    {
                        x1 = 903; y1 = 638; x2 = 1061; y2 = 638;
                        break;
                    }
                default:
                    return -1;
            }

            dm_ret0 = dm.GetColor(x1, y1);
            dm_ret1 = dm.GetColor(x2, y2);

            for (i = 0; i < (x2 - x1); i++)
            {
                string dm_ret3 = dm.GetColor(x1 + i, y1);
                if (dm_ret3 != dm_ret0)
                {
                    //Console.WriteLine("x = " + (x1 + i).ToString());
                    break;
                }
            }
            //检查
            //Console.WriteLine("遍历完成 i = " + i.ToString());
            //Console.WriteLine("百分比为" + Convert.ToInt32(((float)i / (x2 - x1) * 100) + 0.5).ToString());
            int k = Convert.ToInt32(((float)i / (x2 - x1) * 100));
            return k;


        }

        public bool CheckIsBroken(CDmSoft dm, int N)//检测是否大破
        {
            int x1, y1, x2, y2, x3, y3, x4, y4, x5, y5;
            string dm_ret1;
            string dm_main_ret0;
            int tempx;
            switch (N)//识别第N个是否大破
            {
                case 1:
                    {
                        x1 = 10; y1 = 155; x2 = 27; y2 = 155; x3 = 39; y3 = 155; x4 = 74; y4 = 155; x5 = 132; y5 = 155;
                        break;
                    }
                case 2:
                    {
                        x1 = 189; y1 = 155; x2 = 205; y2 = 155; x3 = 229; y3 = 155; x4 = 253; y4 = 155; x5 = 310; y5 = 155;
                        break;
                    }
                case 3:
                    {
                        x1 = 368; y1 = 155; x2 = 384; y2 = 155; x3 = 408; y3 = 155; x4 = 600; y4 = 155; x5 = 668; y5 = 155;
                        break;
                    }
                case 4:
                    {
                        x1 = 547; y1 = 155; x2 = 563; y2 = 155; x3 = 575; y3 = 155; x4 = 611; y4 = 155; x5 = 668; y5 = 155;
                        break;
                    }
                case 5:
                    {
                        x1 = 726; y1 = 155; x2 = 741; y2 = 155; x3 = 753; y3 = 155; x4 = 777; y4 = 155; x5 = 845; y5 = 155;
                        break;
                    }
                case 6:
                    {
                        x1 = 904; y1 = 155; x2 = 920; y2 = 155; x3 = 932; y3 = 155; x4 = 956; y4 = 155; x5 = 1025; y5 = 155;
                        break;
                    }
                case 7:
                    {
                        x1 = 10; y1 = 458; x2 = 28; y2 = 458; x3 = 39; y3 = 458; x4 = 51; y4 = 458; x5 = 130; y5 = 458;
                        break;
                    }
                case 8:
                    {
                        x1 = 189; y1 = 458; x2 = 207; y2 = 458; x3 = 219; y3 = 458; x4 = 231; y4 = 458; x5 = 310; y5 = 458;
                        break;
                    }

                case 9:
                    {
                        x1 = 368; y1 = 458; x2 = 385; y2 = 458; x3 = 576; y3 = 458; x4 = 600; y4 = 458; x5 = 668; y5 = 458;
                        break;
                    }
                case 10:
                    {
                        x1 = 547; y1 = 458; x2 = 565; y2 = 458; x3 = 588; y3 = 458; x4 = 600; y4 = 458; x5 = 667; y5 = 458;
                        break;
                    }
                case 11:
                    {
                        x1 = 725; y1 = 458; x2 = 743; y2 = 458; x3 = 755; y3 = 458; x4 = 790; y4 = 458; x5 = 845; y5 = 458;
                        break;
                    }
                case 12:
                    {
                        x1 = 904; y1 = 458; x2 = 921; y2 = 458; x3 = 945; y3 = 458; x4 = 958; y4 = 458; x5 = 1025; y5 = 458;
                        break;
                    }
                default:
                    return false;
            }

            for (int i = 1; i <= 5; i++)
            {
                switch (i)
                {
                    case 1:
                        {
                            dm_main_ret0 = dm.GetColor(x1, y1);
                            tempx = x1;
                            break;
                        }
                    case 2:
                        {
                            dm_main_ret0 = dm.GetColor(x2, y2);
                            tempx = x2;
                            break;
                        }
                    case 3:
                        {
                            dm_main_ret0 = dm.GetColor(x3, y3);
                            tempx = x3;
                            break;
                        }
                    case 4:
                        {
                            dm_main_ret0 = dm.GetColor(x4, y4);
                            tempx = x4;
                            break;
                        }
                    case 5:
                        {
                            dm_main_ret0 = dm.GetColor(x5, y5);
                            tempx = x5;
                            break;
                        }
                    default:
                        {
                            dm_main_ret0 = dm.GetColor(x1, y1);
                            tempx = x1;
                            break;
                        }
                }
                for (int y = 1; y <= 3; y++)
                {
                    dm_ret1 = dm.GetColor(tempx + y, y1);
                    if (dm_main_ret0 != dm_ret1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public int CheckTeamSlectPage(CDmSoft dm)//梯队详细列表
        {
            int dm_Ret0 = dm.CmpColor(192, 90, "ffffff", 1);
            int dm_Ret1 = dm.CmpColor(1000, 615, "ffffff", 1);
            int dm_Ret2 = dm.CmpColor(388, 94, "ffffff", 1);
            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0)
            {
                return 0;//真0假1
            }

            else
            {
                return 1;
            }
        }

        public int CheckErrorWindows(CDmSoft dm, int x1 = 558, int y1 = 489, int x2 = 721, int y2 = 489)
        {
            int dm_ret0 = dm.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_ret1 = dm.CmpColor(x2, y2, "ffffff", 0.9);

            if (dm_ret0 == 0 && dm_ret1 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }

        public bool CheckLsystemAgain(CDmSoft dm)
        {

            for (int x1 = 446, y1 = 463; x1 <= 610; x1++)
            {
                if (dm.GetColor(x1, y1) != "ffffff") return false;
            }
            for (int x1 = 611, y1 = 463; y1 <= 511; y1++)
            {
                if (dm.GetColor(x1, y1) != "ffffff") return false;
            }
            for (int x1 = 446, y1 = 526; x1 <= 596; x1++)
            {
                if (dm.GetColor(x1, y1) != "ffffff") return false;
            }
            return true;
        }

        public int CheckMissionHelp(CDmSoft dm, int x1 = 164, int y1 = 106, int x2 = 270, int y2 = 106, int x3 = 259, int y3 = 162)
        {
            int dm_Ret0 = dm.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_Ret1 = dm.CmpColor(x2, y2, "ffffff", 0.9);
            int dm_Ret2 = dm.CmpColor(x3, y3, "ffffff", 0.9);

            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }

        public int CheckLogisticsPageReady(CDmSoft dm, int x1 = 435, int y1 = 395, int x2 = 658, int y2 = 392, int x3 = 880, int y3 = 394, int x4 = 1102, int y4 = 394)
        {
            int dm_Ret0 = dm.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_Ret1 = dm.CmpColor(x2, y2, "ffffff", 0.9);
            int dm_Ret2 = dm.CmpColor(x3, y3, "ffffff", 0.9);
            int dm_Ret3 = dm.CmpColor(x4, y4, "ffffff", 0.9);
            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0 && dm_Ret3 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }


        }

        public int CheckBuildEquipmentS(CDmSoft dm, int area)
        {
            switch (area)
            {
                case 0:
                    {
                        //空
                        for (int x1 = 468, y1 = 241; x1 < 548; x1++)
                        {
                            if (dm.CmpColor(x1, y1, "ffffff", 1) == 0)
                            {
                                if (x1 == 547)
                                {
                                    for (x1 = 468, y1 = 242; x1 < 548; x1++)
                                    {
                                        if (dm.CmpColor(x1, y1, "ffffff", 1) == 0)
                                        {
                                            if (x1 == 547)
                                            {
                                                return 0;
                                            }
                                        }
                                    }
                                }
                            }
                            else break;
                        }
                        //完成
                        for (int x1 = 468, y1 = 241; x1 < 548; x1++)
                        {
                            if (dm.CmpColor(x1, y1, "ffffff", 1) == 0)
                            {
                                if (x1 == 547)
                                {
                                    for (x1 = 468, y1 = 242; x1 < 548; x1++)
                                    {
                                        if (dm.CmpColor(x1, y1, "ffffff", 1) != 0)
                                        {
                                            if (x1 == 547)
                                            {
                                                return 1;
                                            }
                                        }
                                    }
                                }

                            }
                            else break;
                        }

                        //建造中
                        return 2;
                    }
                case 1:
                    {
                        //空
                        for (int x1 = 468, y1 = 451; x1 < 565; x1++)
                        {
                            if (dm.CmpColor(x1, y1, "ffffff", 1) == 0)
                            {
                                if (x1 == 564)
                                {
                                    for (x1 = 468, y1 = 452; x1 < 565; x1++)
                                    {
                                        if (dm.CmpColor(x1, y1, "ffffff", 1) == 0)
                                        {
                                            if (x1 == 564)
                                            {
                                                return 0;
                                            }
                                        }
                                    }
                                }
                            }
                            else break;
                        }
                        //完成
                        for (int x1 = 468, y1 = 451; x1 < 565; x1++)
                        {
                            if (dm.CmpColor(x1, y1, "ffffff", 1) == 0)
                            {
                                if (x1 == 564)
                                {
                                    for (x1 = 468, y1 = 452; x1 < 565; x1++)
                                    {
                                        if (dm.CmpColor(x1, y1, "ffffff", 1) != 0)
                                        {
                                            if (x1 == 564)
                                            {
                                                return 1;
                                            }
                                        }
                                    }
                                }

                            }
                            else break;
                        }

                        //建造中
                        return 2;
                    }
                case 2:
                    {
                        //空

                        string Color0 = dm.GetColor(468, 661);
                        string Color1 = dm.GetColor(569, 661);
                        if (Color0 != Color1)
                        {
                            return 0;
                        }
                        //完成
                        for (int x1 = 468, y1 = 661; x1 < 644; x1++)
                        {
                            if (dm.GetColor(x1, y1) == Color0)
                            {
                                if (x1 == 643)
                                {

                                    return 1;

                                }

                            }
                            else break;
                        }

                        //建造中
                        return 2;
                    }
                default:
                    return -1;
            }


        }

        public void CheckFixBox(CDmSoft dm, ref List<int> list)
        {

            for (int x1 = 120, y1 = 291; x1 < 141; x1++, y1++)
            {
                if (dm.GetColor(x1, 309) != "ffffff")
                {
                    break;
                }
                if (dm.GetColor(140, y1) != "ffffff")
                {
                    break;
                }
                if (x1 == 140)
                {
                    list.Add(1);//第一个槽为空
                }
            }

            for (int x1 = 305, y1 = 291; x1 < 326; x1++, y1++)
            {
                if (dm.GetColor(x1, 309) != "ffffff")
                {
                    break;
                }
                if (dm.GetColor(324, y1) != "ffffff")
                {
                    break;
                }
                if (x1 == 325)
                {

                    list.Add(2);//第二个槽为空
                }
            }

            for (int x1 = 488, y1 = 291; x1 < 509; x1++, y1++)
            {
                if (dm.GetColor(x1, 309) != "ffffff")
                {
                    break;
                }
                if (dm.GetColor(509, y1) != "ffffff")
                {
                    break;
                }
                if (x1 == 508)
                {
                    list.Add(3);//第三个槽为空
                }
            }

            for (int x1 = 672, y1 = 291; x1 < 693; x1++, y1++)
            {
                if (dm.GetColor(x1, 308) != "ffffff")
                {
                    break;
                }
                if (dm.GetColor(691, y1) != "ffffff")
                {
                    break;
                }
                if (x1 == 692)
                {
                    list.Add(4);//第四个槽为空
                }
            }
            for (int x1 = 856, y1 = 291; x1 < 877; x1++, y1++)
            {
                if (dm.GetColor(x1, 308) != "ffffff")
                {
                    break;
                }
                if (dm.GetColor(876, y1) != "ffffff")
                {
                    break;
                }
                if (x1 == 856)
                {
                    list.Add(5);//第五个槽为空
                }
            }
            for (int x1 = 1039, y1 = 291; x1 < 1060; x1++, y1++)
            {
                if (dm.GetColor(x1, 309) != "ffffff")
                {
                    break;
                }
                if (dm.GetColor(1058, y1) != "ffffff")
                {
                    break;
                }
                if (x1 == 1059)
                {
                    list.Add(6);//第六个槽为空
                }
            }

            for (int x1 = 1223, y1 = 291; x1 < 1244; x1++, y1++)
            {
                if (dm.GetColor(x1, 309) != "ffffff")
                {
                    break;
                }
                if (dm.GetColor(1242, y1) != "ffffff")
                {
                    break;
                }
                if (x1 == 1243)
                {
                    list.Add(7);//第七个槽为空
                }
            }

        }

        public int CheckSelectFixGirlPage(CDmSoft dm)//检测是否在选取待修复少女的页面
        {
            //符合返回0不符合1
            int dm_ret0 = dm.CmpColor(10, 8, "ffffff", 1);
            int dm_ret1 = dm.CmpColor(131, 8, "ffffff", 1);
            int dm_ret2 = dm.CmpColor(10, 88, "ffffff", 1);
            int dm_ret3 = dm.CmpColor(130, 88, "ffffff", 1);
            if (dm_ret0 == 0 && dm_ret1 == 0 && dm_ret2 == 0 && dm_ret3 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }

        /// <summary>
        /// x1 y1 x2 y2 x3 y3 是连续颜色相同的基点,count 是连续相同像素数量的值 默认为5
        /// </summary>
        /// <param name="dm"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public bool CheckMapSet(CDmSoft dm, int x1,int y1,int x2,int y2,int x3,int y3,int count = 5)
        {
            string color1 = dm.GetColor(x1, y1);
            for(int tempx = x1; tempx <= x1 + count; tempx++)
            {
                if(dm.CmpColor(tempx, y1, color1, 1) == 1)
                {
                    return false;
                }
            }

            string color2 = dm.GetColor(x2, y2);
            for (int tempx = x2; tempx <= x2 + count; tempx++)
            {
                if (dm.CmpColor(tempx, y2, color2, 1) == 1)
                {
                    return false;
                }
            }
            string color3 = dm.GetColor(x3, y3);
            for (int tempx = x3; tempx <= x3 + count; tempx++)
            {
                if (dm.CmpColor(tempx, y3, color3, 1) == 1)
                {
                    return false;
                }
            }

            return true;
        }

        public int CheckBattleMapReady(CDmSoft dm, int x1 = 11, int y1 = 12, int x2 = 246, int y2 = 11, int x3 = 235, int y3 = 78)//检查战斗页面没有按战斗开始
        {
            int dm_Ret0 = dm.CmpColor(x1, y1, "ffffff", 1);
            int dm_Ret1 = dm.CmpColor(x2, y2, "ffffff", 1);
            int dm_Ret2 = dm.CmpColor(x3, y3, "ffffff", 1);

            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }


        }

        public bool CheckBattleResult(CDmSoft dm)
        {
            int dm_ret0 = dm.CmpColor(74, 278, "ffffff", 1);
            int dm_ret1 = dm.CmpColor(74, 333, "ffffff", 1);
            int dm_ret2 = dm.CmpColor(74, 387, "ffffff", 1);
            int dm_ret3 = dm.CmpColor(74, 431, "ffffff", 1);
            int dm_ret4 = dm.CmpColor(296, 431, "ffffff", 1);
            if (dm_ret0 == 0 && dm_ret1 == 0 && dm_ret2 == 0 && dm_ret3 == 0 & dm_ret4 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool CheckNewGunEquipmentPage(CDmSoft dm)
        {
            for (int x = 1095, y = 674; x < 1100; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
                else if (dm.CmpColor(126, 25, "ffffff", 1) == 0)
                {
                    return false;
                }

            }
            return true;
        }

        public bool CheckEquipmentStorageFull(CDmSoft dm)
        {
            int x1 = 779, y1 = 526;
            for (; x1 <= 596; x1++)
            {
                if (dm.GetColor(x1, y1) != "ffffff") return false;
            }

            x1 = 446; y1 = 525;
            for (; x1 <= 597; x1++)
            {
                if (dm.GetColor(x1, y1) != "ffffff") return false;
            }
            x1 = 446; y1 = 463;
            for (; x1 <= 610; x1++)
            {
                if (dm.GetColor(x1, y1) != "ffffff") return false;
            }
            x1 = 446; y1 = 470;
            for (; x1 <= 610; x1++)
            {
                if (dm.GetColor(x1, y1) != "ffffff") return false;
            }
            x1 = 446; y1 = 463;
            for (; y1 <= 525; y1++)
            {
                if (dm.GetColor(x1, y1) != "ffffff") return false;
            }
            x1 = 611; y1 = 463;
            for (; y1 <= 511; y1++)
            {
                if (dm.GetColor(x1, y1) != "ffffff") return false;
            }
            return true;
        }

        public int CheckRandomPointWindows(CDmSoft dm, int x1 = 439, int y1 = 165, int x2 = 523, int y2 = 182, int x3 = 523, int y3 = 165)//检查随机点窗口
        {
            int dm_Ret0 = dm.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_Ret1 = dm.CmpColor(x2, y2, "ffffff", 0.9);
            int dm_Ret2 = dm.CmpColor(x3, y3, "ffffff", 0.9);
            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int CheckActionCount(CDmSoft dm, int x1 = 1012, int y1 = 639, int x2 = 1080, int y2 = 639)
        {
            int dm_Ret0 = dm.CmpColor(x1, y1, "ffffff", 1);
            int dm_Ret1 = dm.CmpColor(x2, y2, "ffffff", 1);
            if (dm_Ret0 == 0 && dm_Ret1 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int CheckBattleEnd(CDmSoft dm, int x1 = 1049, int y1 = 637, int x2 = 1037, int y2 = 145, int x3 = 932, int y3 = 569)//检查回合开始
        {
            int dm_Ret0 = dm.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_Ret1 = dm.CmpColor(x2, y2, "ffffff", 0.9);
            int dm_Ret2 = dm.CmpColor(x3, y3, "ffffff", 0.9);
            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int CheckBattleStart(CDmSoft dm, int x1 = 849, int y1 = 184, int x2 = 1148, int y2 = 184, int x3 = 849, int y3 = 454, int x4 = 119, int y4 = 246, int x5 = 722, int y5 = 327, int x6 = 314, int y6 = 24, int x7 = 50, int y7 = 655)//检查回合开始
        {
            int dm_Ret0 = dm.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_Ret1 = dm.CmpColor(x2, y2, "ffffff", 0.9);
            int dm_Ret2 = dm.CmpColor(x3, y3, "ffffff", 0.9);
            int dm_Ret3 = dm.CmpColor(x4, y4, "ffffff", 0.9);
            int dm_Ret4 = dm.CmpColor(x5, y5, "ffffff", 0.9);
            int dm_Ret5 = dm.CmpColor(x6, y6, "ffffff", 0.9);
            int dm_Ret6 = dm.CmpColor(x7, y7, "ffffff", 0.9);
            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0 && dm_Ret3 == 0 && dm_Ret4 == 0 && dm_Ret5 == 1 && dm_Ret6 == 1)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public void CheckNormalAndAutoBattleButton(CDmSoft dm, out int NormalButtonX1, out int NormalButtonY1, out int AutoButtonX1, out int AutoButtonY1)
        {
            //300,555
            string ignoreColor0;
            string Color0;
            int NormalCount = 0;
            int AutoCount = 0;
            NormalButtonX1 = 0; NormalButtonY1 = 0; AutoButtonX1 = 0; AutoButtonY1 = 0;
            int x1 = 300, y1 = 560;

            ignoreColor0 = dm.GetColor(550, 100);



            for (x1 = 300, y1 = 560; x1 <= 1092; x1++)
            {

                Color0 = dm.GetColor(x1, y1);
                if (Color0 == ignoreColor0)
                {
                    continue;
                }
                if (dm.CmpColor(x1 + 1, y1, Color0, 1) == 0)
                {
                    //NormalCount++;
                    AutoCount++;
                    if (AutoCount == 100) { AutoButtonX1 = x1; AutoButtonY1 = y1; break; }
                    //if (NormalCount == 99) { NormalButtonX1 = x1; NormalButtonY1 = y1; NormalCount = 0; }
                }
                else
                {
                    AutoCount = 0;
                }
            }

            for (; x1 <= 1092; x1++)
            {
                Color0 = dm.GetColor(x1, y1);

                if (Color0 == ignoreColor0)
                {
                    continue;
                }

                if (dm.CmpColor(x1 + 1, y1, Color0, 1) == 0)
                {
                    NormalCount++;
                    if (NormalCount == 98) { NormalButtonX1 = x1; NormalButtonY1 = y1; break; }
                }
                else
                {
                    AutoCount = 0;
                }
            }

            //判断是否只有一个按钮 自律已经使用
            if (NormalButtonX1 == 0)
            {
                NormalButtonX1 = AutoButtonX1;
                NormalButtonY1 = AutoButtonY1;
            }



        }

        public bool CheckPointIsEmpty(CDmSoft dm, int x1, int y1, int x2, int y2, double percentage = 0.3)
        {
            List<string> colorlist = new List<string>();
            List<int> countlist = new List<int>();
            string color0;
            int count = 0, tempy = x1;

            for (tempy = y1; tempy < y2; tempy++)
            {
                for (int x = x1; x < x2; x++)
                {
                    color0 = dm.GetColor(x, tempy);
                    count = colorlist.FindIndex(s => s == color0);

                    if (count == -1)
                    {
                        colorlist.Add(color0);
                        countlist.Add(1);
                    }
                    else
                    {
                        countlist[count] += 1;
                    }
                }
            }
            count = countlist.Max();
            int sum = countlist.Sum();


            double result = (double)count / (double)sum;
            //int a = countlist.FindLastIndex(s => s == count);
            if (result > percentage)
            {
                return true;
            }
            //a是最多点的序列号 colorlist[a] 颜色
            else
            {
                return false;
            }


        }

        public bool CheckBattleSettlementPage(CDmSoft dm)
        {
            for (int x = 938, y = 455; x <= 956; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }

            for (int x = 1076, y = 455; x <= 1094; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            for (int x = 938, y = 601; x <= 956; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            for (int x = 1076, y = 601; x <= 1094; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            for (int x = 1105, y = 568; x <= 1140; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            for (int x = 1105, y = 603; x <= 1140; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }


            for (int x = 938, y = 455; y <= 473; y++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            for (int x = 939, y = 585; y <= 602; y++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            for (int x = 1093, y = 455; y <= 473; y++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            for (int x = 1094, y = 585; y <= 602; y++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            for (int x = 1140, y = 568; y <= 603; y++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }








            return true;
        }

        public bool ChckBattleDropWindow(CDmSoft dm)
        {
            for (int x = 557, y = 488; x <= 700; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckAutoBattleFinishPage(CDmSoft dm)
        {
            for (int x = 108, y = 151; x <= 155; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            for (int x = 155, y = 151; y <= 197; y++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            for (int x = 108, y = 197; x <= 155; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }

            for (int x = 108, y = 151; y <= 197; y++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }

            return true;
        }

        public int CheckHomePage(CDmSoft dm, int x1 = 1100, int y1 = 690, int x2 = 975, int y2 = 680, int x3 = 695, int y3 = 25)
        {
            if (dm.CmpColor(x1, y1, "ffffff", 0.9) == 0 && dm.CmpColor(x2, y2, "ffffff", 0.9) == 0 && dm.CmpColor(x3, y3, "ffffff", 0.9) == 0)
            {
                if (dm.CmpColor(126, 25, "ffffff", 1) == 0)
                {
                    return 1;
                }
                return 0;//相同返回0
            }
            else
            {
                return 1;
            }
        }

        public bool CheckSystemNewsPapge(CDmSoft dm)
        {
            int x1 = 67, y1 = 20;
            for (; x1 <= 165; x1++)
            {
                if (dm.GetColor(x1, y1) != "ffffff") return false;
            }

            x1 = 360; y1 = 85;
            for (; x1 <= 1197; x1++)
            {
                if (dm.GetColor(x1, y1) != "ffffff") return false;
            }
            return true;
        }

        public bool CheckSystemRewardSupportPage(CDmSoft dm)
        {
            int x1 = 557, y1 = 488;
            for (; x1 <= 722; x1++)
            {
                if (dm.GetColor(x1, y1) != "ffffff") return false;
            }

            x1 = 557; y1 = 496;
            for (; x1 <= 722; x1++)
            {
                if (dm.GetColor(x1, y1) != "ffffff") return false;
            }
            return true;



        }

        public bool CheckSystemActivistPage(CDmSoft dm)
        {
            int x1 = 19, y1 = 39;
            for (; x1 <= 117; x1++)
            {
                if (dm.GetColor(x1, y1) != "ffffff") return false;
            }

            x1 = 33; y1 = 106;
            for (; x1 <= 327; x1++)
            {
                if (dm.GetColor(x1, y1) != "ffffff") return false;
            }
            x1 = 338; y1 = 106;
            for (; x1 <= 1246; x1++)
            {
                if (dm.GetColor(x1, y1) != "ffffff") return false;
            }
            return true;
        }

        public bool CheckNewAchievement(CDmSoft dm)
        {
            int x1 = 557, y1 = 488;
            for (; x1 <= 721; x1++)
            {
                if (dm.GetColor(x1, y1) != "ffffff") return false;
            }

            x1 = 557; y1 = 490;
            for (; x1 <= 721; x1++)
            {
                if (dm.GetColor(x1, y1) != "ffffff") return false;
            }
            x1 = 557; y1 = 496;
            for (; x1 <= 721; x1++)
            {
                if (dm.GetColor(x1, y1) != "ffffff") return false;
            }
            return true;

        }

        public int CheckBattlePage(CDmSoft dm, int x1 = 986, int y1 = 30, int x2 = 5, int y2 = 94, int x3 = 138, int y3 = 94, int x4 = 138, int y4 = 1)
        {
            int dm_Ret0 = dm.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_Ret1 = dm.CmpColor(x2, y2, "ffffff", 0.9);
            int dm_Ret2 = dm.CmpColor(x3, y3, "ffffff", 0.9);
            int dm_Ret3 = dm.CmpColor(x3, y3, "ffffff", 0.9);

            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0 && dm_Ret3 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int CheckFixPage(CDmSoft dm, int x1 = 204, int y1 = 63, int x2 = 138, int y2 = 1, int x3 = 5, int y3 = 94)//检测修复页面
        {
            int dm_Ret0 = dm.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_Ret1 = dm.CmpColor(x2, y2, "ffffff", 0.9);
            int dm_Ret2 = dm.CmpColor(x3, y3, "ffffff", 0.9);

            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int CheckActivityBattlePage(CDmSoft dm, int x1 = 135, int y1 = 94, int x2 = 135, int y2 = 1)
        {
            int dm_Ret0 = dm.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_Ret1 = dm.CmpColor(x2, y2, "ffffff", 0.9);

            if (dm_Ret0 == 0 && dm_Ret1 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int CheckBattleDifficultyType(CDmSoft dm)
        {
            int x1 = 940, y1 = 151;
            for (; x1 <= 1043; x1++)
            {
                if (dm.GetColor(x1, y1) != "000000")
                {
                    break;
                }
                if (x1 == 1043)
                {
                    return 0;
                }
            }

            x1 = 1055;
            for (; x1 <= 1157; x1++)
            {
                if (dm.GetColor(x1, y1) != "000000")
                {
                    break;
                }
                if (x1 == 1157)
                {
                    return 1;
                }
            }

            x1 = 1168;
            for (; x1 <= 1272; x1++)
            {
                if (dm.GetColor(x1, y1) != "000000")
                {
                    break;
                }
                if (x1 == 1272)
                {
                    return 2;
                }
            }


            return -1;
        }

        public int CheckMissionSettingPage(CDmSoft dm, int x1 = 180, int y1 = 64, int x2 = 542, int y2 = 79, int x3 = 195, int y3 = 134)
        {
            int dm_Ret0 = dm.CmpColor(x1, y1, "ffffff", 1);
            int dm_Ret1 = dm.CmpColor(x2, y2, "ffffff", 1);
            int dm_Ret2 = dm.CmpColor(x3, y3, "ffffff", 1);


            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int CheckActivityChoicePage(CDmSoft dm, int x1 = 63, int y1 = 445, int x2 = 134, int y2 = 482, int x3 = 191, int y3 = 481)//魔方行动
        {
            int dm_Ret0 = dm.CmpColor(x1, y1, "ffffff", 0.9);
            int dm_Ret1 = dm.CmpColor(x2, y2, "ffffff", 0.9);
            int dm_Ret2 = dm.CmpColor(x3, y3, "ffffff", 0.9);


            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }


        }

        public int CcheckActivityPageReady(CDmSoft dm, int x1 = 200, int y1 = 50, int x2 = 20, int y2 = 675, int x3 = 33, int y3 = 675)//检查魔方行动4个战役加载完毕
        {
            int dm_Ret0 = dm.CmpColor(x1, y1, "ffffff", 1);
            int dm_Ret1 = dm.CmpColor(x2, y2, "ffffff", 1);
            int dm_Ret2 = dm.CmpColor(x3, y3, "ffffff", 1);


            if (dm_Ret0 == 0 && dm_Ret1 == 0 && dm_Ret2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }


        }

        public bool CheckMyDormitory(CDmSoft dm)//检测是否在宿舍页面
        {
            //符合返回0不符合1
            for (int x = 151, y = 13; x <= 354; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }

            }
            return true;
        }

        public bool CheckFriendsListPage(CDmSoft dm)//检测是否在好友列表页面
        {
            //符合返回0不符合1
            for (int x = 199, y = 40; x <= 400; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }

            }
            return true;
        }

        public int CheckVisitFriendsTapge(CDmSoft dm)//检测我的好友我的访客我的拜访3个页面
        {
            string color0 = dm.GetColor(135, 130);
            string color1 = dm.GetColor(290, 130);
            string color2 = dm.GetColor(440, 130);
            if (color0 == color1) { return 2; }
            if (color0 == color2) { return 1; }
            return 0;
        }

        public int CheckMyFriendDormitory(CDmSoft dm)//检测是否打开好友宿舍
        {

            for (int x = 1256, y = 54; y <= 74; y++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return -1;//检测左上角
                }

            }

            for (int x = 1140, y = 650; x <= 1260; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return 0;//通过左上角检测右下角 0 没有右下角
                }

            }

            return 1;//左上右下都有
        }

        public bool CheckFriendDormitoryBattery(CDmSoft dm)
        {
            if (dm.CmpColor(420, 459, "ffffff", 1) == 1)
            {
                return false;
            }

            if (dm.CmpColor(419, 460, "ffffff", 1) == 1)
            {
                return false;
            }
            if (dm.CmpColor(418, 462, "ffffff", 1) == 1)
            {
                return false;
            }
            if (dm.CmpColor(371, 404, "ffffff", 1) == 1)
            {
                return false;
            }
            if (dm.CmpColor(368, 404, "ffffff", 1) == 1)
            {
                return false;
            }
            if (dm.CmpColor(365, 408, "ffffff", 1) == 1)
            {
                return false;
            }
            if (dm.CmpColor(363, 410, "ffffff", 1) == 1)
            {
                return false;
            }
            if (dm.CmpColor(362, 411, "ffffff", 1) == 1)
            {
                return false;
            }
            return true;

        }

        public bool CheckDormitoryBatteryWindow(CDmSoft dm)
        {
            for (int x = 559, y = 487; x <= 719; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            return true;


        }

        public int CheckFriendsPointReward(CDmSoft dm)//检测是否接收友情点数奖励或者本日次数已用完
        {
            //符合返回0不符合1

            for (int x = 557, y = 488; x <= 722; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 0)
                {
                    if (x == 722) { return 0; }//获得友情点数可以继续
                }
                else { break; }

            }

            for (int x = 529, y = 369; x <= 549; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 0)
                {
                    if (x == 549) { return 1; }//本日友情点数以获取不用继续
                }
                else { break; }

            }
            return -1;//都不是需要重来
        }

        public bool CheckResearchPageReady(CDmSoft dm)
        {
            for (int x = 50, y = 215; x <= 180; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                    return false;
            }
            return true;
        }

        public bool CheckEquipmentSelectPageReady(CDmSoft dm)
        {
            for (int x = 300, y = 380; x <= 345; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            for (int x = 320, y = 360; y <= 405; y++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckSelectOneEquipmentPageReady(CDmSoft dm)
        {
            for (int x = 1099, y = 242; x <= 1266; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckEquipmentTabPageReady(CDmSoft dm)
        {
            for (int x = 530, y = 115; x <= 680; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }

            for (int x = 710, y = 115; x <= 520; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }

            for (int x = 890, y = 115; x <= 1035; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckEquipmentSelectdReady(CDmSoft dm, int i)
        {
            switch (i)
            {
                case 0:
                    {
                        if (dm.CmpColor(600, 125, "ffffff", 1) == 1)
                        {
                            return true;
                        }
                        return false;
                    }
                case 1:
                    {
                        if (dm.CmpColor(800, 130, "ffffff", 1) == 1)
                        {
                            return true;
                        }
                        return false;
                    }
                case 2:
                    {
                        if (dm.CmpColor(1000, 130, "ffffff", 1) == 1)
                        {
                            return true;
                        }
                        return false;
                    }
                case 3:
                    {
                        if (dm.CmpColor(600, 200, "ffffff", 1) == 1)
                        {
                            return true;
                        }
                        return false;
                    }
                case 4:
                    {
                        if (dm.CmpColor(800, 200, "ffffff", 1) == 1)
                        {
                            return true;
                        }
                        return false;
                    }
                case 5:
                    {
                        if (dm.CmpColor(1000, 200, "ffffff", 1) == 1)
                        {
                            return true;
                        }
                        return false;
                    }
                case 6:
                    {
                        if (dm.CmpColor(600, 310, "ffffff", 1) == 1)
                        {
                            return true;
                        }
                        return false;
                    }
                case 7:
                    {
                        if (dm.CmpColor(800, 310, "ffffff", 1) == 1)
                        {
                            return true;
                        }
                        return false;
                    }
                case 8:
                    {
                        if (dm.CmpColor(1000, 310, "ffffff", 1) == 1)
                        {
                            return true;
                        }
                        return false;
                    }
                case 9:
                    {
                        if (dm.CmpColor(600, 400, "ffffff", 1) == 1)
                        {
                            return true;
                        }
                        return false;
                    }
                case 10:
                    {
                        if (dm.CmpColor(600, 510, "ffffff", 1) == 1)
                        {
                            return true;
                        }
                        return false;
                    }
                case 11:
                    {
                        if (dm.CmpColor(800, 510, "ffffff", 1) == 1)
                        {
                            return true;
                        }
                        return false;
                    }
                case 12:
                    {
                        if (dm.CmpColor(1000, 510, "ffffff", 1) == 1)
                        {
                            return true;
                        }
                        return false;
                    }
                case 13:
                    {
                        if (dm.CmpColor(600, 600, "ffffff", 1) == 1)
                        {
                            return true;
                        }
                        return false;
                    }
                case 14:
                    {
                        if (dm.CmpColor(800, 600, "ffffff", 1) == 1)
                        {
                            return true;
                        }
                        return false;
                    }
                default:
                    break;
            }
            return false;
        }

        public bool CheckEquipmentTabReadyClose(CDmSoft dm)
        {
            string color0 = dm.GetColor(530, 120);
            for (int x = 530, y = 120; x <= 680; x++)
            {
                if (dm.CmpColor(x, y, color0, 1) == 1)
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckEquipmentLock(CDmSoft dm)
        {

            for (int x = 1099, y = 242; x <= 1265; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckEquipmentReadyToUpdate(CDmSoft dm)
        {
            for (int x = 485, y = 202; x <= 505; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }

            for (int x = 516, y = 202; x <= 537; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckEquipmentUpdateWarningWindows(CDmSoft dm)
        {

            for (int x = 446, y = 463; x <= 611; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckEquipment2Start(CDmSoft dm)
        {
            for (int x = 1095, y = 341; x <= 1140; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckEquipmentConfirmButton(CDmSoft dm)
        {
            for (int x = 1070, y = 530; x <= 1220; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckEquipmentSelected(CDmSoft dm)
        {
            object intX, intY;
            if (dm.FindColor(1116, 410, 1251, 442, "ffffff", 1, 0, out intX, out intY) == 1)
            {
                return true;
            }
            return false;
        }

        public bool CheckEquipmentUpdate50MaxCount(CDmSoft dm)
        {
            for (int x = 560, y = 490; x <= 720; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            return true;


        }

        public bool CheckWhiteM(CDmSoft dm)//检测屏幕是否白屏
        {
            for (int x = 1, y = 1; y < 720; y++)
            {
                for (; x < 1280; x++)
                {
                    if (dm.CmpColor(x, y, "ffffff", 0.9) == 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckInternetTransfer(CDmSoft dm)
        {

            int x1, y1;
            int dm_ret = 0;
            for (x1 = 1160, y1 = 574; y1 <= 639; y1++)
            {
                for (x1 = 1160; x1 <= 1185; x1++)
                {
                    if (dm.CmpColor(x1, y1, "ffffff", 1) == 0)
                    {
                        dm_ret = dm_ret + 1;
                    }
                }
            }
            if (dm_ret >= 90 && dm_ret <= 300)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckDormitoryLoad(CDmSoft dm)//等待宿舍加载完毕，检查右上方的名字
        {
            while (dm.FindColor(900, 15, 1065, 50, "ffffff", 0.9, 0, out object intX, out object intY) == 1)
            {
                return true;
            }

            return false;
        }

        public bool CheckFormationPage(CDmSoft dm)
        {
            for (int x = 1083, y = 540; x <= 1141; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            for (int x = 1141, y = 540; y <= 596; y++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckFormationPostionPresetPage(CDmSoft dm)
        {
            for (int x = 900, y = 590; x <= 1060; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckFormationTeamPresetSelect(CDmSoft dm)
        {
            for (int x = 900, y = 590; x <= 990; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckFormationWindowINFO(CDmSoft dm)
        {
            for (int x = 375, y = 470; x <= 535; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckBattleWithDrawButton(CDmSoft dm)
        {
            for (int x = 106, y = 165; x <= 124; x++)
            {
                if (dm.CmpColor(x, y, "ffffff", 1) == 1)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckDormitoryMLeft(CDmSoft dm)//检测屏幕是否白屏
        {
            for (int x = 1, y = 1; x < 50; x++)
            {
                if (dm.CmpColor(x, y, "000000", 1) == 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
