using System;
using System.Windows;
using System.Windows.Controls;
using OxyPlot;
using OxyPlot.Series;

namespace PracticalWork4
{
    public partial class Page3 : Page
    {
      
        private PlotModel plotModel;

        public Page3()
        {
            InitializeComponent();
            InitializePlot();
        }

       
        private void InitializePlot()
        {
            plotModel = new PlotModel
            {
                Title = "График функции y = (x²/5 - b)·ln(x² + 12.7)",
                TitleFontSize = 14
            };

                 plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Bottom,
                Title = "x"
            });
            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                Title = "y"
            });

            plotView.Model = plotModel;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txtX0.Focus();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtX0.Text) ||
                string.IsNullOrWhiteSpace(txtXk.Text) ||
                string.IsNullOrWhiteSpace(txtDx.Text) ||
                string.IsNullOrWhiteSpace(txtB.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

         
            if (!double.TryParse(txtX0.Text, out double x0))
            {
                MessageBox.Show("x0 должно быть числом!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                txtX0.Focus();
                return;
            }
            if (!double.TryParse(txtXk.Text, out double xk))
            {
                MessageBox.Show("xk должно быть числом!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                txtXk.Focus();
                return;
            }
            if (!double.TryParse(txtDx.Text, out double dx))
            {
                MessageBox.Show("dx должно быть числом!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                txtDx.Focus();
                return;
            }
            if (!double.TryParse(txtB.Text, out double b))
            {
                MessageBox.Show("b должно быть числом!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                txtB.Focus();
                return;
            }

            if (dx <= 0)
            {
                MessageBox.Show("Шаг dx должен быть положительным!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                txtDx.Focus();
                return;
            }
            if (xk <= x0)
            {
                MessageBox.Show("xk должно быть больше x0!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                txtXk.Focus();
                return;
            }

    
            txtResultTable.Clear();
            plotModel.Series.Clear();

        
            var series = new LineSeries
            {
                Title = "y(x)",
                Color = OxyColors.Blue,
                StrokeThickness = 2,
                MarkerType = MarkerType.None
            };

       
            double x = x0;
            int count = 0;
            const int maxPoints = 1000;

            while (x <= xk + 1e-9 && count < maxPoints)
            {
                double x2 = x * x;
                
                double y = (x2 / 5.0 - b) * Math.Log(x2 + 12.7);

             
                txtResultTable.AppendText($"x = {x:F4}\t y = {y:F6}\r\n");

              
                series.Points.Add(new DataPoint(x, y));

                x += dx;
                count++;
            }

           
            plotModel.Series.Add(series);

    
            plotView.InvalidatePlot(true);

            if (count >= maxPoints)
            {
                MessageBox.Show("Достигнуто максимальное количество точек (1000). Возможно, слишком мал шаг.",
                                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtX0.Clear();
            txtXk.Clear();
            txtDx.Clear();
            txtB.Clear();
            txtResultTable.Clear();
            plotModel.Series.Clear();
            plotView.InvalidatePlot(true);
            txtX0.Focus();
        }
    }
}