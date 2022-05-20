using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olimpiada_2 
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int Rows = Int32.Parse(textBox2.Text); // строки
            int Columns = Int32.Parse(textBox1.Text); //столбцы
            if (Columns >= 3 && Columns <= 10) //условие
            {
                double[,] Array = new double[Rows, Columns]; // Создаем массив олимпиады
                dataGridView1.RowCount = Rows;  // Кол‐во строк 
                dataGridView1.ColumnCount = Columns; // Кол‐во столбцов 
                Random rand = new Random(); //рандомное раполнение
                for (int i = 0; i < Array.GetLength(0); i++) //заполнение таблицы
                {
                    for (int j = 0; j < Array.GetLength(1); j++)
                    {
                        Array[i, j] = Math.Round(rand.NextDouble() * 10.0, 1);
                        dataGridView1.Rows[i].Cells[j].Value = Array[i, j].ToString();
                    }
                }
                double[] People = new double[Rows]; // Создаем массив результатов
                dataGridView2.RowCount = Rows;  // Кол‐во строк 
                dataGridView2.ColumnCount = 1; // Кол‐во столбцов
                double max = Array[0, 0]; //максимальное
                double min = Array[0, 0]; //минимальное
                double A = 0; //вычисления
                for (int i = 0; i < Array.GetLength(0); i++) // заполнение таблицы результатв
                {
                    for (int j = 0; j < Array.GetLength(1); j++)
                    {
                        A += Array[i, j];
                        if (min > Array[i, j]) // проверка минимального значесния
                        {
                            min = Array[i, j];
                        }
                        if (max < Array[i, j]) //проверка максимального значения
                        {
                            max = Array[i, j];
                        }
                        People[i] += Array[i, j];
                    }
                    People[i] = Math.Round((People[i] - min - max) / (Columns - 2), 1);

                    dataGridView2.Rows[i].Cells[0].Value = People[i].ToString();
                }
            }
        }
    }
}
