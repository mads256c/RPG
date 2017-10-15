using System;
using System.Collections.Generic;
using RPG.Objects;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Threading;
using System.Windows.Forms;

namespace RPG
{
    public static class ReflectiveEnumerator
    {
        static ReflectiveEnumerator() { }

        public static List<string> GetEnumerableOfType<T>() where T : class
        {
            List<string> objects = new List<string>();
            foreach (Type type in
                Assembly.GetAssembly(typeof(T)).GetTypes()
                    .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                objects.Add(type.FullName);
            }
            objects.Sort();
            return objects;
        }
    }

    public static class Level
    {
        public static int LoadedLevel;

        public static void ClearLevel()
        {
            LevelObject.Objects.Clear();
            FormOverworld.Instance.Controls.Clear();
        }

        public static void LoadLevel(int levelID)
        {
            ClearLevel();
            Logger.WriteLine($"Changed level to: {levelID}");
            FormOverworld.Instance.Text = $"RPG - Level {levelID}";
            LoadedLevel = levelID;
            string loadID = "";

            foreach (string line in File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + $@"\Level\{levelID}.lvl"))
            {
                if (line == "Player")
                {
                    loadID = "Player";
                    goto end;
                }

                foreach (var levelObject in ReflectiveEnumerator.GetEnumerableOfType<LevelObject>())
                {
                    if (line == levelObject)
                    {
                        loadID = levelObject;
                        goto end;
                    }
                }

                string[] temp = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (loadID == "Player")
                {
                    FormOverworld.Instance.Controls.Remove(FormOverworld.OverworldPlayer);
                    FormOverworld.OverworldPlayer = new OverworldPlayer(int.Parse(temp[0]), int.Parse(temp[1]));
                    FormOverworld.Instance.Controls.Add(FormOverworld.OverworldPlayer);
                    FormOverworld.OverworldPlayer.BringToFront();
                }

                foreach (var levelObject in ReflectiveEnumerator.GetEnumerableOfType<LevelObject>())
                {
                    if (levelObject == loadID)
                    {
                        var paramsList = new List<object>();
                        foreach (var param in temp)
                        {
                            paramsList.Add(int.Parse(param));
                        }


                        FormOverworld.Instance.Controls.Add((Control)Activator.CreateInstance(Type.GetType(levelObject), paramsList.ToArray()));
                    }
                }
                end:
                ;

            }

            foreach (var levelObject in LevelObject.Objects)
            {
                FormOverworld.Instance.Controls.Add(levelObject);
            }
        }
    }
}
