using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using WindowsFormsApplication1;
using System.Windows.Forms;

namespace WindowsFormsApplication1.BaseData
{
    class ConfigNode
    {
        public string key;
        public string value;

        public ConfigNode(string key, string value)
        {
            this.key = key;
            this.value = value;
        }

        public override string ToString()
        {
            return this.value;
        }
    }
    class ConfigManager
    {


        public static string fileName;

        private InstanceManager im;
        public Dictionary<int, ConfigNode> config;
        private int maxline = 0;

        public ConfigManager(InstanceManager im)
        {
            fileName = (string)WindowsFormsApplication1.Properties.Settings.Default["ConfigFile"];
            this.im = im;
            this.config = new Dictionary<int, ConfigNode>();
            //im.logger.Log(fileName);
        }

        public bool Load()
        {
            if (String.IsNullOrEmpty(fileName) || !File.Exists(fileName)) return false;
            
            string[] con = File.ReadAllLines(fileName,System.Text.Encoding.UTF8);

            try
            {
                int linenum = 0;
                foreach (string line in con)
                {

                    if (String.IsNullOrEmpty(line) || line[0] == '#') continue;//注释
                    string[] c = line.Split('=');
                    config.Add(linenum, new ConfigNode(c[0].Trim(), c[1].Trim()));
                    ++linenum;
                }

                maxline = con.Length;
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(string.Format("配置文件加载失败: " + e.Message));
                return false;
            }

        }

        public void Save()//添加新节点后保存
        {
            try
            {
                var configfile = File.ReadAllLines(fileName, System.Text.Encoding.UTF8);//旧的
                string[] newconfigfile = new string[maxline];//新的 maxline 总长包括#

                for (int i = 0; i < configfile.Length; ++i)
                    newconfigfile[i] = configfile[i];//复制到新的
                for (int i = 0,key = 0 ; i < configfile.Length; i++)
                {
                    if (newconfigfile[i].IndexOf("#") != -1) { continue; }

                    else
                    {
                        newconfigfile[i] = String.Format("{0}={1}", config[key].key, config[key].value);key++;
                    }
                }

                File.WriteAllLines(fileName, newconfigfile);
            }
            catch(Exception e)
            {
                MessageBox.Show(string.Format("配置文件保存失败: " + e.Message));
            }
        }

        private ConfigNode findConfig(string key)
        {
            foreach(var i in config)
                if (i.Value.key == key) return i.Value;

            throw new KeyNotFoundException();
        }

        public void SetConfig(string key, object value)//添加新节点
        {
            try
            {
                var i = findConfig(key);
                i.value = value.ToString();
            }
            catch(KeyNotFoundException)
            {
                ConfigNode cn = new ConfigNode(key, value.ToString());
                this.config.Add(maxline++, cn);
            }

            this.Save();
        }

