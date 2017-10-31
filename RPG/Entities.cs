using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RPG.Objects;
using RPG.Properties;
using RPG.Weapons;

namespace RPG
{
    /// <summary>
    /// Holder information af spilleren.
    /// </summary>
    public static class Player
    {
        public static string Name;

        /// <summary>
        /// Spillerens livspoint. Sørger også få at spilleren ikke kan have flere livspoint end det maximale antal livspoint.
        /// </summary>
        public static int Health
        {
            get => _health;

            set => _health = value > MaxHealth ? MaxHealth : value;
        }
        private static int _health = MaxHealth;

        /// <summary>
        /// Udregner spillerens maximale livspoint.
        /// </summary>
        public static int MaxHealth => Level * 15 + Defence * 5;

        /// <summary>
        /// Spillerens mana. Sørger også få at spilleren ikke kan have mere mana end det maximale mana.
        /// </summary>
        public static int Mana
        {
            get => _mana;

            set => _mana = value > MaxMana ? MaxMana : value;
        }
        private static int _mana = MaxMana;
        
        /// <summary>
        /// Udregner spillerens maximale mana.
        /// </summary>
        public static int MaxMana => Wisdom * 10;

        public static int Level = 1;
        public static int Experience;
        public static int ExperienceNeeded => Level * 100;

        public static int Strength = 1;
        public static int Wisdom = 1;
        public static int Speed = 1;

        public static int Defence = 1;
        public static int Resistance = 1;

        public static Weapon Weapon = null;
    }

    /// <inheritdoc />
    /// <summary>
    /// Spilleren man kontrollerer i oververdenen.
    /// </summary>
    public sealed class OverworldPlayer : PictureBox
    {
        /// <inheritdoc />
        /// <summary>
        /// Laver en ny <see cref="T:RPG.OverworldPlayer" />.
        /// </summary>
        /// <param name="x">Spillerens lokation på x aksen.</param>
        /// <param name="y">Spillerens lokation på y aksen.</param>
        public OverworldPlayer(int x, int y)
        {
            Size = new Size(32, 64);
            Location = new Point(x, y);
            BackColor = Color.Transparent;
            Image = Resources.Player;
            UpdateCollision();
        }

        /// <summary>
        /// Flytter spilleren op. Tjekker også efter kollisioner.
        /// </summary>
        public void MoveUp()
        {
            UpdatePlayer();
            if (LevelObject.Objects.Any(levelObject => levelObject.IntersectsCollider(_topCollision)) | Location.Y <= 0)
            {
                return;
            }
            Location = new Point(Location.X, Location.Y - 1);
            UpdateCollision();

        }

        /// <summary>
        /// Flytter spilleren ned. Tjekker også efter kollisioner.
        /// </summary>
        public void MoveDown()
        {
            UpdatePlayer();
            if (LevelObject.Objects.Any(levelObject => levelObject.IntersectsCollider(_bottomCollision)) | Location.Y + Size.Height > FormOverworld.Instance.ClientSize.Height)
            {
                return;
            }
            Location = new Point(Location.X, Location.Y + 1);
            UpdateCollision();
        }

        /// <summary>
        /// Flytter spilleren til højre. Tjekker også efter kollisioner.
        /// </summary>
        public void MoveRight()
        {
            UpdatePlayer();
            if (LevelObject.Objects.Any(levelObject => levelObject.IntersectsCollider(_rightCollision)) | Location.X + Size.Width > FormOverworld.Instance.ClientSize.Width)
            {
                return;
            }
            Location = new Point(Location.X + 1, Location.Y);
            UpdateCollision();
        }

        /// <summary>
        /// Flytter spilleren til venstre. Tjekker også efter kollisioner.
        /// </summary>
        public void MoveLeft()
        {
            UpdatePlayer();
            if (LevelObject.Objects.Any(levelObject => levelObject.IntersectsCollider(_leftCollision)) | Location.X < 0)
            {
                return;
            }
            Location = new Point(Location.X - 1, Location.Y);
            UpdateCollision();
        }

        /// <summary>
        /// Opdaterer spillerens kollisionsrektangler.
        /// </summary>
        public void UpdateCollision()
        {
            _topCollision.Location = new Point(Location.X, Location.Y - 1);
            _bottomCollision.Location = new Point(Location.X, Location.Y + Size.Height);
            _rightCollision.Location = new Point(Location.X + Size.Width, Location.Y);
            _leftCollision.Location = new Point(Location.X - 1, Location.Y);
        }

        /// <summary>
        /// Sender kollisionsinformation til aktive <see cref="LevelObject"/> objekter.
        /// </summary>
        public void UpdatePlayer()
        {
            foreach (var levelObject in LevelObject.Objects)
            {
                levelObject.IntersectsPlayer(Bounds);
            }
        }


        private Rectangle _topCollision = new Rectangle(0, 0, 32, 1);
        private Rectangle _bottomCollision = new Rectangle(0, 0, 32, 1);
        private Rectangle _rightCollision = new Rectangle(0, 0, 1, 64);
        private Rectangle _leftCollision = new Rectangle(0, 0, 1, 64);
    }
}
