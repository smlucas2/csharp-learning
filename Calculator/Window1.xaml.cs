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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private CalculatorEngine calculator;

        public Window1()
        {
            InitializeComponent();
            calculator = new CalculatorEngine();
        }

        private void One_Button_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.Input("1");
        }

        private void Two_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Three_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Four_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Five_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Six_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Seven_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Eight_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Nine_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Zero_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Dot_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Equals_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Plus_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Minus_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Mult_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Divide_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PM_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void C_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CE_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
