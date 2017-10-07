using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG
{
    public partial class FormOverworld : Form
    {
        public FormOverworld()
        {
            InitializeComponent();
            Instance = this;
            Level.LoadLevel(1);
        }

        public static FormOverworld Instance;

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}