        public string getConfigString(string key)
        {
            try
            {
                return findConfig(key).ToString();
            }
            catch(KeyNotFoundException)
            {
                return String.Empty;
            }
        }
        public bool setConfigString(string key,string value)
        {
            try
            {
                for(int i = 0; i < config.Count; i++)
                {
                    if (config[i].key == key)
                    {
                        config[i].value = value.ToString();
                        return true;
                    }
               }
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
            return false;
        }
        public bool getConfigBool(string key)
        {
            try
            {
                return findConfig(key).ToString() == "true";
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }
        public bool setConfigBool(string key, bool value)
        {
            try
            {
                for (int i = 0; i < config.Count; i++)
                {
                    if (config[i].value == key)
                    {
                        config[i].value = value.ToString();
                        return true;
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
            return false;
        }

        public int getConfigInt(string key)
        {
            try
            {
                return Convert.ToInt32(findConfig(key).ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public bool setConfigInt(string key, int value)
        {
            try
            {
                for (int i = 0; i < config.Count; i++)
                {
                    if (config[i].key == key)
                    {
                        config[i].value = value.ToString();
                        return true;
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
            return false;
        }
        public double getConfigDouble(string key)
        {
            try
            {
                return Convert.ToDouble(findConfig(key).ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public bool setConfigDouble(string key, double value)
        {
            try
            {
                for (int i = 0; i < config.Count; i++)
                {
                    if (config[i].key == key)
                    {
                        config[i].value = value.ToString();
                        return true;
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
            return false;
        }
        public bool readConfig()
        {
            try
            {
                if (!this.im.configManager.Load())
                {
                    MessageBox.Show("配置文件加载失败！");
                    CommonHelp.DownloadUIcfg();
                    Environment.Exit(0);
                }
                
                SystemInfo.UIcfg = this.im.configManager.getConfigDouble("UIcfg");
                if (SystemInfo.UIcfg < 0.13)
                {
                    MessageBox.Show(string.Format("开始下载UIconfig"));
                    string URLAddress = @"http://45.78.2.254/GF/UIconfig.cfg";
                    try
                    {

                        CommonHelp.client.DownloadFile(URLAddress, "UIconfig.cfg");
                    }
                    catch (Exception a)
                    {
                        MessageBox.Show(string.Format("下载UIconfig发生错误 : {0}", a.ToString()));

                    }
                    MessageBox.Show(string.Format("UIconfig下载完毕"));
                }

                SystemInfo.BattleMap = this.im.configManager.getConfigString("BattleMap");
                SystemInfo.MainTeam = this.im.configManager.getConfigString("MainTeam");
                SystemInfo.SupportTeam = this.im.configManager.getConfigString("SupportTeam");
                SystemInfo.Fix = this.im.configManager.getConfigBool("Fix");
                SystemInfo.Fixmaxtime = this.im.configManager.getConfigInt("Fixmaxtime");
                SystemInfo.Fixmintime = this.im.configManager.getConfigInt("Fixmintime");
                SystemInfo.ResolutionRatio = this.im.configManager.getConfigString("ResolutionRatio");
                SystemInfo.DebugMode = this.im.configManager.getConfigBool("DebugMode");
                SystemInfo.WaitTime = this.im.configManager.getConfigDouble("WaitTime");
                SystemInfo.Supply = this.im.configManager.getConfigBool("Supply");
                SystemInfo.AutoTeam1 = this.im.configManager.getConfigString("AutoTeam1");
                SystemInfo.AutoTeam2 = this.im.configManager.getConfigString("AutoTeam2");
                SystemInfo.AutoTeam3 = this.im.configManager.getConfigString("AutoTeam3");
                SystemInfo.AutoTeam4 = this.im.configManager.getConfigString("AutoTeam4");
                SystemInfo.AutoMap = this.im.configManager.getConfigString("AutoMap");
                SystemInfo.RoundInterval = this.im.configManager.getConfigInt("RoundInterval");
                SystemInfo.BattleLoopUnLockWindows = this.im.configManager.getConfigBool("BattleLoopUnLockWindows");
                SystemInfo.BattleSupport_plus = this.im.configManager.getConfigBool("BattleSupport_plus");
                SystemInfo.SetMap = this.im.configManager.getConfigBool("SetMap");
                SystemInfo.FixMinPercentage = this.im.configManager.getConfigInt("FixMinPercentage");
                SystemInfo.FixMaxPercentage = this.im.configManager.getConfigInt("FixMaxPercentage");
                SystemInfo.FixType = this.im.configManager.getConfigInt("FixType");
                SystemInfo.Team_SerrorTime = this.im.configManager.getConfigInt("Team_SerrorTime");
                SystemInfo.EquipmentUpdateType = this.im.configManager.getConfigString("EquipmentUpdateType");
                SystemInfo.EquipmentUpdatePostion = this.im.configManager.getConfigString("EquipmentUpdatePostion");
                SystemInfo.EquipmentUpdateCount = this.im.configManager.getConfigInt("EquipmentUpdateCount");
                SystemInfo.LogisticsTask1 = this.im.configManager.getConfigString("LogisticsTask1");
                SystemInfo.LogisticsTask2 = this.im.configManager.getConfigString("LogisticsTask2");
                SystemInfo.LogisticsTask3 = this.im.configManager.getConfigString("LogisticsTask3");
                SystemInfo.LogisticsTask4 = this.im.configManager.getConfigString("LogisticsTask4");
                //SystemInfo.LogisticFinishWaittingTime = this.im.configManager.getConfigInt("LogisticFinishWaittingTime");
                SystemInfo.Simulator = this.im.configManager.getConfigInt("Simulator");
                SystemInfo.BindWindowsType = this.im.configManager.getConfigInt("BindWindowsType");
                SystemInfo.LockWindows = this.im.configManager.getConfigBool("LockWindows");
                SystemInfo.FindTeamSlectStrSim = this.im.configManager.getConfigDouble("FindTeamSlectStrSim");
                SystemInfo.FindTeamSlectStrColorOffset = this.im.configManager.getConfigInt("FindTeamSlectStrColorOffset");
                SystemInfo.BattleMissionSlectStrSim = this.im.configManager.getConfigDouble("BattleMissionSlectStrSim");
                SystemInfo.BattleMissionSlectStrColorOffset = this.im.configManager.getConfigInt("BattleMissionSlectStrColorOffset");
                SystemInfo.SetMapType = this.im.configManager.getConfigInt("SetMapType");
                SystemInfo.SimulatorCheckTime = this.im.configManager.getConfigInt("SimulatorCheckTime");
                SystemInfo.Time12AddGetFriendBattery = this.im.configManager.getConfigBool("Time12AddGetFriendBattery");
                SystemInfo.Time3AddGetFriendBattery = this.im.configManager.getConfigBool("Time3AddGetFriendBattery");
                SystemInfo.GetFriendBatterySecondLoop = this.im.configManager.getConfigBool("GetFriendBatterySecondLoop");
                SystemInfo.GetFriendBatteryCapt = this.im.configManager.getConfigBool("GetFriendBatteryCapt");
                SystemInfo.GetFriendBattleryDelayM = this.im.configManager.getConfigInt("GetFriendBattleryDelayM");
                SystemInfo.GetFriendBattleryDelayH = this.im.configManager.getConfigInt("GetFriendBattleryDelayH");





            }
            catch (Exception e)
            {
                //im.logger.Log(e);
                MessageBox.Show("配置读取失败！错误原因: " + e.ToString());
                return false;
            }


            return true;
        }

        public bool saveConfig()
        {
            try
            {

                this.im.configManager.setConfigDouble("UIcfg", SystemInfo.UIcfg);
                this.im.configManager.setConfigString("BattleMap", SystemInfo.BattleMap);
                this.im.configManager.setConfigString("MainTeam", SystemInfo.MainTeam);
                this.im.configManager.setConfigString("SupportTeam", SystemInfo.SupportTeam);
                this.im.configManager.setConfigBool("Fix", SystemInfo.Fix);
                this.im.configManager.setConfigInt("Fixmaxtime", SystemInfo.Fixmaxtime);
                this.im.configManager.setConfigInt("Fixmintime", SystemInfo.Fixmintime);
                this.im.configManager.setConfigString("ResolutionRatio", SystemInfo.ResolutionRatio);
                this.im.configManager.setConfigBool("DebugMode", SystemInfo.DebugMode);
                this.im.configManager.setConfigDouble("WaitTime", SystemInfo.WaitTime);
                this.im.configManager.setConfigBool("Supply", SystemInfo.Supply);
                this.im.configManager.setConfigString("AutoTeam1", SystemInfo.AutoTeam1);
                this.im.configManager.setConfigString("AutoTeam2", SystemInfo.AutoTeam2);
                this.im.configManager.setConfigString("AutoTeam3", SystemInfo.AutoTeam3);
                this.im.configManager.setConfigString("AutoTeam4", SystemInfo.AutoTeam4);
                this.im.configManager.setConfigString("AutoMap", SystemInfo.AutoMap);
                this.im.configManager.setConfigInt("RoundInterval", SystemInfo.RoundInterval);
                this.im.configManager.setConfigBool("BattleLoopUnLockWindows", SystemInfo.BattleLoopUnLockWindows);
                this.im.configManager.setConfigBool("BattleSupport_plus", SystemInfo.BattleSupport_plus);
                this.im.configManager.setConfigBool("SetMap", SystemInfo.SetMap);
                this.im.configManager.setConfigInt("FixMinPercentage", SystemInfo.FixMinPercentage);
                this.im.configManager.setConfigInt("FixMaxPercentage", SystemInfo.FixMaxPercentage);
                this.im.configManager.setConfigInt("FixType", SystemInfo.FixType);
                this.im.configManager.setConfigInt("Team_SerrorTime", SystemInfo.Team_SerrorTime);
                this.im.configManager.setConfigString("EquipmentUpdateType", SystemInfo.EquipmentUpdateType);
                this.im.configManager.setConfigString("EquipmentUpdatePostion", SystemInfo.EquipmentUpdatePostion);
                this.im.configManager.setConfigInt("EquipmentUpdateCount", SystemInfo.EquipmentUpdateCount);
                this.im.configManager.setConfigString("LogisticsTask1", SystemInfo.LogisticsTask1);
                this.im.configManager.setConfigString("LogisticsTask2", SystemInfo.LogisticsTask2);
                this.im.configManager.setConfigString("LogisticsTask3", SystemInfo.LogisticsTask3);
                this.im.configManager.setConfigString("LogisticsTask4", SystemInfo.LogisticsTask4);
                this.im.configManager.setConfigInt("LogisticFinishWaittingTime", SystemInfo.LogisticFinishWaittingTime);
                this.im.configManager.setConfigInt("Simulator", SystemInfo.Simulator);
                this.im.configManager.setConfigInt("BindWindowsType", SystemInfo.BindWindowsType);
                this.im.configManager.setConfigBool("LockWindows", SystemInfo.LockWindows);
                this.im.configManager.setConfigDouble("FindTeamSlectStrSim", SystemInfo.FindTeamSlectStrSim);
                this.im.configManager.setConfigInt("FindTeamSlectStrColorOffset", SystemInfo.FindTeamSlectStrColorOffset);
                this.im.configManager.setConfigDouble("BattleMissionSlectStrSim", SystemInfo.BattleMissionSlectStrSim);
                this.im.configManager.setConfigInt("BattleMissionSlectStrColorOffset", SystemInfo.BattleMissionSlectStrColorOffset);
                this.im.configManager.setConfigInt("SetMapType", SystemInfo.SetMapType);
                this.im.configManager.setConfigInt("SimulatorCheckTime", SystemInfo.SimulatorCheckTime);
                this.im.configManager.setConfigBool("Time12AddGetFriendBattery", SystemInfo.Time12AddGetFriendBattery);
                this.im.configManager.setConfigBool("Time3AddGetFriendBattery", SystemInfo.Time3AddGetFriendBattery);
                this.im.configManager.setConfigBool("GetFriendBatterySecondLoop", SystemInfo.GetFriendBatterySecondLoop);
                this.im.configManager.setConfigBool("GetFriendBatteryCapt", SystemInfo.GetFriendBatteryCapt);
                this.im.configManager.setConfigInt("GetFriendBattleryDelayM", SystemInfo.GetFriendBattleryDelayM);
                this.im.configManager.setConfigInt("GetFriendBattleryDelayH", SystemInfo.GetFriendBattleryDelayH);





            }
            catch (Exception e)
            {
                //im.logger.Log(e);
                MessageBox.Show("配置读取失败！错误原因: " + e.ToString());
                return false;
            }


            this.Save();
            return true;
        }
    }
}
