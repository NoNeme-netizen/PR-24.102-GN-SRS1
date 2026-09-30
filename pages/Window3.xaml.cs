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
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void btnCalculateTask3_Click(object sender, RoutedEventArgs e)
        {
            string input = txtInputArray.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                txtResultTask3.Text = "Ошибка: Введите массив!";
                return;
            }

            string[] parts = input.Split(new char[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            int[] array = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out array[i]))
                {
                    txtResultTask3.Text = $"Ошибка: Неверный элемент '{parts[i]}'!";
                    return;
                }
            }

            string result = $"Исходный массив: [{string.Join(", ", array)}]\n\n";
            result += "Длины серий: ";

            int currentLength = 1;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == array[i - 1])
                {
                    currentLength++;
                }
                else
                {
                    result += currentLength + " ";
                    currentLength = 1;
                }
            }
            result += currentLength;

            txtResultTask3.Text = result;
        }

        private void btnBackToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
