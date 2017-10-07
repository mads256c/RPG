using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RPG.Objects;

namespace RPG
{
    public class OverworldPlayer : PictureBox
    {
        public int Speed;

        public void MoveUp()
        {
            if (Wall.Walls.Any(wall => wall.Intersects(topCollision)) | Door.Doors.Any(door => door.Intersects(topCollision)))
            {
                return;
            }
            Location = new Point(Location.X, Location.Y - 1);
            UpdateCollision();
        }

        public void MoveDown()
        {
            if (Wall.Walls.Any(wall => wall.Intersects(bottomCollision)) | Door.Doors.Any(door => door.Intersects(bottomCollision)))
            {
                return;
            }
            Location = new Point(Location.X, Location.Y + 1);
            UpdateCollision();
        }

        public void MoveRight()
        {
            if (Wall.Walls.Any(wall => wall.Intersects(rightCollision)) | Door.Doors.Any(door => door.Intersects(rightCollision)))
            {
                return;
            }
            Location = new Point(Location.X + 1, Location.Y);
            UpdateCollision();
        }

        public void MoveLeft()
        {
            if (Wall.Walls.Any(wall => wall.Intersects(leftCollision)) | Door.Doors.Any(door => door.Intersects(leftCollision)))
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
            rightCollision.Location = new Point(Location.X - 1, Location.Y);
            leftCollision.Location = new Point(Location.X + Size.Width, Location.Y);
        }

        private Rectangle topCollision = new Rectangle(0, 0, 32, 1);
        private Rectangle bottomCollision = new Rectangle(0, 0, 32, 1);
        private Rectangle rightCollision = new Rectangle(0, 0, 1, 32);
        private Rectangle leftCollision = new Rectangle(0, 0, 1, 32);
    }
}
