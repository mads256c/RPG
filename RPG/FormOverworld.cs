using System;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using RPG.Properties;
using RPG.UI;

namespace RPG
{
    public partial class FormOverworld : Form
    {
        public FormOverworld()
        {
            InitializeComponent();
            ClientSize = new Size(600, 500);
            Instance = this;
            Controls.Add(OverworldPlayer);
            Input.Instance = new Input(Instance);
        }

        /// <summary>
        /// Den eneste instans af <see cref="FormOverworld"/>. Bruges i andre klasser.
        /// </summary>
        public static FormOverworld Instance;

        /// <summary>
        /// Den eneste instans af <see cref="OverworldPlayer"/>. Den spiller brugeren kontrollerer i oververdenen.
        /// </summary>
        public static OverworldPlayer OverworldPlayer;

        /// <summary>
        /// Til at spille lydeffekter med.
        /// </summary>
        public static SoundPlayer SoundPlayer = new SoundPlayer();

        private void FormMain_Load(object sender, EventArgs e)
        {
            #if DEBUG
                new FormDebug().Show();
#endif //DEBUG
            Level.LoadLevel(0);
        }
    }
}
