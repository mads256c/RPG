using System;
using System.Collections.Generic;
using System.Linq;
using RPG.Objects;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RPG
{
    public static class Level
    {
        enum LoadID
        {
            None,
            Player,
            Enemy,
            Wall,
            Grass,
            Entrance,
            Door,
            Key
        }

        public static void ClearLevel()
        {
            Wall.Walls.Clear();
            Grass.Grasses.Clear();
            Entrance.Entrances.Clear();
            Door.Doors.Clear();
            Key.Keys.Clear();
        }

        public static void LoadLevel(int levelID)
        {
            LoadID loadID = LoadID.None;

            foreach (string line in File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + $@"\Level\{levelID}.lvl"))
            {
                switch (line)
                {
                    case "[PLAYER]":
                        loadID = LoadID.Player;
                        goto end;
                    case "[ENEMY]":
                        loadID = LoadID.Enemy;
                        goto end;
                    case "[WALL]":
                        loadID = LoadID.Wall;
                        goto end;
                    case "[GRASS]":
                        loadID = LoadID.Grass;
                        goto end;
                    case "[ENTRANCE]":
                        loadID = LoadID.Entrance;
                        goto end;
                    case "[DOOR]":
                        loadID = LoadID.Door;
                        goto end;
                    case "[KEY]":
                        loadID = LoadID.Key;
                        goto end;
                }

                string[] temp = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                switch (loadID)
                {
                    case LoadID.Player:
                        throw new NotImplementedException();
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

                end:
                ;
            }
        }
    }
}
