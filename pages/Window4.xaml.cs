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
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }

        private void btnCalculateTask4_Click(object sender, RoutedEventArgs e)
        {
            string input = txtInputArrayTask4.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                txtResultTask4.Text = "Ошибка: Введите массив!";
                return;
            }

            string[] parts = input.Split(new char[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            int[] array = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out array[i]))
                {
                    txtResultTask4.Text = $"Ошибка: Неверный элемент '{parts[i]}'!";
                    return;
                }
            }

            int maxNegativeIndex = -1;
            int maxNegativeValue = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    if (maxNegativeIndex == -1 || Math.Abs(array[i]) > Math.Abs(maxNegativeValue))
                    {
                        maxNegativeIndex = i;
                        maxNegativeValue = array[i];
                    }
                }
            }

            int minPositiveIndex = -1;
            int minPositiveValue = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    if (minPositiveIndex == -1 || array[i] < minPositiveValue)
                    {
                        minPositiveIndex = i;
                        minPositiveValue = array[i];
                    }
                }
            }

            string result = $"Исходный массив: [{string.Join(", ", array)}]\n\n";

            if (maxNegativeIndex == -1)
            {
                result += "Ошибка: В массиве нет отрицательных элементов!";
            }
            else if (minPositiveIndex == -1)
            {
                result += "Ошибка: В массиве нет положительных элементов!";
            }
            else
            {
                result += $"Максимальный по модулю отрицательный: {maxNegativeValue} (позиция {maxNegativeIndex + 1})\n";
                result += $"Минимальный положительный: {minPositiveValue} (позиция {minPositiveIndex + 1})\n\n";

                int temp = array[maxNegativeIndex];
                array[maxNegativeIndex] = array[minPositiveIndex];
                array[minPositiveIndex] = temp;

                result += $"Результат перестановки: [{string.Join(", ", array)}]";
            }

            txtResultTask4.Text = result;
        }

        private void btnBackToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
