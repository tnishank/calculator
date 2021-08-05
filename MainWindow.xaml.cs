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
        double lastNumber, result;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();
            ACButton.Click += ACButton_Click1;
            PlusMinuButton.Click += PlusMinuButton_Click;
            percentageButton.Click += PercentageButton_Click;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            if(sender == plusButton)
            {
                selectedOperator = SelectedOperator.Addition;
            }
            else if (sender == minusButton)
            {
                selectedOperator = SelectedOperator.Subtraction;
            }
            else if(sender == multiplyButton)
            {
                selectedOperator = SelectedOperator.Multipplication;
            }
            else if(sender == divideButton)
            {
                selectedOperator = SelectedOperator.Division;
            }
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

        private void equalButton_Click(object sender, RoutedEventArgs e)
        {
            double firstNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out firstNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Addition(lastNumber, firstNumber);
                        break;

                    case SelectedOperator.Multipplication:
                        result = SimpleMath.Multiplication(lastNumber, firstNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtraction(lastNumber, firstNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Division(lastNumber, firstNumber);
                        break;
                }
                resultLabel.Content = result.ToString();
            }
        }

        private void decimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains("."))
            {
                //Do Nothing
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int number_sent = int.Parse((sender as Button).Content.ToString());

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

    public class SimpleMath
    {
        public static double Addition(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Subtraction(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Multiplication(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Division(double n1, double n2)
        {
            if (n2 == 0)
            {
                MessageBox.Show("Number can't be divided by 0", "Wrong Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return n1 / n2;
        }
    }
    
    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multipplication,
        Division
    }
}
