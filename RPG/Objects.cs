using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RPG.Extensions;
using RPG.Properties;

namespace RPG.Objects
{



    public class Wall : LevelObject
    {
        public new static List<Wall> Objects = new List<Wall>();

        public Wall(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2)
        {
            BackColor = Color.White;
            Objects.Add(this);
        }
    }

    public class Grass : LevelObject
    {
        public new static List<Grass> Objects = new List<Grass>();

        public int EncounterRate;

        public Grass(int x1, int y1, int x2, int y2, int encounterRate) : base(x1, y1, x2, y2)
        {
            BackColor = Color.DarkGreen;
            this.SetImage(Resources.Grass);
            EncounterRate = encounterRate;
            Objects.Add(this);
        }

        public override bool Intersects(Rectangle bounds)
        {
            if (Bounds.IntersectsWith(bounds))
            {
                if (EncounterRate != 0)
                {
                    if (Program.Random.Next(0, EncounterRate) == 0)
                    {
                        //Start battle
                    }
                }
                return true;
            }
            return false;
        }

        public override string GetDebugInfo()
        {
            return base.GetDebugInfo() + $", E:{EncounterRate}";
        }
    }

    public class Entrance : LevelObject
    {
        public new static List<Entrance> Objects = new List<Entrance>();

        public int LevelID;

        public Entrance(int x1, int y1, int x2, int y2, int levelID) : base(x1, y1, x2, y2)
        {
            LevelID = levelID;
            Objects.Add(this);
        }

        public override bool Intersects(Rectangle bounds)
        {
            if (Bounds.IntersectsWith(bounds))
            {
                Level.LoadLevel(LevelID);
                return true;
            }
            return false;

        }

        public override string GetDebugInfo()
        {
            return base.GetDebugInfo() + $", ID:{LevelID}";
        }
    }

    public class Door : LevelObject
    {
        public new static List<Door> Objects = new List<Door>();

        public int ID;

        public bool Open
        {
            get => _open;
            set
            {
                Logger.WriteLine($"Door {ID} open state changed to: {value}");
                Visible = !value;
                _open = value;
            }
        }

        private bool _open = false;

        public Door(int x1, int y1, int x2, int y2, int id) : base(x1, y1, x2, y2)
        {
            ID = id;
            BackColor = Color.SaddleBrown;
            Objects.Add(this);
        }

        public override bool Intersects(Rectangle bounds)
        {
            return !Open && base.Intersects(bounds);
        }

        public override string GetDebugInfo()
        {
            return base.GetDebugInfo() + $", ID:{ID}, O:{Open}";
        }
    }

    public class Key : LevelObject
    {
        public new static List<Key> Objects = new List<Key>();

        public int ID;

        public Key(int x1, int y1, int x2, int y2, int id) : base(x1, y1, x2, y2)
        {
            ID = id;
            BackColor = Color.Transparent;
            Image = Resources.Key;
            Objects.Add(this);
        }

        public override bool Intersects(Rectangle bounds)
        {
            if (Bounds.IntersectsWith(bounds) && Visible)
            {
                foreach (var door in Door.Objects)
                {
                    if (door.ID == ID)
                        door.Open = true;
                }
                FormOverworld.SoundPlayer.Stream = Resources.testsound;
                FormOverworld.SoundPlayer.Play();
                Visible = false;
                return true;
            }
            return false;

        }

        public override string GetDebugInfo()
        {
            return base.GetDebugInfo() + $", ID:{ID}";
        }

    }

    public class Floor : LevelObject
    {
        private static readonly Image Dirt = Resources.Dirt;
        private static readonly Image Tiles = Resources.Tiles;
        public enum FloorTexture : int
        {
            Dirt = 0,
            Tiles = 1
        }

        public new static List<Floor> Objects = new List<Floor>();

        public FloorTexture floorTexture;

        public Floor(int x1, int y1, int x2, int y2, int floor) : base(x1, y1, x2, y2)
        {
            Image temp;
            floorTexture = (FloorTexture)floor;
            switch (floorTexture)
            {
                case FloorTexture.Dirt:
                    temp = Dirt;
                    break;
                case FloorTexture.Tiles:
                    temp = Tiles;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(floor), floor, null);
            }
            this.SetImage(temp);
            Objects.Add(this);
        }

        public override bool Intersects(Rectangle bounds) => false;

        public override string GetDebugInfo()
        {
            return base.GetDebugInfo() + $", T:{floorTexture}";
        }
    }

    //TODO lav et bedre drawing system
    public class LevelObject : PictureBox
    {
        public static List<LevelObject> Objects = new List<LevelObject>();

        public LevelObject(int x1, int y1, int x2, int y2)
        {
            Location = new Point(x1, y1);
            Size = new Size(x2 - x1, y2 - y1);
            Objects.Add(this);
        }

        public virtual bool Intersects(Rectangle bounds)
        {
            return Bounds.IntersectsWith(bounds);
        }

        public virtual string GetDebugInfo()
        {
            return $"X:{Location.X}, Y:{Location.Y}, W:{Size.Width}, H:{Size.Height}";
        }

    }
}
