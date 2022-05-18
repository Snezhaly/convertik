using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormPresent : Form
    {
        public FormPresent()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(207, 246, 219);
            this.Text = "English Studying";
            this.Size = new System.Drawing.Size(898, 599);
            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            FormTest Ft = new FormTest("present");
            Ft.ShowDialog();
        }
    }
}
