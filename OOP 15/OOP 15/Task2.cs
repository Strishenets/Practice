using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace OOP_15
{
    public partial class Task2 : Form
    {
        private OpenFileDialog openFileDialog1 = new OpenFileDialog();
        private SaveFileDialog saveFileDialog1 = new SaveFileDialog();

        public Task2()
        {
            InitializeComponent();
        }

        private void Task2_Load(object sender, EventArgs e)
        {

        }
        private void TextFunc()
        {
            string[] str = textBox1.Text.Split(' ');

            textBox1.Clear();

            for (int i = str.Length - 1; i >= 0; i--)
            {
                textBox1.Text += str[i] + " ";
            }

            textBox2.Text = (textBox1.Text.Length - str.Length).ToString();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextFunc();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TextFunc();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string name = saveFileDialog1.FileName;

                File.WriteAllText(name, textBox1.Text);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string name = openFileDialog1.FileName;
                textBox1.Clear();
                textBox1.Text = File.ReadAllText(name);
                textBox2.Text = (textBox1.Text.Length - textBox1.Text.Split(' ').Length).ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            FirstMain firstMain = new FirstMain();
            firstMain.Show();
        }


    }
}
