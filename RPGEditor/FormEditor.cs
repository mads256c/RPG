using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RPG.Objects;

namespace RPGEditor
{
    public partial class FormEditor : Form
    {
        public FormEditor()
        {
            InitializeComponent();
            ClientSize = new Size(600, ClientSize.Width);
            Instance = this;
            comboBoxObjectType.Items.AddRange(InheritedClassEnumerator.GetListOfStrings<EditorObjectHelper>().ToArray());
        }

        public static FormEditor Instance;

        private string _loadId;

        public static void AddObject(string objectType)
        {
            Instance.Controls.Add((Control)Activator.CreateInstance(Type.GetType(objectType)));
        }

        public static void ClearEditor()
        {
            foreach (var editorObjectHelper in EditorObjectHelper.EditorObjectHelpers.ToArray())
            {
                editorObjectHelper.RemoveObject();
            }

            Instance.Controls.Remove(Player.player);
            Player.player = null;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {

            AddObject(comboBoxObjectType.Text);
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ClearEditor();

                _loadId = "";
                foreach (string line in File.ReadAllLines(openFileDialog.FileName))
                {
                    foreach (var levelObject in InheritedClassEnumerator.GetListOfStrings<EditorObjectHelper>())
                    {
                        if (line == levelObject)
                        {
                            _loadId = levelObject;
                            goto end;
                        }
                    }

                    string[] temp = line.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var levelObject in InheritedClassEnumerator.GetListOfStrings<EditorObjectHelper>())
                    {
                        if (levelObject == _loadId)
                        {
                            Instance.Controls.Add((Control)Activator.CreateInstance(Type.GetType(levelObject) ?? throw new ArgumentNullException(), temp.Select(param => int.Parse(param)).Cast<object>().ToArray()));
                        }
                    }

                    end:
                    ;
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var temp = new List<string>();

                temp.Add("Player");
                temp.Add($"{Player.player.Location.X},{Player.player.Location.Y}");

                foreach (var editorObjectHelper in EditorObjectHelper.EditorObjectHelpers)
                {
                    temp.Add(editorObjectHelper.GetType().FullName);
                    temp.Add(editorObjectHelper.GetFileFormat());
                }
                File.WriteAllLines(saveFileDialog.FileName, temp);
            }
        }
    }
}
