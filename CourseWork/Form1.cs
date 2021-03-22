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
        
        byte[] str2 = new byte[1000000];
        List<byte[]> array = new List<byte[]>();
        public void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            textBox3.Clear();
            
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

                for (int k = 0; k < i; k++)
                {
                    textBox3.Text += Encoding.UTF7.GetString(rc5.Cipher(Encoding.UTF32.GetBytes(str[k])));

                    str2 = rc5.Cipher(Encoding.UTF7.GetBytes(str[k]));
                    array.Add(str2);
                }
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

            List<byte[]> dearray = new List<byte[]>();
            dearray = array;
            for (int k = 0; k < dearray.Count; k++)
            {
               
              textBox4.Text += Encoding.UTF7.GetString(rc5.Decipher(dearray[k]));
            }
            dearray.Clear();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = textBox4.Text;
            textBox4.Text = str.Replace(">", "");

        }
    }
}
