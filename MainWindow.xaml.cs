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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calcluator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber;
        public MainWindow()
        {
            InitializeComponent();
            ACButton.Click += ACButton_Click1;
            PlusMinuButton.Click += PlusMinuButton_Click;
            percentageButton.Click += PercentageButton_Click;
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber /= 100;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void PlusMinuButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber *= -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void ACButton_Click1(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int number_sent = 0;

            if(sender == nineButton)
            {
                number_sent = 9;
            }
            else if (sender == eightButton)
            {
                number_sent = 8;
            }
            else if(sender == sevenButton)
            {
                number_sent = 7;
            }
            else if(sender == sixButton)
            {
                number_sent = 6;
            }
            else if(sender == fiveButton)
            {
                number_sent = 5;
            }
            else if(sender == fourButton)
            {
                number_sent = 4;
            }
            else if(sender == threeButton)
            {
                number_sent = 3;
            }
            else if(sender == twoButton)
            {
                number_sent = 2;
            }
            else if(sender == oneButton)
            {
                number_sent = 1;
            }
            else if(sender == zeroButton)
            {
                number_sent = 0;
            }

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = number_sent.ToString();
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{number_sent}";
            }
        }

    }
}
