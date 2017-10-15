using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

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
        }

        public static FormOverworld Instance;

        public static OverworldPlayer OverworldPlayer;

        public static SoundPlayer SoundPlayer = new SoundPlayer();

        [Flags]
        private enum Direction
        {
            Up = 1 << 0,
            Down = 1 << 1,
            Right = 1 << 2,
            Left = 1 << 3
        }

        private Direction _direction;

        private void FormMain_Load(object sender, EventArgs e)
        {
#if DEBUG
            new FormDebug().Show();
#endif //DEBUG
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if ((_direction & Direction.Up) == Direction.Up)
            {
                OverworldPlayer.MoveUp();
            }

            if ((_direction & Direction.Down) == Direction.Down)
            {
                OverworldPlayer.MoveDown();
            }

            if ((_direction & Direction.Right) == Direction.Right)
            {
                OverworldPlayer.MoveRight();
            }

            if ((_direction & Direction.Left) == Direction.Left)
            {
                OverworldPlayer.MoveLeft();
            }
        }

        private void FormOverworld_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    _direction |= Direction.Up;
                    break;

                case Keys.S:
                    _direction |= Direction.Down;
                    break;

                case Keys.D:
                    _direction |= Direction.Right;
                    break;

                case Keys.A:
                    _direction |= Direction.Left;
                    break;
            }
        }

        private void FormOverworld_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    _direction &= ~Direction.Up;
                    break;

                case Keys.S:
                    _direction &= ~Direction.Down;
                    break;

                case Keys.D:
                    _direction &= ~Direction.Right;
                    break;

                case Keys.A:
                    _direction &= ~Direction.Left;
                    break;
            }
        }
    }
}
