using System;
using System.Windows.Forms;
using TaskList;
using WindowsFormsApplication1;
using WindowsFormsApplication1.Properties;
namespace testdm
{
    partial class Battle : Form
    {
        private InstanceManager im;
        public Battle(InstanceManager im)
        {
            InitializeComponent();
            this.im = im;
        }

        private void Battle_Load(object sender, EventArgs e)
        {
            label18.Visible = false; comboBox9.Visible = false;

            comboBox1.Text = Settings.Default.battlemap;

            comboBox2.Text = im.gameData.User_battleInfo[0].TaskType.ToString();

            comboBox14.Text = Settings.Default.mainteam;
            comboBox13.Text = Settings.Default.supportteam;
            checkBox1.Checked = Settings.Default.Fix;
            checkBox2.Checked = Settings.Default.supplies;
            checkBox3.Checked = Settings.Default.BattleLoopUnLockWindows;

            checkBox6.Checked = true;


            if(Settings.Default.FixType == 1)
            {
                radioButton1.Checked = true;
            }
            else if(Settings.Default.FixType == 2)
            {
                radioButton2.Checked = true;
            }



            checkBox5.Checked = Settings.Default.ChangeGun;


            textBox4.Text = im.userData.DismantlementGunCount.ToString();
            textBox1.Text = Settings.Default.Fixmaxtime.ToString();
            textBox2.Text = Settings.Default.Fixmintime.ToString();
            textBox3.Text = Settings.Default.RoundInterval.ToString();
            textBox6.Text = Settings.Default.FixMinPercentage.ToString();
            textBox7.Text = Settings.Default.FixMaxPercentage.ToString();
            textBox8.Text = Settings.Default.Team_SerrorTime.ToString();
            textBox9.Text = Settings.Default.EquipmentUpdatePostion;
            //page2


            comboBox3.Text = Settings.Default.AutoTeam1;
            comboBox4.Text = Settings.Default.AutoTeam2;
            comboBox5.Text = Settings.Default.AutoTeam3;
            comboBox6.Text = Settings.Default.AutoTeam4;
            comboBox7.Text = Settings.Default.AutoMap;
            comboBox8.Text = Settings.Default.EquipmentUpdateType;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            Settings.Default.RoundInterval = Int32.Parse(textBox3.Text);
            Settings.Default.battlemap = comboBox1.Text;
            Settings.Default.mainteam = comboBox14.Text;
            Settings.Default.supportteam = comboBox13.Text;
            Settings.Default.Fix = checkBox1.Checked;
            Settings.Default.supplies = checkBox2.Checked;
            Settings.Default.BattleLoopUnLockWindows = checkBox3.Checked;

            Settings.Default.ChangeGun = checkBox5.Checked;
            Settings.Default.Team_SerrorTime = Int32.Parse(textBox8.Text);
            Settings.Default.Fixmaxtime = Int32.Parse(textBox1.Text);
            Settings.Default.Fixmintime = Int32.Parse(textBox2.Text);
            Settings.Default.FixMinPercentage = Int32.Parse(textBox6.Text);
            Settings.Default.FixMaxPercentage = int.Parse(textBox7.Text);

            Settings.Default.EquipmentUpdateType = comboBox8.Text;
            Settings.Default.EquipmentUpdatePostion = textBox9.Text;


            if(radioButton1.Checked == true)
            {
                Settings.Default.FixType = 1;
            }
            else if(radioButton2.Checked == true)
            {
                Settings.Default.FixType = 2;
            }

            im.userData.DismantlementGunCount = Convert.ToInt32(textBox4.Text);


            if (im.gameData.User_battleInfo[0].Used == false)
            {
                im.gameData.User_battleInfo[0].TaskName = comboBox1.Text;
                im.gameData.User_battleInfo[0].TaskMianTeam = comboBox14.Text;
                im.gameData.User_battleInfo[0].TaskSupportTeam1 = comboBox13.Text;
                im.gameData.User_battleInfo[0].TaskSupportTeam2 = comboBox9.Text;
                im.gameData.User_battleInfo[0].Team_SerrorTime = Int32.Parse(textBox8.Text);
                im.gameData.User_battleInfo[0].LoopMaxTime = Int32.Parse(textBox10.Text);

                im.gameData.User_battleInfo[0].ChoiceToFix = checkBox1.Checked;
                im.gameData.User_battleInfo[0].ChoiceToSupply = checkBox2.Checked;
                im.gameData.User_battleInfo[0].BattleLoopUnLockWindows = checkBox3.Checked;

                im.gameData.User_battleInfo[0].DismantleGunOrEquipment = checkBox4.Checked;
                im.gameData.User_battleInfo[0].ChangeGun = checkBox5.Checked;
                im.gameData.User_battleInfo[0].SetMap = checkBox6.Checked;


                im.gameData.User_battleInfo[0].FixMaxTime = Int32.Parse(textBox1.Text);
                im.gameData.User_battleInfo[0].FixMintime = Int32.Parse(textBox2.Text);
                im.gameData.User_battleInfo[0].FixMinPercentage = Int32.Parse(textBox6.Text);
                im.gameData.User_battleInfo[0].FixMaxPercentage = Int32.Parse(textBox7.Text);
                im.gameData.User_battleInfo[0].RoundInterval = Int32.Parse(textBox3.Text);
                im.gameData.User_battleInfo[0].TaskType = Int32.Parse(comboBox2.Text);

                if (radioButton1.Checked == true)
                {
                    im.gameData.User_battleInfo[0].FixType = 1;
                }
                else if (radioButton2.Checked == true)
                {
                    im.gameData.User_battleInfo[0].FixType = 2;
                }

                //拆解或装备强化设置
                if (checkBox4.Checked == true)
                {
                    im.gameData.User_battleInfo[0].DismantleGunOrEquipment = true;
                    if (radioButton3.Checked == true)
                    {
                        im.gameData.User_battleInfo[0].DismantleType = 0;
                        im.gameData.User_battleInfo[0].DismantlementGunCount = Convert.ToInt32(textBox4.Text);
                    }
                    if (radioButton4.Checked == true)
                    {
                        im.gameData.User_battleInfo[0].DismantleType = 1;
                        im.gameData.User_battleInfo[0].EquipmentType = comboBox8.SelectedIndex;
                        im.gameData.User_battleInfo[0].EquipmentUpdatePostion = Convert.ToInt32(textBox9.Text);
                    }
                }

                im.gameData.User_battleInfo[0].Used = true;
                im.taskList.taskadd(WindowsFormsApplication1.BaseData.TaskList.Battle1);




            }
            else if (im.gameData.User_battleInfo[1].Used == false)
            {
                im.gameData.User_battleInfo[1].TaskName = comboBox1.Text;
                im.gameData.User_battleInfo[1].TaskMianTeam = comboBox14.Text;
                im.gameData.User_battleInfo[1].TaskSupportTeam1 = comboBox13.Text;
                im.gameData.User_battleInfo[1].TaskSupportTeam2 = comboBox9.Text;
                im.gameData.User_battleInfo[1].Team_SerrorTime = Int32.Parse(textBox8.Text);
                im.gameData.User_battleInfo[1].LoopMaxTime = Int32.Parse(textBox10.Text);

                im.gameData.User_battleInfo[1].ChoiceToFix = checkBox1.Checked;
                im.gameData.User_battleInfo[1].ChoiceToSupply = checkBox2.Checked;
                im.gameData.User_battleInfo[1].BattleLoopUnLockWindows = checkBox3.Checked;
                im.gameData.User_battleInfo[1].DismantleGunOrEquipment = checkBox4.Checked;
                im.gameData.User_battleInfo[1].ChangeGun = checkBox5.Checked;
                im.gameData.User_battleInfo[1].SetMap = checkBox6.Checked;


                im.gameData.User_battleInfo[1].FixMaxTime = Int32.Parse(textBox1.Text);
                im.gameData.User_battleInfo[1].FixMintime = Int32.Parse(textBox2.Text);
                im.gameData.User_battleInfo[1].FixMinPercentage = Int32.Parse(textBox6.Text);
                im.gameData.User_battleInfo[1].FixMaxPercentage = Int32.Parse(textBox7.Text);
                im.gameData.User_battleInfo[1].RoundInterval = Int32.Parse(textBox3.Text);

                if (radioButton1.Checked == true)
                {
                    im.gameData.User_battleInfo[1].FixType = 1;
                }
                else if (radioButton2.Checked == true)
                {
                    im.gameData.User_battleInfo[1].FixType = 2;
                }

                //拆解或装备强化设置
                if (checkBox4.Checked == true)
                {
                    im.gameData.User_battleInfo[1].DismantleGunOrEquipment = true;
                    if (radioButton3.Checked == true)
                    {
                        im.gameData.User_battleInfo[1].DismantleType = 0;
                        im.gameData.User_battleInfo[1].DismantlementGunCount = Convert.ToInt32(textBox4.Text);
                    }
                    if (radioButton4.Checked == true)
                    {
                        im.gameData.User_battleInfo[1].DismantleType = 1;
                        im.gameData.User_battleInfo[1].EquipmentType = comboBox8.SelectedIndex;
                        im.gameData.User_battleInfo[1].EquipmentUpdatePostion = Convert.ToInt32(textBox9.Text);
                    }
                }


                im.gameData.User_battleInfo[1].TaskType = Int32.Parse(comboBox2.Text);
                im.gameData.User_battleInfo[1].Used = true;
                im.taskList.taskadd(WindowsFormsApplication1.BaseData.TaskList.Battle2);
            }

            else if (im.gameData.User_battleInfo[2].Used == false)
            {


                im.gameData.User_battleInfo[2].TaskName = comboBox1.Text;
                im.gameData.User_battleInfo[2].TaskMianTeam = comboBox14.Text;
                im.gameData.User_battleInfo[2].TaskSupportTeam1 = comboBox13.Text;
                im.gameData.User_battleInfo[2].TaskSupportTeam2 = comboBox9.Text;
                im.gameData.User_battleInfo[2].Team_SerrorTime = Int32.Parse(textBox8.Text);
                im.gameData.User_battleInfo[2].LoopMaxTime = Int32.Parse(textBox10.Text);

                im.gameData.User_battleInfo[2].ChoiceToFix = checkBox1.Checked;
                im.gameData.User_battleInfo[2].ChoiceToSupply = checkBox2.Checked;
                im.gameData.User_battleInfo[2].BattleLoopUnLockWindows = checkBox3.Checked;
                im.gameData.User_battleInfo[2].DismantleGunOrEquipment = checkBox4.Checked;
                im.gameData.User_battleInfo[2].ChangeGun = checkBox5.Checked;
                im.gameData.User_battleInfo[2].SetMap = checkBox6.Checked;


                im.gameData.User_battleInfo[2].FixMaxTime = Int32.Parse(textBox1.Text);
                im.gameData.User_battleInfo[2].FixMintime = Int32.Parse(textBox2.Text);
                im.gameData.User_battleInfo[2].FixMinPercentage = Int32.Parse(textBox6.Text);
                im.gameData.User_battleInfo[2].RoundInterval = Int32.Parse(textBox3.Text);
                im.gameData.User_battleInfo[2].FixMaxPercentage = Int32.Parse(textBox7.Text);


                if (radioButton1.Checked == true)
                {
                    im.gameData.User_battleInfo[2].FixType = 1;
                }
                else if (radioButton2.Checked == true)
                {
                    im.gameData.User_battleInfo[2].FixType = 2;
                }

                //拆解或装备强化设置
                if (checkBox4.Checked == true)
                {
                    im.gameData.User_battleInfo[2].DismantleGunOrEquipment = true;
                    if (radioButton3.Checked == true)
                    {
                        im.gameData.User_battleInfo[2].DismantleType = 0;
                        im.gameData.User_battleInfo[2].DismantlementGunCount = Convert.ToInt32(textBox4.Text);
                    }
                    if (radioButton4.Checked == true)
                    {
                        im.gameData.User_battleInfo[2].DismantleType = 1;
                        im.gameData.User_battleInfo[2].EquipmentType = comboBox8.SelectedIndex;
                        im.gameData.User_battleInfo[2].EquipmentUpdatePostion = Convert.ToInt32(textBox9.Text);
                    }
                }




                im.gameData.User_battleInfo[2].TaskType = Int32.Parse(comboBox2.Text);
                im.gameData.User_battleInfo[2].Used = true;
                im.taskList.taskadd(WindowsFormsApplication1.BaseData.TaskList.Battle3);
            }

            else if(im.gameData.User_battleInfo[3].Used == false)
            {


                im.gameData.User_battleInfo[3].TaskName = comboBox1.Text;
                im.gameData.User_battleInfo[3].TaskMianTeam = comboBox14.Text;
                im.gameData.User_battleInfo[3].TaskSupportTeam1 = comboBox13.Text;
                im.gameData.User_battleInfo[3].TaskSupportTeam2 = comboBox9.Text;
                im.gameData.User_battleInfo[3].Team_SerrorTime = Int32.Parse(textBox8.Text);
                im.gameData.User_battleInfo[3].LoopMaxTime = Int32.Parse(textBox10.Text);

                im.gameData.User_battleInfo[3].ChoiceToFix = checkBox1.Checked;
                im.gameData.User_battleInfo[3].ChoiceToSupply = checkBox2.Checked;
                im.gameData.User_battleInfo[3].BattleLoopUnLockWindows = checkBox3.Checked;
                im.gameData.User_battleInfo[3].DismantleGunOrEquipment = checkBox4.Checked;
                im.gameData.User_battleInfo[3].ChangeGun = checkBox5.Checked;
                im.gameData.User_battleInfo[3].SetMap = checkBox6.Checked;

                im.gameData.User_battleInfo[3].FixMaxTime = Int32.Parse(textBox1.Text);
                im.gameData.User_battleInfo[3].FixMintime = Int32.Parse(textBox2.Text);
                im.gameData.User_battleInfo[3].FixMinPercentage = Int32.Parse(textBox6.Text);
                im.gameData.User_battleInfo[3].FixMaxPercentage = Int32.Parse(textBox7.Text);
                im.gameData.User_battleInfo[3].RoundInterval = Int32.Parse(textBox3.Text);

                if (radioButton1.Checked == true)
                {
                    im.gameData.User_battleInfo[3].FixType = 1;
                }
                else if (radioButton2.Checked == true)
                {
                    im.gameData.User_battleInfo[3].FixType = 2;
                }

                //拆解或装备强化设置
                if (checkBox4.Checked == true)
                {
                    im.gameData.User_battleInfo[3].DismantleGunOrEquipment = true;
                    if (radioButton3.Checked == true)
                    {
                        im.gameData.User_battleInfo[3].DismantleType = 0;
                        im.gameData.User_battleInfo[3].DismantlementGunCount = Convert.ToInt32(textBox4.Text);
                    }
                    if (radioButton4.Checked == true)
                    {
                        im.gameData.User_battleInfo[3].DismantleType = 1;
                        im.gameData.User_battleInfo[3].EquipmentType = comboBox8.SelectedIndex;
                        im.gameData.User_battleInfo[3].EquipmentUpdatePostion = Convert.ToInt32(textBox9.Text);
                    }
                }


                im.gameData.User_battleInfo[3].TaskType = Int32.Parse(comboBox2.Text);
                im.gameData.User_battleInfo[3].Used = true;
                im.taskList.taskadd(WindowsFormsApplication1.BaseData.TaskList.Battle4);
            }
            Settings.Default.Save();
            this.Close();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Settings.Default.AutoTeam1 = comboBox3.Text;
            Settings.Default.AutoTeam2 = comboBox4.Text;
            Settings.Default.AutoTeam3 = comboBox5.Text;
            Settings.Default.AutoTeam4 = comboBox6.Text;
            Settings.Default.AutoMap = comboBox7.Text;
            Settings.Default.SetMap = checkBox6.Checked;
            Settings.Default.Save();
            im.taskList.taskadd(WindowsFormsApplication1.BaseData.TaskList.AutoBattle);
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                //case "0_4": { label2.Visible = true; comboBox13.Visible = true; checkBox5.Visible = false; checkBox5.Checked = false; comboBox2.Items.Clear(); comboBox2.Items.AddRange(new object[] { "1" }); comboBox2.SelectedIndex = 0; label11.Text = ""; break; }
                case "0_1": { label2.Visible = false; comboBox13.Visible = false; checkBox5.Visible = false; checkBox5.Checked = false; checkBox6.Checked = true; comboBox2.Items.Clear(); comboBox2.Items.AddRange(new object[] { "1"}); comboBox2.SelectedIndex = 0; label11.Text = "两战结束"; break; }
                //case "1_2": { label2.Visible = false; comboBox13.Visible = false; checkBox5.Visible = true; checkBox5.Checked = true; comboBox2.Items.Clear(); comboBox2.Items.AddRange(new object[] { "1" }); comboBox2.SelectedIndex = 0; label11.Text = ""; break; }
                case "1_4E": { label2.Visible = true; comboBox13.Visible = true; checkBox5.Visible = false; checkBox5.Checked = false; comboBox2.Items.Clear(); comboBox2.Items.AddRange(new object[] { "1" }); comboBox2.SelectedIndex = 0; label11.Text = "";label18.Visible = true;comboBox9.Visible = true; break; }
                //case "2_1E": { label2.Visible = true; comboBox13.Visible = true; checkBox5.Visible = false; checkBox5.Checked = false; comboBox2.Items.Clear(); comboBox2.Items.AddRange(new object[] { "1" }); comboBox2.SelectedIndex = 0; label11.Text = ""; break; }
                case "2_4E": { label2.Visible = true; comboBox13.Visible = true; checkBox5.Visible = false; checkBox5.Checked = false; comboBox2.Items.Clear(); comboBox2.Items.AddRange(new object[] { "1" }); comboBox2.SelectedIndex = 0; label11.Text = ""; break; }
                case "3_2N": { label2.Visible = true; comboBox13.Visible = true; checkBox5.Visible = false; checkBox5.Checked = false; checkBox6.Checked = true; comboBox2.Items.Clear(); comboBox2.Items.AddRange(new object[] { "1", "2" }); comboBox2.SelectedIndex = 0; label11.Text = "1为俩战2为三战"; break; }
                //case "3_3E": { label2.Visible = true; comboBox13.Visible = true; checkBox5.Visible = false; checkBox5.Checked = false; comboBox2.Items.Clear(); comboBox2.Items.AddRange(new object[] { "1", "2" }); comboBox2.SelectedIndex = 0; label11.Text = "1为指挥部2为BOSS"; break; }
                case "3_4E": { label2.Visible = true; comboBox13.Visible = true; checkBox5.Visible = false; checkBox5.Checked = false; checkBox6.Checked = true; comboBox2.Items.Clear(); comboBox2.Items.AddRange(new object[] { "1" }); comboBox2.SelectedIndex = 0; label11.Text = ""; break; }
                //case "4_3": { label2.Visible = true; comboBox13.Visible = true; checkBox5.Visible = false; checkBox5.Checked = false; comboBox2.Items.Clear(); comboBox2.Items.AddRange(new object[] { "1" }); comboBox2.SelectedIndex = 0; label11.Text = "随机点"; break; }
                case "4_4E": { label2.Visible = true; comboBox13.Visible = true; checkBox5.Visible = false; checkBox5.Checked = false; comboBox2.Items.Clear(); comboBox2.Items.AddRange(new object[] { "1", "2" }); comboBox2.SelectedIndex = 0; label11.Text = "1为俩战2为四战"; break; }
                //case "5_1E": { label2.Visible = false; comboBox13.Visible = false; checkBox5.Visible = false; checkBox5.Checked = false; comboBox2.Items.Clear(); comboBox2.Items.AddRange(new object[] { "1" }); comboBox2.SelectedIndex = 0; label11.Text = "5_1E是连走2次随机点"; break; }
                //case "5_2": { label2.Visible = false;comboBox13.Visible = false; checkBox5.Visible = false; checkBox5.Checked = false; comboBox2.Items.Clear(); comboBox2.Items.AddRange(new object[] { "1" }); comboBox2.SelectedIndex = 0; label11.Text = "5_2是连走2次随机点"; break; }
                case "5_4": { label2.Visible = true; comboBox13.Visible = true; checkBox5.Visible = false; checkBox5.Checked = false; checkBox6.Checked = true; comboBox2.Items.Clear(); comboBox2.Items.AddRange(new object[] { "1", "2" }); comboBox2.SelectedIndex = 0; label11.Text = ""; break; }
                case "5_4E": { label2.Visible = true; comboBox13.Visible = true; checkBox5.Visible = false; checkBox5.Checked = false; checkBox6.Checked = true; comboBox2.Items.Clear(); comboBox2.Items.AddRange(new object[] { "1", "2" }); comboBox2.SelectedIndex = 0; label11.Text = "1为三战2为四战"; break; }
                case "6_6": { label2.Visible = false; comboBox13.Visible = false; checkBox5.Visible = false; checkBox5.Checked = false; checkBox6.Checked = true; comboBox2.Items.Clear(); comboBox2.Items.AddRange(new object[] { "1" }); comboBox2.SelectedIndex = 0; label11.Text = ""; break; }
                //case "魔方行动E4": { label2.Visible = true; comboBox13.Visible = true; checkBox5.Visible = false; checkBox5.Checked = false; comboBox2.Items.Clear(); comboBox2.Items.AddRange(new object[] { "1", "2","3" }); comboBox2.SelectedIndex = 0; label11.Text = "1为两战2为随机点\n3为4战"; break; }
                default:
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
    }
}
