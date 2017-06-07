using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testdm;

namespace WindowsFormsApplication1.Events
{
    class Formation
    {
        //编程
        private InstanceManager im;
        public Formation(InstanceManager im)
        {
            this.im = im;
        }



        public void TeamFormationChangeToFighter(DmAe dmae,string mainteam, int x)
        {
            im.mouse.ClickTeam(dmae);
            im.time.Team_S(dmae, im.mouse, mainteam, 1);

            im.mouse.ClickFormationTeamPresetButton(dmae);//编队页面下点击编队预设按钮

            im.mouse.ClickFormationPostionPreset(dmae);//阵型页面下点击梯队预设

            im.mouse.ClickFormationTeamPresetTeam(dmae,x);//点击预设梯队

            im.mouse.ClickFormationTeamUsePresets(dmae);//点击套用梯队

            im.mouse.ClickFormationChangeWindowINFO(dmae);//处理警告窗口

            im.mouse.ClickFormationSelectedFinishButton(dmae);//点击确定

            im.mouse.LeftClickBackHome(dmae);//回首页
        }

        public void TeamFormationFighterSupport(DmAe dmae,Mouse mouse, ref BaseData.UserBattleInfo userbattleinfo)
        {
            im.time.ChoseThebattle(dmae, mouse, ref userbattleinfo);
        }

        public void TeamFormationChange(DmAe dmae, Mouse mouse, ref BaseData.UserBattleInfo userbattleinfo)
        {

            //单独补给

            //换成打手编队
            TeamFormationChangeToFighter(dmae,userbattleinfo.TaskMianTeam, 1);
            //进图补给
            TeamFormationFighterSupport(dmae, mouse, ref userbattleinfo);
            //换成完整梯队
            TeamFormationChangeToFighter(dmae, userbattleinfo.TaskMianTeam, 2);
            //over

        }










    }
}
