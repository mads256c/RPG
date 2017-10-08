using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RPG.Objects;

namespace RPG
{
    public partial class FormDebug : Form
    {
        public FormDebug()
        {
            InitializeComponent();
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


            for (int i = 0; i < treeViewObjects.Nodes.Count; i++)
            {
                treeViewObjects.Nodes[i].Nodes.Clear();
                switch (i)
                {
                    case 0:
                        foreach (var wall in Wall.Walls)
                        {
                            treeViewObjects.Nodes[i].Nodes
                                .Add($"X: {wall.Location.X}, Y: {wall.Location.Y}, W: {wall.Size.Width}, H: {wall.Size.Height}");
                        }
                        break;
                    case 1:
                        foreach (var grass in Grass.Grasses)
                        {
                            treeViewObjects.Nodes[i].Nodes
                                .Add($"X: {grass.Location.X}, Y: {grass.Location.Y}, W: {grass.Size.Width}, H: {grass.Size.Height}, E: {grass.EncounterRate}");
                        }
                        break;
                    case 2:
                        foreach (var entrance in Entrance.Entrances)
                        {
                            treeViewObjects.Nodes[i].Nodes
                                .Add($"X: {entrance.Bounds.Location.X}, Y: {entrance.Bounds.Location.Y}, W: {entrance.Bounds.Size.Width}, H: {entrance.Bounds.Size.Height}, ID: {entrance.LevelID}");
                        }
                        break;
                    case 3:
                        foreach (var door in Door.Doors)
                        {
                            treeViewObjects.Nodes[i].Nodes
                                .Add($"X: {door.Location.X}, Y: {door.Location.Y}, W: {door.Size.Width}, H: {door.Size.Height}, ID: {door.ID}, O: {door.Open}");
                        }
                        break;
                    case 4:
                        foreach (var key in Key.Keys)
                        {
                            treeViewObjects.Nodes[i].Nodes
                                .Add($"X: {key.Location.X}, Y: {key.Location.Y}, W: {key.Size.Width}, H: {key.Size.Height}, ID: {key.ID}, V: {key.Visible}");
                        }
                        break;
                }
            }
            treeViewObjects.ExpandAll();

            textBoxLog.Text = Logger.Log;

        }
    }
}
