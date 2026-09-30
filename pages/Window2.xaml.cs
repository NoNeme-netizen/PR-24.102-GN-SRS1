using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void btnCalculateTask2_Click(object sender, RoutedEventArgs e)
        {
            string input = txtInputString.Text;

            if (string.IsNullOrEmpty(input))
            {
                txtResultTask2.Text = "Ошибка: Введите строку!";
                return;
            }

            string result = Regex.Replace(input.Trim(), @"\s+", " ");

            string output = $"Исходная строка:\n\"{input}\"\n\n";
            output += $"Преобразованная строка:\n\"{result}\"";

            txtResultTask2.Text = output;
        }

        private void btnBackToMain2_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
