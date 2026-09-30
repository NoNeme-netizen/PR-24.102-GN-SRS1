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
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void btnCalculateTask1_Click(object sender, RoutedEventArgs e)
        {
            string input = txtInputNumber.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                txtResultTask1.Text = "Ошибка: Введите число!";
                return;
            }

            if (!long.TryParse(input, out long number))
            {
                txtResultTask1.Text = "Ошибка: Введено не число!";
                return;
            }

            if (number < 100000 || number > 999999)
            {
                txtResultTask1.Text = "Ошибка: Число должно быть шестизначным (от 100000 до 999999)!";
                return;
            }

            string numberStr = number.ToString();

            int sumFirst3 = 0;
            int sumLast3 = 0;

            for (int i = 0; i < 3; i++)
            {
                sumFirst3 += int.Parse(numberStr[i].ToString());
            }

            for (int i = 3; i < 6; i++)
            {
                sumLast3 += int.Parse(numberStr[i].ToString());
            }

            string result = $"Введенное число: {number}\n";
            result += $"Первые 3 цифры: {numberStr.Substring(0, 3)}, их сумма: {sumFirst3}\n";
            result += $"Последние 3 цифры: {numberStr.Substring(3, 3)}, их сумма: {sumLast3}\n\n";

            if (sumFirst3 == sumLast3)
            {
                result += $"Результат: СУММЫ РАВНЫ ({sumFirst3} = {sumLast3})";
            }
            else
            {
                result += $"Результат: СУММЫ НЕ РАВНЫ ({sumFirst3} ≠ {sumLast3})";
            }

            txtResultTask1.Text = result;
        }

        private void btnBackToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
