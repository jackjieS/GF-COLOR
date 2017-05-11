using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.events
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



    }
}
