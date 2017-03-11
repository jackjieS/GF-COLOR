using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.BaseData
{
    public class FixGirlsInfo
    {
        public int Location;
        public int Hp;
        public string Color = "";//点击之前的颜色于点击后比较确认是否点击成功
        public bool NeedToFix = false;
        public bool NeedNFix = true;
        public bool NeedQFix = false;

        public void CheckNeedQfix(UserBattleInfo userBattleInfo)
        {
            if ((this.Hp <= userBattleInfo.FixMinPercentage) && userBattleInfo.FixMinPercentage != 0)
            {
                //快修
                this.NeedToFix = true;
                this.NeedNFix = false;
                this.NeedQFix = true;
                return;
            }
            if ((this.Hp >= userBattleInfo.FixMaxPercentage) && userBattleInfo.FixMaxPercentage != 0)
            {
                this.NeedToFix = false;
                this.NeedNFix = false;
                this.NeedQFix = false;
                return;
            }
            if (userBattleInfo.FixMinPercentage == 0 && (this.Hp < userBattleInfo.FixMaxPercentage))
            {
                //点击普通维修
                this.NeedToFix = true;
                this.NeedNFix = true;
                this.NeedQFix = false;
                return;
            }
            if (userBattleInfo.FixMinPercentage == 0 && userBattleInfo.FixMaxPercentage == 0)
            {
                //点击普通维修
                this.NeedToFix = true;
                this.NeedNFix = true;
                this.NeedQFix = false;
                return;
            }
            if (this.Hp < userBattleInfo.FixMinPercentage)
            {
                //快修
                this.NeedToFix = true;
                this.NeedNFix = false;
                this.NeedQFix = true;
                return;
            }
            if (this.Hp > userBattleInfo.FixMinPercentage && userBattleInfo.FixMaxPercentage == 0)
            {
                //点击普通维修
                this.NeedToFix = true;
                this.NeedNFix = true;
                this.NeedQFix = false;
                return;
            }
        }



    }
}
