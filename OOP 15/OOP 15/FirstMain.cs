using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_15
{
    public partial class FirstMain : Form
    {
        public FirstMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Task1 task1 = new Task1();
            task1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Task2 task2 = new Task2();
            task2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
