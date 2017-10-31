using System;
using System.Collections.Generic;
using System.Drawing;
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
        public Wall(Point location, Size size) : base(location, size)
        {
            BackColor = Color.White;
        }

        public Wall(int x1, int y1, int x2, int y2) : this(new Point(x1, y1), new Size(x2 - x1, y2 - y1)) { }

    }

    public sealed class Grass : LevelObject
    {
        public int EncounterRate;

        public Grass(Point location, Size size, int encounterRate) : base(location, size)
        {
            BackColor = Color.DarkGreen;
            this.SetImage(Resources.Grass);
            EncounterRate = encounterRate;
        }

        public Grass(int x1, int y1, int x2, int y2, int encounterRate) : this(new Point(x1, y1), new Size(x2 - x1, y2 - y1), encounterRate) { }

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

        public Entrance(Point location, Size size, int levelID) : base(location, size)
        {
            LevelID = levelID;
            Objects.Add(this);
        }

        public Entrance(int x1, int y1, int x2, int y2, int levelID) : this(new Point(x1, y1), new Size(x2 - x1, y2 - y1), levelID) { }

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

        public Door(Point location, Size size, int id) : base(location, size)
        {
            ID = id;
            BackColor = Color.SaddleBrown;
            Objects.Add(this);
        }

        public Door(int x1, int y1, int x2, int y2, int id) : this(new Point(x1, y1), new Size(x2 - x1, y2 - y1), id) { }

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

        public Key(Point location, Size size, int id) : base(location, size)
        {
            ID = id;
            BackColor = Color.Transparent;
            Image = Resources.Key;
            Objects.Add(this);
        }

        public Key(int x1, int y1, int x2, int y2, int id) : this(new Point(x1, y1), new Size(x2 - x1, y2 - y1), id) { }

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
        public enum FloorTexture
        {
            Dirt = 0,
            Tiles = 1
        }

        private readonly FloorTexture _floorTexture;

        public Floor(Point location, Size size, FloorTexture floorTexture) : base(location, size)
        {
            Image temp;
            _floorTexture = floorTexture;
            switch (_floorTexture)
            {
                case FloorTexture.Dirt:
                    temp = Dirt;
                    break;
                case FloorTexture.Tiles:
                    temp = Tiles;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            this.SetImage(temp);
        }

        public Floor(int x1, int y1, int x2, int y2, int floor) : this(new Point(x1, y1), new Size(x2 - x1, y2 - y1), (FloorTexture)floor) { }

        public override bool IntersectsCollider(Rectangle bounds) => false;

        public override string GetDebugInfo()
        {
            return base.GetDebugInfo() + $", T:{_floorTexture}";
        }
    }

    public sealed class HealthPotionLevelObject : PotionLevelObject
    {
        public HealthPotionLevelObject(Point location, Potion.PotionSize size) : base(location)
        {
            Potion = new HealthPotion(size);
            Image = Potion.GetImage();
            SizeMode = PictureBoxSizeMode.CenterImage;
        }

        public HealthPotionLevelObject(int x, int y, int size) : this(new Point(x, y), (Potion.PotionSize)size) { }

    }

    public sealed class ManaPotionLevelObject : PotionLevelObject
    {
        public ManaPotionLevelObject(Point location, Potion.PotionSize size) : base(location)
        {
            Potion = new ManaPotion(size);
            Image = Potion.GetImage();
            SizeMode = PictureBoxSizeMode.CenterImage;
        }

        public ManaPotionLevelObject(int x, int y, int size) : this(new Point(x, y), (Potion.PotionSize)size) { }
    }

    //Gør klassen abstrakt så det ikke er muligt at lave en instans af klassen.
    public abstract class PotionLevelObject : LevelObject
    {
        public Potion Potion;

        protected PotionLevelObject(Point location) : base (location, new Size(32, 32)) { }

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

        public WeaponChest(int x, int y) : base(new Point(x, y))
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
                    if (Weapon == null)
                    {
                        ChestUi.ChestUiInfo chestUiInfo = new ChestUi.ChestUiInfo(Location, "Våbenkiste",
                            null, "Tom", "Kisten er tom",
                            "");
                        ChestUi = new ChestUi(chestUiInfo);
                    }
                    else
                    {
                        ChestUi.ChestUiInfo chestUiInfo = new ChestUi.ChestUiInfo(Location, "Våbenkiste",
                            Weapon.GetWeaponImage(), Weapon.GetWeaponLongName(), Weapon.GetWeaponDescription(),
                            "Tryk mellemrum for at bytte våben.");
                        ChestUi = new ChestUi(chestUiInfo);
                    }
                }
            }
            else
            {
                ChestUi?.Dispose();
                ChestUi = null;
            }
        }

        protected override void UseContents()
        {
            VariableHelper.Swap(ref Weapon, ref Player.Weapon);
            ChestUi.Dispose();
            ChestUi = null;
            IntersectsPlayer(FormOverworld.OverworldPlayer.Bounds);
        }
    }

    public sealed class PotionChest : Chest
    {
        public Potion Potion;

        public PotionChest(Point location) : base(location)
        {
            Image = Resources.PotionChest;
            Potion = Potion.GeneratePotion();
        }

        public PotionChest(int x, int y) : this(new Point(x, y)) { }

        public override void IntersectsPlayer(Rectangle bounds)
        {
            if (TriggerBounds.IntersectsWith(bounds))
            {

                if (ChestUi == null)
                {
                    ChestUi.ChestUiInfo chestUiInfo;
                    if (Potion != null)
                    {
                        chestUiInfo = new ChestUi.ChestUiInfo(Location, "Elexirkiste",
                            Potion.GetImage(),
                            Potion.GetLongName(), Potion.GetDescription(),
                            "Tryk mellemrum for at drikke elexiren.");
                    }
                    else
                    {
                        chestUiInfo = new ChestUi.ChestUiInfo(Location, "Elexirkiste",
                            null,
                            "Tom", "Kisten er tom",
                            "");
                    }
                    ChestUi = new ChestUi(chestUiInfo);
                }
            }
            else
            {
                ChestUi?.Dispose();
                ChestUi = null;
            }
        }

        protected override void UseContents()
        {
            if (Potion != null)
            {
                Potion.ApplyEffect();
                Potion = null;
                ChestUi.Dispose();
                ChestUi = null;
                IntersectsPlayer(FormOverworld.OverworldPlayer.Bounds);
            }
        }
    }

    public abstract class Chest : LevelObject
    {
        protected ChestUi ChestUi;

        protected Rectangle TriggerBounds;

        protected Chest(Point location) : base(location, new Size(32, 32))
        {
            TriggerBounds = new Rectangle(new Point(location.X - 48, location.Y - 48), new Size(96, 96));
            Input.Instance.SpacePressed += SpacePressed;
        }

        private void SpacePressed()
        {
            if (TriggerBounds.IntersectsWith(FormOverworld.OverworldPlayer.Bounds))
            UseContents();
        }

        protected abstract void UseContents();

    }

    public class EnemyLevelObject : LevelObject
    {
        public Enemy Enemy;

        protected EnemyLevelObject(Point location, int health, int mana, int speed, int spriteIndex) : base(location, new Size(32, 32))
        {
            Image = Enemy.Sprites[spriteIndex];
            Enemy = new Enemy(health, mana, speed, "Ork", Image);
        }

        protected EnemyLevelObject(int x, int y, int health, int mana, int speed, int spriteIndex) : this(new Point(x, y), health, mana, speed, spriteIndex) { }
    }

    //TODO lav et bedre drawing system
    //Gør klassen abstrakt så det ikke er muligt at lave en instans af klassen.
    public abstract class LevelObject : PictureBox
    {
        public static List<LevelObject> Objects = new List<LevelObject>();

        protected LevelObject(Point location, Size size)
        {
            Location = location;
            Size = size;
            Objects.Add(this);
        }

        public virtual bool IntersectsCollider(Rectangle bounds)
        {
            return Bounds.IntersectsWith(bounds);
        }

        public virtual void IntersectsPlayer(Rectangle bounds) { }

        public virtual string GetDebugInfo()
        {
            return $"X:{Location.X}, Y:{Location.Y}, W:{Size.Width}, H:{Size.Height}";
        }

    }
}
