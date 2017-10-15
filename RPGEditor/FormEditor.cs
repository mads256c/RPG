using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGEditor
{
    public partial class FormEditor : Form
    {
        public FormEditor()
        {
            InitializeComponent();
            ClientSize = new Size(600, ClientSize.Width);
            Instance = this;
            comboBoxObjectType.Items.AddRange(Enum.GetNames(typeof(ObjectType)));
        }

        public static FormEditor Instance;

        private enum LoadID
        {
            None,
            Player,
            Enemy,
            Wall,
            Grass,
            Entrance,
            Door,
            Key,
            Floor
        }

        public static void AddObject(ObjectType objectType)
        {
            switch (objectType)
            {
                case ObjectType.Player:
                    Instance.Controls.Add(new Player(0,0));
                    break;
                case ObjectType.Wall:
                    Instance.Controls.Add(new Wall(0,0,100,100));
                    break;
                case ObjectType.Grass:
                    Instance.Controls.Add(new Grass(0, 0, 100, 100, 0));
                    break;
                case ObjectType.Entrance:
                    Instance.Controls.Add(new Entrance(0, 0, 100, 100, 0));
                    break;
                case ObjectType.Door:
                    Instance.Controls.Add(new Door(0, 0, 100, 100, 0));
                    break;
                case ObjectType.Key:
                    Instance.Controls.Add(new Key(0, 0, 100, 100, 0));
                    break;
                case ObjectType.Floor:
                    Instance.Controls.Add(new Floor(0, 0, 100, 100, 0));
                    break;
            }
        }

        public static void ClearEditor()
        {
            foreach (var wall in Wall.Walls.ToList())
            {
                wall.RemoveObject();
                Instance.Controls.Remove(wall);
            }

            foreach (var grass in Grass.Grasses.ToList())
            {
                grass.RemoveObject();
                Instance.Controls.Remove(grass);
            }

            foreach (var entrance in Entrance.Entrances.ToList())
            {
                entrance.RemoveObject();
                Instance.Controls.Remove(entrance);
            }

            foreach (var door in Door.Doors.ToList())
            {
                door.RemoveObject();
                Instance.Controls.Remove(door);
            }

            foreach (var key in Key.Keys.ToList())
            {
                key.RemoveObject();
                Instance.Controls.Remove(key);
            }

            foreach (var floor in Floor.Floors.ToList())
            {
                floor.RemoveObject();
                Instance.Controls.Remove(floor);
            }

            Instance.Controls.Remove(Player.player);
            Player.player = null;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            AddObject((ObjectType)Enum.Parse(typeof(ObjectType), comboBoxObjectType.Text));
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ClearEditor();

                LoadID loadID = LoadID.None;
                foreach (string line in File.ReadAllLines(openFileDialog.FileName))
                {
                    switch (line)
                    {
                        case "Player":
                            loadID = LoadID.Player;
                            continue;
                        case "RPG.Entities.Enemy":
                            loadID = LoadID.Enemy;
                            continue;
                        case "RPG.Objects.Wall":
                            loadID = LoadID.Wall;
                            continue;
                        case "RPG.Objects.Grass":
                            loadID = LoadID.Grass;
                            continue;
                        case "RPG.Objects.Entrance":
                            loadID = LoadID.Entrance;
                            continue;
                        case "RPG.Objects.Door":
                            loadID = LoadID.Door;
                            continue;
                        case "RPG.Objects.Key":
                            loadID = LoadID.Key;
                            continue;
                        case "RPG.Objects.Floor":
                            loadID = LoadID.Floor;
                            continue;
                    }

                    string[] temp = line.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                    switch (loadID)
                    {
                        case LoadID.Player:
                            Instance.Controls.Remove(Player.player);
                            Player.player = new Player(int.Parse(temp[0]), int.Parse(temp[1]));
                            Instance.Controls.Add(Player.player);
                            break;
                        case LoadID.Enemy:
                            throw new NotImplementedException();
                        case LoadID.Wall:
                            Instance.Controls.Add(new Wall(int.Parse(temp[0]), int.Parse(temp[1]), int.Parse(temp[2]), int.Parse(temp[3])));
                            break;
                        case LoadID.Grass:
                            Instance.Controls.Add(new Grass(int.Parse(temp[0]), int.Parse(temp[1]), int.Parse(temp[2]), int.Parse(temp[3]),
                                int.Parse(temp[4])));
                            break;
                        case LoadID.Entrance:
                            Instance.Controls.Add(new Entrance(int.Parse(temp[0]), int.Parse(temp[1]), int.Parse(temp[2]), int.Parse(temp[3]),
                                int.Parse(temp[4])));
                            break;
                        case LoadID.Door:
                            Instance.Controls.Add(new Door(int.Parse(temp[0]), int.Parse(temp[1]), int.Parse(temp[2]), int.Parse(temp[3]),
                                int.Parse(temp[4])));
                            break;
                        case LoadID.Key:
                            Instance.Controls.Add(new Key(int.Parse(temp[0]), int.Parse(temp[1]), int.Parse(temp[2]), int.Parse(temp[3]),
                                int.Parse(temp[4])));
                            break;
                    }
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<string> temp = new List<string>();

                temp.Add("Player");
                temp.Add($"{Player.player.Location.X},{Player.player.Location.Y}");

                temp.Add("RPG.Objects.Wall");
                foreach (var wall in Wall.Walls)
                {
                    temp.Add($"{wall.Location.X},{wall.Location.Y},{wall.Location.X + wall.Size.Width},{wall.Location.Y + wall.Size.Height}");
                }

                temp.Add("RPG.Objects.Grass");
                foreach (var grass in Grass.Grasses)
                {
                    temp.Add($"{grass.Location.X},{grass.Location.Y},{grass.Location.X + grass.Size.Width},{grass.Location.Y + grass.Size.Height},{grass.EncounterRate}");
                }

                temp.Add("RPG.Objects.Entrances");
                foreach (var entrance in Entrance.Entrances)
                {
                    temp.Add($"{entrance.Location.X},{entrance.Location.Y},{entrance.Location.X + entrance.Size.Width},{entrance.Location.Y + entrance.Size.Height},{entrance.LevelID}");
                }

                temp.Add("RPG.Objects.Door");
                foreach (var door in Door.Doors)
                {
                    temp.Add($"{door.Location.X},{door.Location.Y},{door.Location.X + door.Size.Width},{door.Location.Y + door.Size.Height},{door.ID}");
                }

                temp.Add("RPG.Objects.Key");
                foreach (var key in Key.Keys)
                {
                    temp.Add($"{key.Location.X},{key.Location.Y},{key.Location.X + key.Size.Width},{key.Location.Y + key.Size.Height},{key.ID}");
                }

                temp.Add("RPG.Objects.Floor");
                foreach (var floor in Floor.Floors)
                {
                    temp.Add($"{floor.Location.X},{floor.Location.Y},{floor.Location.X + floor.Size.Width},{floor.Location.Y + floor.Size.Height},{floor.TextureID}");
                }
                File.WriteAllLines(saveFileDialog.FileName, temp);
            }
        }
    }
}
