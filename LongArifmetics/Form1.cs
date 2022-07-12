using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LongArifmetics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string Summa ( string a, string b)
        {
            string result = "";
            if ( a.Length <b.Length)
            {
                string temp = a;
                a = b;
                b = temp;
            }
            a = new string(a.Reverse().ToArray());
            b = new string(b.Reverse().ToArray());
            bool vUme = false;

            for (int i = 0; i < a.Length;i++)
            {
                int summa = 0;
                if ( i < b.Length)
                {
                    summa = a[i] + b[i]-96;
                }
                else
                {
                    summa = a[i]-48;
                }
                if (vUme == true)
                {
                    summa++;
                }
                if (summa>=10)
                {
                    vUme = true;
                    summa -= 10;
                }
                else
                {
                    vUme = false;
                }
            result += summa.ToString();
            }
            if (vUme == true)
                result += "1";
            result = new string(result.Reverse().ToArray());
            return result;
        }

        string Mult (string a, int b)
        {
            string result = "0";
            for ( int i=0; i<b; i++)
            {
                result = Summa(result, a);
            }
            return result;
        }

        void Fact (object N)
        {
            int n = (int)N;
            string result = "1";
            //if (n == 0)
            {
               // return "0";
            }
            for ( int i=1; i<=n;i++)
            {
                result = Mult(result, i);

                Invoke(new Action(() => progressBar1.Value += 1));
            }
            // return result;
            Invoke(new Action(()=>MessageBox.Show(result)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            string b = textBox2.Text;
            MessageBox.Show(Summa(a, b));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            int b = Convert.ToInt32(textBox2.Text);
            MessageBox.Show(Mult(a, b));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox3.Text);
            progressBar1.Value = 0;
            progressBar1.Maximum = n;
            Thread thread = new Thread(new ParameterizedThreadStart(Fact));
            thread.Start(n);
        }
    }
}
