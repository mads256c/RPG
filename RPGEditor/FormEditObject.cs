using System;
using System.Windows.Forms;

namespace RPGEditor
{
    public struct FormEditObjectInfo
    {
        public FormEditObjectInfo(int x1, int y1, int x2, int y2, int ID)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.ID = ID;
        }
        public int x1, y1, x2, y2;
        public int ID;
    }

    public partial class FormEditObject : Form
    {
        public FormEditObject(int x1, int y1, int x2, int y2, int? id)
        {
            InitializeComponent();

            numericUpDownX1.Value = x1;
            numericUpDownY1.Value = y1;
            numericUpDownX2.Value = x2;
            numericUpDownY2.Value = y2;

            if (id == null)
            {
                groupBoxID.Visible = false;
            }
            else
            {
                groupBoxID.Visible = true;
                numericUpDownID.Value = (int)id;
            }
        }

        public FormEditObjectInfo FormEditObjectInfo;


        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            FormEditObjectInfo = new FormEditObjectInfo((int) numericUpDownX1.Value, (int) numericUpDownY1.Value, (int) numericUpDownX2.Value, (int) numericUpDownY2.Value, (int) numericUpDownID.Value);
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
