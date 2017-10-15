using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RPG.Objects;
using RPG.Properties;

namespace RPG
{
    public static class Player
    {
        public static string Name;

        public static int Health = MaxHealth;
        public static int MaxHealth => Level * 15 + Defence * 5;

        public static int MP = MaxMP;
        public static int MaxMP => Wisdom * 10;

        public static int Level = 1;
        public static int XP;
        public static int XPNeeded => Level * 100;

        public static int Strength = 1;
        public static int Wisdom = 1;
        public static int Speed = 1;

        public static int Defence = 1;
        public static int Resistance = 1;
    }


    public sealed class OverworldPlayer : PictureBox
    {
        public OverworldPlayer(int x, int y) : base()
        {

            Size = new Size(32, 64);
            Location = new Point(x, y);
            BackColor = Color.Transparent;
            Image = Resources.Player;
            UpdateCollision();
        }

        public void MoveUp()
        {
            if (LevelObject.Objects.Any(levelObject => levelObject.Intersects(topCollision)) | Location.Y <= 0)
            {
                return;
            }
            Location = new Point(Location.X, Location.Y - 1);
            UpdateCollision();

        }

        public void MoveDown()
        {
            if (LevelObject.Objects.Any(levelObject => levelObject.Intersects(bottomCollision)) | Location.Y + Size.Height > FormOverworld.Instance.ClientSize.Height)
            {
                return;
            }
            Location = new Point(Location.X, Location.Y + 1);
            UpdateCollision();
        }

        public void MoveRight()
        {
            if (LevelObject.Objects.Any(levelObject => levelObject.Intersects(rightCollision)) | Location.X + Size.Width > FormOverworld.Instance.ClientSize.Width)
            {
                return;
            }
            Location = new Point(Location.X + 1, Location.Y);
            UpdateCollision();
        }

        public void MoveLeft()
        {
            if (LevelObject.Objects.Any(levelObject => levelObject.Intersects(leftCollision)) | Location.X < 0)
            {
                return;
            }
            Location = new Point(Location.X - 1, Location.Y);
            UpdateCollision();
        }

        public void UpdateCollision()
        {
            topCollision.Location = new Point(Location.X, Location.Y - 1);
            bottomCollision.Location = new Point(Location.X, Location.Y + Size.Height);
            rightCollision.Location = new Point(Location.X + Size.Width, Location.Y);
            leftCollision.Location = new Point(Location.X - 1, Location.Y);
        }


        private Rectangle topCollision = new Rectangle(0, 0, 32, 1);
        private Rectangle bottomCollision = new Rectangle(0, 0, 32, 1);
        private Rectangle rightCollision = new Rectangle(0, 0, 1, 64);
        private Rectangle leftCollision = new Rectangle(0, 0, 1, 64);
    }
}
