using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Events
{
    class Equipment
    {
        private InstanceManager im;
        public Equipment(InstanceManager im)
        {
            this.im = im;
        }

        public void EquipmentUpdate(DmAe dmae,int equipmentType,int equipmentPostion,int equipmentcount)
        {
            //点击研发按钮
            im.mouse.ClickHomeResearch(dmae);

            //点击装备强化
            im.mouse.ClickEquipmentStrengthen(dmae);
            //选择装备
            im.mouse.ClickEquipmentSelect(dmae);

            //打开装备类型面板
            im.mouse.ClickEquipmentTab(dmae);
            //选择装备类型
            im.mouse.ClickEquipmentType(dmae, equipmentType);
            //关闭装备面板
            im.mouse.ClickEquipmentTabToClose(dmae);
            //点击添加
            im.mouse.ClickEquipmentToUpdate(dmae, equipmentPostion);
            //点击强化按钮 加号
            //im.mouse.ClickEquipmentADDButton(dmae);
            //点击所有2星装备
            im.mouse.ClickAll2Start(dmae, equipmentcount);
            //点击确定
            //im.mouse.ClickEquipmentConfirm(dmae);
            //点击确定强化
            im.mouse.ClickEquipmentUpdateConfirmButton(dmae);
            //点击返回基地
            im.mouse.LeftClickBackHome(dmae);
        }


    }
}
