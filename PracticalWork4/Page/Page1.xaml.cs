using System;
using System.Windows;
using System.Windows.Controls;

namespace PracticalWork4
{
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txtX.Focus();
        }

      
        private double Cbrt(double value)
        {
            return Math.Pow(Math.Abs(value), 1.0 / 3.0) * Math.Sign(value);
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(txtX.Text) ||
                string.IsNullOrWhiteSpace(txtY.Text) ||
                string.IsNullOrWhiteSpace(txtZ.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка",
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
            if (!double.TryParse(txtZ.Text, out double z))
            {
                MessageBox.Show("z должно быть числом!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                txtZ.Focus();
                return;
            }

           
            if (Math.Abs(x + y) < 1e-9)
            {
                MessageBox.Show("|x+y| не может быть равен нулю (деление на ноль в знаменателе).",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Math.Abs(Math.Sin(z)) < 1e-9)
            {
                MessageBox.Show("sin(z) не может быть равен нулю.",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Math.Abs(x + 1) < 1e-9)
            {
                MessageBox.Show("x+1 не может быть равен нулю.",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                double numerator = Math.Pow(y, x + 1);
                double denom1 = Cbrt(Math.Abs(y - 2)); 
                double denom2 = (x + Cbrt(2)) / (2 * Math.Abs(x + y));
                double denominator = denom1 + denom2;

                if (Math.Abs(denominator) < 1e-9)
                {
                    MessageBox.Show("Знаменатель основной дроби равен нулю.",
                                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                double result = numerator / denominator / (x + 1) / Math.Sin(z);
                txtResult.Text = result.ToString("F6");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при вычислении: {ex.Message}",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtX.Clear();
            txtY.Clear();
            txtZ.Clear();
            txtResult.Clear();
            txtX.Focus();
        }
    }
}