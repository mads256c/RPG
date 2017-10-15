using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RPG.Extensions;

namespace RPG
{
    public partial class FormBattle : Form
    {
        public FormBattle()
        {
            InitializeComponent();

            progressBarPlayerHP.SetColor(ProgressBarColor.Red);
            progressBarPlayerMP.SetColor(ProgressBarColor.Green);
            progressBarPlayerXP.SetColor(ProgressBarColor.Yellow);

            groupBoxPlayer.Text = Player.Name;

            progressBarPlayerHP.Maximum = Player.MaxHealth;
            progressBarPlayerHP.Value = Player.Health;

            progressBarPlayerMP.Maximum = Player.MaxMP;
            progressBarPlayerMP.Value = Player.MP;

            progressBarPlayerXP.Maximum = Player.XPNeeded;
            progressBarPlayerXP.Value = Player.XP;

        }
    }
}
