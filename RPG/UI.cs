using System.Drawing;
using System.Windows.Forms;
using RPG.Extensions;
using RPG.Properties;

namespace RPG.UI
{
    public class ChestUi
    {
        public struct ChestUiInfo
        {
            public ChestUiInfo(Point location, string title, Image image, string itemTitle, string description,
                string helpText)
            {
                Location = location;
                Title = title;
                Image = image;
                ItemTitle = itemTitle;
                Description = description;
                HelpText = helpText;
            }

            public Point Location;
            public string Title;
            public Image Image;
            public string ItemTitle;
            public string Description;
            public string HelpText;
        }


        public GroupBox GroupBox;
        public PictureBox ItemBox;
        public Label ItemTitle;
        public Label ItemDescription;
        public Label HelpText;

        public ChestUi(ChestUiInfo chestUiInfo)
        {
            GroupBox = new GroupBox
            {
                Text = chestUiInfo.Title,
                BackColor = Color.Black,
                ForeColor = Color.White,
                Size = new Size(300, 100),
                Location = new Point(MathExtension.Clamp(chestUiInfo.Location.X, 0, FormOverworld.Instance.ClientSize.Width - 300),
                MathExtension.Clamp(chestUiInfo.Location.Y, 0, FormOverworld.Instance.ClientSize.Height - 100))
            };

            ItemBox = new PictureBox
            {
                BackColor = Color.Black,
                BackgroundImage = Resources.Frame,
                Image = chestUiInfo.Image,
                SizeMode = PictureBoxSizeMode.CenterImage,
                Location = new Point(15, 15),
                Size = new Size(75, 75)
            };

            ItemTitle = new Label
            {
                Text = chestUiInfo.ItemTitle,
                Location = new Point(100, 15),
                Size = new Size(GroupBox.Size.Width - 100 - 15, 15)
            };

            ItemTitle.Font = new Font(ItemTitle.Font, FontStyle.Bold);

            ItemDescription = new Label
            {
                Text = chestUiInfo.Description,
                Location = new Point(100, 45),
                Size = new Size(GroupBox.Size.Width - 100 - 15, 30)
            };

            HelpText = new Label
            {
                Text = chestUiInfo.HelpText,
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
