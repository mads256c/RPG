using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RPG.Objects;
using RPG.Properties;

namespace RPG
{
    public class OverworldPlayer : PictureBox
    {
        public int Speed;

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
        }

        private Rectangle topCollision = new Rectangle(0, 0, 32, 1);
        private Rectangle bottomCollision = new Rectangle(0, 0, 32, 1);
        private Rectangle rightCollision = new Rectangle(0, 0, 1, 64);
        private Rectangle leftCollision = new Rectangle(0, 0, 1, 64);
    }
}
