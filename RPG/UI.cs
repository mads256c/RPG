using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using RPG.Extensions;
using RPG.Properties;

namespace RPG.UI
{
    public class ChestItem
    {
        public GroupBox GroupBox;

        public PictureBox ItemBox;

        public Label ItemTitle;

        public Label ItemDescription;

        public Label HelpText;

        public ChestItem(int x, int y, string title, Image image, string weaponTitle, string weaponDescription, string help)
        {
            GroupBox = new GroupBox
            {
                Text = title,
                BackColor = Color.Black,
                ForeColor = Color.White,
                Location = new Point(MathExtension.Clamp(x, 0, FormOverworld.Instance.ClientSize.Width), MathExtension.Clamp(y, 0, FormOverworld.Instance.ClientSize.Height)),
                Size = new Size(300, 100)
            };

            ItemBox = new PictureBox
            {
                BackColor = Color.Black,
                BackgroundImage = Resources.Frame,
                Image = image,
                SizeMode = PictureBoxSizeMode.CenterImage,
                Location = new Point(15, 15),
                Size = new Size(75, 75)
            };

            ItemTitle = new Label
            {
                Text = weaponTitle,
                Location = new Point(100, 15),
                Size = new Size(GroupBox.Size.Width - 100 - 15, 15)
            };

            ItemTitle.Font = new Font(ItemTitle.Font, FontStyle.Bold);

            ItemDescription = new Label
            {
                Text = weaponDescription,
                Location = new Point(100, 45),
                Size = new Size(GroupBox.Size.Width - 100 - 15, 15)
            };

            HelpText = new Label
            {
                Text = help,
                Location = new Point(100, 75),
                Size = new Size(GroupBox.Size.Width - 100 - 15, 15)
            };

            GroupBox.Controls.AddRange(new Control[]{ItemBox, ItemTitle, ItemDescription, HelpText});
            FormOverworld.Instance.Controls.Add(GroupBox);
            GroupBox.BringToFront();

        }

        public void Dispose()
        {
            FormOverworld.Instance.Controls.Remove(GroupBox);
            ItemBox.Dispose();
            ItemTitle.Dispose();
            ItemDescription.Dispose();
            HelpText.Dispose();
            GroupBox.Dispose();
        }
    }
}
