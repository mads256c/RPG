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
            TriggerEvents();
        }

        public void MoveUp()
        {
            if (Wall.Walls.Any(wall => wall.Intersects(topCollision)) | Door.Doors.Any(door => door.Intersects(topCollision) && !door.Open) | Location.Y < 0)
            {
                return;
            }
            Location = new Point(Location.X, Location.Y - 1);
            UpdateCollision();
            TriggerEvents();
        }

        public void MoveDown()
        {
            if (Wall.Walls.Any(wall => wall.Intersects(bottomCollision)) | Door.Doors.Any(door => door.Intersects(bottomCollision) && !door.Open) | Location.Y + Size.Height > FormOverworld.Instance.ClientSize.Height)
            {
                return;
            }
            Location = new Point(Location.X, Location.Y + 1);
            UpdateCollision();
            TriggerEvents();
        }

        public void MoveRight()
        {
            if (Wall.Walls.Any(wall => wall.Intersects(rightCollision)) | Door.Doors.Any(door => door.Intersects(rightCollision) && !door.Open) | Location.X + Size.Width > FormOverworld.Instance.ClientSize.Width)
            {
                return;
            }
            Location = new Point(Location.X + 1, Location.Y);
            UpdateCollision();
            TriggerEvents();
        }

        public void MoveLeft()
        {
            if (Wall.Walls.Any(wall => wall.Intersects(leftCollision)) | Door.Doors.Any(door => door.Intersects(leftCollision) && !door.Open ) | Location.X < 0)
            {
                return;
            }
            Location = new Point(Location.X - 1, Location.Y);
            UpdateCollision();
            TriggerEvents();
        }

        public void UpdateCollision()
        {
            topCollision.Location = new Point(Location.X, Location.Y - 1);
            bottomCollision.Location = new Point(Location.X, Location.Y + Size.Height);
            rightCollision.Location = new Point(Location.X + Size.Width, Location.Y);
            leftCollision.Location = new Point(Location.X - 1, Location.Y);
        }

        public void TriggerEvents()
        {
            foreach (var key in Key.Keys.ToList())
            {
                key.Intersects(Bounds);
            }
            foreach (var entrance in Entrance.Entrances.ToList())
            {
                entrance.Intersects(Bounds);
            }

            foreach (var grass in Grass.Grasses.ToList())
            {
                grass.Intersects(Bounds);
            }
        }

        private Rectangle topCollision = new Rectangle(0, 0, 32, 1);
        private Rectangle bottomCollision = new Rectangle(0, 0, 32, 1);
        private Rectangle rightCollision = new Rectangle(0, 0, 1, 64);
        private Rectangle leftCollision = new Rectangle(0, 0, 1, 64);
    }
}
