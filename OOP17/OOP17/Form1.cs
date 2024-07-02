using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

namespace OOP17
{
    public partial class Form1 : Form
    {
        Pentagon pentagon;
        Graphics graphics;
        Pen pen;

        public Form1()
        {
            InitializeComponent();

            graphics = pictureBox1.CreateGraphics();
            pen = new Pen(Color.Black, 2);
            pentagon = new Pentagon();

            textBox1.TextChanged += TextBox1_TextChanged;
        }

        [Serializable]
        public class Pentagon
        {
            public float r { get; set; }

            public Pentagon()
            {
                r = 0;
            }

            public Pentagon(float r)
            {
                if (r < 1.0f)
                    throw new ArgumentException("Радіус повинен бути не менше 1.0", nameof(r));

                this.r = r;
            }

            public void Draw(Graphics graphics, Pen pen, int centerX, int centerY)
            {
                if (r == 0)
                    return;

                double side = 2 * r * 0.587;
                double angle = 1.2566;

                PointF[] points = new PointF[5];
                for (int i = 0; i < 5; i++)
                {
                    points[i] = new PointF(
                        centerX + (float)(r * Math.Cos(i * angle)),
                        centerY + (float)(r * Math.Sin(i * angle))
                    );
                }

                graphics.Clear(Color.White);
                graphics.DrawPolygon(pen, points);
            }

            public string Reflection()
            {
                Type t = typeof(Pentagon);
                string rez = "";

                MethodInfo[] x = t.GetMethods();
                foreach (MethodInfo m in x)
                {
                    rez = rez + m.ToString() + "\n";
                }

                return rez;
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (char i in textBox1.Text)
            {
                if (!Char.IsDigit(i))
                    return;
            }

            if (textBox1.Text != "")
            {
                pentagon.r = Convert.ToInt32(textBox1.Text);
                int centerX = pictureBox1.Width / 2;
                int centerY = pictureBox1.Height / 2;
                pentagon.Draw(graphics, pen, centerX, centerY);
            }
        }

        private void LoadSerializablePent()
        {
            if (File.Exists("Pentagon.xml"))
            {
                var xmlSerializer = new XmlSerializer(typeof(Pentagon));

                var fs = new FileStream("Pentagon.xml", FileMode.Open);

                pentagon = (Pentagon)xmlSerializer.Deserialize(fs);
                fs.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var xmlSerializer = new XmlSerializer(typeof(Pentagon));
            using (var fs = new FileStream("Pentagon.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, pentagon);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var xmlSerializer = new XmlSerializer(typeof(Pentagon));
            if (File.Exists("Pentagon.xml"))
            {
                using (var fs = new FileStream("Pentagon.xml", FileMode.Open))
                {
                    pentagon = (Pentagon)xmlSerializer.Deserialize(fs);
                }
            }
            else
            {
                pentagon = new Pentagon(); 
            }

            graphics.Clear(Color.White);
            textBox1.Text = pentagon.r.ToString();

            int centerX = pictureBox1.Width / 2;
            int centerY = pictureBox1.Height / 2;
            pentagon.Draw(graphics, pen, centerX, centerY);
        }



        private void button3_Click(object sender, EventArgs e)
        {
            var binFormatter = new BinaryFormatter();
            using (var fs = new FileStream("Pentagon.dat", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(fs, pentagon);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (File.Exists("Pentagon.dat"))
            {
                var binFormatter = new BinaryFormatter();
                using (var fs = new FileStream("Pentagon.dat", FileMode.Open))
                {
                    pentagon = (Pentagon)binFormatter.Deserialize(fs);
                }
            }
            else
            {
                pentagon = new Pentagon(); 
            }

            graphics.Clear(Color.White);
            textBox1.Text = pentagon.r.ToString();

            int centerX = pictureBox1.Width / 2;
            int centerY = pictureBox1.Height / 2;
            pentagon.Draw(graphics, pen, centerX, centerY);
        }



        private void button6_Click(object sender, EventArgs e)
        {
            label1.Text = label1.Text + pentagon.Reflection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
