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
    public partial class Form1 : Form
    {
        bool lang = true;

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(207, 246, 219);
            this.Text = "English Tests";
            this.Size = new System.Drawing.Size(898, 599);
            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void buttonTrans_Click(object sender, EventArgs e)
        {
            if (lang == true)
            {
                //buttonHelp.Text = "Помощь";
                //buttonTrans.Text = "Перевести";
                //buttonLit.Text = "Литература";
                //buttonExit.Text = "Выход";
                labelTitle.Text = "Объектно-ориентированная модель для обучения английскому языку";
                labelText.Text = "Выберите одно из трех времен";
                button1.Text = "Настоящее";
                button2.Text = "Прошедшее";
                button3.Text = "Будущее";
                lang = false;
            }
            else if (lang == false)
            {
                //buttonHelp.Text = "Help";
                //buttonTrans.Text = "Translate";
                //buttonLit.Text = "Literature";
                //buttonExit.Text = "Exit";
                labelTitle.Text = "Objective-oriented model for English Styudying";
                labelText.Text = "Choose one of the three simple times";
                button1.Text = "Present Simple";
                button2.Text = "  Past   Simple";
                button3.Text = "Future Simple";
                lang = true;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPresent FPrs = new FormPresent();
            FPrs.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormPast FPast = new FormPast();
            FPast.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormFuture FFut = new FormFuture();
            FFut.ShowDialog();
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            FormTest Ft = new FormTest("new_level");
            Ft.ShowDialog();
        }
    }
}
