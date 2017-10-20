using System;
using System.Collections.Generic;
using RPG.Objects;
using System.IO;
using System.Windows.Forms;
using RPG.Extensions;

namespace RPG
{
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
            var loadID = "";

            foreach (var line in File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + $@"\Level\{levelID}.lvl"))
            {
                if (line == "Player")
                {
                    loadID = "Player";
                    goto end;
                }

                foreach (var levelObject in InheritedClassEnumerator.GetListOfStrings<LevelObject>())
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

                foreach (var levelObject in InheritedClassEnumerator.GetListOfStrings<LevelObject>())
                {
                    if (levelObject == loadID)
                    {
                        var paramsList = new List<object>();
                        foreach (var param in temp)
                        {
                            paramsList.Add(int.Parse(param));
                        }


                        FormOverworld.Instance.Controls.Add((Control)Activator.CreateInstance(Type.GetType(levelObject) ?? throw new ArgumentNullException(), paramsList.ToArray()));
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
