using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        byte[] key;
        public RC5 rc5; 
        public RC5 rc5_2; 
        
        byte[] str2 = new byte[1000000];
        List<byte[]> array = new List<byte[]>();
        public void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            textBox3.Clear();
            label4.Text = "";
            if (textBox1.Text.Length != 0)
            {
                string[] str = new string[1000000];
                array.Clear();
                key = Encoding.UTF7.GetBytes(textBox1.Text);
                rc5 = new RC5(key);

                //Hello me! world!Hello me! world!
                foreach (var v in Split(textBox2.Text))
                {
                    str[i] = v;
                    i++;
                }
                var startTime = System.Diagnostics.Stopwatch.StartNew();
                for (int k = 0; k < i; k++)
                {
                    textBox3.Text += Encoding.UTF7.GetString(rc5.Cipher(Encoding.UTF32.GetBytes(str[k])));

                    str2 = rc5.Cipher(Encoding.UTF7.GetBytes(str[k]));
                    array.Add(str2);
                }
                startTime.Stop();
                var resultTime = startTime.Elapsed;

                // elapsedTime - строка, которая будет содержать значение затраченного времени
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                    resultTime.Hours,
                    resultTime.Minutes,
                    resultTime.Seconds,
                    resultTime.Milliseconds);
                label4.Text = elapsedTime.ToString();
            }
            else
            {
                MessageBox.Show("Key value is empty!");
            }

        }
        static IEnumerable<string> Split(string str)
        {
            while (str.Length % 16 != 0)
            {
                str = str.Insert(str.Length,">");
            }
            while (str.Length > 0)
            {
                yield return new string(str.Take(16).ToArray());
                str = new string(str.Skip(16).ToArray());
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            label5.Text = "";
            key = Encoding.UTF7.GetBytes(textBox1.Text);
            rc5_2 = new RC5(key);
            List<byte[]> dearray = new List<byte[]>();
            dearray = array;
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            for (int k = 0; k < dearray.Count; k++)
            {
               
              textBox4.Text += Encoding.UTF7.GetString(rc5_2.Decipher(dearray[k]));
            }
            startTime.Stop();
            var resultTime = startTime.Elapsed;

            // elapsedTime - строка, которая будет содержать значение затраченного времени
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                resultTime.Hours,
                resultTime.Minutes,
                resultTime.Seconds,
                resultTime.Milliseconds);
            label5.Text = elapsedTime.ToString();
            dearray.Clear();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = textBox4.Text;
            textBox4.Text = str.Replace(">", "");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Key length (0-255) bit" + '\n' + "W = 64" + '\n' + "R = 16" + '\n' + "Developed By Nikolay Tsvetkov");
        }
    }
}
