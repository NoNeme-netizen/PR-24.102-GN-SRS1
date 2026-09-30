using System;
using System.Windows;
using пavrilov_rul.pages;
namespace пavrilov_rul
{
    public partial class MainWindow : Window
    {
            public MainWindow()
            {
                InitializeComponent();
            }
            private void btnWindow1_Click(object sender, RoutedEventArgs e)
            {
                Window1 window1 = new Window1();
                window1.Show();
                this.Close();
            }
            private void btnWindow2_Click(object sender, RoutedEventArgs e)
            {
                Window2 window2 = new Window2();
                window2.Show();
                this.Close();
            }
            private void btnWindow3_Click(object sender, RoutedEventArgs e)
            {
                Window3 window3 = new Window3();
                window3.Show();
                this.Close();
            }
            private void btnWindow4_Click(object sender, RoutedEventArgs e)
            {
                Window4 window4 = new Window4();
                window4.Show();
                this.Close();
            }
            private void btnWindow5_Click(object sender, RoutedEventArgs e)
            {
                Window5 window5 = new Window5();
                window5.Show();
                this.Close();
            }
    }
}

