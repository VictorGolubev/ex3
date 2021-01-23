using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ex3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ChildClass t = new ChildClass();
        //размер матрицы
        int n = 0;
        int m = 0;
        List<List<int>> matr = new List<List<int>>();
        private void button1_Click(object sender, EventArgs e)
        {           
            string[] stroki = textBox1.Text.Split('\n');
            foreach (string stroka in stroki)
            {
                matr.Add(new List<int>());
                string[] q = stroka.Split(' ');
                int temp_m = 0;
                foreach (string temp in q)
                {
                    matr[n].Add(Convert.ToInt32(temp));
                    temp_m++;
                }
                n++;
                m = temp_m;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t.getSum(matr);
            textBox2.Text = t.sum.ToString();
            int i = 1;
            foreach(bool f in t.ODD)
            {
                textBox3.Text+= "Четность "+ i + "-й строки =" + f + "   \n";
            }

        }

        class ParentClass
        {
            protected List<bool> oddOrNot = new List<bool>();
            public List<bool> ODD
            {
                get
                {
                    return oddOrNot;
                }

                set
                {
                    oddOrNot = value;
                }
            }
            public int sum;
        }

        class ChildClass : ParentClass
        {
            public bool getOdd(List<int> stroka)
            {
                foreach (int temp in stroka)
                    if (temp % 2 == 0)
                    {
                        return true;
                    }
                return false;

            }

            public void getSum(List<List<int>> matr)
            {
                List<bool> result = new List<bool>();
                int i = 1;
                int sum = 0;
                foreach (List<int> stroka in matr)
                {
                    result.Add(getOdd(stroka));
                    if (getOdd(stroka))
                        sum += i;
                    i++;
                }
                this.sum = sum;
                this.ODD = result;
            }

        }
    }
}
