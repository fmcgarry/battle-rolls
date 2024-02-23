using System;
using System.Drawing;
using System.Windows.Forms;

namespace DndFormsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RollButton_Click(object sender, EventArgs e)
        {
            textBoxAttack1.BackColor = DefaultBackColor;
            textBoxBonusActionAttack.BackColor = DefaultBackColor;
            textBoxAttack1Bite.BackColor = DefaultBackColor;

            Random rnd = new Random();

            double profbonus = Double.Parse(textBoxProficiency.Text);

            int damagedie1 = int.Parse(textBoxWpnDmg1.Text.Split('d')[1]);
            int damagedie2 = int.Parse(textBoxWpnDmg2.Text.Split('d')[1]);

            double attack1 = rnd.Next(1, 21);
            double attack2 = rnd.Next(1, 21);

            double damage1 = rnd.Next(1, damagedie1);
            double damage2 = rnd.Next(1, damagedie2);

            double bonus1 = Double.Parse(textBoxBonus1.Text);
            double bonus2 = Double.Parse(textBoxBonus2.Text);

            double dexmod = Math.Truncate(((double.Parse(textBoxDexLvl.Text)) / 2) - 5);
            double strmod = Math.Truncate(((double.Parse(textBoxStrLvl.Text)) / 2) - 5);

            if (attack1 == 20)
            {
                double critchart1 = rnd.Next(1, 101);
                MessageBox.Show("Natural 20 on Attack Roll 1!" + Environment.NewLine + "Crit Chart: " + critchart1.ToString());
                textBoxAttack1.BackColor = Color.Green;
            }

            if (attack1 == 1)
            {
                double critchart1 = rnd.Next(1, 101);
                MessageBox.Show("Critical Miss on Attack Roll 1!" + Environment.NewLine + "Crit Chart: " + critchart1.ToString());
                textBoxAttack1.BackColor = Color.Red;
            }

            if (attack2 == 20)
            {
                double critchart2 = rnd.Next(1, 101);
                MessageBox.Show("Natural 20 on Attack Roll 2!" + Environment.NewLine + "Crit Chart: " + critchart2.ToString());
                textBoxBonusActionAttack.BackColor = Color.Green;
            }

            if (attack2 == 1)
            {
                double critchart2 = rnd.Next(1, 101);
                MessageBox.Show("Critical Miss on Attack Roll 2!" + Environment.NewLine + "Crit Chart: " + critchart2.ToString());
                textBoxBonusActionAttack.BackColor = Color.Red;
            }

            if (checkBoxFinesse1.Checked == true)
            {
                damage1 += dexmod + bonus1;
                attack1 += dexmod + profbonus;
            }
            else
            {
                damage1 += strmod + bonus1;
                attack1 += strmod + profbonus;
            }

            if (checkBoxFinesse2.Checked == true)
            {
                damage2 += dexmod + bonus2;
                attack2 += dexmod + profbonus;
            }
            else
            {
                damage2 += strmod + bonus2;
                attack2 += strmod + profbonus;
            }

            if (checkBoxSneakAttack.Checked == true)
            {
                damage1 += rnd.Next(1, 7);
            }

            if (checkBoxHuntersMark.Checked == true)
            {
                damage1 += rnd.Next(1, 7);
            }

            textBoxAttack1.Text = attack1.ToString();
            textBoxBonusActionAttack.Text = attack2.ToString();

            textBoxDamage1.Text = damage1.ToString();
            textBoxBonusActionDamage.Text = damage2.ToString();

            if (checkBoxBite.Checked == true)
            {
                int damagedie3 = int.Parse(textBoxWpnDmg3.Text.Split('d')[1]);
                double attack3 = rnd.Next(1, 21);
                double damage3 = rnd.Next(1, damagedie3);

                if (attack3 == 20)
                {
                    double critchart3 = rnd.Next(1, 101);
                    MessageBox.Show("Natural 20 on Bite Attack!" + Environment.NewLine + "Crit Chart: " + critchart3.ToString());
                    textBoxAttack1Bite.BackColor = Color.Green;
                }

                if (attack3 == 1)
                {
                    double critchart3 = rnd.Next(1, 101);
                    MessageBox.Show("Critical Miss on Bite Attack!" + Environment.NewLine + "Crit Chart: " + critchart3.ToString());
                    textBoxAttack1Bite.BackColor = Color.Red;
                }

                damage3 += strmod;
                attack3 += strmod + profbonus;
                textBoxAttack1Bite.Text = attack3.ToString();
                textBoxDamageBite.Text = damage3.ToString();
            }
        }

        private void checkBoxThirdAttack_CheckedChanged(object sender, EventArgs e)
        {
            if (textBoxWpnDmg3.ReadOnly && textBoxBonusBite.ReadOnly)
            {
                textBoxWpnDmg3.ReadOnly = false;
                textBoxBonusBite.ReadOnly = false;
            }
            else
            {
                textBoxWpnDmg3.ReadOnly = true;
                textBoxBonusBite.ReadOnly = true;
            }
        }

        private void buttonDieRoller_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int die = 0;

            switch (listBoxDice.SelectedItem.ToString())
            {
                case "D4":
                    {
                        die = 5;
                        break;
                    }
                case "D6":
                    {
                        die = 7;
                        break;
                    }
                case "D8":
                    {
                        die = 9;
                        break;
                    }
                case "D10":
                    {
                        die = 11;
                        break;
                    }
                case "D12":
                    {
                        die = 13;
                        break;
                    }
                case "D20":
                    {
                        die = 21;

                        break;
                    }
                case "D100":
                    {
                        die = 101;
                        break;
                    }
            }

            int roll = rnd.Next(1, die);
            labeld20.Text = roll.ToString();
        }

        private void checkBoxWeapon2_CheckedChanged(object sender, EventArgs e)
        {
            if (textBoxWpnDmg2.ReadOnly && textBoxBonus2.ReadOnly)
            {
                textBoxWpnDmg2.ReadOnly = false;
                textBoxBonus2.ReadOnly = false;
            }
            else
            {
                textBoxWpnDmg2.ReadOnly = true;
                textBoxBonus2.ReadOnly = true;
            }
        }

        private void checkBoxClaw_CheckedChanged(object sender, EventArgs e)
        {
            if (textBoxClawDmg.ReadOnly && textBoxBonusClaw.ReadOnly)
            {
                textBoxClawDmg.ReadOnly = false;
                textBoxBonusClaw.ReadOnly = false;
            }
            else
            {
                textBoxClawDmg.ReadOnly = true;
                textBoxBonusClaw.ReadOnly = true;
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}