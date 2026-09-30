using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace пavrilov_rul.pages
{
    public partial class Window5 : Window
    {
        private int[,] array;
        private int rows;
        private int cols;

        public Window5()
        {
            InitializeComponent();
        }

        private void btnGenerateTask5_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtRows.Text.Trim(), out rows) || rows <= 0)
            {
                txtResultTask5.Text = "Ошибка: Введите корректное количество строк!";
                return;
            }

            if (!int.TryParse(txtCols.Text.Trim(), out cols) || cols <= 0)
            {
                txtResultTask5.Text = "Ошибка: Введите корректное количество столбцов!";
                return;
            }

            Random random = new Random();
            array = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = random.Next(-10, 11);
                }
            }

            string result = "Сгенерированный массив:\n\n";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result += array[i, j].ToString().PadLeft(4);
                }
                result += "\n";
            }

            txtResultTask5.Text = result;
        }

        private void btnCalculateTask5_Click(object sender, RoutedEventArgs e)
        {
            if (array == null)
            {
                txtResultTask5.Text = "Ошибка: Сначала сгенерируйте массив!";
                return;
            }

            int maxElement = array[0, 0];
            int minElement = array[0, 0];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (array[i, j] > maxElement) maxElement = array[i, j];
                    if (array[i, j] < minElement) minElement = array[i, j];
                }
            }

            int[] flatArray = new int[rows * cols];
            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    flatArray[index++] = array[i, j];
                }
            }

            Array.Sort(flatArray);

            string result = $"Максимальный элемент: {maxElement}\n";
            result += $"Минимальный элемент: {minElement}\n\n";

            result += "Сортировка по возрастанию:\n\n";
            index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result += flatArray[index++].ToString().PadLeft(4);
                }
                result += "\n";
            }

            Array.Reverse(flatArray);

            result += "\nСортировка по убыванию:\n\n";
            index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result += flatArray[index++].ToString().PadLeft(4);
                }
                result += "\n";
            }

            txtResultTask5.Text = result;
        }

        private void btnBackToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
