using System.Windows;

namespace PracticalWork4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
            MainFrame.Navigate(new Page1());
        }

        private void Page1Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page1());
        }

        private void Page2Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page2());
        }

        private void Page3Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page3());
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Вы действительно хотите выйти?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }
    }
}