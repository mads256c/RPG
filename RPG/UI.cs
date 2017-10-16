using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace RPG.UI
{
    public class ChestItem
    {
        public GroupBox GroupBox;

        public PictureBox ItemBox;

        public Label ItemTitle;

        public Label ItemDescription;

        public ChestItem(int x, int y, string title, string description, Image image)
        {
            GroupBox = new GroupBox
            {
                Text = "Chest",
                BackColor = Color.Black,
                ForeColor = Color.White,
                Location = new Point(Math.Max(x, 0), Math.Max(y, 0)),
                Size = new Size(300, 100)
            };

            ItemBox = new PictureBox
            {
                Image = image,
                SizeMode = PictureBoxSizeMode.CenterImage,
                Location = new Point(15, 15),
                Size = new Size(75, 75)
            };

            ItemTitle = new Label
            {
                Text = title,
                Location = new Point(100, 15),
            };

            ItemDescription = new Label
            {
                Text = description,
                Location = new Point(100, 45),
                Size = new Size(GroupBox.Size.Width - 100 - 15, GroupBox.Size.Height - 45 - 15)
            };

            GroupBox.Controls.AddRange(new Control[]{ItemBox, ItemTitle, ItemDescription});
            FormOverworld.Instance.Controls.Add(GroupBox);
            GroupBox.BringToFront();

        }

        public void Dispose()
        {
            FormOverworld.Instance.Controls.Remove(GroupBox);
            ItemBox.Dispose();
            ItemTitle.Dispose();
            ItemDescription.Dispose();
            GroupBox.Dispose();
            Logger.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString());
        }
    }
}
