using System.Windows.Forms;
using RPG.Extensions;

namespace RPG
{
    /// <inheritdoc />
    /// <summary>
    /// Denne <see cref="Form"/> bruges når en spiller kæmper mod en fjende.
    /// </summary>
    public partial class FormBattle : Form
    {
        /// <inheritdoc />
        /// <summary>
        /// Laver en ny <see cref="T:RPG.FormBattle" />.
        /// </summary>
        public FormBattle()
        {
            InitializeComponent();

            progressBarPlayerHP.SetColor(ProgressBarColor.Red);
            progressBarPlayerMP.SetColor(ProgressBarColor.Green);
            progressBarPlayerXP.SetColor(ProgressBarColor.Yellow);

            groupBoxPlayer.Text = Player.Name;

            progressBarPlayerHP.Maximum = Player.MaxHealth;
            progressBarPlayerHP.Value = Player.Health;

            progressBarPlayerMP.Maximum = Player.MaxMana;
            progressBarPlayerMP.Value = Player.Mana;

            progressBarPlayerXP.Maximum = Player.ExperienceNeeded;
            progressBarPlayerXP.Value = Player.Experience;

        }
    }
}
