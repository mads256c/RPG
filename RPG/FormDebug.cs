using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RPG.Extensions;
using RPG.Objects;

namespace RPG
{
    /// <inheritdoc />
    /// <summary>
    /// En Debug form der kun kører når programmet debugges.
    /// </summary>
    public partial class FormDebug : Form
    {
        /// <inheritdoc />
        /// <summary>
        /// Laver en ny <see cref="T:RPG.FormDebug" />.
        /// </summary>
        public FormDebug()
        {
            InitializeComponent();
            treeViewObjects.Nodes.Clear();
            foreach (var obj in InheritedClassEnumerator.GetListOfStrings<LevelObject>())
            {
                treeViewObjects.Nodes.Add(obj);
            }
            timer.Start();

        }

        /// <summary>
        /// Kører når brugeren klikker på <see cref="buttonLoadLevel"/>.
        /// </summary>
        private void ButtonLoadLevel_Click(object sender, EventArgs e)
        {
            Level.LoadLevel((int)numericUpDownLoadLevel.Value);
        }

        /// <summary>
        /// Kører 60 gange i sekundet.
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            labelPlayerPosition.Text =
                $"Player position: {FormOverworld.OverworldPlayer.Location.X}, {FormOverworld.OverworldPlayer.Location.Y}";

            labelPlayerSize.Text =
                $"Player size: {FormOverworld.OverworldPlayer.Size.Width}, {FormOverworld.OverworldPlayer.Size.Height}";

            labelPlayfieldSize.Text =
                $"Playfield size: {FormOverworld.Instance.ClientSize.Width}, {FormOverworld.Instance.ClientSize.Height}";

            labelLevelID.Text = $"Level ID: {Level.LoadedLevel}";


            //Dette er en workaround på grund af en bug. Normalt kan man indexe treeViewNodes med en string, men den kaster en NullRefrence exception når jeg gør det på den måde.
            Dictionary<string, int> tempDictionary = new Dictionary<string, int>();

            foreach (TreeNode node in treeViewObjects.Nodes)
            {
                tempDictionary.Add(node.Text, node.Index);
                node.Nodes.Clear();
            }

            foreach (var levelObject in LevelObject.Objects)
            {
                int index = 0;
                foreach (KeyValuePair<string, int> keyPair in tempDictionary)
                {
                    if (levelObject.GetType().FullName == keyPair.Key)
                    {
                        index = keyPair.Value;
                        break;
                    }
                }
                treeViewObjects.Nodes[index].Nodes.Add(levelObject.GetDebugInfo());
            }

            treeViewObjects.ExpandAll();

            textBoxLog.Text = Logger.Log;

        }
    }
}
