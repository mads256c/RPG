using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RPG.Objects;

namespace RPG
{
    public partial class FormDebug : Form
    {
        public FormDebug()
        {
            InitializeComponent();
            treeViewObjects.Nodes.Clear();
            foreach (var obj in ReflectiveEnumerator.GetEnumerableOfType<LevelObject>())
            {
                Logger.WriteLine(obj);
                treeViewObjects.Nodes.Add(obj);
            }
            timer.Start();

        }

        private void buttonLoadLevel_Click(object sender, EventArgs e)
        {
            Level.LoadLevel((int)numericUpDownLoadLevel.Value);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            labelPlayerPosition.Text =
                $"Player position: {FormOverworld.OverworldPlayer.Location.X}, {FormOverworld.OverworldPlayer.Location.Y}";

            labelPlayerSize.Text =
                $"Player size: {FormOverworld.OverworldPlayer.Size.Width}, {FormOverworld.OverworldPlayer.Size.Height}";

            labelPlayfieldSize.Text =
                $"Playfield size: {FormOverworld.Instance.ClientSize.Width}, {FormOverworld.Instance.ClientSize.Height}";

            labelLevelID.Text = $"Level ID: {Level.LoadedLevel}";

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
