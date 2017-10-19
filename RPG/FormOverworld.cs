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
            Level.LoadLevel(5);
            Controls.Add(OverworldPlayer);
            Input.Instance = new Input(Instance);
        }

        public static ChestUi ChestUi;

        public static FormOverworld Instance;

        public static OverworldPlayer OverworldPlayer;

        public static SoundPlayer SoundPlayer = new SoundPlayer();

        private void FormMain_Load(object sender, EventArgs e)
        {
#if DEBUG
            new FormDebug().Show();
#endif //DEBUG
        }
    }
}
