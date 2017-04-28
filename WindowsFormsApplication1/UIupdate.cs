using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    
    class UIupdate
    {
        private InstanceManager im;
        delegate void SetTextCallback(string name, string text);//委托 
        public UIupdate(InstanceManager im)
        {
            this.im = im;
        }

        private void SetText(string name, string text)//委托修改UI控件
        {
            switch (name)
            {
                case "label99": { if (im.Form1.label99.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.label99.Text = text; } break; }
                case "comboBox1": { if (im.Form1.comboBox1.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.comboBox1.Text = text; } break; }
                case "comboBox2": { if (im.Form1.comboBox2.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.comboBox2.Text = text; } break; }
                case "comboBox3": { if (im.Form1.comboBox3.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.comboBox3.Text = text; } break; }
                case "comboBox4": { if (im.Form1.comboBox4.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.comboBox4.Text = text; } break; }
                case "comboBox5": { if (im.Form1.comboBox5.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.comboBox5.Text = text; } break; }
                case "comboBox6": { if (im.Form1.comboBox6.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.comboBox6.Text = text; } break; }
                case "comboBox7": { if (im.Form1.comboBox7.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.comboBox7.Text = text; } break; }
                case "comboBox8": { if (im.Form1.comboBox8.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.comboBox8.Text = text; } break; }
                case "textBox1": { if (im.Form1.textBox1.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox1.Text = text; } break; }
                case "textBox2": { if (im.Form1.textBox2.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox2.Text = text; } break; }
                case "textBox3": { if (im.Form1.textBox3.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox3.Text = text; } break; }
                case "textBox4": { if (im.Form1.textBox4.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox4.Text = text; } break; }
                //任务队列
                case "label3": { if (im.Form1.label3.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.label3.Text = text; } break; }
                case "label4": { if (im.Form1.label4.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.label4.Text = text; } break; }
                case "label5": { if (im.Form1.label5.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.label5.Text = text; } break; }
                case "label6": { if (im.Form1.label6.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.label6.Text = text; } break; }
                case "label7": { if (im.Form1.label7.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.label7.Text = text; } break; }
                //战斗任务的倒数
                case "textBox12": { if (im.Form1.textBox12.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox12.Text = text; } break; }
                case "textBox14": { if (im.Form1.textBox14.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox14.Text = text; } break; }
                case "textBox15": { if (im.Form1.textBox15.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox15.Text = text; } break; }
                case "textBox17": { if (im.Form1.textBox17.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox17.Text = text; } break; }
                case "textBox19": { if (im.Form1.textBox19.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox19.Text = text; } break; }

                case "textBox6": { if (im.Form1.textBox6.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox6.Text = text; } break; }
                case "textBox7": { if (im.Form1.textBox7.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox7.Text = text; } break; }
                case "textBox8": { if (im.Form1.textBox8.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox8.Text = text; } break; }
                case "textBox9": { if (im.Form1.textBox9.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox9.Text = text; } break; }
                case "textBox10": { if (im.Form1.textBox10.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox10.Text = text; } break; }
                case "textBox11": { if (im.Form1.textBox11.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox11.Text = text; } break; }

                case "label12": { if (im.Form1.label12.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.label12.Text = text; } break; }

                case "label23": { if (im.Form1.label23.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.label23.Text = text; } break; }
                case "label24": { if (im.Form1.label24.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.label24.Text = text; } break; }
                case "label25": { if (im.Form1.label25.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.label25.Text = text; } break; }
                case "label26": { if (im.Form1.label26.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.label26.Text = text; } break; }

                case "textBox13": { if (im.Form1.textBox13.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox13.Text = text; } break; }
                case "textBox16": { if (im.Form1.textBox16.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox16.Text = text; } break; }
                case "textBox18": { if (im.Form1.textBox18.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox18.Text = text; } break; }
                case "textBox5": { if (im.Form1.textBox5.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox5.Text = text; } break; }
                case "textBox20": { if (im.Form1.textBox20.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox20.Text = text; } break; }
                case "label13": { if (im.Form1.label13.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.label13.Text = text; } break; }

                case "textBox22": { if (im.Form1.textBox22.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox22.Text = text; } break; }
                case "textBox23": { if (im.Form1.textBox23.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox23.Text = text; } break; }
                case "textBox24": { if (im.Form1.textBox24.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox24.Text = text; } break; }
                case "textBox25": { if (im.Form1.textBox25.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox25.Text = text; } break; }
                case "textBox26": { if (im.Form1.textBox26.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox26.Text = text; } break; }
                case "textBox27": { if (im.Form1.textBox27.InvokeRequired) { SetTextCallback d = new SetTextCallback(SetText); im.Form1.Invoke(d, new object[] { name, text }); } else { im.Form1.textBox27.Text = text; } break; }
                default:
                    break;
            }
        }
        private string PageCheck()
        {
            switch (BaseData.SystemInfo.PageCheck)
            {
                case "后勤结束": { return "后勤结束"; }
                case "主页": { return "主页"; }
                default: { return ""; }
           }
        }
        public void UIupdateOperation()
        {
            switch (BaseData.SystemInfo.WindowsState)
            {
                case 0: { SetText("label12", "窗口未锁定"); break; }
                case 1: { SetText("label12", "窗口已锁定"); break; }
                default:
                    break;
            }
            this.SetText("label99", BaseData.SystemInfo.AppState);
            this.SetText("label13", PageCheck());

            try
            {
                SetText("comboBox1", im.gameData.User_operationInfo[0].OperationTeamName);
                SetText("comboBox2", im.gameData.User_operationInfo[1].OperationTeamName);
                SetText("comboBox3", im.gameData.User_operationInfo[2].OperationTeamName);
                SetText("comboBox4", im.gameData.User_operationInfo[3].OperationTeamName);
                SetText("comboBox5", im.gameData.User_operationInfo[0].OperationName);
                SetText("comboBox6", im.gameData.User_operationInfo[1].OperationName);
                SetText("comboBox7", im.gameData.User_operationInfo[2].OperationName);
                SetText("comboBox8", im.gameData.User_operationInfo[3].OperationName);
                SetText("textBox1", Convert.ToInt32(im.gameData.User_operationInfo[0].OperationLastTime).ToString());
                SetText("textBox2", Convert.ToInt32(im.gameData.User_operationInfo[1].OperationLastTime).ToString());
                SetText("textBox3", Convert.ToInt32(im.gameData.User_operationInfo[2].OperationLastTime).ToString());
                SetText("textBox4", Convert.ToInt32(im.gameData.User_operationInfo[3].OperationLastTime).ToString());
            }
            catch (Exception)
            {


            }

            try
            {
                SetText("textBox22", Convert.ToInt32(im.gameData.User_BuildingEquipmentInfo[0].BuildingTime).ToString());// 装备建造次数
                SetText("textBox24", Convert.ToInt32(im.gameData.User_BuildingEquipmentInfo[0].BuildEquipmentLastTime).ToString());// 装备建造时间
                SetText("textBox23", Convert.ToInt32(im.gameData.User_BuildingEquipmentInfo[1].BuildingTime).ToString());// 装备建造次数
                SetText("textBox25", Convert.ToInt32(im.gameData.User_BuildingEquipmentInfo[1].BuildEquipmentLastTime).ToString());// 装备建造时间
                SetText("textBox27", Convert.ToInt32(im.gameData.User_BuildingEquipmentInfo[2].BuildingTime).ToString());// 装备建造次数
                SetText("textBox26", Convert.ToInt32(im.gameData.User_BuildingEquipmentInfo[2].BuildEquipmentLastTime).ToString());// 装备建造时间
            }
            catch (Exception)
            {

                throw;
            }

            try
            {
                SetText("textBox12", Convert.ToInt32(im.gameData.User_battleInfo[0].BattleFixTime).ToString());// 战斗任务倒数时间
                SetText("textBox14", Convert.ToInt32(im.gameData.User_battleInfo[1].BattleFixTime).ToString());
                SetText("textBox15", Convert.ToInt32(im.gameData.User_battleInfo[2].BattleFixTime).ToString());
                SetText("textBox17", Convert.ToInt32(im.gameData.User_battleInfo[3].BattleFixTime).ToString());
                SetText("textBox19", Convert.ToInt32(im.gameData.User_AutobattleInfo[0].AutoBattleLastTime).ToString());
                SetText("textBox5", Convert.ToInt32(im.gameData.User_battleInfo[0].BattleLoopTime).ToString());// 战斗任务倒数时间
                SetText("textBox13", Convert.ToInt32(im.gameData.User_battleInfo[1].BattleLoopTime).ToString());
                SetText("textBox16", Convert.ToInt32(im.gameData.User_battleInfo[2].BattleLoopTime).ToString());
                SetText("textBox18", Convert.ToInt32(im.gameData.User_battleInfo[3].BattleLoopTime).ToString());
                SetText("textBox20", Convert.ToInt32(im.gameData.User_AutobattleInfo[0].AutoBattleLastTime).ToString());

                if (im.gameData.User_battleInfo[0].Used)
                {
                    SetText("label23", im.gameData.User_battleInfo[0].TaskName);
                }
                else
                {
                    SetText("label23", "战斗任务1");
                }
                if (im.gameData.User_battleInfo[1].Used )
                {
                    SetText("label24", im.gameData.User_battleInfo[1].TaskName);
                }
                else
                {
                    SetText("label24", "战斗任务2");
                }
                if (im.gameData.User_battleInfo[2].Used)
                {
                    SetText("label25", im.gameData.User_battleInfo[2].TaskName);
                }
                else
                {
                    SetText("label25", "战斗任务3");
                }

                if (im.gameData.User_battleInfo[3].Used)
                {
                    SetText("label26", im.gameData.User_battleInfo[3].TaskName);
                }
                else
                {
                    SetText("label26", "战斗任务4");
                }

            }
            catch (Exception)
            {
                throw;
            }

            try
            {
                SetText("textBox6", Convert.ToInt32(im.ShowerTime[0]).ToString());//澡堂
                SetText("textBox7", Convert.ToInt32(im.ShowerTime[1]).ToString());
                SetText("textBox8", Convert.ToInt32(im.ShowerTime[2]).ToString());
                SetText("textBox9", Convert.ToInt32(im.ShowerTime[3]).ToString());
                SetText("textBox10", Convert.ToInt32(im.ShowerTime[4]).ToString());
                SetText("textBox11", Convert.ToInt32(im.ShowerTime[5]).ToString());
            }
            catch (Exception)
            {

                throw;
            }


            try
            {

                //SetText("label3", "");//清空队列任务
                //SetText("label4", "");
                //SetText("label5", "");
                //SetText("label6", "");
                //SetText("label7", "");
                int i = 3;
                foreach (var item in im.gametasklist)
                {
                    SetText("label" + i.ToString(), item.TaskName);
                    i++;
                }
                for (; i < 8; i++)
                {
                    SetText("label" + i.ToString(), "");
                }

                //SetText("label3", im.gametasklist[0].TaskName);//显示队列任务
                //SetText("label4", im.gametasklist[1].TaskName);
                //SetText("label5", im.gametasklist[2].TaskName);
                //SetText("label6", im.gametasklist[3].TaskName);
                //SetText("label7", im.gametasklist[4].TaskName);
            }
            catch (Exception)
            {

            }


        }
    }
}
