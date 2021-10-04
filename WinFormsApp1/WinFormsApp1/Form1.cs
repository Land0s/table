using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string name;
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
         
            StreamReader rd = new StreamReader(@"C:\Class.txt");
            DataSet ds = new DataSet();
            ds.Tables.Add("Classroom");
            string header = rd.ReadLine();
            string[] mas=System.Text.RegularExpressions.Regex.Split(header, ",");
            for (int i=0; i< mas.Length; i++)
            {
                ds.Tables[0].Columns.Add(mas[i]);
            }
            string row = rd.ReadLine();
            while (row!=null)
            {
                string[] stroka = System.Text.RegularExpressions.Regex.Split(row, ",");
                ds.Tables[0].Rows.Add(stroka);
                row = rd.ReadLine();
            }
            dataGridView1.DataSource = ds.Tables[0];
            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void Открыть_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog(); // задаем переменую для OpenFileDialog

            openfile.Filter = "(*.txt*)|*.txt*|(*.hdt*)|*.hdt*"; //задаем фильтр

            openfile.Multiselect = false; // задаем режим выбора только одного файла

            if (openfile.ShowDialog() != DialogResult.OK)

            {
                MessageBox.Show("Вы не выбрали файл для открытия", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] rows = File.ReadAllLines(openfile.FileName);

            // открывает текстовый файл, считывает все строки файла в массив строк и затем закрывает файл

            if (rows.Length == 0) return;

            for (int i = 0; i < rows.Length; i++)

                dataGridView1.Rows.Add(rows[i].Split(",".ToCharArray()));
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog(); // задаем переменую для OpenFileDialog

            openfile.Filter = "(*.txt*)|*.txt*|(*.hdt*)|*.hdt*"; //задаем фильтр

            openfile.Multiselect = false; // задаем режим выбора только одного файла

            if (openfile.ShowDialog() != DialogResult.OK)

            {
                MessageBox.Show("Вы не выбрали файл для открытия", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] rows = File.ReadAllLines(openfile.FileName);

            // открывает текстовый файл, считывает все строки файла в массив строк и затем закрывает файл

            if (rows.Length == 0) return;

            for (int i = 0; i < rows.Length; i++)

                dataGridView1.Rows.Add(rows[i].Split(",".ToCharArray()));
        }
    }
}
