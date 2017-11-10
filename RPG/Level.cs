using System;
using RPG.Objects;
using System.IO;
using System.Windows.Forms;
using RPG.Extensions;

namespace RPG
{
    /// <summary>
    /// Denne klasse loader spillets baner.
    /// </summary>
    public static class Level
    {
        
        public static int LoadedLevel;

        /// <summary>
        /// Fjerner alle <see cref="LevelObject"/>er i <see cref="FormOverworld"/>.
        /// </summary>
        public static void ClearLevel()
        {
            foreach (var levelObject in LevelObject.Objects)
                FormOverworld.Instance.Controls.Remove(levelObject);

            LevelObject.Objects.Clear();
        }

        public static void LoadLevel(int levelId)
        {
            ClearLevel();
            Logger.WriteLine($"Changed level to: {levelId}");
            FormOverworld.Instance.Text = $"RPG - Level {levelId}";
            LoadedLevel = levelId;
            var loadId = "";

            //For hver linje i filen levelId.lvl. Hvor levelId er levelets nummer.
            foreach (var line in File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + $@"\Level\{levelId}.lvl"))
            {
                if (line == "Player")
                {
                    loadId = "Player";
                    //Går vidre til næste linje.
                    continue;
                }

                foreach (var levelObject in InheritedClassEnumerator.GetListOfStrings<LevelObject>())
                {
                    if (line == levelObject)
                    {
                        loadId = levelObject;
                        //Går vidre til næste linje.
                        goto end;
                    }
                }

                string[] parameters = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (loadId == "Player")
                {
                    FormOverworld.Instance.Controls.Remove(FormOverworld.OverworldPlayer);
                    FormOverworld.OverworldPlayer = new OverworldPlayer(int.Parse(parameters[0]), int.Parse(parameters[1]));
                    FormOverworld.Instance.Controls.Add(FormOverworld.OverworldPlayer);
                    FormOverworld.OverworldPlayer.BringToFront();
                }

                //For hver klasse der nedarver af LevelObject: Hvis loadId passer med klassens navn lav en ny instans af klassen.
                foreach (var levelObject in InheritedClassEnumerator.GetListOfStrings<LevelObject>())
                {
                    if (levelObject == loadId)
                    {
                        //Konverterer et string array til it objekt array så det kan bruges senere.
                        object[] paramsConvertor = new object[parameters.Length];
                        for (int i = 0; i < paramsConvertor.Length; i++)
                        {
                            paramsConvertor[i] = int.Parse(parameters[i]);
                        }

                        //Lav en ny instans af klassen loadId.
                        FormOverworld.Instance.Controls.Add((Control)Activator.CreateInstance(Type.GetType(levelObject) ?? throw new ArgumentNullException(), paramsConvertor));
                    }
                }

                //Nødvendig på grund af loops inde i loops. En bedre løsning skal laves
                end:;
            }

            foreach (var levelObject in LevelObject.Objects)
            {
                FormOverworld.Instance.Controls.Add(levelObject);
            }
        }
    }
}
