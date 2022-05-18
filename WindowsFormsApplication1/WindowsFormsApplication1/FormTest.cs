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
    public partial class FormTest : Form
    {
        bool testGo = false;
        int minute = 30;
        int second = 0;
        string mode = "";
        string[,] questPresent = new string[,]    //Present
        {
            {"I .... Spanish with my sister." , "Study" , "Studies" , "studied " , "studying" },
            {"My sister .... a shower every morning." , "take " , "takes" , "taken" , "taking" },
            {"This house .... to my grandmother." , "belong " , "belongs" , "belonging" , "belongings" },
            {"We .... to go for a walk in the morning." , "like " , "likes" , "likewise" , "likely" },
            {"My husband and I .... a lot of money on books." , "spend " , "spends" , "spent" , "spending" }
        };
        int[] true_Present = new int[] { 1, 2, 2, 1, 1 }; // Массив с правильными ответами  

        string[,] questPast = new string[,]       //Past
        {
            {"Two years ago I … my old aunt in a small old town." , "visit" , "visited" , "visitted" , "didn't visited" },
            {"It … a long visit as my aunt … well." , "was…didn't feel" , "was…didn't fall" , "was…wasn't feel" , "did…didn't felt" },
            {"I … to … medicine and food." , "have…buyed" , "had…bought" , "had…buy" , "haved…buyed" },
            {"I also … dinner and … about the house." , "cook…helped" , "cooked…helped" , "cook…held" , "cooked…help" },
            {"One day my aunt asked me: … the flowers in the garden yesterday?." , "Did you water" , "You watered" , "Did you watered" , "You did water" },
        };
        int[] true_Past = new int[] { 2, 1, 3, 2, 1 }; // Массив с правильными ответами 

        string[,] questFuture = new string[,]     //Future
        {
            {"It’s late. I think I … a taxi." , "shall take" , "am take" , "will take " , "taking" },
            {"We don’t know their address. What … ?" , "will we do" , "are we do " , "shall we do" , "the we do" },
            {"You … in Paris tomorrow evening." , "arrive" , "will arrive" , "arriving" , "was arrived" },
            {"The boy … this day all his life." , "will remember " , "remembers" , "should remember" , "remembered" },
            {"I’m not sure I … Jim at the hotel." , "shall found" , "found " , "shall find" , "was founded" }
        };
        int[] true_Furute = new int[] { 1, 3, 2, 1, 3 }; // Массив с правильными ответами 

        string[,] newLevel = new string[,]     //newLevel
        {
            {"12344" , "123" , "123" , "123 " , "123" },
            {"12344" , "123" , "123" , "123 " , "123" },
            {"12344" , "123" , "123" , "123 " , "123" },
            {"12344" , "123" , "123" , "123 " , "123" },
            {"12344" , "123" , "123" , "123 " , "123" }
        };
        int[] true_newLevel= new int[] { 1, 3, 2, 1, 3 }; // Массив с правильными ответами 

        int[] user_responses = new int[5]; // Массив с ответами пользователя
        int number_questions = 0;
        int number_points = 0;  // Количество правильных ответов
        public FormTest(string temp)
        {
            InitializeComponent();
            mode = temp;
            this.BackColor = Color.FromArgb(207, 246, 219);
            this.Text = "English Te";
            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            label1.Text = "00 : 00";

            label2.Visible = false;
            label3.Visible = false;
            button3.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testGo = true;
            button1.Enabled = false;
            button2.Enabled = true;
            timer1.Enabled = true;
            minute = 30;
            second = 0;
            test();
            label2.Visible = true;
            label3.Visible = true;
            button3.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            testGo = false;
            button1.Enabled = false;
            button2.Enabled = false;
            timer1.Enabled = false;
            label2.Visible = false;
            label3.Visible = false;
            button3.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            result();
            button4.Visible = true;
            label4.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (second > 0)
                second--;
            else
            {
                if (minute > 0)
                {
                    minute--;
                    second = 59;
                }
                else
                {
                    timer1.Enabled = false;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    MessageBox.Show("К сожалению время вышло. Прочтите материал по выбранному времени еще раз и пройдите тест заново");
                }

            }
            if (minute < 10) label1.Text = "0" + minute + " : ";
            else label1.Text = minute + " : ";
            if (second < 10) label1.Text += "0" + second;
            else label1.Text += second;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true || radioButton4.Checked == true)
            {
                if (radioButton1.Checked == true) { user_responses[number_questions] = 1; }
                else if (radioButton2.Checked == true) { user_responses[number_questions] = 2; }
                else if (radioButton3.Checked == true) { user_responses[number_questions] = 3; }
                else { user_responses[number_questions] = 4; }
                number_questions++; // Следующий вопрос

                if (number_questions == 5)// Если дали ответ на все вопросы
                {
                    label2.Visible = false;
                    label3.Visible = false;
                    button3.Visible = false;
                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                    radioButton3.Visible = false;
                    radioButton4.Visible = false;
                    timer1.Enabled = false;

                }
                else
                {
                    label3.Text = (number_questions + 1) + "/5";
                    radioButton1.Checked = false;   // Сброс состояния
                    radioButton2.Checked = false;   // Сброс состояния
                    radioButton3.Checked = false;   // Сброс состояния
                    radioButton4.Checked = false;   // Сброс состояния
                    test(); // Переход к выполнению теста
                }

            }
            else
            {
                MessageBox.Show("Выберите одно из утверждений!");
            }
        }

        public void test() //Вывод утверждений
        {
            if (mode == "present")
            {
                label2.Text = questPresent[number_questions, 0];
                radioButton1.Text = questPresent[number_questions, 1];
                radioButton2.Text = questPresent[number_questions, 2];
                radioButton3.Text = questPresent[number_questions, 3];
                radioButton4.Text = questPresent[number_questions, 4];
            }
           else if (mode == "past")
            {
                label2.Text = questPast[number_questions, 0];
                radioButton1.Text = questPast[number_questions, 1];
                radioButton2.Text = questPast[number_questions, 2];
                radioButton3.Text = questPast[number_questions, 3];
                radioButton4.Text = questPast[number_questions, 4];
            }
            else if (mode == "future")
            {
                label2.Text = questFuture[number_questions, 0];
                radioButton1.Text = questFuture[number_questions, 1];
                radioButton2.Text = questFuture[number_questions, 2];
                radioButton3.Text = questFuture[number_questions, 3];
                radioButton4.Text = questFuture[number_questions, 4];
            }
            else if (mode == "new_level")
            {
                label2.Text = newLevel[number_questions, 0];
                radioButton1.Text = newLevel[number_questions, 1];
                radioButton2.Text = newLevel[number_questions, 2];
                radioButton3.Text = newLevel[number_questions, 3];
                radioButton4.Text = newLevel[number_questions, 4];
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //проверка
        public void result()
        {
            if (mode == "present")
            {
                for (int i = 0; i < user_responses.Length; i++)
                {
                    if (user_responses[i] == true_Present[i])
                    {
                        number_points++;
                    }
                }

            }
            else if (mode == "past")
            {
                for (int i = 0; i < user_responses.Length; i++)
                {
                    if (user_responses[i] == true_Past[i])
                    {
                        number_points++;
                    }
                }
            }
            else if (mode == "future")
            {
                for (int i = 0; i < user_responses.Length; i++)
                {
                    if (user_responses[i] == true_Furute[i])
                    {
                        number_points++;
                    }
                }
            }
            else if (mode == "new_level")
            {
                for (int i = 0; i < user_responses.Length; i++)
                {
                    if (user_responses[i] == true_newLevel[i])
                    {
                        number_points++;
                    }
                }
            }
            label4.Text = "Ваш результат: " + number_points + " из " + user_responses.Length;
        }
    }
}
