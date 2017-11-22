using System;
using System.Windows.Forms;

namespace RPG
{
    /// <summary>
    /// Denne klasse holder styr på input.
    /// </summary>
    public class Input
    {
        public Input(FormOverworld form)
        {
            form.KeyDown += KeyDown;
            form.KeyUp += KeyUp;
            _timer.Tick += Tick;
        }

        /// <summary>
        /// Instansen af <see cref="Input"/>.
        /// </summary>
        public static Input Instance;

        /// <summary>
        /// Vejen spilleren går.
        /// </summary>
        [Flags]
        private enum Direction
        {
            Up = 1 << 0,
            Down = 1 << 1,
            Right = 1 << 2,
            Left = 1 << 3
        }

        private Direction _direction;

        private bool _spacePressed = false;

        private readonly Timer _timer = new Timer
        {
            Interval = 1,
            Enabled = true
        };

        public delegate void EmptyEventArgs();

        public event EmptyEventArgs SpacePressed;


        private void Tick(object sender, EventArgs e)
        {
            if ((_direction & Direction.Up) == Direction.Up)
            {
                FormOverworld.OverworldPlayer.MoveUp();
            }

            if ((_direction & Direction.Down) == Direction.Down)
            {
                FormOverworld.OverworldPlayer.MoveDown();
            }

            if ((_direction & Direction.Right) == Direction.Right)
            {
                FormOverworld.OverworldPlayer.MoveRight();
            }

            if ((_direction & Direction.Left) == Direction.Left)
            {
                FormOverworld.OverworldPlayer.MoveLeft();
            }
        }

        private void KeyDown(object sender, KeyEventArgs e)
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
                case Keys.Space:
                    if (!_spacePressed)
                        SpacePressed?.Invoke();

                    break;
            }
        }

        private void KeyUp(object sender, KeyEventArgs e)
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

                case Keys.Space:
                    _spacePressed = false;
                    break;
            }
        }
    }
}
