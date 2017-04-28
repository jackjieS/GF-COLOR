using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.BaseData;

namespace WindowsFormsApplication1
{
    class GameeData
    {
        private InstanceManager im;
        public GameeData(InstanceManager im)
        {
            this.im = im;
        }

        public Dictionary<int, UserBattleInfo> User_battleInfo = new Dictionary<int, UserBattleInfo>();
        public Dictionary<int, UserAutoBattleInfo> User_AutobattleInfo = new Dictionary<int, UserAutoBattleInfo>();
        public Dictionary<int, UserOperationInfo> User_operationInfo = new Dictionary<int, UserOperationInfo>();
        public Dictionary<int, BuildingEquipmentInfo> User_BuildingEquipmentInfo = new Dictionary<int, BuildingEquipmentInfo>();
        public Dictionary<int, BuildingGunInfo> User_BuildingGunInfo = new Dictionary<int, BuildingGunInfo>();

        public bool GetOperationTime_60s()
        {
            foreach (var item in im.gameData.User_operationInfo)
            {
                if(item.Value.OperationUsingState == true)
                {
                    if (item.Value.OperationNeedTowait == true)
                    {
                        if (item.Value.Added == false)
                            return true;
                    }
                }


            }

            return false;
        }


    }
        class UserData
        {
            private InstanceManager im;
            public UserData(InstanceManager im)
            {
                this.im = im;
            }
        public int DismantlementGunCount = 0;
        public int BattleFixNumber;
        public bool NeedToFix = false;
    }


    }

