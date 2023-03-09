using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class TCalculator : Form
    {
        public TCalculator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }
        private void button7_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }
        private void button8_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }
        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }


        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += ",";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                double number = double.Parse(textBox1.Text);
                textBox1.Text = (Math.Sin(number)).ToString();
            }
            catch
            {
                MessageBox.Show("Проверьте введённые данные");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                double number = double.Parse(textBox1.Text);
                textBox1.Text = (Math.Cos(number)).ToString();
            }
            catch
            {
                MessageBox.Show("Проверьте введённые данные");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                double number = double.Parse(textBox1.Text);
                textBox1.Text = (Math.Tan(number)).ToString();
            }
            catch
            {
                MessageBox.Show("Проверьте введённые данные");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                double number = double.Parse(textBox1.Text);
                textBox1.Text = (Math.Sqrt(number)).ToString();
            }
            catch
            {
                MessageBox.Show("Проверьте введённые данные");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                double number = double.Parse(textBox1.Text);
                double st = (1.0 / 3.0);
                textBox1.Text = ((double)Math.Pow(number, st)).ToString();
            }
            catch
            {
                MessageBox.Show("Проверьте введённые данные");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                double number = double.Parse(textBox1.Text);
                int st = int.Parse((string)comboBox1.SelectedItem);
                textBox1.Text = ((double)Math.Pow(number, st)).ToString();
            }
            catch
            {
                MessageBox.Show("Проверьте введённые данные");
            }
        }
        double saved;
        private void button13_Click(object sender, EventArgs e)
        {
            
            try
            {
                saved = double.Parse(textBox1.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = saved.ToString();
        }
    }
}
