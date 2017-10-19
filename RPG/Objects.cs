using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using RPG.Extensions;
using RPG.Potions;
using RPG.Properties;
using RPG.UI;
using RPG.Weapons;

namespace RPG.Objects
{
    public sealed class Wall : LevelObject
    {
        public new static List<Wall> Objects = new List<Wall>();

        public Wall(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2)
        {
            BackColor = Color.White;
            Objects.Add(this);
        }

    }

    public sealed class Grass : LevelObject
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

        public override bool IntersectsCollider(Rectangle bounds)
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

    public sealed class Entrance : LevelObject
    {
        public new static List<Entrance> Objects = new List<Entrance>();

        public int LevelID;

        public Entrance(int x1, int y1, int x2, int y2, int levelID) : base(x1, y1, x2, y2)
        {
            LevelID = levelID;
            Objects.Add(this);
        }

        public override bool IntersectsCollider(Rectangle bounds)
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

    public sealed class Door : LevelObject
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

        private bool _open;

        public Door(int x1, int y1, int x2, int y2, int id) : base(x1, y1, x2, y2)
        {
            ID = id;
            BackColor = Color.SaddleBrown;
            Objects.Add(this);
        }

        public override bool IntersectsCollider(Rectangle bounds)
        {
            return !Open && base.IntersectsCollider(bounds);
        }

        public override string GetDebugInfo()
        {
            return base.GetDebugInfo() + $", ID:{ID}, O:{Open}";
        }
    }

    public sealed class Key : LevelObject
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

        public override bool IntersectsCollider(Rectangle bounds)
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
            }
            return false;

        }

        public override string GetDebugInfo()
        {
            return base.GetDebugInfo() + $", ID:{ID}";
        }

    }

    public sealed class Floor : LevelObject
    {
        private static readonly Image Dirt = Resources.Dirt;
        private static readonly Image Tiles = Resources.Tiles;
        private enum FloorTexture
        {
            Dirt = 0,
            Tiles = 1
        }

        public new static List<Floor> Objects = new List<Floor>();

        private readonly FloorTexture _floorTexture;

        public Floor(int x1, int y1, int x2, int y2, int floor) : base(x1, y1, x2, y2)
        {
            Image temp;
            _floorTexture = (FloorTexture)floor;
            switch (_floorTexture)
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

        public override bool IntersectsCollider(Rectangle bounds) => false;

        public override string GetDebugInfo()
        {
            return base.GetDebugInfo() + $", T:{_floorTexture}";
        }
    }

    public sealed class HealthPotionLevelObject : PotionLevelObject
    {
        public HealthPotionLevelObject(int x, int y, int size) : base(x, y)
        {
            Potion = new HealthPotion((Potion.PotionSize)size);
            Image = Potion.GetImage();
            SizeMode = PictureBoxSizeMode.CenterImage;
        }

    }

    public sealed class ManaPotionLevelObject : PotionLevelObject
    {
        public ManaPotionLevelObject(int x, int y, int size) : base(x, y)
        {
            Potion = new ManaPotion((Potion.PotionSize)size);
            Image = Potion.GetImage();
            SizeMode = PictureBoxSizeMode.CenterImage;
        }
    }

    //Gør klassen abstrakt så det ikke er muligt at lave en instans af klassen.
    public abstract class PotionLevelObject : LevelObject
    {
        public Potion Potion;

        protected PotionLevelObject(int x, int y) : base (x, y, x + 32, y + 32)
        {

        }

        public override string GetDebugInfo()
        {
            return base.GetDebugInfo() + $", S:{Potion.potionSize}, V:{Visible}";
        }

        public override void IntersectsPlayer(Rectangle bounds)
        {
            if (Visible && Bounds.IntersectsWith(bounds))
            {
                Potion.ApplyEffect();
                Visible = false;
            }
        }

    }

    public sealed class WeaponChest : Chest
    {
        public Weapon Weapon;

        public WeaponChest(int x, int y) : base(x, y)
        {
            Image = Resources.WeaponChest;
            Weapon = Weapon.GenerateWeapon();
        }

        public override void IntersectsPlayer(Rectangle bounds)
        {
            if (TriggerBounds.IntersectsWith(bounds))
            {

                if (ChestUi == null)
                {
                    ChestUi.ChestUiInfo chestUiInfo = new ChestUi.ChestUiInfo(Location, "Våbenkiste", Weapon.GetWeaponImage(), Weapon.GetWeaponLongName(), Weapon.GetWeaponDescription(),
                        "Tryk mellemrum for at bytte våben." );
                    ChestUi = new ChestUi(chestUiInfo);
                }
            }
            else
            {
                ChestUi?.Dispose();
                ChestUi = null;
            }
        }
    }

    public sealed class PotionChest : Chest
    {
        public Potion Potion;

        public PotionChest(int x, int y) : base(x, y)
        {
            Image = Resources.PotionChest;
            Potion = Potion.GeneratePotion();
        }

        public override void IntersectsPlayer(Rectangle bounds)
        {
            if (TriggerBounds.IntersectsWith(bounds))
            {

                if (ChestUi == null)
                {
                    ChestUi.ChestUiInfo chestUiInfo = new ChestUi.ChestUiInfo(Location, "Elexirkiste", Potion.GetImage(),
                        Potion.GetLongName(), Potion.GetDescription(),
                        "Tryk mellemrum for at drikke elexiren.");
                    ChestUi = new ChestUi(chestUiInfo);
                }
            }
            else
            {
                ChestUi?.Dispose();
                ChestUi = null;
            }
        }
    }

    public abstract class Chest : LevelObject
    {
        protected ChestUi ChestUi;

        protected Rectangle TriggerBounds;
        protected Chest(int x, int y) : base(x, y, x + 32, y + 32)
        {
            TriggerBounds = new Rectangle(x - 48, y - 48, 96, 96);
        }

    }

    //TODO lav et bedre drawing system
    //Gør klassen abstrakt så det ikke er muligt at lave en instans af klassen.
    public abstract class LevelObject : PictureBox
    {
        public static List<LevelObject> Objects = new List<LevelObject>();

        protected LevelObject(int x1, int y1, int x2, int y2)
        {
            Location = new Point(x1, y1);
            Size = new Size(x2 - x1, y2 - y1);
            Objects.Add(this);
        }

        public virtual bool IntersectsCollider(Rectangle bounds)
        {
            return Bounds.IntersectsWith(bounds);
        }

        public virtual void IntersectsPlayer(Rectangle bounds)
        {

        }

        public virtual string GetDebugInfo()
        {
            return $"X:{Location.X}, Y:{Location.Y}, W:{Size.Width}, H:{Size.Height}";
        }

    }
}
