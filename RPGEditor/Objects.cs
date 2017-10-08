using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGEditor
{
    public enum ObjectType
    {
        Player,
        Wall,
        Grass,
        Entrance,
        Door,
        Key
    }

    public class Player : PictureBox
    {
        public static Player player = null;

        public static ContextMenu ContextMenu;

        public Player(int x, int y) : base()
        {
            BackColor = Color.Red;
            Location = new Point(x, y);
            Size = new Size(32, 64);
            MouseDown += Player_MouseDown;
            MouseMove += Player_MouseMove;
            MouseUp += Player_MouseUp;
            player = this;
        }

        public virtual void EditObject()
        {
            using (FormEditObject formEditObject = new FormEditObject(Location.X, Location.Y, Location.X + Size.Width,
                Location.Y + Size.Height, null))
            {
                if (formEditObject.ShowDialog() == DialogResult.OK)
                {
                    var info = formEditObject.FormEditObjectInfo;
                    Location = new Point(info.x1, info.y1);
                }
            }
        }

        public virtual void RemoveObject()
        {
            player = null;
        }

        void EditorObject_EditClick(object sender, EventArgs e)
        {
            EditObject();
        }

        void EditorObject_RemoveClick(object sender, EventArgs e)
        {
            FormEditor.Instance.Controls.Remove(this);
            RemoveObject();
        }

        void Player_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                activeControl = sender as Control;
                lastPoint = e.Location;
            }
            else if (e.Button == MouseButtons.Right)
            {
                ContextMenu = new ContextMenu(new[]
                    {new MenuItem("Edit", EditorObject_EditClick), new MenuItem("Remove", EditorObject_RemoveClick)});
                ContextMenu.Show(this, this.PointToClient(Cursor.Position));
            }

        }

        void Player_MouseMove(object sender, MouseEventArgs e)
        {
            if (activeControl == null || activeControl != sender)
                return;
            var location = activeControl.Location;
            location.Offset(e.Location.X - lastPoint.X, e.Location.Y - lastPoint.Y);
            activeControl.Location = location;
        }

        void Player_MouseUp(object sender, MouseEventArgs e)
        {
            activeControl = null;
        }

        private Control activeControl;
        private Point lastPoint;
    }

    public class Wall : EditorObject
    {
        public static List<Wall> Walls = new List<Wall>();

        public Wall(int x1, int y1, int x2, int y2)
        {
            BackColor = Color.White;
            Location = new Point(x1, y1);
            Size = new Size(x2 - x1, y2 - y1);
            Walls.Add(this);
        }

        public override void RemoveObject()
        {
            Walls.Remove(this);
        }
    }

    public class Grass : EditorObject
    {
        public static List<Grass> Grasses = new List<Grass>();

        public Grass(int x1, int y1, int x2, int y2, int encounterRate)
        {
            Location = new Point(x1, y1);
            Size = new Size(x2 - x1, y2 - y1);
            EncounterRate = encounterRate;
            BackColor = Color.DarkGreen;
            Grasses.Add(this);
        }

        public int EncounterRate = 0;

        public override void EditObject()
        {
            using (FormEditObject formEditObject = new FormEditObject(Location.X, Location.Y, Location.X + Size.Width,
                Location.Y + Size.Height, EncounterRate))
            {
                if (formEditObject.ShowDialog() == DialogResult.OK)
                {
                    var info = formEditObject.FormEditObjectInfo;
                    Location = new Point(info.x1, info.y1);
                    Size = new Size(info.x2 - info.x1, info.y2 - info.y1);
                    EncounterRate = info.ID;
                }
            }
        }

        public override void RemoveObject()
        {
            Grasses.Remove(this);
        }
    }

    public class Entrance : EditorObject
    {
        public static List<Entrance> Entrances = new List<Entrance>();

        public Entrance(int x1, int y1, int x2, int y2, int id)
        {
            Location = new Point(x1, y1);
            Size = new Size(x2 - x1, y2 - y1);
            LevelID = id;
            BackColor = Color.Aqua;
            Entrances.Add(this);
        }

        public int LevelID = 0;

        public override void EditObject()
        {
            using (FormEditObject formEditObject = new FormEditObject(Location.X, Location.Y, Location.X + Size.Width,
                Location.Y + Size.Height, LevelID))
            {
                if (formEditObject.ShowDialog() == DialogResult.OK)
                {
                    var info = formEditObject.FormEditObjectInfo;
                    Location = new Point(info.x1, info.y1);
                    Size = new Size(info.x2 - info.x1, info.y2 - info.y1);
                    LevelID = info.ID;
                }
            }
        }

        public override void RemoveObject()
        {
            Entrances.Remove(this);
        }
    }

    public class Door : EditorObject
    {
        public static List<Door> Doors = new List<Door>();

        public int ID = 0;

        public Door(int x1, int y1, int x2, int y2, int id)
        {
            Location = new Point(x1, y1);
            Size = new Size(x2 - x1, y2 - y1);
            ID = id;
            BackColor = Color.SaddleBrown;
            Doors.Add(this);
        }

        public override void EditObject()
        {
            using (FormEditObject formEditObject = new FormEditObject(Location.X, Location.Y, Location.X + Size.Width,
                Location.Y + Size.Height, ID))
            {
                if (formEditObject.ShowDialog() == DialogResult.OK)
                {
                    var info = formEditObject.FormEditObjectInfo;
                    Location = new Point(info.x1, info.y1);
                    Size = new Size(info.x2 - info.x1, info.y2 - info.y1);
                    ID = info.ID;
                }
            }
        }

        public override void RemoveObject()
        {
            Doors.Remove(this);
        }
    }

    public class Key : EditorObject
    {
        public static List<Key> Keys = new List<Key>();

        public int ID = 0;

        public Key(int x1, int y1, int x2, int y2, int id)
        {
            Location = new Point(x1, y1);
            Size = new Size(x2 - x1, y2 - y1);
            ID = id;
            BackColor = Color.Goldenrod;
            Keys.Add(this);
        }

        public override void EditObject()
        {
            using (FormEditObject formEditObject = new FormEditObject(Location.X, Location.Y, Location.X + Size.Width,
                Location.Y + Size.Height, ID))
            {
                if (formEditObject.ShowDialog() == DialogResult.OK)
                {
                    var info = formEditObject.FormEditObjectInfo;
                    Location = new Point(info.x1, info.y1);
                    Size = new Size(info.x2 - info.x1, info.y2 - info.y1);
                    ID = info.ID;
                }
            }
        }

        public override void RemoveObject()
        {
            Keys.Remove(this);
        }
    }

    //Fra stackoverflow. Lavet meget om af mig.
    public class EditorObject : SizeablePictureBox
    {
        public static ContextMenu ContextMenu;

        public EditorObject() : base()
        {
            MouseDown += EditorObject_MouseDown;
            MouseMove += EditorObject_MouseMove;
            MouseUp += EditorObject_MouseUp;
        }

        public virtual void EditObject()
        {
            using (FormEditObject formEditObject = new FormEditObject(Location.X, Location.Y, Location.X + Size.Width,
                Location.Y + Size.Height, null))
            {
                if (formEditObject.ShowDialog() == DialogResult.OK)
                {
                    var info = formEditObject.FormEditObjectInfo;
                    Location = new Point(info.x1, info.y1);
                    Size = new Size(info.x2 - info.x1, info.y2 - info.y1);
                }
            }
        }

        public virtual void RemoveObject()
        {

        }

        void EditorObject_EditClick(object sender, EventArgs e)
        {
            EditObject();
        }

        void EditorObject_RemoveClick(object sender, EventArgs e)
        {
            FormEditor.Instance.Controls.Remove(this);
            RemoveObject();
        }

        void EditorObject_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                activeControl = sender as Control;
                lastPoint = e.Location;
            }
            else if (e.Button == MouseButtons.Right)
            {
                ContextMenu = new ContextMenu(new[]
                    {new MenuItem("Edit", EditorObject_EditClick), new MenuItem("Remove", EditorObject_RemoveClick)});
                ContextMenu.Show(this, this.PointToClient(Cursor.Position));
            }

        }

        void EditorObject_MouseMove(object sender, MouseEventArgs e)
        {
            if (activeControl == null || activeControl != sender)
                return;
            var location = activeControl.Location;
            location.Offset(e.Location.X - lastPoint.X, e.Location.Y - lastPoint.Y);
            activeControl.Location = location;
        }

        void EditorObject_MouseUp(object sender, MouseEventArgs e)
        {
            activeControl = null;
        }

        private Control activeControl;
        private Point lastPoint;
    }

    //Fra stackoverflow
    public class SizeablePictureBox : PictureBox
    {
        public SizeablePictureBox()
        {
            this.ResizeRedraw = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var rc = new Rectangle(this.ClientSize.Width - grab, this.ClientSize.Height - grab, grab, grab);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                var pos = this.PointToClient(new Point(m.LParam.ToInt32()));
                if (pos.X >= this.ClientSize.Width - grab && pos.Y >= this.ClientSize.Height - grab)
                    m.Result = new IntPtr(17);  // HT_BOTTOMRIGHT
            }
        }
        private const int grab = 16;
    }
}
