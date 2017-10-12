using System;
using RPG.Objects;
using System.IO;
using System.Threading;

namespace RPG
{
    public static class Level
    {
        public static int LoadedLevel;

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

        public static void ClearLevel()
        {
            Wall.Walls.Clear();
            Grass.Grasses.Clear();
            Entrance.Entrances.Clear();
            Door.Doors.Clear();
            Key.Keys.Clear();
            Floor.Floors.Clear();
            FormOverworld.Instance.Controls.Clear();
        }

        public static void LoadLevel(int levelID)
        {
            ClearLevel();
            Logger.WriteLine($"Changed level to: {levelID}");
            FormOverworld.Instance.Text = $"RPG - Level {levelID}";
            LoadedLevel = levelID;
            LoadID loadID = LoadID.None;

            foreach (string line in File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + $@"\Level\{levelID}.lvl"))
            {
                switch (line)
                {
                    case "[PLAYER]":
                        loadID = LoadID.Player;
                        continue;
                    case "[ENEMY]":
                        loadID = LoadID.Enemy;
                        continue;
                    case "[WALL]":
                        loadID = LoadID.Wall;
                        continue;
                    case "[GRASS]":
                        loadID = LoadID.Grass;
                        continue;
                    case "[ENTRANCE]":
                        loadID = LoadID.Entrance;
                        continue;
                    case "[DOOR]":
                        loadID = LoadID.Door;
                        continue;
                    case "[KEY]":
                        loadID = LoadID.Key;
                        continue;
                    case "[FLOOR]":
                        loadID = LoadID.Floor;
                        continue;
                }

                string[] temp = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                switch (loadID)
                {
                    case LoadID.Player:
                        FormOverworld.Instance.Controls.Remove(FormOverworld.OverworldPlayer);
                        FormOverworld.OverworldPlayer = new OverworldPlayer(int.Parse(temp[0]), int.Parse(temp[1]));
                        FormOverworld.Instance.Controls.Add(FormOverworld.OverworldPlayer);
                        FormOverworld.OverworldPlayer.BringToFront();
                        break;
                    case LoadID.Enemy:
                        throw new NotImplementedException();
                    case LoadID.Wall:
                        new Wall(int.Parse(temp[0]), int.Parse(temp[1]), int.Parse(temp[2]), int.Parse(temp[3]));
                        break;
                    case LoadID.Grass:
                        new Grass(int.Parse(temp[0]), int.Parse(temp[1]), int.Parse(temp[2]), int.Parse(temp[3]), int.Parse(temp[4]));
                        break;
                    case LoadID.Entrance:
                        new Entrance(int.Parse(temp[0]), int.Parse(temp[1]), int.Parse(temp[2]), int.Parse(temp[3]), int.Parse(temp[4]));
                        break;
                    case LoadID.Door:
                        new Door(int.Parse(temp[0]), int.Parse(temp[1]), int.Parse(temp[2]), int.Parse(temp[3]), int.Parse(temp[4]));
                        break;
                    case LoadID.Key:
                        new Key(int.Parse(temp[0]), int.Parse(temp[1]), int.Parse(temp[2]), int.Parse(temp[3]), int.Parse(temp[4]));
                        break;
                    case LoadID.Floor:
                        new Floor(int.Parse(temp[0]), int.Parse(temp[1]), int.Parse(temp[2]), int.Parse(temp[3]), (Floor.FloorTexture)int.Parse(temp[4]));
                        break;
                }

                foreach (var wall in Wall.Walls)
                {
                    FormOverworld.Instance.Controls.Add(wall);
                }

                foreach (var grass in Grass.Grasses)
                {
                    FormOverworld.Instance.Controls.Add(grass);
                }

                foreach (var door in Door.Doors)
                {
                    FormOverworld.Instance.Controls.Add(door);
                }

                foreach (var key in Key.Keys)
                {
                    FormOverworld.Instance.Controls.Add(key);
                }

                foreach (var floor in Floor.Floors)
                {
                    FormOverworld.Instance.Controls.Add(floor);
                    floor.SendToBack();
                }
            }
        }
    }
}
