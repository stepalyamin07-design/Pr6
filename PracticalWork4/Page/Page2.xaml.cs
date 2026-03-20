using System;
using System.Windows;
using System.Windows.Controls;

namespace PracticalWork4
{
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txtX.Focus();
        }

      
        private double GetF(double x)
        {
            if (rbSh.IsChecked == true)
                return Math.Sinh(x);
            if (rbX2.IsChecked == true)
                return x * x;
       
            return Math.Exp(x);
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
      
            if (string.IsNullOrWhiteSpace(txtX.Text) || string.IsNullOrWhiteSpace(txtY.Text))
            {
                MessageBox.Show("Заполните поля x и y!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!double.TryParse(txtX.Text, out double x))
            {
                MessageBox.Show("x должно быть числом!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                txtX.Focus();
                return;
            }
            if (!double.TryParse(txtY.Text, out double y))
            {
                MessageBox.Show("y должно быть числом!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                txtY.Focus();
                return;
            }

            double fx = GetF(x);
            double result;

            
            if (x > y)
                result = Math.Pow(fx - y, 3) + Math.Atan(fx);
            else if (y > x)
                result = Math.Pow(y - fx, 3) + Math.Atan(fx);
            else 
                result = Math.Pow(y + fx, 3) + 0.5;

            txtResult.Text = result.ToString("F6");
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtX.Clear();
            txtY.Clear();
            txtResult.Clear();
            rbSh.IsChecked = true; 
            txtX.Focus();
        }
    }
}