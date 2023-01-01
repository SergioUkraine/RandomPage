using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;

namespace RandomPage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            Random random = new Random();

            string[] history = richTextBox1.Text.Split(" | ", StringSplitOptions.RemoveEmptyEntries);

            bool isNumber1 = int.TryParse (textBox1.Text, out int pageNumb);

            bool isNumber3 = int.TryParse(textBox3.Text, out int pageStart);

            if (!checkBox2.Checked) pageStart = 1;


            if (!isNumber1 || pageNumb < 0)
            {
                label4.Text = "¬ведена максимальна к≥льк≥сть стор≥нок не д≥йсна";
            }
            else if ((!isNumber3 || pageNumb < 0) && checkBox2.Checked)
            {
                label4.Text = "¬ведена м≥нимальна к≥льк≥сть стор≥нок не д≥йсна";
            }
            else if ((pageStart >= pageNumb) && checkBox2.Checked)
            {
                label4.Text = "ѕочатокова стор≥нка маЇ бути меньшою за загальну к≥лк≥сть";
            }

            else


            {
                int randomPage;

                if (history.Length == (1 + pageNumb - pageStart) && checkBox1.Checked)
                {
                    label4.Text = "”н≥кальн≥ стор≥нки зак≥нчились. \nЅудь ласка, очист≥ть ≥стор≥ю стор≥нок";
                    return;
                }

                if (checkBox1.Checked)
                {
                    do
                    {
                        randomPage = random.Next(pageStart, pageNumb + 1);
                    }
                    while (history.Contains(randomPage.ToString()));
                }
                else
                {
                    randomPage = random.Next(pageStart, pageNumb + 1);
                }

                textBox2.Text = randomPage.ToString();
                richTextBox1.Text = "";
                for (int i = 0; i < history.Length + 1; i++)
                {
                    if (i == history.Length)
                    {
                        richTextBox1.Text += randomPage.ToString();
                    }
                    else
                    {
                        richTextBox1.Text += history[i].ToString() + " | ";
                    }

                }

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) textBox3.ReadOnly = false;
            else textBox3.ReadOnly = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)richTextBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) richTextBox1.Text = "";
        }
    }
}