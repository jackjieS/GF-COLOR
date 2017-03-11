using testdm;
namespace WindowsFormsApplication1
{
    class GetSetColor
    {
        public void GetHomeColor(CDmSoft dm,string color0,string color1,string color2)
        {
            color0 = dm.GetColor(40, 85);
            color1 = dm.GetColor(900, 35);
            color2 = dm.GetColor(85, 590);
        }

        public void GetBattleColor(CDmSoft dm,string color0)
        {
            color0 = dm.GetColor(1030, 110); //紧急任务
        }
        public void GetFightType(CDmSoft dm,string color0,string color1)
        {
            color0 = dm.GetColor(608, 546);//绿色
            color1 = dm.GetColor(806, 546);//黄色
        }

        public void GetBattleDCoLor(CDmSoft dm,string color0)
        {
            color0 = dm.GetColor(285, 40);//橙色 用于判断是否战斗过程
        }

    }
}
