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
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();
        }

        private void Task1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = 0.0, S, V;

            a = double.Parse(textBox1.Text);
            S = 6 * a * a;
            V = Math.Pow(a, 3);

            this.textBox2.Text = Math.Round(S, 2).ToString();
            this.textBox3.Text = Math.Round(V, 2).ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            FirstMain firstMain = new FirstMain();
            firstMain.Show();
        }
    }
}
