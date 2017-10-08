using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        public int PointsTotal = 20;

        public int PointsLeft => PointsTotal + 5 - (int)(numericUpDownStrength.Value + numericUpDownWisdom.Value +
                                          numericUpDownSpeed.Value + numericUpDownDefence.Value +
                                          numericUpDownResistance.Value);

        public bool CheckPoints()
        {
            return PointsLeft > -1;
        }

        public void UpdatePoints()
        {
            labelPointsLeft.Text = $"Point tilbage: {PointsLeft}";
        }

        private void numericUpDownStrength_ValueChanged(object sender, EventArgs e)
        {
            if (!CheckPoints())
            {
                numericUpDownStrength.Value--;
            }
            UpdatePoints();

        }

        private void numericUpDownWisdom_ValueChanged(object sender, EventArgs e)
        {
            if (!CheckPoints())
            {
                numericUpDownWisdom.Value--;
            }
            UpdatePoints();
        }

        private void numericUpDownSpeed_ValueChanged(object sender, EventArgs e)
        {
            if (!CheckPoints())
            {
                numericUpDownSpeed.Value--;
            }
            UpdatePoints();
        }

        private void numericUpDownDefence_ValueChanged(object sender, EventArgs e)
        {
            if (!CheckPoints())
            {
                numericUpDownDefence.Value--;
            }
            UpdatePoints();
        }

        private void numericUpDownResistance_ValueChanged(object sender, EventArgs e)
        {
            if (!CheckPoints())
            {
                numericUpDownResistance.Value--;
            }
            UpdatePoints();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Giv din karakter et navn.");
                return;
            }

            if (PointsLeft != 0)
            {
                MessageBox.Show("Uddel alle dine færdighedspoint.");
                return;
            }

            Player.Strength = (int) numericUpDownStrength.Value;
            Player.Wisdom = (int) numericUpDownWisdom.Value;
            Player.Speed = (int) numericUpDownSpeed.Value;
            Player.Defence = (int) numericUpDownDefence.Value;
            Player.Resistance = (int) numericUpDownResistance.Value;

            this.Hide();
            new FormOverworld().ShowDialog();
            this.Close();

        }
    }
}
