using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepetedWord
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<Word> words = new List<Word>();
            string[] strings = textBox1.Text.ToLower().Replace("\r\n"," ").Split(' ');
            foreach (var item in strings)
            {
                int t = isDuplicate(item, words);
                if(t==-1)
                {
                    words.Add(new Word(item));
                }
                else
                {
                    words[t].count++;
                }

            }
            textBox2.Clear();
            SortArray(words);
            chart1.Series[0].Points.Clear();
               
            for (int i = 0; i < words.Count; i++)
            {
                textBox2.Text += $"{words[words.Count-i-1].word} : {words[words.Count - i - 1].count}\r\n";
                chart1.Series[0].Points.AddXY(i, words[words.Count - i - 1].count);
                chart1.Series[0].Points[i].Label = words[words.Count - i - 1].word;
                Random rnd = new Random();
                chart1.Series[0].Points[i].Color = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255));
            }
        }
        public void SortArray(List<Word> array)
        {
            int length = array.Count;

            Word temp = array[0];

            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (array[i].count > array[j].count)
                    {
                        temp = array[i];

                        array[i] = array[j];

                        array[j] = temp;
                    }
                }
            }

        }
        private int isDuplicate(string s,List<Word> words)
        {
            for (int i = 0; i < words.Count; i++)
            {
                if (s.Equals(words[i].word))
                    return i;
            }
            return -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            Form2.chart = chart1;
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
